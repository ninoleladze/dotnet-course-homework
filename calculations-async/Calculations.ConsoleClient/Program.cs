using System;
using System.Threading;
using System.Threading.Tasks;
using Calculations;

namespace Calculations.ConsoleClient
{
    internal static class Program
    {
        /// <summary>
        /// Calculates the sum from 1 to n asynchronously.
        /// The value of n is set by the user from the console.
        /// The user can change the boundary n during the calculation, which causes the calculation to be restarted,
        /// this should not crash the application.
        /// After receiving the result, be able to continue calculations without leaving the console.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task Main()
        {
            Console.WriteLine("=== Async Sum Calculator ===");
            Console.WriteLine("Enter a positive integer n to calculate 1 + 2 + ... + n.");
            Console.WriteLine("Enter a new number at any time to restart. Press Ctrl+C to exit.\n");

            CancellationTokenSource? cts = null;
            Task<long>? calculationTask = null;

            while (true)
            {
                Console.Write("Enter n: ");
                string? input = Console.ReadLine();

                if (input == null)
                {
                    break;
                }

                if (!int.TryParse(input.Trim(), out int n) || n <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.\n");
                    continue;
                }

                if (cts != null)
                {
                    await cts.CancelAsync();
                    try
                    {
                        if (calculationTask != null)
                        {
                            await calculationTask;
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("Previous calculation cancelled.");
                    }

                    cts.Dispose();
                }

                cts = new CancellationTokenSource();
                var token = cts.Token;

                var progress = new Progress<(int index, long value)>(
                    p => Console.Write($"\r  Progress: index={p.index:N0}, sum={p.value:N0}   "));

                Console.WriteLine($"Calculating sum from 1 to {n:N0}...");

                var localN = n;
                calculationTask = Calculator.CalculateSumAsync(localN, token, progress);

                _ = calculationTask.ContinueWith(
                    t =>
                    {
                        if (t.IsCanceled)
                        {
                            return;
                        }

                        Console.WriteLine();

                        if (t.IsFaulted)
                        {
                            Console.WriteLine($"  Error: {t.Exception!.InnerException?.Message}");
                        }
                        else
                        {
                            Console.WriteLine($"  Result: Sum(1..{localN:N0}) = {t.Result:N0}\n");
                        }
                    },
                    TaskScheduler.Default);
            }

            if (cts != null)
            {
                await cts.CancelAsync();
                cts.Dispose();
            }
        }
    }
}
