using UnityEngine;
using System;
using TMPro;
//build
public class UniverseClock : GameTickSubscriber
{
    [Tooltip("In-universe hours displayed per tick elapsed.")]
    [SerializeField] private int UniverseHoursPerTick = 1;
    [SerializeField] TMP_Text clockText;
    private GameTick tick;
    private bool subscribed;
    private DateTime universeEpoch;

    public override void Init(GameTick _tick)
    {
        universeEpoch = new DateTime(2350, 1, 1, 0, 0, 0); //arbirtrary start point
        UpdateClockText();
        base.Init(_tick);
    }

    void Awake()
    {
        
    }

    protected override void HandleTick(float deltaTime)
    {
        universeEpoch = universeEpoch.AddHours(UniverseHoursPerTick);
        UpdateClockText();
    }

    private void UpdateClockText()
    {
        if (clockText is null)
        {
            Debug.LogError("Universe Clock Clock Text is Null");
        }

        clockText.text = universeEpoch.ToString("yyyy-MM-dd HH:mm");
    }
}
