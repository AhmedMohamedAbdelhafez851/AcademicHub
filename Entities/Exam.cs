using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcademifyHub.Entities
{
   public class Exam
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int DurationInMinutes { get; set; }

        public int QuesionsNumber { get; set; }

        public Course ?Course { get; set; } 

        public int CourseId { get; set; }   
    }

   public class MultipleChoiceExam : Exam   
    {
        
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public char CorrectAnswer { get; set; }

    }

   public class WrittenExam : Exam
    {
        public string Instructions { get; set; }


    }

    public class IntrviewExam : Exam
    {
        public string Interviewer { get; set; }

    }

    public class TrueAndFalse : Exam   
    {
        public bool CorrectAnswer {  set; get; }    

    }


}
