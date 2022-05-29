using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Prac03
{
    /// <summary>
    /// Логика взаимодействия для UserToolsWin.xaml
    /// </summary>
    /// string connectionString = null;
    public partial class UserToolsWin : Window
    {
        MainWindow MainWin;

        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        string IsCustomAllowed;
        string login;
        string password;
        public UserToolsWin(MainWindow mw, string login, string password)
        {
            this.login = login;
            this.password = password;
            MainWin = mw;
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            CheckAllowance();
        }

        private void CheckAllowance()
        {
            string SQLQuery = "select IsCustomPasswordEnabled from Users where " +
                              "Login = '" + login + "';";

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                IsCustomAllowed = Table.Rows[0][0].ToString();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWin.Show();
        }

        private void TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NewPassTB.Text.Replace(" ", "") != "" && RepeatNewPassTB.Text.Replace(" ", "") != "")
                ChangePassBtn.IsEnabled = true;
            else ChangePassBtn.IsEnabled = false;
        }

        private void ChangePassBtn_Click(object sender, RoutedEventArgs e)
        {
            string updatedPassword = NewPassTB.Text;
            if(IsCustomAllowed == "False")
            {
                string allowedChars = "qwertyuiopasdfghjklzxcvbnm1234567890_";
                string newPassword = "";
                string textboxPass = NewPassTB.Text;
                textboxPass = textboxPass.ToLower();
                bool check = false;
                for (int i = 0; i < textboxPass.Length - 1; i++)
                {
                    check = false;
                    for (int j = 0; j < allowedChars.Length - 1; j++)
                    {
                        if (textboxPass[i] == allowedChars[j])
                        {
                            newPassword += NewPassTB.Text[i];
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        MessageBox.Show("Error. Forbidden chars in password.");
                        return;
                    }
                }
                updatedPassword = newPassword;
            }
            

            if (OldPassTB.Text == password)
            {
                if (NewPassTB.Text == RepeatNewPassTB.Text)
                {
                    string SQLQuery = "update Users " +
                                      "set Password = '" + updatedPassword + "' " +
                                      "where Login = '" + login + "';";
                    try
                    {
                        connection.Open();
                        command = new SqlCommand(SQLQuery, connection);
                        adapter = new SqlDataAdapter(command);
                        DataTable Table = new DataTable();
                        adapter.Fill(Table);
                        connection.Close();
                        password = updatedPassword;
                        OldPassTB.Text = "";
                        NewPassTB.Text = "";
                        RepeatNewPassTB.Text = "";
                        ChangePassBtn.IsEnabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("New passwords does not match.");
                }
            }
            else
            {
                MessageBox.Show("Wrong password.");
            }
        }
    }
}
