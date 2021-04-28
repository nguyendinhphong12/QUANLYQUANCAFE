using quanly.DAO;
using quanly.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanly
{
    public partial class FLogin : Form
    {
        
        public FLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        

        private void tbnLogin_Click(object sender, EventArgs e)
        {

            string useName = txttk.Text;
            string passWord = txtmk.Text;

            if (Login(useName, passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(useName);
                IndexForm f = new IndexForm(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu !!!");
            }
        }

        bool Login(string useName, string passWord)
        {
            return AccountDAO.Instance.Login(useName, passWord);
        }

        private void tbnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
