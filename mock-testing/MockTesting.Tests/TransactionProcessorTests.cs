using Moq;
using NUnit.Framework;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace MockTesting.Tests;

[TestFixture]
public class TransactionProcessorTests
{
    private Mock<IPermissionService> permissionMock = null!;
    private Mock<IAccountService> accountMock = null!;
    private Mock<ITransactionService> transactionMock = null!;
    private Mock<ILogger> loggerMock = null!;
    private List<string> logs = null!;
    private TransactionProcessor processor = null!;

    [SetUp]
    public void Setup()
    {
        // Make logging and formatting deterministic
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        permissionMock = new Mock<IPermissionService>(MockBehavior.Strict);
        accountMock = new Mock<IAccountService>(MockBehavior.Strict);
        transactionMock = new Mock<ITransactionService>(MockBehavior.Strict);
        loggerMock = new Mock<ILogger>(MockBehavior.Loose);

        logs = new List<string>();
        loggerMock.Setup(l => l.Log(It.IsAny<string>())).Callback<string>(s => logs.Add(s));

        processor = new TransactionProcessor(permissionMock.Object, accountMock.Object, transactionMock.Object, loggerMock.Object);
    }

    [Test]
    public void ProcessTransfer_SuccessfulTransfer_LogsAndReturnsTrue()
    {
        var from = 1;
        var to = 2;
        decimal amount = 100m;

        permissionMock.Setup(p => p.HasTransferPermission(from)).Returns(true);
        accountMock.Setup(a => a.GetBalance(from)).Returns(amount);
        transactionMock.Setup(t => t.Transfer(from, to, amount));

        var result = processor.ProcessTransfer(from, to, amount);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            transactionMock.Verify(t => t.Transfer(from, to, amount), Times.Once);
            Assert.That(logs.Any(l => l.Contains("started: Transfer", StringComparison.Ordinal) && l.Contains($"from {from} to {to}", StringComparison.Ordinal)), Is.True);
            Assert.That(logs.Any(l => l.Contains("completed successfully", StringComparison.Ordinal)), Is.True);
        });
    }

    [Test]
    public void ProcessTransfer_NoPermission_LogsAndReturnsFalse()
    {
        var from = 5;
        var to = 6;
        decimal amount = 50m;

        permissionMock.Setup(p => p.HasTransferPermission(from)).Returns(false);

        var result = processor.ProcessTransfer(from, to, amount);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            transactionMock.Verify(t => t.Transfer(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<decimal>()), Times.Never);
            Assert.That(logs.Any(l => l.Contains("failed: Permission denied", StringComparison.Ordinal)), Is.True);
        });
    }

    [Test]
    public void ProcessTransfer_InsufficientBalance_LogsAndReturnsFalse()
    {
        var from = 7;
        var to = 8;
        decimal amount = 200m;

        permissionMock.Setup(p => p.HasTransferPermission(from)).Returns(true);
        accountMock.Setup(a => a.GetBalance(from)).Returns(10m);

        var result = processor.ProcessTransfer(from, to, amount);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            transactionMock.Verify(t => t.Transfer(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<decimal>()), Times.Never);
            Assert.That(logs.Any(l => l.Contains("failed: Insufficient funds. Current balance:", StringComparison.Ordinal)), Is.True);
        });
    }

    [Test]
    public void ProcessTransfer_TransactionThrowsException_LogsAndReturnsFalse()
    {
        var from = 9;
        var to = 10;
        decimal amount = 30m;

        permissionMock.Setup(p => p.HasTransferPermission(from)).Returns(true);
        accountMock.Setup(a => a.GetBalance(from)).Returns(amount);
        transactionMock.Setup(t => t.Transfer(from, to, amount)).Throws(new InvalidOperationException("Transfer failed"));

        var result = processor.ProcessTransfer(from, to, amount);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            Assert.That(logs.Any(l => l.Contains("failed with error: Transfer failed", StringComparison.Ordinal)), Is.True);
        });
    }

    [Test]
    public void ProcessTransfer_InvalidFromUserId_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => processor.ProcessTransfer(0, 2, 10m));
    }

    [Test]
    public void ProcessTransfer_InvalidToUserId_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => processor.ProcessTransfer(1, 0, 10m));
    }

    [Test]
    public void ProcessTransfer_SameUserIds_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => processor.ProcessTransfer(1, 1, 10m));
    }

    [Test]
    public void ProcessTransfer_InvalidAmount_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => processor.ProcessTransfer(1, 2, 0m));
    }

    [Test]
    public void Constructor_NullDependencies_ThrowsArgumentNullException()
    {
        var acc = accountMock.Object;
        var perm = permissionMock.Object;
        var tx = transactionMock.Object;
        var log = loggerMock.Object;

        Assert.Throws<ArgumentNullException>(() => new TransactionProcessor(null!, acc, tx, log));
        Assert.Throws<ArgumentNullException>(() => new TransactionProcessor(perm, null!, tx, log));
        Assert.Throws<ArgumentNullException>(() => new TransactionProcessor(perm, acc, null!, log));
        Assert.Throws<ArgumentNullException>(() => new TransactionProcessor(perm, acc, tx, null!));
    }

    [Test]
    public void ProcessTransfer_WithMaxIntValues_ShouldSucceed()
    {
        var from = int.MaxValue - 1;
        var to = int.MaxValue;
        decimal amount = 1m;

        permissionMock.Setup(p => p.HasTransferPermission(from)).Returns(true);
        accountMock.Setup(a => a.GetBalance(from)).Returns(amount);
        transactionMock.Setup(t => t.Transfer(from, to, amount));

        var result = processor.ProcessTransfer(from, to, amount);

        Assert.That(result, Is.True);
    }

    [Test]
    public void ProcessTransfer_WithMinValidValues_ShouldSucceed()
    {
        var from = 1;
        var to = 2;
        decimal amount = 0.01m;

        permissionMock.Setup(p => p.HasTransferPermission(from)).Returns(true);
        accountMock.Setup(a => a.GetBalance(from)).Returns(amount);
        transactionMock.Setup(t => t.Transfer(from, to, amount));

        var result = processor.ProcessTransfer(from, to, amount);

        Assert.That(result, Is.True);
    }

    [Test]
    public void ProcessTransfer_LogMessages_ShouldContainCorrectInformation()
    {
        var from = 11;
        var to = 12;
        decimal amount = 123.45m;

        permissionMock.Setup(p => p.HasTransferPermission(from)).Returns(true);
        accountMock.Setup(a => a.GetBalance(from)).Returns(amount);
        transactionMock.Setup(t => t.Transfer(from, to, amount));

        var result = processor.ProcessTransfer(from, to, amount);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            // Start message should contain amount and user ids
            Assert.That(logs.Any(l => l.Contains($"Transfer {amount}", StringComparison.Ordinal) && l.Contains($"from {from} to {to}", StringComparison.Ordinal)), Is.True);
            // Success message should be present
            Assert.That(logs.Any(l => l.Contains("completed successfully", StringComparison.Ordinal)), Is.True);
        });
    }

    [Test]
    public void ProcessTransfer_TransactionId_ShouldBeUnique()
    {
        var from = 20;
        var to = 21;
        decimal amount = 10m;

        permissionMock.Setup(p => p.HasTransferPermission(from)).Returns(true);
        accountMock.Setup(a => a.GetBalance(from)).Returns(amount);
        transactionMock.Setup(t => t.Transfer(from, to, amount));

        // Run twice
        processor.ProcessTransfer(from, to, amount);
        var logsFirst = logs.ToList();
        logs.Clear();
        processor.ProcessTransfer(from, to, amount);
        var logsSecond = logs.ToList();

        string ExtractId(string s)
        {
            var m = Regex.Match(s, "Transaction ([0-9a-fA-F\\-]{36})");
            return m.Success ? m.Groups[1].Value : string.Empty;
        }

        var id1 = logsFirst.Select(ExtractId).FirstOrDefault(x => !string.IsNullOrEmpty(x));
        var id2 = logsSecond.Select(ExtractId).FirstOrDefault(x => !string.IsNullOrEmpty(x));

        Assert.Multiple(() =>
        {
            Assert.That(string.IsNullOrEmpty(id1), Is.False);
            Assert.That(string.IsNullOrEmpty(id2), Is.False);
            Assert.That(id1, Is.Not.EqualTo(id2));
        });
    }

    [Test]
    public void ProcessTransfer_ErrorMessages_ShouldBeProperlyFormatted()
    {
        var from = 30;
        var to = 31;
        decimal amount = 1000m;

        permissionMock.Setup(p => p.HasTransferPermission(from)).Returns(true);
        accountMock.Setup(a => a.GetBalance(from)).Returns(0m);

        var result = processor.ProcessTransfer(from, to, amount);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            var msg = logs.FirstOrDefault(l => l.Contains("Insufficient funds", StringComparison.Ordinal));
            Assert.That(msg, Is.Not.Null);
            Assert.That(msg != null && msg.Contains("Current balance:", StringComparison.Ordinal), Is.True);
        });
    }

    [Test]
    public void ProcessTransfer_ExceptionMessages_ShouldBeProperlyFormatted()
    {
        var from = 40;
        var to = 41;
        decimal amount = 5m;

        permissionMock.Setup(p => p.HasTransferPermission(from)).Returns(true);
        accountMock.Setup(a => a.GetBalance(from)).Returns(amount);
        transactionMock.Setup(t => t.Transfer(from, to, amount)).Throws(new InvalidOperationException("boom!"));

        var result = processor.ProcessTransfer(from, to, amount);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.False);
            var msg = logs.FirstOrDefault(l => l.Contains("failed with error:", StringComparison.Ordinal));
            Assert.That(msg, Is.Not.Null);
            Assert.That(msg != null && msg.Contains("boom!", StringComparison.Ordinal), Is.True);
        });
    }
}
