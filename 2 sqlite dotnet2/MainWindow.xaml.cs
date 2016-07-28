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

using System.Data.SQLite;
namespace _2_sqlite_dotnet2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dbConnectingString = @"Data Source=userdata.sqlite;Pooling=true;FailIfMissing=false;Version=3";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var sqlConn = new SQLiteConnection(dbConnectingString);
            // open connection to database
            try
            {
                sqlConn.Open();
                string Query = "SELECT * FROM userdata WHERE username='" + this.tb_username.Text + "' and password='" + this.tb_password.Password + "'";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqlConn);

                createCommand.ExecuteNonQuery();

                SQLiteDataReader dataRead = createCommand.ExecuteReader();

                int count = 0;
                while (dataRead.Read()) {
                    count++;
                }
                if (count == 1){
                    MessageBox.Show("Hello " + tb_username.Text + "! You're successfully log in");
                    sqlConn.Close();
                    this.Hide();
                    Window1 window1 = new Window1();
                    window1.ShowDialog();

            }
                else
                    MessageBox.Show("Error, try one more time!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
