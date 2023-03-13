using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();

            int range = (int)Math.Ceiling(Students.Count * 0.2);

            var sortedGrades = Students.OrderByDescending(e => e.AverageGrade).Select(s => s.AverageGrade).ToList();

            var position = sortedGrades.FindIndex(e => e == averageGrade) +1;

            if(position <= range)
            {
                return 'A';
            }
            else if(position <= range * 2)
            {
                return 'B';
            }
            else if (position <= range * 3)
            {
                return 'C';
            }
            else if (position <= range * 4)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }

        }
    }

}
