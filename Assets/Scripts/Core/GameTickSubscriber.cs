using System;
using UnityEngine;

public abstract class GameTickSubscriber : MonoBehaviour
{
    private GameTick tick;
    private bool subscribed;

    public virtual void Init(GameTick _tick)
    {
        Unsubscribe();
        tick = _tick;
        Subscribe();
    }

    protected abstract void HandleTick(float deltaTime);

    private void Subscribe()
    {
        if (!subscribed && isActiveAndEnabled && tick is not null)
        {
            tick.OnTick += HandleTick;
            subscribed = true;
        }
    }

    private void Unsubscribe()
    {
        if (subscribed && tick is not null)
        {
            tick.OnTick -= HandleTick;
            subscribed = false;
        }
    }
    //build
    private void OnEnable() => Subscribe();
    private void OnDisable() => Unsubscribe();
}
