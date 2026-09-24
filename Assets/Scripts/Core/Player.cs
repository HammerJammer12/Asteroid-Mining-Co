public class Player 
{
    private float _credits = 0;
    public float Credits => _credits;

    public Player(float startingCredits = 0)
    {
        _credits = startingCredits;
    }

    public void AddCredits(float amt)
    {
        _credits += amt;
    }

    public bool TrySpendCredits(float amt)
    {
        if (_credits < amt)
        {
            return false;
        }
        _credits -= amt;
        return true;
    }
}
