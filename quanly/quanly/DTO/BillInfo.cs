using quanly.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanly.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int idbill, int idfood, int count)
        {
            this.ID = id;
            this.BillID = idbill;
            this.FoodID = idfood;
            this.Count = count;
        }


        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idBill"];
            this.FoodID = (int)row["idFood"];
            this.Count = (int)row["count"];
        }

        private int count;
        private int foodID;
        private int BillID;
        private int ID;
       

        public int ID1 { get => ID; set => ID = value; }
        public int BillID1 { get => BillID; set => BillID = value; }
        public int FoodID { get => foodID; set => foodID = value; }
        public int Count { get => count; set => count = value; }
    }
       
}
