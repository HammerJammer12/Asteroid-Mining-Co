public interface IRecurringJob 
{
    /// <summary>
    /// True once jobs stop condition is met
    /// </summary>
    bool IsFinished { get; }

    /// <summary>
    /// what the job runs on each tick
    /// </summary>
    void Tick();

    /// <summary>
    /// Called once when the job is stopped naturally or externally. Notify the player/log why.
    /// </summary>
    void OnStopped();
}
