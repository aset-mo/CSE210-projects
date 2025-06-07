public class WritingAssignment : Assignment
{
    // Specific member variable for a writing assignment.
    private string _title;

    // Constructor for the WritingAssignment class.
    // It calls the base class constructor to set the student name and topic.
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to get writing information.
    // It uses the _studentName from the base class to format the output.
    public string GetWritingInformation()
    {
        return $"{_title} by {_studentName}";
    }
}