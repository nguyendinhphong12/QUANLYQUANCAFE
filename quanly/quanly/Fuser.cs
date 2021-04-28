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
    public partial class Fuser : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public Fuser(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }

        

        void ChangeAccount(Account acc)
        {
            txtName1.Text = LoginAccount.UserName;
            txtName2.Text = LoginAccount.DisplayName;
            txtMk.Text = LoginAccount.Password;
        }

        //void ChangeAccount(Account acc)
        //{
        //    txtName1.Text = LoginAccount.UserName;
        //    txtName2.Text = LoginAccount.DisplayName;
        //}

        //void UpdateAccountInfo()
        //{
        //    string displayName = txbDisplayName.Text;
        //    string password = txbPassWord.Text;
        //    string newpass = txbNewPass.Text;
        //    string reenterPass = txbReEnterPass.Text;
        //    string userName = txbUserName.Text;

        //    if (!newpass.Equals(reenterPass))
        //    {
        //        MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
        //    }
        //    else
        //    {
        //        if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass))
        //        {
        //            MessageBox.Show("Cập nhật thành công");
        //            if (updateAccount != null)
        //                updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
        //        }
        //        else
        //        {
        //            MessageBox.Show("Vui lòng điền đúng mật khấu");
        //        }
        //    }
        //}

    //    private event EventHandler<AccountEvent> updateAccount;
    //    public event EventHandler<AccountEvent> UpdateAccount
    //    {
    //        add { updateAccount += value; }
    //        remove { updateAccount -= value; }
    //    }

    //    private void btnExti_Click(object sender, EventArgs e)
    //    {
    //        this.Close();
    //    }

    //    private void btnUpdate_Click(object sender, EventArgs e)
    //    {
    //        UpdateAccountInfo();
    //    }
    //}

    //public class AccountEvent : EventArgs
    //{
    //    private Account acc;

    //    public Account Acc
    //    {
    //        get { return acc; }
    //        set { acc = value; }
    //    }

    //    public AccountEvent(Account acc)
    //    {
    //        this.Acc = acc;
    //    }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMk_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
