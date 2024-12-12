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
            // Reservations tablosuna veri yükleniyor.
            try
            {
                this.reservationsTableAdapter.Fill(this.hotelSystemDataSet1.Reservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservations: " + ex.Message);
            }
        }

        // Save Button
        private void btnSaveReservation_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime checkInDate = dateTimePicker1.Value;
                DateTime checkOutDate = dateTimePicker2.Value;

                this.reservationsTableAdapter.Insert(
                    int.Parse(txtCustomerID.Text),  // CustomerID
                    int.Parse(txtRoomID.Text),     // RoomID
                    checkInDate,                   // CheckInDate
                    checkOutDate,                  // CheckOutDate
                    decimal.Parse(txtTotalPrice.Text), // TotalPrice
                    "Active" // ReservationStatus
                );

                MessageBox.Show("Reservation saved successfully.");
                this.reservationsTableAdapter.Fill(this.hotelSystemDataSet1.Reservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving reservation: " + ex.Message);
            }
        }

        // Update Button
        private void btnUpdateReservation_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime checkInDate = dateTimePicker1.Value;
                DateTime checkOutDate = dateTimePicker2.Value;

                this.reservationsTableAdapter.Update(
                    int.Parse(txtCustomerID.Text),  // CustomerID
                    int.Parse(txtRoomID.Text),     // RoomID
                    checkInDate,                   // CheckInDate
                    checkOutDate,                  // CheckOutDate
                    decimal.Parse(txtTotalPrice.Text), // TotalPrice
                    "Active", // ReservationStatus
                    int.Parse(txtReservationID.Text)  // ReservationID
                );

                MessageBox.Show("Reservation updated successfully.");
                this.reservationsTableAdapter.Fill(this.hotelSystemDataSet1.Reservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating reservation: " + ex.Message);
            }
        }

        // Delete Button
        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            try
            {
                this.reservationsTableAdapter.Delete(
                    int.Parse(txtReservationID.Text),  // ReservationID
                    int.Parse(txtCustomerID.Text),     // CustomerID
                    int.Parse(txtRoomID.Text),         // RoomID
                    dateTimePicker1.Value,             // CheckInDate
                    dateTimePicker2.Value,             // CheckOutDate
                    decimal.Parse(txtTotalPrice.Text), // TotalPrice
                    "Active"                           // ReservationStatus
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
