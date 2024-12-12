using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelSystemProject
{
    public partial class Form5 : Form
    {
        private string connectionString = "Server=DESKTOP-VMGKG2U\\SQLEXPRESS;Database=HotelSystem;Trusted_Connection=True;";
        private HotelSystemDataSet2 hotelSystemDataSet2;
        private HotelSystemDataSet2TableAdapters.RoomsTableAdapter roomsTableAdapter;

        public Form5()
        {
            InitializeComponent();
            hotelSystemDataSet2 = new HotelSystemDataSet2();
            roomsTableAdapter = new HotelSystemDataSet2TableAdapters.RoomsTableAdapter();
        }

        
        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                
                roomsTableAdapter.Fill(hotelSystemDataSet2.Rooms);
                dataGridView1.DataSource = hotelSystemDataSet2.Rooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading rooms: " + ex.Message);
            }
        }

        
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                string customerName = textName.Text;
                string customerMail = textMail.Text;
                string customerID = textIDNo.Text;
                string customerPhone = maskedTextBox1.Text;

                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    
                    string query = "INSERT INTO Customers (CustomerName, CustomerEmail, CustomerID, CustomerPhone) " +
                                   "VALUES (@CustomerName, @CustomerEmail, @CustomerID, @CustomerPhone);";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", customerName);
                        cmd.Parameters.AddWithValue("@CustomerEmail", customerMail);
                        cmd.Parameters.AddWithValue("@CustomerID", customerID);
                        cmd.Parameters.AddWithValue("@CustomerPhone", customerPhone);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Müşteri kaydı başarılı!");

                    
                    textName.Clear();
                    textMail.Clear();
                    textIDNo.Clear();
                    maskedTextBox1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                roomsTableAdapter.FillBy(hotelSystemDataSet2.Rooms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                roomsTableAdapter.FillBy1(hotelSystemDataSet2.Rooms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
