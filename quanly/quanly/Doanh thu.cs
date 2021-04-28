using quanly.DAO;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quanly
{
    public partial class FDoanhthu : Form
    {
        public FDoanhthu()
        {
            InitializeComponent();

            LoadBill(dtpdate.Value);
        }

      
        void loadNameTable()
        {

        }

        void LoadBill(DateTime checkIn)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void FDoanhthu_Load(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            LoadBill(dtpdate.Value);
        }
    }
}
