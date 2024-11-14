using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ASM1_Database_QLMIXUE.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int foodID, int count) 
        {
            this.ID = id;
            this.BillID = billID;
            this.FoodID = foodID;
            this.Count1 = count; 
        }

        public BillInfo(DataRow row) 
        {
            this.ID = (int)Convert.ToDouble(row["id"].ToString());
            this.BillID = (int)Convert.ToDouble(row["idBill"].ToString());
            this.FoodID = (int)Convert.ToDouble(row["idFood"].ToString());
            this.Count1 = (int)Convert.ToDouble(row["count"].ToString());
        }
        private int Count;

        public int Count1 { get => Count; set => Count = value; }

        private int foodID;

        public int FoodID { get => foodID; set => foodID = value; }

        private int BillID;

        public int BillID1 { get => BillID; set => BillID = value; }

        private int id;

        public int Id { get => id; set => id = value; }
        public int ID { get; }
        
    }
}
