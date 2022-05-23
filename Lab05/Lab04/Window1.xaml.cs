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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow mw;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        string connectionString = null;

        string OrganizerId;

        public Window1(MainWindow mainWindow)
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            mw = mainWindow;
            ShowExistingOrganizers();
        }
        public void ShowExistingOrganizers()
        {
            string sqlQuery = "select Replace(OrganizerCompany,'\t','') as Company, Replace(OrganizerFirstName,'\t','') as [First Name], Replace(OrganizerSurname,'\t','') as Surname, Replace(OrganizerEmail,'\t','') as Email " +
                "from Organizers;";
            try
            {
                GetAndShowData(sqlQuery, OrganizersDG);
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

        private void OrganizersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow1;
            string OrganizerCompany = null;
            string OrganizerName = null;
            string OrganizerSurname = null;
            string OrganizerEmail = null;
            try
            {
                dataRow1 = (DataRowView)OrganizersDG.SelectedItem;
                if (dataRow1 != null)
                {
                    OrganizerCompany = dataRow1.Row.ItemArray[0].ToString();
                    OrganizerName = dataRow1.Row.ItemArray[1].ToString();
                    OrganizerSurname = dataRow1.Row.ItemArray[2].ToString();
                    OrganizerEmail = dataRow1.Row.ItemArray[3].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string SQLQuery = "select OrganizerId from Organizers " +
                "where Replace(OrganizerCompany,'\t','') = '" + OrganizerCompany + "' and " +
                "Replace(OrganizerFirstName,'\t','') = '" + OrganizerName + "' and " +
                "Replace(OrganizerSurname,'\t','') = '" + OrganizerSurname + "' and " +
                "Replace(OrganizerEmail,'\t','') = '" + OrganizerEmail + "';";

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                OrganizerId = Table.Rows[0][0].ToString();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string SQLQuery2 = "select Replace(OrganizerCompany,'\t',''), " +
                "Replace(OrganizerSurname,'\t',''), " +
                "Replace(OrganizerFirstName,'\t',''), " +
                "Replace(OrganizerSecondName,'\t',''), " +
                "Replace(OrganizerEmail,'\t',''), " +
                "Replace(OrganizerPhoneNumber,'\t',''), " +
                "Replace(OrganizerPaidFee,'\t','') " +
                "from Organizers " +
                "where OrganizerId = " + OrganizerId + ";";

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery2, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);

                OrgCompanyTb.Text = Table.Rows[0][0].ToString();
                OrgSurnameTb.Text = Table.Rows[0][1].ToString();
                OrgFirstNameTb.Text = Table.Rows[0][2].ToString();
                OrgSecondNameTb.Text = Table.Rows[0][3].ToString();
                OrgEmailTb.Text = Table.Rows[0][4].ToString();
                OrgNumberTb.Text = Table.Rows[0][5].ToString();

                if (Table.Rows[0][6].ToString() == "0")
                    Checkbox.IsChecked = false;
                else 
                    Checkbox.IsChecked = true;

                connection.Close();

                OrgCompanyTb.IsReadOnly = true;
                OrgSurnameTb.IsReadOnly = true;
                OrgFirstNameTb.IsReadOnly = true;
                OrgSecondNameTb.IsReadOnly = true;
                OrgEmailTb.IsReadOnly = true;
                OrgNumberTb.IsReadOnly = true;
                Checkbox.IsEnabled = false;

                AddOrgBt.IsEnabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddOrgBt_Click(object sender, RoutedEventArgs e)
        {
            OrgCompanyTb.IsReadOnly = false;
            OrgSurnameTb.IsReadOnly = false;
            OrgFirstNameTb.IsReadOnly = false;
            OrgSecondNameTb.IsReadOnly = false;
            OrgEmailTb.IsReadOnly = false;
            OrgNumberTb.IsReadOnly = false;
            Checkbox.IsEnabled = true;
            AddOrgBt.IsEnabled = false;

            OrgCompanyTb.Text = "";
            OrgSurnameTb.Text = "";
            OrgFirstNameTb.Text = "";
            OrgSecondNameTb.Text = ""; //optional
            OrgEmailTb.Text = "";
            OrgNumberTb.Text = ""; //optional
            Checkbox.IsChecked = false;
        }

        private void ConNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if( ConNameTb.Text.Replace(" ","") == "" || ConLangTb.Text.Replace(" ", "") == "" || ConDateTb.Text.Replace(" ", "") == "" || ConPlaceTb.Text.Replace(" ", "") == "" || ConThemeTb.Text.Replace(" ", "") == "" || OrgCompanyTb.Text.Replace(" ", "") == "" || OrgSurnameTb.Text.Replace(" ", "") == "" || OrgFirstNameTb.Text.Replace(" ", "") == "" || OrgEmailTb.Text.Replace(" ", "") == "")
            {
                AddBt.IsEnabled = false;
            }
            else
            {
                AddBt.IsEnabled = true;
            }
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            string SQLQuery = "";
            if (AddOrgBt.IsEnabled == true)
            {
                SQLQuery = "insert into Conferences (ConferenceName, ConferenceLanguage, ConferenceDate, ConferencePlace, ConferenceOrganizerId, ConferenceTheme, ConferenceArrangementFee) " +
                    "values ('" + ConNameTb.Text + "','" + ConLangTb.Text + "','" + ConDateTb.Text + "','" + ConPlaceTb.Text + "',"+OrganizerId+",'" + ConThemeTb.Text + "'," + ConFeeTb.Text + ");";
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    command = new SqlCommand(SQLQuery, connection);
                    adapter = new SqlDataAdapter(command);
                    DataTable Table = new DataTable();
                    adapter.Fill(Table);
                    connection.Close();

                    string SQLQuery2 = "select Conferences.ConferenceName as Conference, Replace(Organizers.OrganizerCompany,'\t','') as Organizer" +
                " from Conferences " +
                "inner join Organizers on Conferences.ConferenceOrganizerId = Organizers.OrganizerId;";
                    GetAndShowData(SQLQuery2, mw.ConferencesDG);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
            }
            else
            {
                int paidFee;
                if (Checkbox.IsChecked == false)
                    paidFee = 0;
                else
                    paidFee = 1;

                string SQLQuery1 = "insert into Organizers (OrganizerCompany, OrganizerSurname, OrganizerFirstName, OrganizerSecondName, OrganizerEmail, OrganizerPhoneNumber, OrganizerPaidFee) " +
                    "values ('" + OrgCompanyTb.Text + "','" + OrgSurnameTb.Text + "','" + OrgFirstNameTb.Text + "','" + OrgSecondNameTb.Text + "','" + OrgEmailTb.Text + "','" + OrgNumberTb.Text + "'," + paidFee + "); " +
                    "select Replace(OrganizerCompany,'\t','') as Company, Replace(OrganizerFirstName,'\t','') as [First Name], Replace(OrganizerSurname,'\t','') as Surname, Replace(OrganizerEmail,'\t','') as Email " +
                "from Organizers;";
                try
                {
                    GetAndShowData(SQLQuery1, OrganizersDG);

                    string SQLQuery3 = "select max(OrganizerId) from Organizers;";

                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    command = new SqlCommand(SQLQuery3, connection);
                    adapter = new SqlDataAdapter(command);
                    DataTable Table = new DataTable();
                    adapter.Fill(Table);
                    OrganizerId = Table.Rows[0][0].ToString();
                    connection.Close();

                    SQLQuery = "insert into Conferences (ConferenceName, ConferenceLanguage, ConferenceDate, ConferencePlace, ConferenceOrganizerId, ConferenceTheme, ConferenceArrangementFee) " +
                    "values ('" + ConNameTb.Text + "','" + ConLangTb.Text + "','" + ConDateTb.Text + "','" + ConPlaceTb.Text + "'," + OrganizerId + ",'" + ConThemeTb.Text + "'," + ConFeeTb.Text + ");";
                    try
                    {
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        command = new SqlCommand(SQLQuery, connection);
                        adapter = new SqlDataAdapter(command);
                        DataTable Table1 = new DataTable();
                        adapter.Fill(Table1);
                        connection.Close();

                        string SQLQuery2 = "select Conferences.ConferenceName as Conference, Replace(Organizers.OrganizerCompany,'\t','') as Organizer" +
                    " from Conferences " +
                    "inner join Organizers on Conferences.ConferenceOrganizerId = Organizers.OrganizerId;";
                        GetAndShowData(SQLQuery2, mw.ConferencesDG);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }
    }
}
