using quanly.DAO;
using quanly.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanly
{
    public partial class NhanVien : Form
    {
        BindingSource foodList = new BindingSource();

        BindingSource accountList = new BindingSource();

        public NhanVien()
        {
            InitializeComponent();

            LoadNhanVien();


            AddAccountBinding();

        }


        void AddAccountBinding()
        {
            txtnameaccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtdisplayaccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            txtpass.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "PassWord", true, DataSourceUpdateMode.Never));
            nmtype.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void LoadNhanVien()
        {
            dtgvAccount.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void AddAccount(string userName, string displayName, int type, string password)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type, password))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadNhanVien();
        }

        void DeleteAccount(string userName)
        {
            //if (loginAccount.UserName.Equals(userName))
            //{
            //    MessageBox.Show("Vui lòng đừng xóa chính bạn chứ");
            //    return;
            //}
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadNhanVien();
        }

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnaddaccount_Click(object sender, EventArgs e)
        {
            string userName = txtnameaccount.Text;
            string displayName = txtdisplayaccount.Text;
            int type = (int)nmtype.Value;
            string password = txtpass.Text;
            

            AddAccount(userName, displayName, type , password);
        }

        private void tbndelete_Click(object sender, EventArgs e)
        {
            string userName = txtnameaccount.Text;

            DeleteAccount(userName);
        }
    }
}
