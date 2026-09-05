using System;
using UnityEngine;
public class Game : MonoBehaviour
{
    [SerializeField] private GameTick _tick;
    [SerializeField] private UniverseClock _clock;
    [SerializeField] private JobQueue _jobQueue;
  
    void Awake()
    {
        _clock.Init(_tick);
        _jobQueue.Init(_tick);
    }

    private void OnEnable()
    {
        _tick.OnTick += HandleTick;
    }

    private void OnDisable()
    {
        _tick.OnTick -= HandleTick;
    }

    private void HandleTick(float dt)
    {

    }
}