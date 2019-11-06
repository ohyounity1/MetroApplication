using System;
using System.Windows;

namespace MetroApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadedEventHandler(object sender, RoutedEventArgs e)
        {
            string connStr = "server=localhost;user=root;database=world;port=3306;password=p2JuCq#5798^";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql1 = "USE MetroLines";
                using MySqlCommand cmd1 = new MySqlCommand(sql1, conn);

                var result = cmd1.ExecuteNonQuery();

                // Perform database operations
                string sql = "SELECT * FROM MetroLines";
                using MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine($"{rdr[8]}: {rdr[0]} Line From {rdr[3]} to {rdr[2]} Opened in {rdr[9]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
