using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using quanly.DAO;
using quanly.DTO;

namespace quanly
{
    public partial class FQuanly : Form
    {
        BindingSource foodList = new BindingSource();

        public FQuanly()
        {
           

            InitializeComponent();

            LoadFood();

            dtgvDssp.DataSource = foodList;
     
            AddFoodBinding();

            LoadCategoryIntoCombobox(cbxCategory);

            LoadFoodCategory(cbxFoodCategory);
        }

        

        void AddFoodBinding()
        {
            txtnamenew.DataBindings.Add(new Binding("Text", dtgvDssp.DataSource, "Name" , true, DataSourceUpdateMode.Never));
            txtID.DataBindings.Add(new Binding("Text", dtgvDssp.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmPrice.DataBindings.Add(new Binding("Value", dtgvDssp.DataSource, "Price", true, DataSourceUpdateMode.Never));    

        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        void LoadFoodCategory(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

       

        void LoadFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        
        private void butthem_Click(object sender, EventArgs e)
        {
            string name = txtnamesp.Text;
            int categoryID = (cbxFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmPrices.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadFood();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
           

        }

        private void insertFood(FQuanly fQuanly, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

       

        

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadFood();
                
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string name = txtnamenew.Text;
            int categoryID = (cbxCategory.SelectedItem as Category).ID;
            float price = (float)nmPrice.Value;
            int id = Convert.ToInt32(txtID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadFood();
               
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvDssp.SelectedCells.Count > 0)
            {
                int id = (int)dtgvDssp.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                cbxCategory.SelectedItem = cateogory;

                int index = -1;
                int i = 0;
                foreach (Category item in cbxCategory.Items)
                {
                    if (item.ID == cateogory.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbxCategory.SelectedIndex = index;
            }
        }

        
    }
}

