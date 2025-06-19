using System;

public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int minutes, double distanceKm)
        : base(date, minutes) // Call the base class constructor
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return _distanceKm;
    }

    public override double GetSpeed()
    {
        if (Minutes == 0) return 0;
        return (_distanceKm / Minutes) * 60;
    }

    public override double GetPace()
    {
        if (_distanceKm == 0) return 0;
        return Minutes / _distanceKm;
    }

    protected override string GetActivityType()
    {
        return "Running";
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}