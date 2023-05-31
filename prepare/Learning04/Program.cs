using System;

namespace Learning04
{
    class Program
    {
        static void Main(string[] args)
        {
            MathAssignment mathAssignment = new MathAssignment("Samuel Bennett", "Multiplication", 1, 2);
            Console.WriteLine(mathAssignment.GetSummary());
            Console.WriteLine(mathAssignment.GetHomeworkList());
            WritingAssignment writingAssignment = new WritingAssignment("Samuel Bennett", "Writing", 1, 2);
            Console.WriteLine(writingAssignment.GetSummary());
            Console.WriteLine(writingAssignment.GetWritingInformation());
        }
    }

    class Assignment
    {
        private string _studentName;
        private string _topic;
        private int _numberOfPages;
        private int _numberOfQuestions;

        public Assignment(string studentName, string topic, int numberOfPages, int numberOfQuestions)
        {
            _studentName = studentName;
            _topic = topic;
            _numberOfPages = numberOfPages;
            _numberOfQuestions = numberOfQuestions;
        }

        public string GetSummary()
        {
            return _studentName + " - " + _topic;
        }
    }

    class MathAssignment : Assignment
    {
        private int _numberOfProblems;
        private int _numberOfProblemsPerPage;

        public MathAssignment(string studentName, string topic, int numberOfPages, int numberOfQuestions) : base(studentName, topic, numberOfPages, numberOfQuestions)
        {
            _numberOfProblems = numberOfPages * numberOfQuestions;
            _numberOfProblemsPerPage = numberOfQuestions;
        }


        public string GetHomeworkList()
        {
            return "Number of problems: " + _numberOfProblems + " Number of problems per page: " + _numberOfProblemsPerPage;
        }
    }

    class WritingAssignment : Assignment
    {

        private int _numberOfSentences;
        private int _numberOfSentencesPerPage;


        public WritingAssignment(string studentName, string topic, int numberOfPages, int numberOfQuestions) : base(studentName, topic, numberOfPages, numberOfQuestions)
        {
            _numberOfSentences = numberOfPages * numberOfQuestions;
            _numberOfSentencesPerPage = numberOfQuestions;
        }

        // GetWritingInformation() method
        public string GetWritingInformation()
        {
            return "Number of sentences: " + _numberOfSentences + " Number of sentences per page: " + _numberOfSentencesPerPage;
        }
    }

}