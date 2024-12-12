using System;
using System.Data;
using System.Windows.Forms;

namespace HotelSystemProject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            try
            {
                this.reservationsTableAdapter.Fill(this.hotelSystemDataSet1.Reservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservations: " + ex.Message);
            }
        }

        
        private void btnSaveReservation_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime checkInDate = dateTimePicker1.Value;
                DateTime checkOutDate = dateTimePicker2.Value;

                this.reservationsTableAdapter.Insert(
                    int.Parse(txtCustomerID.Text),  
                    int.Parse(txtRoomID.Text),     
                    checkInDate,                   
                    checkOutDate,                  
                    decimal.Parse(txtTotalPrice.Text), 
                    "Active" 
                );

                MessageBox.Show("Reservation saved successfully.");
                this.reservationsTableAdapter.Fill(this.hotelSystemDataSet1.Reservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving reservation: " + ex.Message);
            }
        }

        
        private void btnUpdateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime checkInDate = dateTimePicker1.Value;
                DateTime checkOutDate = dateTimePicker2.Value;

                this.reservationsTableAdapter.Update(
                    int.Parse(txtCustomerID.Text),  
                    int.Parse(txtRoomID.Text),     
                    checkInDate,                   
                    checkOutDate,                  
                    decimal.Parse(txtTotalPrice.Text), 
                    "Active", 
                    int.Parse(txtReservationID.Text)  
                );

                MessageBox.Show("Reservation updated successfully.");
                this.reservationsTableAdapter.Fill(this.hotelSystemDataSet1.Reservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating reservation: " + ex.Message);
            }
        }

        
        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            try
            {
                this.reservationsTableAdapter.Delete(
                    int.Parse(txtReservationID.Text),  
                    int.Parse(txtCustomerID.Text),     
                    int.Parse(txtRoomID.Text),         
                    dateTimePicker1.Value,             
                    dateTimePicker2.Value,             
                    decimal.Parse(txtTotalPrice.Text), 
                    "Active"                           
                );

                MessageBox.Show("Reservation deleted successfully.");
                this.reservationsTableAdapter.Fill(this.hotelSystemDataSet1.Reservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting reservation: " + ex.Message);
            }
        }
    }
}
