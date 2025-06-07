// Assignment.cs

// Base class for all assignments
public class Assignment
{
    // Member variables for student name and topic.
    // Using 'protected' so they can be accessed by derived classes.
    protected string _studentName;
    protected string _topic;

    // Constructor to initialize the assignment with a student name and topic.
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to get a summary of the assignment.
    // Returns the student's name and the assignment topic.
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}
