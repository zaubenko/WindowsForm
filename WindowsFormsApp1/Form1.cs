using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            TreeNode root = new TreeNode
            {
                Name = "rootName",
                Text = "Teachers"
            };
            treeView1.Nodes.Add(root);
            for (int index = 0; index < TeacherList.teacherlist.Count; index++)
            {
                treeView1.Nodes[0].Nodes.Add(TeacherList.teacherlist[index].Name + " " + TeacherList.teacherlist[index].Surname);
                for (int jindex = 0; jindex < TeacherList.teacherlist[index].studentlist.Count(); jindex++)
                {
                    List<Student> lst = TeacherList.teacherlist[index].studentlist;
                    treeView1.Nodes[0].Nodes[index].Nodes.Add(lst[jindex].Name + " " + lst[jindex].Surname);
                }
            }
            treeView1.ExpandAll();
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
        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            Components();

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
        private void Components()
        {
            InitialTree();
            InitialDataTableTeacher(TeacherList.teacherlist);
            List<Student> lst = new List<Student>();
            InitialDataTableStudent(lst);
            chartininitial(TeacherList.teacherlist);
            chartininitial1();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

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
    }
}
