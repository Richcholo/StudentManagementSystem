using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Student
    {
        public int ID { get; set; }
        public string fName { get; set; }
        public string mName { get; set; }
        public string lName { get; set; }
        public byte Age { get; set; }
        public char Gender { get; set; }

        public void AddStudent(List<Student> students, int ID, string fName, string mName, string lName, byte Age, char Gender)
        {
            Student student = new Student()
            {
                ID = ID,
                fName = fName,
                mName = mName,
                lName = lName,
                Age = Age,
                Gender = Gender
            };
            students.Add(student);
        }

        public static Student SearchById(List<Student> students, int id)
        {
            return students.FirstOrDefault(student => student.ID == id);
        }

        public static List<Student> SearchByName(List<Student> students, string name)
        {
            string lowerCaseName = name.ToLower(); // Convert the search name to lowercase

            return students.Where(student =>
                student.fName.ToLower().Contains(lowerCaseName) ||
                student.mName.ToLower().Contains(lowerCaseName) ||
                student.lName.ToLower().Contains(lowerCaseName)
            ).ToList();
        }


    }
}
