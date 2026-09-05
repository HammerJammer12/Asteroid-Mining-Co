/// <summary>
/// No Fixed duration. Runs IRecurringJob until it finishes or is cancelled.
/// </summary>
public class RecurringJob : IJob
{
    private readonly IRecurringJob _job;
    private bool _cancelled;
    private bool _stopped;

    public bool IsComplete => _stopped;

    public RecurringJob(IRecurringJob job) => _job = job;

    public void Tick()
    {
        if (_stopped) return;

        if (_cancelled || _job.IsFinished)
        {
            _job.OnStopped();
            _stopped = true;
            return;
        }

        _job.Tick();
    }

    public void Cancel() => _cancelled = true;
}
