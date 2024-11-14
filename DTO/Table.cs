using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1_Database_QLMIXUE.DTO
{
    public class Table
    {
        public Table(int id, string name,string status)
        {
            this.ID = id;
            this.Name= name;
            this.Status = status;   

        }
        private string status;
        public string Status 
        {
            get { return status; }
            set { status = value; }
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
        }
        private string name;
        public string Name 
        { 
            get { return name; }
            set { name = value;}
        }
        
        private int iD;

        public int ID {
            get { return iD; }
            set { iD = value; }
        }
        
    }
}
