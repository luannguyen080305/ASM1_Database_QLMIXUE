using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1_Database_QLMIXUE.DTO
{
        public class MenuTable
        {
        public MenuTable(string foodName, int count, float price, float totalPrice = 0)
        {
            this.foodName = foodName;
            this.Count1 = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }
        public MenuTable(DataRow row)
        {
            this.foodName = row["name"].ToString();
            this.Count1 = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }


        private  float totalPrice;
        private float price;
        private string foodName;

        public string FoodName { get => foodName; set => foodName = value; }

        
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int Count11 { get => Count1; set => Count1 = value; }

        private int Count1;

       
    }
}
