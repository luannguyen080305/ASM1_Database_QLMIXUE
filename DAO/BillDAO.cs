﻿using ASM1_Database_QLMIXUE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1_Database_QLMIXUE.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        {
            get { if(instance == null) instance =new BillDAO();return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }
        //Thành công: Bill ID
        //Thất bại: -1
        public int GetUnCheckBillIDByTableID(int id)
        { 
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id + "AND status = 0");

            if (data.Rows.Count > 0) 
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public void CheckOut(int id, int discount, float totalPrice)
        {
            string query = "UPDATE dbo.Bill SET dateCheckOut = GETDATE(), status = 1, " +"discount = " + discount + ",totalPrice = " + totalPrice + "  WHERE id = "+id;
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExcuteNonQuery("exec USP_InsertBill @idTable ", new object[] { id });
        }

        public DataTable GetBillListByDate(DateTime checkIn,DateTime checkOut)
        {
            return DataProvider.Instance.ExcuteQuery("exec USP_GetListBillByDate @checkIn , @checkOut", new object[] {checkIn,checkOut});
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar("SELECT MAX(id) FROM dbo.Bill");
            } 
            catch 
            {
                return 1; 
            }
        }
    }
}
