using UnityEngine;
using System;
using TMPro;

public class UniverseClock : GameTickSubscriber
{
    [Tooltip("In-universe hours displayed per tick elapsed.")]
    [SerializeField] private int UniverseHoursPerTick = 1;
    [SerializeField] TMP_Text clockText;
    private DateTime universeEpoch;
    private DateTime universeStartEpoch;

    public override void Init(GameTick _tick)
    {
        universeStartEpoch = new DateTime(2350, 1, 1, 0, 0, 0); //arbirtrary start point
        universeEpoch = universeStartEpoch;
        UpdateClockText();
        base.Init(_tick);
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

    public double UniverseElapsedEpoch() => (universeEpoch - universeStartEpoch).TotalHours;
}
