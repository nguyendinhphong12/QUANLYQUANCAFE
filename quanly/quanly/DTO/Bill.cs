using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanly.DTO
{
    public class Bill
    {
        public Bill(int idtable, int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status)
        {
            this.Idtable = idtable;
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;

            this.Status = status; 
        }

        public Bill(DataRow row)
        {
            this.Idtable = (int)row["idtable"];
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];

            var dateCheckOutTemp  = row["dateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;

            this.Status = (int)row["status"];
        }

        private int status;
        private DateTime? dateCheckOut;
        private DateTime? dateCheckIn;
        private int iD;
        internal static object bill;
        private int idtable;

        
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public object DateCheckOutTemp { get; }
        public int ID { get => iD; set => iD = value; }
        public int Idtable { get => idtable; set => idtable = value; }
    }
}
