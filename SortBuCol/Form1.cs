using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortBuCol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BindingSource source;
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Person> people = new List<Person>
            {
                new Person
                {
                    LastName = "One",
                    FirstName = "Awo",
                    Patronymic = "Sfsd",
                    Birthday = new DateTime(1990, 2,3)
                },
                new Person
                {
                    LastName = "Ane",
                    FirstName = "Bwo",
                    Patronymic = "Efsd",
                    Birthday = new DateTime(1993, 2,3)
                },
                new Person
                {
                    LastName = "Ane",
                    FirstName = "Cwo",
                    Patronymic = "Pfsd",
                    Birthday = new DateTime(1990, 2,3)
                },
                new Person
                {
                    LastName = "Ane",
                    FirstName = "Dwo",
                    Patronymic = "Pfsd",
                    Birthday = new DateTime(1990, 2,3)
                },
                new Person
                {
                    LastName = "Bne",
                    FirstName = "Ewo",
                    Patronymic = "Pfsd",
                    Birthday = new DateTime(1993, 2,3)
                }

            };
            source = new BindingSource();
            source.DataSource = people;
            dataGridView1.DataSource = source;
        }
        int i = 0;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string propertyName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
            List<Person> people = (List<Person>)source.DataSource;
            //people = people.OrderBy(propertyName, "OrderByDescending").ToList();
            if( i== 0)
            {
                people = people.OrderBy(propertyName, "OrderByDescending").ToList();
                //people = people.MyOrdering(propertyName, "").ToList();
            }
            else
            {
                people = people.OrderBy(propertyName, "OrderBy").ToList();
            }
            source.DataSource = people;
            i = 1;
        }
    }
}
