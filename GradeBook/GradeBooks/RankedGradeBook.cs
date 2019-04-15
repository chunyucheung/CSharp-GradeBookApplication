using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade){
            if (Students.Count < 5){
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }
            var threshold= (int)Math.Ceiling(Students.Count * 0.2);
            var descendingGrades= Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (descendingGrades[threshold-1] <= averageGrade)
                return 'A';
            else if (descendingGrades[(threshold*2)-1] <= averageGrade)
                return 'B';
            else if (descendingGrades[(threshold*4)-1] <= averageGrade)
                return 'C';
            else if (descendingGrades[(threshold*6)-1] <= averageGrade)
                return 'D';

            return 'F';

        }
    }
}
