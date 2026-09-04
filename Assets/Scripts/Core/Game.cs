using System;
using UnityEngine;
public class Game : MonoBehaviour
{
    [SerializeField] private GameTick tick;
    [SerializeField] private UniverseClock clock;
  
    void Awake()
    {
        clock.Init(tick);
    }

    private void OnEnable()
    {
        tick.OnTick += HandleTick;
    }

    private void OnDisable()
    {
        tick.OnTick -= HandleTick;
    }

    private void HandleTick(float dt)
    {

    }
}