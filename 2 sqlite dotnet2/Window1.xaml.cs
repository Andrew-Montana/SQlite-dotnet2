using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Data.SQLite;

namespace _2_sqlite_dotnet2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string dbConnectingString = @"Data Source=userdata.sqlite;Pooling=true;FailIfMissing=false;Version=3";

        public Window1()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void button_insert_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqlConnect = new SQLiteConnection(dbConnectingString);
            sqlConnect.Open();

            string Query = "insert into userdata (id,name,surname,age,username,password) values("+tb_id.Text+",'"+tb_name.Text+"','"+ tb_surname.Text + "'," +tb_age.Text+",'"+tb_username.Text+"','"+tb_password.Text+"')";
            SQLiteCommand sqlCommand = new SQLiteCommand(Query, sqlConnect);
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
            MessageBox.Show("Data Updated");
        }

        private void button_close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
