using System;

public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes) // Call the base class constructor
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * LapLengthMeters) / 1000;
    }

    public override double GetSpeed()
    {
        if (Minutes == 0) return 0;
        return (GetDistance() / Minutes) * 60;
    }

    public override double GetPace()
    {
        if (GetDistance() == 0) return 0;
        return Minutes / GetDistance();
    }

    protected override string GetActivityType()
    {
        return "Swimming";
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}