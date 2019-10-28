using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homew4
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        private readonly string connectionString = "Server=DESKTOP-RM1NBDJ;Database=Sales;Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection();
            viewer = new DataGridView();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string tableName = string.Empty;
            if (comboBox1.Text.ToString().Contains("Покупатели"))
            {
                tableName = "Buyers";
                using (SqlConnection connection = new SqlConnection())
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    string query = $"select * from {tableName};";
                    sqlCommand.CommandText = query;

                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    List<Buyer> buyers = new List<Buyer>();
                    while (sqlDataReader.Read())
                    {
                        buyers.Add(new Buyer
                        {
                            Id = Guid.Parse(sqlDataReader["id"].ToString()),
                            FirstName = sqlDataReader["firstName"].ToString(),
                            LastName = sqlDataReader["lastName"].ToString(),
                        });
                    }
                    textBox1.Clear();
                    for (int i = 0; i < buyers.Count; i++)
                    {
                        textBox1.Text += buyers[i].FirstName.ToString() + " \r";
                        textBox1.Text += buyers[i].LastName.ToString() + "\r\n";
                    }
                }
            }
            else if (comboBox1.Text.ToString().Contains("Продавцы"))
            {
                tableName = "Sellers";
                using (SqlConnection connection = new SqlConnection())
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    string query = $"select * from {tableName};";
                    sqlCommand.CommandText = query;

                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    List<Seller> sellers = new List<Seller>();
                    while (sqlDataReader.Read())
                    {
                        sellers.Add(new Seller
                        {
                            Id = Guid.Parse(sqlDataReader["id"].ToString()),
                            FirstName = sqlDataReader["firstName"].ToString(),
                            LastName = sqlDataReader["lastName"].ToString(),
                        });
                    }
                    textBox1.Clear();
                    for (int i = 0; i < sellers.Count; i++)
                    {
                        textBox1.Text += sellers[i].FirstName.ToString() + " \r";
                        textBox1.Text += sellers[i].LastName.ToString() + "\r\n";
                    }
                }
            }
            else if (comboBox1.Text.ToString().Contains("Заказы"))
            {
                tableName = "Orders";
                using (SqlConnection connection = new SqlConnection())
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    string query = $"select * from {tableName};";
                    sqlCommand.CommandText = query;

                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    List<Order> orders = new List<Order>();
                    while (sqlDataReader.Read())
                    {
                        orders.Add(new Order
                        {
                            Id = Guid.Parse(sqlDataReader["id"].ToString()),
                            SellerId = Guid.Parse(sqlDataReader["sellerId"].ToString()),
                            BuyerId = Guid.Parse(sqlDataReader["buyerId"].ToString()),
                            OrderPrice = Int32.Parse(sqlDataReader["orderPrice"].ToString()),
                            Date = DateTime.Parse(sqlDataReader["date"].ToString())
                        });
                    }
                    textBox1.Clear();
                    for (int i = 0; i < orders.Count; i++)
                    {
                        textBox1.Text += orders[i].SellerId.ToString() + " \r";
                        textBox1.Text += orders[i].BuyerId.ToString() + "\r\n";
                        textBox1.Text += orders[i].OrderPrice.ToString() + "\r\n";
                        textBox1.Text += orders[i].Date.ToString() + "\r\n";
                    }
                }

            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
