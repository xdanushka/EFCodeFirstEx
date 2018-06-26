using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstEx
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SchoolContext())
            {
                var stud = new Student() { StudentName = "Bill" };
                ctx.Students.Add(stud);
                ctx.SaveChanges();
                Console.WriteLine("Finished ");

                Student s = ctx.Students.First();
                Console.WriteLine(s.StudentName);
            }
        }
    }
}
