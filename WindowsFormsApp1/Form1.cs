using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TeacherList.Load();
            addteacher.SendT += Components;
            addstudent.SendS += Components;
            removeteacher.SendRemoveT += Components;
            removestudent.SendRemoveS += Components;
            InitialTree();
            InitialDataTableTeacher(TeacherList.teacherlist);
            List<Student> lst = new List<Student>();
            InitialDataTableStudent(lst);
            chartininitial(TeacherList.teacherlist);
            chartininitial1();
        }
        public void InitialTree()
        {
            treeView1.Nodes.Clear();
            TreeNode derevo = new TreeNode
            {
                Text = "Teachers and student"
            };
            treeView1.Nodes.Add(derevo);
            for (int index = 0; index < TeacherList.teacherlist.Count; index++)
            {
                treeView1.Nodes[0].Nodes.Add(TeacherList.teacherlist[index].Surname + " " + TeacherList.teacherlist[index].Name);
                for (int jindex = 0; jindex < TeacherList.teacherlist[index].studentlist.Count(); jindex++)
                {
                    List<Student> students = TeacherList.teacherlist[index].studentlist;
                    treeView1.Nodes[0].Nodes[index].Nodes.Add(students[jindex].Surname + " " + students[jindex].Name);
                }
            }
        }



        private void InitialDataTableStudent(List<Student> students)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Name");
            datatable.Columns.Add("Surname");
            datatable.Columns.Add("Age");
            datatable.Columns.Add("City");
            datatable.Columns.Add("Street");
            datatable.Columns.Add("nHouse");
            datatable.Columns.Add("Score");
            for (int index = 0; index < TeacherList.teacherlist.Count(); index++)
            {
                students = TeacherList.teacherlist[index].studentlist;
                for (int jindex = 0; jindex < students.Count(); jindex++)
                {
                    datatable.Rows.Add(students[jindex].Name, students[jindex].Surname, students[jindex].Age, students[jindex].Adress.City, students[jindex].Adress.Street, students[jindex].Adress.NHouse, students[jindex].scores);
                }


            }
            dataGridView1.DataSource = datatable;
        }

        private void InitialDataTableTeacher(List<Teacher> teachers)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Name");
            datatable.Columns.Add("Surname");
            datatable.Columns.Add("Age");
            datatable.Columns.Add("City");
            datatable.Columns.Add("Street");
            datatable.Columns.Add("House");
            datatable.Columns.Add("MaxCountStudents");
            foreach (Teacher index in teachers)
            {
                datatable.Rows.Add(index.Name, index.Surname, index.Age, index.Adress.City, index.Adress.Street, index.Adress.NHouse, index.maxcount);

            }
            dataGridView2.DataSource = datatable;

        }
        public void studentinitialize()
        {
            for (int k = 0; k < TeacherList.teacherlist.Count(); k++)
            {
                for (int j = 0; j < TeacherList.teacherlist[k].studentlist.Count(); j++)
                {
                    Student b = TeacherList.teacherlist[k].studentlist[j];
                    List<Student> lst = new List<Student>();
                    lst.Add(b);
                    InitialDataTableStudent(lst);
                }
            }

        }
        private void chartininitial(List<Teacher> teachers)
        {
            chart1.Series["Teacher"].Points.Clear();
            for (int index = 0; index < teachers.Count; index++)
            {
                chart1.Series["Teacher"].Points.AddXY(teachers[index].Name, teachers[index].Age);
            }
        }
        private void chartininitial1()
        {
            chart2.Series["Student"].Points.Clear();
            for (int h = 0; h < TeacherList.teacherlist.Count; h++)
            {
                foreach (Student k in TeacherList.teacherlist[h].studentlist)
                {
                    chart2.Series["Student"].Points.AddXY(k.Name, k.Age);
                }
            }
        }

        private void Colored(List<Student> students)
        {
            var colorList = new List<Color>
                            {
                                Color.Red,
                                Color.Purple,
                                Color.Black,
                                Color.Blue,
                                Color.Green,
                                Color.LightGreen,
                                Color.LightSkyBlue,
                                Color.Yellow
                            };

            for (int index = 0; index < TeacherList.teacherlist.Count; index++)
            {
                for (int k = 0; k < TeacherList.teacherlist[index].studentlist.Count; k++)
                {
                    students = TeacherList.teacherlist[index].studentlist;
                    foreach (Student st in students)
                    {
                        for (int color = 0; color < students.Count;color++)
                        {
                            if (TeacherList.teacherlist[index].studentlist.Contains(st))
                            {

                                dataGridView1.Rows[k+index+index].Cells[0].Style.BackColor = colorList[index];
                                dataGridView2.Rows[index].Cells[0].Style.BackColor = colorList[index];
                            }
                            else
                            {
                                index++;
                                k++;
                                color--;
                            }
                        }
                    }
                }


            }


        }
    
           
       
        private void Components()
        {
            InitialTree();
            InitialDataTableTeacher(TeacherList.teacherlist);
            List<Student> lst = new List<Student>();
            InitialDataTableStudent(lst);
            Colored(lst);
            chartininitial(TeacherList.teacherlist);
            chartininitial1();
        }


        private void addTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addteacher teacher = new addteacher();
            teacher.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addstudent student = new addstudent();
            student.Show();
        }


        private void removeTecherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeteacher teacher = new removeteacher();
            teacher.Show();
        }

        private void removeStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removestudent student = new removestudent();
            student.Show();
        }
        private void save()
        {
            File.WriteAllText(TeacherList.SaveDirectory, JsonConvert.SerializeObject(TeacherList.teacherlist));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}
