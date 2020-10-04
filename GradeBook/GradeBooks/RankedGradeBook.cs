using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var progProcentowy = (int)Math.Ceiling(Students.Count * 0.2);
            var stopnie = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (stopnie[progProcentowy - 1] <= averageGrade)
                return 'A';
            else if (stopnie[(progProcentowy * 2) - 1] <= averageGrade)
                return 'B';
            else if (stopnie[(progProcentowy * 3) - 1] <= averageGrade)
                return 'C';
            else if (stopnie[(progProcentowy * 4) - 1] <= averageGrade)
                return 'D';

            return 'F';

        }
    }
}
