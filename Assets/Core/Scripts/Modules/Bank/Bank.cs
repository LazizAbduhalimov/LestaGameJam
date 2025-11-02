using System;

public static class Bank
{
    public static int Score { get; private set; }

    public static Action<object, int, int> OnValueChangedEvent;

    public static void AddScore(object sender, int coins)
    {
        if (coins < 1)
            throw new ArgumentException("Number of coins should be positive");
        
        var oldValue = Score;
        Score += coins;
        OnValueChangedEvent?.Invoke(sender, oldValue, Score);
    }

    public static void SpendScore(object sender, int coins)
    {
        if (coins < 1)
            throw new ArgumentException("Number of coins should be positive");

        if (IsEnoughCoins(coins))
            return;

        var oldValue = Score;
        Score -= coins;
        OnValueChangedEvent?.Invoke(sender, oldValue, Score);
    }

    public static bool IsEnoughCoins(int number)
    {
        return Score >= number;
    }
}
