public abstract class TimedJob : IJob
{

    private int _remainingTicks;
    private bool _cancelled; 

    protected TimedJob(int durationInTicks) => _remainingTicks = durationInTicks;

    public bool IsComplete => _cancelled || _remainingTicks <= 0;

    public void Cancel() => _cancelled = true;

    public void Tick()
    {
        if (_cancelled) return;

        _remainingTicks --;
        if (_remainingTicks <=0)
        {
            Execute();
        }
    }
    /// <summary>
    /// Confirms the job can still run, applies its effect, then fires any completion jobs
    /// Concrete implementations customize behavior through Validate, Apply, OnFail, and OnComplete.
    /// </summary>
    private void Execute()
    {
        if (!Validate())
        {
            OnFail();
            return;
        }

        Apply();
        OnComplete();
    }

    /// <summary>
    /// Checks the jobs's preconditions hold at any given time
    /// </summary>
    /// <returns>Default returns true, return's false to abort without appliying any effect</returns>
    protected abstract bool Validate();

    /// <summary>
    /// Applies the jobs effect on game state. Any UI/Notification, or follow-up chains should occur in OnComplete
    /// </summary>
    protected abstract void Apply();

    /// <summary>
    /// Runs when Validate returns false, No-op by default
    /// </summary>
    protected virtual void OnFail() {}

    /// <summary>
    /// Runs afer Apply to trigger UI notifications or chain any follow-up jobs.
    /// </summary>
    protected virtual void OnComplete() {}
}
