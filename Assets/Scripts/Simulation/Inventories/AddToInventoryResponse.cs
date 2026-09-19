public enum AddResult
{
    AllAdded,
    PartiallyAdded,
    NoneAdded
}

public readonly struct AddToInventoryResponse
{
    public readonly AddResult Result;
    public readonly float AmountAdded;
    public readonly float AmountRejected;

    public AddToInventoryResponse(float requested, float accepted)
    {
        AmountAdded = accepted;
        AmountRejected = requested - accepted;
        Result = accepted <= 0f ? AddResult.NoneAdded
               : accepted >= requested ? AddResult.AllAdded
               : AddResult.PartiallyAdded;
    }
}