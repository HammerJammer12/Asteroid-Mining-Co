using System.Collections.Generic;
using UnityEngine;

public class JobQueue : GameTickSubscriber
{
    private readonly List<IJob> _activeJobs = new();

    public void Enqueue(IJob job) => _activeJobs.Add(job);
    protected override void HandleTick(float deltaTime)
    {
        for (int i = _activeJobs.Count - 1; i >= 0; i--)
        {
            var job = _activeJobs[i];
            job.Tick();

            if (job.IsComplete) _activeJobs.RemoveAt(i);
        }
    }
    
}
