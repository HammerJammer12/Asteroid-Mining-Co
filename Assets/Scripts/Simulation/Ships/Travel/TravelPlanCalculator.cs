using UnityEngine;

/// <summary>
/// Produces a TravelPlan based on 2 locations, and a speed in kms/hr
/// </summary>
public static class TravelPlanCalculator
{
    /// <summary>
    /// Makes a guess assuming the destination won't move, then keeps recalculating based on destinations true location, hoping to converge after maxIterations
    /// </summary>
    /// <param name="origin">Starting Location</param>
    /// <param name="destination">Destination Location</param>
    /// <param name="elapsedTimeAtDeparture">Elapsed Time at time of departure, to calculate current positions</param>
    /// <param name="speedKmPerHour">Speed of travel in kms/hour</param>
    /// <param name="maxIterations">How many refinement attempts you're willing to tollerate</param>
    /// <param name="toleranceHours">How close 2 attempts need to be before we consider the result converged</param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentException"></exception>
    public static TravelPlan Calcualte(
        Location origin,
        Location destination,
        float elapsedTimeAtDeparture,
        float speedKmPerHour,
        int maxIterations = 20,
        float toleranceHours = 0.01f
    )
    {
        if (origin.System != destination.System)
        {
            throw new System.ArgumentException("Origin and Destination must exist in the same system");
        }

        Vector2 originalPosition = GetPositionAt(origin, elapsedTimeAtDeparture);

        //assume the destination doesn't move for a first guess
        float estimatedTime = Vector2.Distance(originalPosition, GetPositionAt(destination, elapsedTimeAtDeparture)) / speedKmPerHour;

        for (int i=0; i < maxIterations; i++)
        {
            float distance = Vector2.Distance(originalPosition, GetPositionAt(destination, elapsedTimeAtDeparture + estimatedTime));
            float refinedTime = distance/speedKmPerHour;

            if (Mathf.Abs(refinedTime - estimatedTime) < toleranceHours)
            {
                estimatedTime = refinedTime;
                break;
            }

            estimatedTime = refinedTime;
        }

        RadialCoordinate arrivalPosition = GetPositionAtRadial(destination, elapsedTimeAtDeparture + estimatedTime);
        return new TravelPlan(estimatedTime, arrivalPosition);
    }

    private static RadialCoordinate GetPositionAtRadial(Location location, float elapsedTime)
    {
        if (location is IOrbitable orbitable) return orbitable.GetCurrentPosition(elapsedTime);

        return new RadialCoordinate(0f, 0f);
    }

    private static Vector2 GetPositionAt(Location location, float elapsedTime) => GetPositionAtRadial(location, elapsedTime).ToCartesian();


}
