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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Lab04
{
    /// <summary>
    /// Логика взаимодействия для AddVisitorWin.xaml
    /// </summary>
    public partial class AddVisitorWin : Window
    {
        MainWindow mw;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        string connectionString = null;
        string selectedVisitorId;
        string VisitorId;
        public AddVisitorWin(MainWindow mainWindow)
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            mw = mainWindow;
            ShowExistingVisitors();
        }
        public void ShowExistingVisitors()
        {
            string SQLQuery = "select Replace(Visitors.VisitorFirstName,'\t','') as Name, Replace(Visitors.VisitorSurname,'\t','') as Surname, Replace(Visitors.VisitorCountry,'\t','') as Country, " +
                "Replace(Visitors.VisitorEmail,'\t','') as Email" +
                " from Visitors";
            try
            {
                GetAndShowData(SQLQuery, VisitorsDG);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetAndShowData(string SQLQuery, DataGrid myDataGrid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            myDataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
        }

        private void SurnameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SurnameTb.Text == "" || FirstNameTb.Text == "" || EmailTb.Text == "")
            {
                AddBt.IsEnabled = false;
            }
            else
            {
                AddBt.IsEnabled = true;
            }
        }

        private void VisitorsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CancelBt.IsEnabled = true;

            DataRowView dataRow1 = null;
            string VisitorEmail = null;
            try
            {
                dataRow1 = (DataRowView)VisitorsDG.SelectedItem;
                if(dataRow1 != null)
                    VisitorEmail = dataRow1.Row.ItemArray[3].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string SQLQuery1 = "select Visitors.VisitorId from Visitors " +
                "where Replace(VisitorEmail,'\t','') = '" + VisitorEmail + "';";

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery1, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                selectedVisitorId = Table.Rows[0][0].ToString();
                //selectedVisitorL.Content = selectedVisitorId;
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string SQLQuery2 = "select Replace(VisitorSurname,'\t',''), Replace(VisitorFirstName,'\t',''), Replace(VisitorSecondName,'\t',''), Replace(VisitorEmail,'\t',''), Replace(VisitorPhoneNumber,'\t',''), Replace(VisitorCountry,'\t','') from Visitors " +
                "where VisitorId = '" + selectedVisitorId + "';";
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery2, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                SurnameTb.Text = Table.Rows[0][0].ToString();
                FirstNameTb.Text = Table.Rows[0][1].ToString();
                SecondNameTb.Text = Table.Rows[0][2].ToString();
                EmailTb.Text = Table.Rows[0][3].ToString();
                PhoneNumberTb.Text = Table.Rows[0][4].ToString();
                CountryTb.Text = Table.Rows[0][5].ToString();
                connection.Close();

                SurnameTb.IsReadOnly = true;
                FirstNameTb.IsReadOnly = true;
                SecondNameTb.IsReadOnly = true;
                EmailTb.IsReadOnly = true;
                PhoneNumberTb.IsReadOnly = true;
                CountryTb.IsReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            CancelBt.IsEnabled = false;

            SurnameTb.IsReadOnly = false;
            FirstNameTb.IsReadOnly = false;
            SecondNameTb.IsReadOnly = false;
            EmailTb.IsReadOnly = false;
            PhoneNumberTb.IsReadOnly = false;
            CountryTb.IsReadOnly = false;


            SurnameTb.Text = "";
            FirstNameTb.Text = "";
            SecondNameTb.Text = "";
            EmailTb.Text = "";
            PhoneNumberTb.Text = "";
            CountryTb.Text = "";
            FeedbackTb.Text = "";
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            if (CancelBt.IsEnabled)
            {
                try
                {
                    string SQLQuery3 = "insert into ConferencesVisit (VisitorId, ConferenceId, Feedback) values " +
                   "(" + selectedVisitorId + "," + mw.selectedConferenceId + ",'" + FeedbackTb.Text + "')";

                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    command = new SqlCommand(SQLQuery3, connection);
                    adapter = new SqlDataAdapter(command);
                    DataTable Table3 = new DataTable();
                    adapter.Fill(Table3);
                    connection.Close();

                    mw.SetVisitorsInfo();
                    ShowExistingVisitors();
                }
                catch(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                string SQLQuery = "insert into Visitors (VisitorSurname, VisitorFirstName, VisitorSecondName, VisitorEmail, VisitorPhoneNumber, VisitorCountry) " +
                    "values ('" + SurnameTb.Text + "','" + FirstNameTb.Text + "','" + SecondNameTb.Text + "','" + EmailTb.Text + "','" + PhoneNumberTb.Text + "','" + CountryTb.Text + "')";
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    command = new SqlCommand(SQLQuery, connection);
                    adapter = new SqlDataAdapter(command);
                    DataTable Table = new DataTable();
                    adapter.Fill(Table);
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                string SQLQuery2 = "select max(VisitorId) from Visitors;";

                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery2, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table2 = new DataTable();
                adapter.Fill(Table2);
                selectedVisitorId = Table2.Rows[0][0].ToString();
                connection.Close();

                string SQLQuery3 = "insert into ConferencesVisit (VisitorId, ConferenceId, Feedback) values " +
                    "("+selectedVisitorId+","+mw.selectedConferenceId+",'"+FeedbackTb.Text+"')";

                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery3, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table3 = new DataTable();
                adapter.Fill(Table3);
                connection.Close();

                mw.SetVisitorsInfo();
                ShowExistingVisitors();
            }
        }
    }
}
