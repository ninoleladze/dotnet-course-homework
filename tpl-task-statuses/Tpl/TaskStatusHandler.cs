using System.Threading;
using System.Threading.Tasks;

namespace Tpl;

public static class TaskStatusHandler
{
    // TaskStatus.Created — use new Task(...) without starting it
    public static Task CreateTaskWithCreatedStatus()
        => new Task(() => { });

    // TaskStatus.WaitingForActivation — TaskCompletionSource.Task sits in this state until resolved
    public static Task CreateTaskWithWaitingForActivationStatus()
        => new TaskCompletionSource<object>().Task;

    // TaskStatus.WaitingToRun — scheduled on a custom scheduler that never runs it
    public static Task CreateTaskWithWaitingToRunStatus()
    {
        var task = new Task(() => Thread.Sleep(Timeout.Infinite));
        task.Start(new HangingScheduler());
        return task;
    }

    // TaskStatus.Running — started and blocked inside, captured before it finishes
    public static Task CreateTaskWithRunningStatus()
    {
        var running = new SemaphoreSlim(0);
        var proceed = new SemaphoreSlim(0);

        var task = Task.Run(() =>
        {
            running.Release();
            proceed.Wait();
        });

        running.Wait(); // wait until the task body is actually executing
        return task;    // return while it's still blocked on proceed.Wait()
    }

    // TaskStatus.RanToCompletion — already-completed task
    public static Task CreateTaskWithRanToCompletionStatus()
        => Task.CompletedTask;

    // TaskStatus.WaitingForChildrenToComplete — parent finishes but child (AttachedToParent) has not
    public static Task CreateTaskWithWaitingForChildrenToCompleteStatus()
    {
        var childStarted = new SemaphoreSlim(0);
        var childProceed = new SemaphoreSlim(0);

        var parent = new Task(() =>
        {
            // Attached child keeps the parent in WaitingForChildrenToComplete
            var child = new Task(() =>
            {
                childStarted.Release();
                childProceed.Wait();
            }, TaskCreationOptions.AttachedToParent);
            child.Start();
        });

        parent.Start();
        childStarted.Wait(); // child is running; parent body has finished → WaitingForChildrenToComplete
        return parent;
    }

    // IsCompleted = true, Status = RanToCompletion
    public static Task CreateTaskWithIsCompletedStatus()
        => Task.CompletedTask;

    // TaskStatus.Canceled
    public static Task CreateTaskWithIsCancelledStatus()
    {
        var tcs = new TaskCompletionSource();
        tcs.SetCanceled();
        return tcs.Task;
    }
    // TaskStatus.Faulted
    public static Task CreateTaskWithIsFaultedStatus()
        => Task.FromException(new Exception("Task faulted"));

    // Custom scheduler that accepts tasks but never executes them → WaitingToRun
    private sealed class HangingScheduler : TaskScheduler
    {
        protected override void QueueTask(Task task) { } // intentionally do nothing
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) => false;
        protected override IEnumerable<Task> GetScheduledTasks() => Enumerable.Empty<Task>();
    }
}
