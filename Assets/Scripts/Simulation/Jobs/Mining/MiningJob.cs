using UnityEngine;

public class MiningJob : IRecurringJob, IMiningInfo
{
    private readonly Ship ship;
    private readonly AsteroidDeposit deposit;
    private readonly float yieldPerTick;
    private bool cargoFull;
    public Item Ore => deposit.Item;
    public string DepositRemainingDisplay => $"{deposit.GetReamainingYield()} / {deposit.StartingYield}";

    public MiningJob(MiningJobRequest request)
    {
        ship = request.Ship;
        deposit = request.Deposit;
        yieldPerTick = request.YieldPerTick;
    }

    public bool IsFinished => deposit.IsDepleted() || cargoFull;

    public void OnStopped()
    {
        if (deposit.IsDepleted())
            Debug.Log($"[MiningJob] {deposit.Item.DisplayName} deposit exhausted.");
        else if (cargoFull)
            Debug.Log($"[MiningJob] Cargo full — stopped mining {deposit.Item.DisplayName}.");
        else
            Debug.Log("[MiningJob] Mining cancelled.");
    }

    public void Tick()
    {
        var attemped = new ItemStack(deposit.Item, yieldPerTick);
        var response = ship.CargoHold.TryAddToInventory(attemped);

        deposit.Extract(response.AmountAdded);
        cargoFull = response.Result == AddResult.NoneAdded;
    }
}

public readonly struct MiningJobRequest
{
    public readonly Ship Ship;
    public readonly AsteroidDeposit Deposit;
    public readonly float YieldPerTick;

    public MiningJobRequest(Ship _ship, AsteroidDeposit _deposit, float _yieldPerTick)
    {
        Ship = _ship;
        Deposit = _deposit;
        YieldPerTick = _yieldPerTick;
    }
}
