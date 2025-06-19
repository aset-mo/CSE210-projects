using System;

public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(DateTime date, int minutes, double speedKph)
        : base(date, minutes) // Call the base class constructor
    {
        _speedKph = speedKph;
    }

    public override double GetDistance()
    {
        return (_speedKph * Minutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speedKph;
    }

    public override double GetPace()
    {
        if (_speedKph == 0) return 0;
        return 60 / _speedKph;
    }

    protected override string GetActivityType()
    {
        return "Cycling";
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}