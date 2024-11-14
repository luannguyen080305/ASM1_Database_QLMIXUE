using ASM1_Database_QLMIXUE.DAO;
using ASM1_Database_QLMIXUE.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM1_Database_QLMIXUE
{
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;
        


        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        public fAccountProfile(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }
        void ChangeAccount(Account acc )
        {
            txtUser.Text = loginAccount.UserName;
            txtDisPlayName.Text = loginAccount.DisplayName;
        }
        public fAccountProfile()
        {
        }

        private void AccountInfor_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update
            UpdateAccountInfo();
        }

        void UpdateAccountInfo()
        {
            string displayName = txtDisPlayName.Text;
            string password = txtPassWord.Text;
            string newpass = txtNewPassword.Text;
            string reenterPass = txtReenterPassword.Text;
            string userName = txtUser.Text;

            if (newpass.Equals(reenterPass))
            {
                MessageBox.Show("Please enter correct new password!");
            }
            else { 
                if (AccountDAO.Instance.UpdateAccount(userName, displayName , password, newpass))
                {
                    MessageBox.Show("Update successful");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Please enter correct password!");
                }
            }
        }
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class AccountEvent:EventArgs
    {
        private Account acc;

        public Account Acc { get => acc; set => acc = value; }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
