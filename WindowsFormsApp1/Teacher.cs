using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Teacher : Person
    {
        private List<Student> StudentList = new List<Student>();
        private int MaxCountStudent;
        public int maxcount { get { return MaxCountStudent; } set { MaxCountStudent = value; } }
        public List<Student> studentlist { get { return StudentList; } set { StudentList = value; } }
        public Teacher(string name, string surname, int age, Adress adress, int maxcount) : base(name, surname, age, adress)
        {
            MaxCountStudent = maxcount;
        }
        public void AddStudent(Student st)
        {
            if (StudentList.Count < maxcount)
                StudentList.Add(st);
                
        }
        public void RemoveStudent(int i)
        {
            StudentList.RemoveAt(i);
        }
    }
}
        
