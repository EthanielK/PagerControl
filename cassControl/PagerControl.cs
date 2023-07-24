using CCWin.SkinControl;
using System;
using System.ComponentModel;
using System.Data;
<<<<<<< HEAD
using System.Drawing;
=======
>>>>>>> 95e6c7555229f401d321d95b984af39acb332b67
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace cassControl
{
    public partial class PagerControl : UserControl
    {
        public PagerControl()
        {
            InitializeComponent();
<<<<<<< HEAD
            DoubleBuffered = true;
=======
>>>>>>> 95e6c7555229f401d321d95b984af39acb332b67
        }

        #region fields, properties

        private int pageCount;
        private int dataCount;
        private int pageSize = 50;
        private int currentPage;

        private DataTable dataSourceTable;
        private DataTable tempTable;

        private SkinDataGridView dataGridViewToBind;

        [Browsable(true)]
        [Category("PagerControl")]
        [Description("为 PagerControl 绑定 DataGridView 数据项")]
        public SkinDataGridView DataGridView
        {
            get { return dataGridViewToBind; }
            set
            {
                dataGridViewToBind = value;
            }
        }

        [Browsable(false)]
        public object DataSource    // 数据类型可以扩展
        {
            get { return dataSourceTable; }
            set
            {
                if (value is DataTable dt)
                {
                    dataSourceTable = dt;
                    PageSorter();
                }
                else
                {
                    return;
                }
            }
        }

<<<<<<< HEAD
        private Color itemForeColor = SystemColors.ControlText;

        [Browsable(true)]
        [Category("PagerControl")]
        [Description("设置控件中字体颜色")]

        public Color ItemForeColor
        {
            get { return itemForeColor; }
            set
            {
                itemForeColor = value;
                ApplyItemForeColor();
            }
        }


=======
>>>>>>> 95e6c7555229f401d321d95b984af39acb332b67
        [Browsable(false)]
        public int CurrentPage { get => currentPage; set => currentPage = value; }

        [Browsable(false)]
        public int PageCount { get => pageCount; set => pageCount = value; }

        [Browsable(false)]
        public int DataCount { get => dataCount; set => dataCount = value; }

        [Browsable(true)]
        [Category("PagerControl")]
        [Description("设置每页显示的数据量")]
        public int PageSize
        {
            get => pageSize;
            set
            {
                if (value <= 0)
                {
                    pageSize = 50;  // 默认显示50条数据
                }
                else { pageSize = value; }
            }
        }

        #endregion fields, properties

        #region methods

<<<<<<< HEAD
        private void ApplyItemForeColor()
        {
            lblDataCount.ForeColor = itemForeColor;
            lblPageCount.ForeColor = itemForeColor;
            lblCurrentPage.ForeColor = itemForeColor;
            label1.ForeColor = itemForeColor;
            label3.ForeColor = itemForeColor;
            label4.ForeColor = itemForeColor;
            label5.ForeColor = itemForeColor;
            label7.ForeColor = itemForeColor;

            //btnFirstpage.ForeColor = itemForeColor;
            //btnPreviouspage.ForeColor = itemForeColor;
            //btnNextpage.ForeColor = itemForeColor;
            //btnLastpage.ForeColor = itemForeColor;
            //btnSwitchPage.ForeColor = itemForeColor;
        }

=======
>>>>>>> 95e6c7555229f401d321d95b984af39acb332b67
        private void PageSorter()
        {
            DataCount = dataSourceTable.Rows.Count;
            lblDataCount.Text = DataCount.ToString();
            PageCount = (DataCount / PageSize);
            if ((DataCount % PageSize) > 0)
            {
                PageCount++;
            }
            lblPageCount.Text = PageCount.ToString();
            CurrentPage = 1;
            lblCurrentPage.Text = CurrentPage.ToString();
            SetCtlEnabled(true);
            LoadPage();
        }

        private void LoadPage()
        {
            if (CurrentPage < 1) CurrentPage = 1;
            if (CurrentPage > PageCount) CurrentPage = pageCount;

            tempTable = dataSourceTable.Clone();

            int beginIndex, endIndex;

            if (CurrentPage == 1)
            {
                beginIndex = 0;
            }
            else { beginIndex = PageSize * (CurrentPage - 1); }
            if (CurrentPage == PageCount)
            {
                endIndex = DataCount - 1;
            }
            else { endIndex = PageSize * CurrentPage; }
            lblCurrentPage.Text = CurrentPage.ToString();
            txtTargetPage.Text = CurrentPage.ToString();
            for (int i = beginIndex; i < endIndex; i++)
            {
                DataRow row = dataSourceTable.Rows[i];
                tempTable.ImportRow(row);
            }
            dataGridViewToBind.DataSource = tempTable;
        }

        private void SetCtlEnabled(bool status)
        {
            btnFirstpage.Enabled = status;
            btnNextpage.Enabled = status;
            btnPreviouspage.Enabled = status;
            btnLastpage.Enabled = status;
            txtTargetPage.Enabled = status;
            btnSwitchPage.Enabled = status;
        }

        #endregion methods

        #region events

        private void btnFirstpage_Click(object sender, EventArgs e)
        {
            if (CurrentPage == 1)
            { return; }
            CurrentPage = 1;
            LoadPage();
        }

        private void btnPreviouspage_Click(object sender, EventArgs e)
        {
            if (CurrentPage == 1)
            { return; }
            CurrentPage--;
            LoadPage();
        }

        private void btnNextpage_Click(object sender, EventArgs e)
        {
            if (CurrentPage == PageCount)
            { return; }
            CurrentPage++;
            LoadPage();
        }

        private void btnLastpage_Click(object sender, EventArgs e)
        {
            if (CurrentPage == PageCount)
            { return; }
            CurrentPage = PageCount;
            LoadPage();
        }

        private void btnSwitchPage_Click(object sender, EventArgs e)
        {
            int num = 0;
            int.TryParse(txtTargetPage.Text.Trim(), out num);
            CurrentPage = num;
            LoadPage();
        }

        private void txtTargetPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = @"[0-9]";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(e.KeyChar.ToString()) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion events
    }
}