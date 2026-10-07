using System;
using System.Runtime.CompilerServices;

class Assignment
{
   string _studentName = "";
   string _topic = "";
   public (string, string, string) GetSummary()
    {
        return ( _studentName,  _topic, $"{_studentName} - {_topic}");
    }
}

class MathAssignment : Assignment
{
    string _textbookSection = "";
    string _problems = "";

    public (string, string, string) GetHomeworklist()
    {
        return ( _problems,  _textbookSection, $"Section{_textbookSection} Problems{_problems}");
    }
}

class WritingAssignment : Assignment
{
    string _title = "";

    public string stringGetWritingInformation()
    {
        return _title;
    }
}