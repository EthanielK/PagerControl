using System;
using System.Data;
using System.Windows.Forms;

namespace ctlTestDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Age", typeof(string));
            dataTable.Columns.Add("Age1", typeof(string));
            dataTable.Columns.Add("Age2", typeof(string));

            // 生成60条数据并填充到 DataTable 中
            for (int i = 1; i <= 3000; i++)
            {
                DataRow newRow = dataTable.NewRow();
                newRow["ID"] = i;
                newRow["Name"] = "Name_" + i;
                newRow["Age"] = i * 1.2;
                newRow["Age1"] = i * 1.2;
                newRow["Age2"] = i * 1.2;
                dataTable.Rows.Add(newRow);
            }
            superGridView1.DataSource = dataTable;
            skinDataGridView1.DataSource = dataTable;
            pagerControl1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Age", typeof(string));
            dataTable.Columns.Add("Age1", typeof(string));
            dataTable.Columns.Add("Age2", typeof(string));
            dataTable.Columns.Add("Age3", typeof(string));
            dataTable.Columns.Add("Age4", typeof(string));
            dataTable.Columns.Add("Age5", typeof(string));
            dataTable.Columns.Add("Age6", typeof(string));
            dataTable.Columns.Add("Age7", typeof(string));
            dataTable.Columns.Add("Age8", typeof(string));
            dataTable.Columns.Add("Age9", typeof(string));
            dataTable.Columns.Add("Age10", typeof(string));
            dataTable.Columns.Add("Age11", typeof(string));
            dataTable.Columns.Add("Age12", typeof(string));
            dataTable.Columns.Add("Age13", typeof(string));
            dataTable.Columns.Add("Age14", typeof(string));
            dataTable.Columns.Add("Age15", typeof(string));
            for (int i = 1; i <= 100000; i++)
            {
                DataRow newRow = dataTable.NewRow();
                newRow["ID"] = i;
                newRow["Name"] = "Name_" + i;
                newRow["Age"] = i * 1.2;
                dataTable.Rows.Add(newRow);
            }
            superGridView1.DataSource = dataTable;
            skinDataGridView1.DataSource = dataTable;
            pagerControl1.DataSource = dataTable;
        }
    }
}