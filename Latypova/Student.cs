using System;
namespace Latypova
{
    internal class Student1
    {
        struct Student2
        {
            public string LastName;
            public string FirstName;
            public int YearOfBirth;
            public string Exam;
            public int Score;
            public override string ToString()
            {
                return $"{LastName} {FirstName}, {YearOfBirth}, {Exam}, {Score}";
            }
        }
    }
}
