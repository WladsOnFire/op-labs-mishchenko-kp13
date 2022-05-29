using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Логика взаимодействия для UserModeWin.xaml
    /// </summary>
    public partial class UserModeWin : Window
    {
        MainWindow MainWin;

        bool HasOpenedUserTools = false;
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        string login;
        string password;
        public UserModeWin(MainWindow mw)
        {
            MainWin = mw;
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void LoginTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LoginTB.Text.Replace(" ", "") != "")
                LogInBtn.IsEnabled = true;
            else LogInBtn.IsEnabled = false;
        }

        private bool CheckInfo()
        {
            string SQLQuery = "select Login, Password from Users " +
                              "where Login = '" + LoginTB.Text + "';";

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                if (Table.Rows[0][0].ToString() == LoginTB.Text && Table.Rows[0][1].ToString() == PasswordTB.Text)
                {
                    login = LoginTB.Text;
                    password = PasswordTB.Text;
                    connection.Close();
                    return true;
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        private bool CheckIfBlocked()
        {
            string SQLQuery = "select IsBlocked from Users where " +
                              "Login = '" + LoginTB.Text + "';";
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                //MessageBox.Show(Table.Rows[0][0].ToString());
                if (Table.Rows[0][0].ToString() == "True")
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfBlocked() == false)
            {
                if (CheckInfo())
                {
                    HasOpenedUserTools = true;
                    UserToolsWin UserWindow = new UserToolsWin(MainWin, login, password);
                    UserWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong login or password.");
                }
            }
            else
            {
                MessageBox.Show("User with this login is blocked.");
            }

            
            
            
            //MessageBox.Show(CheckInfo() + "");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!HasOpenedUserTools)
                MainWin.Show();
        }
    }
}
