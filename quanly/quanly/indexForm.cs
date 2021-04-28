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
    public partial class IndexForm : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public IndexForm( Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc; 

            LoadTable();

            LoadCategory();

            LoadSp();
        }

        #region Method

        void LoadSp()
        {

           
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbxLoadCategory.DataSource = listCategory;
            cbxLoadCategory.DisplayMember = "name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbxLoadFood.DataSource = listFood;
            cbxLoadFood.DisplayMember = "name";

        }
        void LoadTable()
        {
            flotable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.LightBlue;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flotable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);

            float TotalPrice = 0;

            foreach (DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                TotalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            txtPrice.Text = TotalPrice.ToString("c");
            txtTongtien.Text = TotalPrice.ToString("c");
            
        }



        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);


        }
        #endregion
        #region t
        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabKH_Click(object sender, EventArgs e)
        {

        }

        private void tabBill_Click(object sender, EventArgs e)
        {

        }

        private void IndexForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //IndexForm f = new IndexForm();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQuanly f = new FQuanly();
            
            f.Show();
            
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDoanhthu f = new FDoanhthu();
            
            f.Show();
        
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien f = new NhanVien();

            f.Show();
        }

        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txttien_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabKhuA_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }   

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flotable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvLoadFood_SelectionChanged(object sender, EventArgs e)
        {

           
                 
        }

        private void cbxLoadFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        #endregion
        void ChangeAccount(int type)
        {
            tolNV.Enabled = type == 1;
            tolDT.Enabled = type == 1;
            tolQL.Enabled = type == 1;
            adminToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";

        }

        private void cbxLoadCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbxLoadFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;
            

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }

            ShowBill(table.ID);
            LoadTable();
        }

        private void tbnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            double tatoPrice = Convert.ToDouble(txtPrice.Text.Split(',')[0]);
            double finatatoPrice = tatoPrice;

            if (idBill != -1)
            {
                if (MessageBox.Show("Bạn có muốn thanh toán bàn " + table.Name,"Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill,(float)finatatoPrice);
                    ShowBill(table.ID);
                    LoadTable();
                }    
            }    
        }

        private void dtgvLoadFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvLoadFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int numrow;
            //numrow = e.RowIndex;
            //cbxLoadFood.Text = dtgvLoadFood.Rows[numrow].Cells[2].Value.ToString();
        }

        private void btntk_Click(object sender, EventArgs e)
        {
            
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fuser f = new Fuser(LoginAccount);
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}


