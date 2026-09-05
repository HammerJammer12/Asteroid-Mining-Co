public class Ship
{
    public IJob CurrentJob{ get; private set; }
    public Location CurrentLocation { get; private set; }
    public ShipStatus shipStatus;

    private readonly JobQueue _jobQueue;

    public Ship(JobQueue jobQueue, Location startingLocation)
    {
        _jobQueue = jobQueue;
        shipStatus = ShipStatus.Idle;
        CurrentLocation = startingLocation;
    }

    public void AssignJob(IJob job)
    {
        CurrentJob = job;
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
