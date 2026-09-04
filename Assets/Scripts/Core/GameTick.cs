using System;
using UnityEngine;
public class GameTick : MonoBehaviour
{
    public readonly float TickRate = 0.1f; // 10 ticks per second
    float timer;
    public event Action<float> OnTick;

    void Update()
    {
        timer += Time.deltaTime;

        while (timer >= TickRate)
        {
            timer -= TickRate;
            OnTick?.Invoke(TickRate);
        }
    }
    //build
}