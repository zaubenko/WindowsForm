using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Student:Person 
    {
       private int score;
        public int scores {get { return score; }set { score = value; }}
        public Student(string Name, string Surname, int Age, Adress addres,int scores) : base(Name, Surname, Age, addres)
        {
            score = scores;
        }
      
    }
}
