using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace cassControl
{
    public partial class SuperGridView : UserControl
    {
        private int pageSize = 30;  // 每页记录数
        private int recordCount = 0;    // 总记录数
        private int pageCount = 0;  // 总页数
        private int currentPage = 0;    // 当前页数
        private DataTable originalTable = new DataTable();  // 数据源表
        private DataTable schemaTable = new DataTable();  // 虚拟表

        public SuperGridView()
        {
            InitializeComponent();
            InitializeDataGridzview();
        }

        private void InitializeDataGridzview()
        {
            dgv.AutoGenerateColumns = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = true;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        [Category("DataSource"), Description("指示 DataGridView 控件的数据源。")]
        public object DataSource
        {
            get { return OriginalTable; }
            set
            {
                if (value is DataTable dt)
                {
                    OriginalTable = dt;
                    dgv.DataSource = dt;
                    PageSorter();
                }
                else
                {
                    throw new ArgumentException("Only DataTable is supported as DataSource.");
                }
            }
        }

        [Category("PageSize"), Description("指示 DataGridView 控件每页数据量。")]
        public int PageSize { get => pageSize; set => pageSize = value; }

        private int RecordCount { get => recordCount; set => recordCount = value; }
        private int PageCount { get => pageCount; set => pageCount = value; }
        private int CurrentPage { get => currentPage; set => currentPage = value; }
        private DataTable OriginalTable { get => originalTable; set => originalTable = value; }
        private DataTable SchemaTable { get => schemaTable; set => schemaTable = value; }

        private void PageSorter()
        {
            RecordCount = OriginalTable.Rows.Count;
            this.lblCount.Text = RecordCount.ToString();

            PageCount = (RecordCount / PageSize);

            if ((RecordCount % PageSize) > 0)
            {
                PageCount++;
            }

            //默认第一页
            CurrentPage = 1;

            LoadPage();
        }

        private void LoadPage()
        {
            if (CurrentPage < 1) CurrentPage = 1;
            if (CurrentPage > PageCount) CurrentPage = PageCount;

            SchemaTable = OriginalTable.Clone();

            int beginRecord;
            int endRecord;

            beginRecord = PageSize * (CurrentPage - 1);
            if (CurrentPage == 1) beginRecord = 0;
            endRecord = PageSize * CurrentPage - 1;
            if (CurrentPage == PageCount) endRecord = RecordCount - 1;

            int startIndex = beginRecord;
            int endIndex = endRecord;
            for (int i = startIndex; i <= endIndex; i++)
            {
                DataRow row = OriginalTable.Rows[i];
                SchemaTable.ImportRow(row);
            }

            dgv.DataSource = SchemaTable;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPage == PageCount)
            { return; }
            CurrentPage++;
            LoadPage();
        }

        private void btnBegain_Click(object sender, EventArgs e)
        {
            if (CurrentPage == 1)
            { return; }
            CurrentPage = 1;
            LoadPage();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (CurrentPage == PageCount)
            { return; }
            CurrentPage = PageCount;
            LoadPage();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (CurrentPage == 1)
            { return; }
            CurrentPage--;
            LoadPage();
        }
    }
}