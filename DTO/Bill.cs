using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1_Database_QLMIXUE.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckin, DateTime? dateCheckOut,int status, int discount = 0) 
        {
            this.ID = id;
            this.DateCheckIn = dateCheckin;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];

            var dateCheckOutTemp = row["DateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
                
            this.Status = (int)row["status"];

            if(row["discount"].ToString() != "")
                this.discount = (int)row["discount"];
           
        }


        private int discount;
 
        private int status;

        public int Status { get { return status; } set => status = value; }

        private DateTime? dataCheckOut;

        public DateTime? DateCheckOut { get { return dataCheckOut; } set => dataCheckOut = value; }

        private DateTime? dataCheckIn;
        public DateTime? DataCheckIn { get { return dataCheckIn; }  set => dataCheckIn = value; }
        
        private int iD;

        public int ID { get { return iD; } set => iD = value; }

        public DateTime? DateCheckIn { get; }
        public int Discount { get => discount; set => discount = value; }
    }
}
