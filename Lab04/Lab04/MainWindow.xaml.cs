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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Lab04
{
    public partial class MainWindow : Window
    {
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        string connectionString = null;

        string selectedConferenceId = "1";
        string selectedVisitorId = null;
        List<TextBox> textboxesList = new List<TextBox>();
        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SetConferencesInfo();
            SetVisitorsInfo();
            InitializeTextBoxes();
        }
        public void InitializeTextBoxes()
        {
            int y = 10;
            for(int i = 0; i<6; i++)
            {
                TextBox myTextBox = new TextBox();
                myTextBox.HorizontalAlignment = HorizontalAlignment.Left;
                myTextBox.VerticalAlignment = VerticalAlignment.Top;
                myTextBox.TextWrapping = TextWrapping.Wrap;
                myTextBox.Width = 320;
                myTextBox.Height = 25;
                myTextBox.Margin = new Thickness(374,y,0,0);
                y += 30;
                myGrid.Children.Add(myTextBox);
                textboxesList.Add(myTextBox);
            }
            //< TextBox HorizontalAlignment = "Left" Margin = "395,10,0,0" TextWrapping = "Wrap" Text = "TextBox" VerticalAlignment = "Top" Width = "120" />
        }
        public void SetVisitorsInfo()
        {

            string SQLQuery = "select Replace(Visitors.VisitorFirstName,'\t','') as Name, Replace(Visitors.VisitorSurname,'\t','') as Surname, Replace(Visitors.VisitorCountry,'\t','') as Country, " +
                "Replace(Visitors.VisitorEmail,'\t','') as Email" +
                " from Visitors" +
                " inner join ConferencesVisit on Visitors.VisitorId = ConferencesVisit.VisitorId" +
                " where ConferencesVisit.ConferenceId = " + selectedConferenceId + ";";
            try
            {
                GetAndShowData(SQLQuery, VisitorsDG);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SetConferencesInfo()
        {
            string SQLQuery = "select Conferences.ConferenceName as Conference, Replace(Organizers.OrganizerCompany,'\t','') as Organizer" +
                " from Conferences " +
                "inner join Organizers on Conferences.ConferenceOrganizerId = Organizers.OrganizerId;";
            try
            {
                GetAndShowData(SQLQuery, ConferencesDG);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowOrganizerInfo()
        {
            string SQLQuery = "select convert(varchar, Conferences.ConferenceDate, 111), Conferences.ConferencePlace, Conferences.ConferenceTheme, " +
                " Replace(Organizers.OrganizerFirstName,'\t',''), Replace(Organizers.OrganizerSurname,'\t',''), Organizers.OrganizerEmail" +
                ", Conferences.ConferenceLanguage from Conferences " +
                "inner join Organizers on Conferences.ConferenceOrganizerId = Organizers.OrganizerId " +
                "where Conferences.ConferenceId ="+selectedConferenceId+";"; 
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery, connection);
                adapter = new SqlDataAdapter(command);

                DataTable Table = new DataTable();
                adapter.Fill(Table);

                textboxesList[0].Text = "Date: " + Table.Rows[0][0].ToString();
                textboxesList[1].Text = "Place: " + Table.Rows[0][1].ToString();
                textboxesList[2].Text = "Theme: " + Table.Rows[0][2].ToString();
                textboxesList[3].Text = "Speaker: " + Table.Rows[0][3].ToString() + " " + Table.Rows[0][4].ToString();
                textboxesList[4].Text = "Speaker email: " + Table.Rows[0][5].ToString();
                textboxesList[5].Text = "Language: " + Table.Rows[0][6].ToString();
                connection.Close();
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

        private void ConferencesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow1 = null;
            string ConferenceName = null;
            try
            {
                dataRow1 = (DataRowView)ConferencesDG.SelectedItem;
                ConferenceName = dataRow1.Row.ItemArray[0].ToString();

                
            }
            catch/*(Exception ex)*/
            {
                //MessageBox.Show(ex.Message);
            }

            string SQLQuery1 = "select Conferences.ConferenceId from Conferences " +
                "where ConferenceName = '" + ConferenceName + "';";

            try
            {
                

                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery1, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table = new DataTable();
                adapter.Fill(Table);
                selectedConferenceId = Table.Rows[0][0].ToString();
                //selectedConferenceL.Content = selectedConferenceId;
                connection.Close();

                SetVisitorsInfo();
                ShowOrganizerInfo();
            }
            catch /*(Exception ex)*/
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void VisitorsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(VisitorsDG.SelectedItem != null)
            {
                DataRowView dataRow1 = null;
                string VisitorEmail = null;
                try
                {
                    dataRow1 = (DataRowView)VisitorsDG.SelectedItem;
                    VisitorEmail = dataRow1.Row.ItemArray[3].ToString();
                }
                catch(Exception ex)
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

                string SQLQuery2 = "select Feedback from ConferencesVisit " +
                    "where VisitorId = " + selectedVisitorId + " and ConferenceId = " + selectedConferenceId + ";";
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    command = new SqlCommand(SQLQuery2, connection);
                    adapter = new SqlDataAdapter(command);
                    DataTable Table2 = new DataTable();
                    adapter.Fill(Table2);
                    FeedbackTB.Text = Table2.Rows[0][0].ToString();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

            }
            
        }
    }
}
