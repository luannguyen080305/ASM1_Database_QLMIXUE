﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1_Database_QLMIXUE.DTO
{
    public class Food
    {

        public Food(int id, string name, int categoryID, float price)
        {
            this.ID = id;
            this.Name = name;
            this.CategoryID = categoryID;
            this.Price = price;
        }
        public Food(DataRow rows)
        {
            this.ID = (int)rows["id"];
            this.Name = rows["name"].ToString();
            this.CategoryID = (int)rows["idCategory"]; 
            this.Price = (float)Convert.ToDouble(rows["price"].ToString());
        }
        private float price;
        private int categoryID;
        private string name;
        private int iD;

        
        public string Name { get => name; set => name = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public float Price { get => price; set => price = value; }
        public int ID { get => iD; set => iD = value; }
    }
}
