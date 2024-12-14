using System;
using System.Data;
using System.Linq;
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
                using (var context = new HotelSystemEntities())
                {
                    var reservations = context.Reservations.ToList();
                    dataGridView1.DataSource = reservations; 
                }
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

                using (var context = new HotelSystemEntities())
                {
                    var reservation = new Reservation
                    {
                        CustomerID = int.Parse(txtCustomerID.Text),
                        RoomID = int.Parse(txtRoomID.Text),
                        CheckInDate = checkInDate,
                        CheckOutDate = checkOutDate,
                        TotalPrice = decimal.Parse(txtTotalPrice.Text),
                        Status = "Active"
                    };

                    context.Reservations.Add(reservation);
                    context.SaveChanges();
                }

                MessageBox.Show("Reservation saved successfully.");
                Form4_Load(sender, e); 
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

                using (var context = new HotelSystemEntities())
                {
                    int reservationID = int.Parse(txtReservationID.Text);
                    var reservation = context.Reservations.FirstOrDefault(r => r.ReservationID == reservationID);

                    if (reservation != null)
                    {
                        reservation.CustomerID = int.Parse(txtCustomerID.Text);
                        reservation.RoomID = int.Parse(txtRoomID.Text);
                        reservation.CheckInDate = checkInDate;
                        reservation.CheckOutDate = checkOutDate;
                        reservation.TotalPrice = decimal.Parse(txtTotalPrice.Text);
                        reservation.Status = "Active";

                        context.SaveChanges();
                    }
                }

                MessageBox.Show("Reservation updated successfully.");
                Form4_Load(sender, e); 
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
                using (var context = new HotelSystemEntities())
                {
                    int reservationID = int.Parse(txtReservationID.Text);
                    var reservation = context.Reservations.FirstOrDefault(r => r.ReservationID == reservationID);

                    if (reservation != null)
                    {
                        context.Reservations.Remove(reservation);
                        context.SaveChanges();
                    }
                }

                MessageBox.Show("Reservation deleted successfully.");
                Form4_Load(sender, e); -
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting reservation: " + ex.Message);
            }
        }
    }
}
