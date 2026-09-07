public class Ship
{
    public IJob CurrentJob{ get; private set; }
    public Location CurrentLocation { get; private set; }
    private ShipStatus _assignedStatus = ShipStatus.Idle;
    public bool IsIdle => CurrentJob is null || CurrentJob.IsComplete;
    /// <summary>
    /// Idle when there is no job or job is finished, otherwise, derived from CurrentJob. 
    /// </summary>
    public ShipStatus shipStatus => IsIdle ? ShipStatus.Idle : _assignedStatus;

    private readonly JobQueue _jobQueue;

    public Ship(JobQueue jobQueue, Location startingLocation)
    {
        _jobQueue = jobQueue;
        CurrentLocation = startingLocation;
    }

    public void AssignJob(IJob job, ShipStatus status)
    {
        CurrentJob = job;
        _assignedStatus = status;
        _jobQueue.Enqueue(job);
    }

    public void SetLocation(Location location) => CurrentLocation = location;
}

public enum ShipStatus
{
    Idle,
    Travelling,
    Mining
}
