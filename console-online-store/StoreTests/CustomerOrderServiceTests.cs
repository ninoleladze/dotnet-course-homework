namespace StoreTests;

using StoreBLL.Services;

/// <summary>
/// Verifies <see cref="CustomerOrderService"/> order placement, ownership checks and status-change
/// validation end to end against a real (in-memory) database.
/// </summary>
public class CustomerOrderServiceTests
{
    [Fact]
    public void CreateOrder_StartsInNewOrderStatus_AndCapturesCurrentPrice()
    {
        using var context = TestDbContextFactory.Create();
        var service = new CustomerOrderService(context);

        var order = service.CreateOrder(2, new[] { (ProductId: 1, Amount: 3) });

        Assert.Equal(OrderStateIds.NewOrder, order.OrderStateId);
        Assert.Equal(3.60m, order.TotalPrice);
    }

    [Fact]
    public void CreateOrder_WithNoItems_Throws()
    {
        using var context = TestDbContextFactory.Create();
        var service = new CustomerOrderService(context);

        Assert.Throws<InvalidOperationException>(() => service.CreateOrder(2, Array.Empty<(int, int)>()));
    }

    [Fact]
    public void CreateOrder_WithUnknownProduct_Throws()
    {
        using var context = TestDbContextFactory.Create();
        var service = new CustomerOrderService(context);

        Assert.Throws<InvalidOperationException>(() => service.CreateOrder(2, new[] { (ProductId: 9999, Amount: 1) }));
    }

    [Fact]
    public void ChangeStatus_ValidTransition_Succeeds()
    {
        using var context = TestDbContextFactory.Create();
        var service = new CustomerOrderService(context);
        var order = service.CreateOrder(2, new[] { (ProductId: 1, Amount: 1) });

        var success = service.ChangeStatus(order.Id, OrderStateIds.Confirmed);

        Assert.True(success);
        var reloaded = (StoreBLL.Models.CustomerOrderModel)service.GetById(order.Id);
        Assert.Equal(OrderStateIds.Confirmed, reloaded.OrderStateId);
    }

    [Fact]
    public void ChangeStatus_InvalidTransition_KeepsLastValidStatus()
    {
        using var context = TestDbContextFactory.Create();
        var service = new CustomerOrderService(context);
        var order = service.CreateOrder(2, new[] { (ProductId: 1, Amount: 1) });

        var success = service.ChangeStatus(order.Id, OrderStateIds.DeliveredToClient);

        Assert.False(success);
        var reloaded = (StoreBLL.Models.CustomerOrderModel)service.GetById(order.Id);
        Assert.Equal(OrderStateIds.NewOrder, reloaded.OrderStateId);
    }

    [Fact]
    public void CancelByUser_OnOwnOrder_Succeeds()
    {
        using var context = TestDbContextFactory.Create();
        var service = new CustomerOrderService(context);
        var order = service.CreateOrder(2, new[] { (ProductId: 1, Amount: 1) });

        var success = service.CancelByUser(order.Id, 2);

        Assert.True(success);
    }

    [Fact]
    public void CancelByUser_OnSomeoneElsesOrder_Fails()
    {
        using var context = TestDbContextFactory.Create();
        var service = new CustomerOrderService(context);
        var order = service.CreateOrder(2, new[] { (ProductId: 1, Amount: 1) });

        var success = service.CancelByUser(order.Id, 1);

        Assert.False(success);
        var reloaded = (StoreBLL.Models.CustomerOrderModel)service.GetById(order.Id);
        Assert.Equal(OrderStateIds.NewOrder, reloaded.OrderStateId);
    }

    [Fact]
    public void ConfirmDeliveryReceived_BeforeDelivered_Fails()
    {
        using var context = TestDbContextFactory.Create();
        var service = new CustomerOrderService(context);
        var order = service.CreateOrder(2, new[] { (ProductId: 1, Amount: 1) });

        var success = service.ConfirmDeliveryReceived(order.Id, 2);

        Assert.False(success);
    }

    [Fact]
    public void ConfirmDeliveryReceived_AfterFullDeliveryPipeline_Succeeds()
    {
        using var context = TestDbContextFactory.Create();
        var service = new CustomerOrderService(context);
        var order = service.CreateOrder(2, new[] { (ProductId: 1, Amount: 1) });

        service.ChangeStatus(order.Id, OrderStateIds.Confirmed);
        service.ChangeStatus(order.Id, OrderStateIds.MovedToDeliveryCompany);
        service.ChangeStatus(order.Id, OrderStateIds.InDelivery);
        service.ChangeStatus(order.Id, OrderStateIds.DeliveredToClient);

        var success = service.ConfirmDeliveryReceived(order.Id, 2);

        Assert.True(success);
        var reloaded = (StoreBLL.Models.CustomerOrderModel)service.GetById(order.Id);
        Assert.Equal(OrderStateIds.DeliveryConfirmedByClient, reloaded.OrderStateId);
    }

    [Fact]
    public void GetOrderHistory_OnlyReturnsThatCustomersOrders()
    {
        using var context = TestDbContextFactory.Create();
        var service = new CustomerOrderService(context);
        service.CreateOrder(2, new[] { (ProductId: 1, Amount: 1) });

        var historyForUser2 = service.GetOrderHistory(2).ToList();
        var historyForUser1 = service.GetOrderHistory(1).ToList();

        Assert.NotEmpty(historyForUser2);
        Assert.All(historyForUser2, o => Assert.True(o.UserId == 2));
        Assert.Empty(historyForUser1);
    }
}
