using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        List<User> Users;
        List<DateTime> endDate;
        DialogResult ok_cancel;

        public Form1()
        {
            InitializeComponent();
            Users = new List<User>();
            endDate = new List<DateTime>();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (CheckPsw(textBoxPassword.Text.ToString()))
            {
                Users.Add(new User(textBoxLogin.Text, textBoxPassword.Text, textBoxEmail.Text, textBoxPhone.Text, dateTimeExpiration.Value));
                listBoxUsers.Items.Add(Users[Users.Count - 1].ToString() + '\n');
            }
            else
            {
                MessageBox.Show("Введите другой пароль!");
            }
            endDate.Add(dateTimeExpiration.Value);

        }
        private bool CheckPsw(string password)
        {
            bool checkpass = true;
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Password.Password == password)
                {
                    checkpass = false;
                    break;
                }
            }
            return checkpass;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Password.ExpirationDate < DateTime.Today)
                {
                    ok_cancel = MessageBox.Show("Program is going to delete expired password or passwords.\n" + "Press OK to do it and Cancel to stop it",  "DeleteBox", MessageBoxButtons.OKCancel);
                    break;
                }
            }

            if (ok_cancel == DialogResult.OK)
            {
                listBoxUsers.Items.Clear();
                for (int i = 0; i < Users.Count; i++)
                {
                    if (endDate[i] <= DateTime.Today)
                    {
                        Users.RemoveAt(i);
                    }
                    else
                    {
                        listBoxUsers.Items.Add(Users[i].ToString() + "\n");
                    }
                }
            }


        }

    }
}

