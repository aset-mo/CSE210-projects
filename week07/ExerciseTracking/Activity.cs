using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected DateTime Date => _date;
    protected int Minutes => _minutes;

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    protected virtual string GetActivityType()
    {
        return "Activity";
    }

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetActivityType()} ({_minutes} min)";
    }
}