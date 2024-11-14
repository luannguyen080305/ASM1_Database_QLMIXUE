using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1_Database_QLMIXUE.DTO
{
    public class Category
    {
        public Category(int id,string name) 
        { 
            this.ID = id;
            this.Name1 = name;

        }

        public Category(DataRow rows)
        {
            this.ID = (int)rows["id"];
            this.Name1 = rows["name"].ToString();
        }

        private int iD;
        private string Name;

        public int ID { get => iD; set => iD = value; }
        public string Name1 { get => Name; set => Name = value; }
    }
}
