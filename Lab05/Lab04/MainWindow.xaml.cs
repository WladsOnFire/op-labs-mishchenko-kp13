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

        public string selectedConferenceId = "1";
        string selectedVisitorId = null;
        List<TextBox> textboxesList = new List<TextBox>();

        int textboxIndex = 0;
        bool textboxIsChanged = false;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SetConferencesInfo();
            //SetVisitorsInfo();
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
                myTextBox.KeyUp += TextBoxUpdateInfo;
                myTextBox.GotFocus += TbGotFocus;
                myTextBox.LostFocus += TbLostFocus;

                myGrid.Children.Add(myTextBox);
                textboxesList.Add(myTextBox);
                
            }
            
            //< TextBox HorizontalAlignment = "Left" Margin = "395,10,0,0" TextWrapping = "Wrap" Text = "TextBox" VerticalAlignment = "Top" Width = "120" />
        }
        private void TbLostFocus(object sender, RoutedEventArgs e)
        {
            if (textboxIsChanged)
            {
                MessageBoxResult result = MessageBox.Show($"Save changes?", "Confirmation", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        string date = "";
                        for(int i = textboxesList[0].Text.IndexOf(':') + 2; i< textboxesList[0].Text.Length; i++)
                            date += textboxesList[0].Text[i];
                        
                        string place = "";
                        for (int i = textboxesList[1].Text.IndexOf(':') + 2; i < textboxesList[1].Text.Length; i++)
                            place += textboxesList[1].Text[i];
                        string theme = "";
                        for (int i = textboxesList[2].Text.IndexOf(':') + 2; i < textboxesList[2].Text.Length; i++)
                            theme += textboxesList[2].Text[i];
                        string language = "";
                        for (int i = textboxesList[5].Text.IndexOf(':') + 2; i < textboxesList[5].Text.Length; i++)
                            language += textboxesList[5].Text[i];
                        string firstname = "";
                        int spaceIndex = 0;
                        for (int i = textboxesList[3].Text.IndexOf(':') + 2; i < textboxesList[3].Text.Length; i++)
                        {
                            if (textboxesList[3].Text[i] == ' ') 
                            {
                                
                                spaceIndex = i;
                                break;
                            }
                            firstname += textboxesList[3].Text[i];
                        }
                        string surname = "";
                        for (int i = spaceIndex+1; i < textboxesList[3].Text.Length; i++)
                            surname += textboxesList[3].Text[i];
                        string email = "";
                        for (int i = textboxesList[4].Text.IndexOf(':') + 2; i < textboxesList[4].Text.Length; i++)
                            email += textboxesList[4].Text[i];
                        //MessageBox.Show($"-{date}-{place}-{theme}-{language}-{firstname}-{surname}-{email}-");
                        string OrganizerID = null;
                        
                        string sqlQuery2 = "select ConferenceOrganizerId from Conferences " +
                            "where ConferenceId =" + selectedConferenceId + "; ";
                        
                        textboxIsChanged = false;
                        try
                        {
                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            command = new SqlCommand(sqlQuery2, connection);
                            adapter = new SqlDataAdapter(command);
                            DataTable Table = new DataTable();
                            adapter.Fill(Table);
                            OrganizerID = Table.Rows[0][0].ToString();
                            connection.Close();
                            //MessageBox.Show("ok");
                            string sqlQuery1 = "Begin TRANSACTION " +
                                            "UPDATE Conferences " +
                                            "SET ConferenceDate = '" + date + "', " +
                                            "ConferencePlace = '" + place + "', " +
                                            "ConferenceTheme = '" + theme + "', " +
                                            "ConferenceLanguage = '" + language + "' " +
                                            //"from Organizers, Conferences " +
                                            //"Where Conferences.ConferenceOrganizerId = Organizers.OrganizerId and " +
                                            "Where ConferenceOrganizerId =" + OrganizerID + "; " +

                                            "UPDATE Organizers " +
                                            "set Organizers.OrganizerFirstName = '" + firstname + "', " +
                                            "Organizers.OrganizerSurname = '" + surname + "', " +
                                            "Organizers.OrganizerEmail = '" + email + "' " +
                                            //"from Organizers, Conferences " +
                                            //"Where Conferences.ConferenceOrganizerId = Organizers.OrganizerId and " +
                                            "Where OrganizerId =" + OrganizerID + "; " +
                                            " Commit;";

                            connection = new SqlConnection(connectionString);
                            connection.Open();
                            command = new SqlCommand(sqlQuery1, connection);
                            adapter = new SqlDataAdapter(command);
                            DataTable Table2 = new DataTable();
                            adapter.Fill(Table2);
                            connection.Close();

                            ShowOrganizerInfo();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;

                    case MessageBoxResult.No:
                        textboxIsChanged = false;
                        ShowOrganizerInfo();
                        break;
                }
            }
            
        }
        private void TbGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox myTextBox = (TextBox)e.Source;
            textboxIndex = myTextBox.Text.IndexOf(':');
            ((TextBox)e.Source).CaretIndex = myTextBox.Text.Length;
            //MessageBox.Show("" + textboxIndex);
        }

        public void TextBoxUpdateInfo(object sender, KeyEventArgs e)
        {

            //MessageBox.Show(""+((TextBox)e.Source).Text.Length);
            textboxIsChanged = true;
            if (((TextBox)e.Source).Text.Length <= textboxIndex + 1)
            {
                while (((TextBox)e.Source).Text.Length < textboxIndex + 2)
                    ((TextBox)e.Source).Undo();

                //MessageBox.Show(myTextBox.Text.ToString());
            }
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
                if (dataRow1 != null)
                {
                    ConferenceName = dataRow1.Row.ItemArray[0].ToString();
                }
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

                DeleteBtnC.IsEnabled = true;
                AddVisitorBt.IsEnabled = true;
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
                DeleteVisitorBt.IsEnabled = true;
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
            
        }
        private void ConferencesDG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            TextBox t = e.EditingElement as TextBox;
            string editedCellValue = t.Text.ToString();

            string index = (string) e.Column.Header;
            if (editedCellValue != "")
            {

                DataRowView dataRow2 = (DataRowView)activeCellAtEdit.Item;
            string originalValue = dataRow2[index].ToString();
            //string originalValue = dataRow1.Row.ItemArray[0].ToString() + " " + dataRow1.Row.ItemArray[1].ToString();


                if (editedCellValue != originalValue)
                {
                    //MessageBox.Show(originalValue + "\n" + editedCellValue + " " + index);
                    MessageBoxResult result = MessageBox.Show($"Save changes? \n {originalValue} -> {editedCellValue}", "Confirmation", MessageBoxButton.YesNo);
                    switch (result)
                    { 
                        case MessageBoxResult.Yes:
                            string SQLQuery1 = null;
                            //MessageBox.Show(index + " " + originalValue + " " + editedCellValue);
                            if (index == "Conference")
                                SQLQuery1 = "UPDATE Conferences " +
                                                   "SET ConferenceName = '" + editedCellValue + "' " +
                                                   "WHERE ConferenceName ='" + originalValue + "'; ";
                            else if (index == "Organizer")
                            {
                                SQLQuery1 = "UPDATE Organizers " +
                                                   "SET OrganizerCompany = '" + editedCellValue + "' " +
                                                   "WHERE Replace(OrganizerCompany,'\t','') ='" + originalValue + "'; ";
                            }
                            
                            try
                            {
                                GetAndShowData(SQLQuery1, ConferencesDG);
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            SetConferencesInfo();
                            break;

                        case MessageBoxResult.No:
                            SetConferencesInfo();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Value can not be 'null'");
                SetConferencesInfo();
            }
        }
        private DataGridCellInfo activeCellAtEdit;
        private void ConferencesDG_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            this.activeCellAtEdit = ConferencesDG.CurrentCell;
        }

        private void VisitorsDG_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            this.activeCellAtEdit = VisitorsDG.CurrentCell;
        }

        private void VisitorsDG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
            TextBox t = e.EditingElement as TextBox;
            string editedCellValue = t.Text.ToString();

            
            string index = (string)e.Column.Header;
            if(editedCellValue != "")
            {
                

                DataRowView dataRow2 = (DataRowView)activeCellAtEdit.Item;
                string originalValue = dataRow2[index].ToString();
                //string originalValue = dataRow1.Row.ItemArray[0].ToString() + " " + dataRow1.Row.ItemArray[1].ToString();

                if (editedCellValue != originalValue)
                {
                    MessageBoxResult result = MessageBox.Show($"Save changes? \n {originalValue} -> {editedCellValue}", "Confirmation", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            string SQLQuery1 = null;
                            if (index == "Name")
                            {
                                SQLQuery1 = "UPDATE Visitors " +
                                                  "SET VisitorFirstName = '" + editedCellValue + "' " +
                                                  "where VisitorId = " + selectedVisitorId + ";";
                            }
                            else if (index == "Surname")
                            {
                                SQLQuery1 = "UPDATE Visitors " +
                                                   "SET VisitorSurname = '" + editedCellValue + "' " +
                                                   "where VisitorId = " + selectedVisitorId + ";";
                            }
                            else if (index == "Country")
                            {
                                SQLQuery1 = "UPDATE Visitors " +
                                                   "SET VisitorCountry = '" + editedCellValue + "' " +
                                                   "where VisitorId = " + selectedVisitorId + ";";
                            }
                            else if (index == "Email")
                            {
                                SQLQuery1 = "UPDATE Visitors " +
                                                   "SET VisitorEmail = '" + editedCellValue + "' " +
                                                   "where VisitorId = " + selectedVisitorId + ";";
                            }
                            try
                            {
                                GetAndShowData(SQLQuery1, VisitorsDG);
                                SetVisitorsInfo();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            break;

                        case MessageBoxResult.No:
                            SetVisitorsInfo();
                            break;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Value can not be 'null'");
                SetVisitorsInfo();
            }

        }
        bool FeedbackIsChanged = false;
        private void FeedbackTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (FeedbackIsChanged)
            {
                MessageBoxResult result = MessageBox.Show($"Save changes?", "Confirmation", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    string SQLQuery1 = "update ConferencesVisit " +
                        "set Feedback = '" + FeedbackTB.Text + "' " +
                        "where VisitorId = " + selectedVisitorId + " and ConferenceId = " + selectedConferenceId + ";";
                        FeedbackIsChanged = false;
                    try
                    {
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        command = new SqlCommand(SQLQuery1, connection);
                        adapter = new SqlDataAdapter(command);
                        DataTable Table1 = new DataTable();
                        adapter.Fill(Table1);
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                FeedbackIsChanged = false;
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
        }

        private void FeedbackTB_KeyUp(object sender, KeyEventArgs e)
        {
            FeedbackIsChanged = true;
        }

        private void AddBtnC_Click(object sender, RoutedEventArgs e)
        {
            Window1 AddConferenceWin = new Window1(this);
            AddConferenceWin.Show();
        }

        private void DeleteBtnC_Click(object sender, RoutedEventArgs e)
        {
            string SQLQuery = "delete from Conferences where ConferenceId = "+selectedConferenceId+";";
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table2 = new DataTable();
                adapter.Fill(Table2);
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SetConferencesInfo();
            DeleteBtnC.IsEnabled = false;
        }

        private void DeleteVisitorBt_Click(object sender, RoutedEventArgs e)
        {
            string SQLQuery = "delete from ConferencesVisit where VisitorId ="+selectedVisitorId+" and ConferenceId ="+selectedConferenceId+"; ";
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery, connection);
                adapter = new SqlDataAdapter(command);
                DataTable Table2 = new DataTable();
                adapter.Fill(Table2);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SetVisitorsInfo();
            DeleteVisitorBt.IsEnabled = false;
        }

        private void AddVisitorBt_Click(object sender, RoutedEventArgs e)
        {
            AddVisitorWin AddVisitorWindow = new AddVisitorWin(this);
            AddVisitorWindow.Show();
        }
    }
}
