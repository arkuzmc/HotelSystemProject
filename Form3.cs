using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSystemProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        // Form yüklendiğinde DataGridView'e verileri bağlama
        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                // Entity Framework ile bağlanıyoruz
                using (var context = new HotelSystemEntities())
                {
                    // Table_1 tablosundaki tüm verileri alıyoruz
                    var personelListesi = context.Table_1.ToList();

                    // Verileri DataGridView'e bağlıyoruz
                    dataGridView1.DataSource = personelListesi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme hatası: " + ex.Message);
            }
        }

        // Add Personel Butonu (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Yeni personel ekliyoruz
                using (var context = new HotelSystemEntities())
                {
                    var newPersonel = new Table_1
                    {
                        Username = txtUsername.Text,  // TextBox'tan alınan veriler
                        Password = txtPassword.Text
                    };

                    // Personeli veritabanına ekliyoruz
                    context.Table_1.Add(newPersonel);
                    context.SaveChanges();
                    MessageBox.Show("Yeni personel başarıyla eklendi");

                    // Verileri güncelliyoruz
                    this.Form3_Load(sender, e);  // Form verilerini güncelle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel ekleme hatası: " + ex.Message);
            }
        }

        // Update Personel Butonu (button2)
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen personelin ID'sini alıyoruz
                var personelId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                using (var context = new HotelSystemEntities())
                {
                    // Personeli veritabanından buluyoruz
                    var personel = context.Table_1.FirstOrDefault(p => p.PersonelID == personelId);

                    if (personel != null)
                    {
                        // TextBox'lardaki bilgileri güncelliyoruz
                        personel.Username = txtUsername.Text;
                        personel.Password = txtPassword.Text;

                        // Veritabanında güncelleniyor
                        context.SaveChanges();
                        MessageBox.Show("Personel başarıyla güncellendi!");

                        // Verileri güncelliyoruz
                        this.Form3_Load(sender, e);  // Form verilerini güncelle
                    }
                    else
                    {
                        MessageBox.Show("Personel bulunamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel güncelleme hatası: " + ex.Message);
            }
        }

        // Delete Personel Butonu (button3)
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen personelin ID'sini alıyoruz
                var personelId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                using (var context = new HotelSystemEntities())
                {
                    // Personeli veritabanından buluyoruz
                    var personel = context.Table_1.FirstOrDefault(p => p.PersonelID == personelId);

                    if (personel != null)
                    {
                        // Personeli siliyoruz
                        context.Table_1.Remove(personel);
                        context.SaveChanges();
                        MessageBox.Show("Personel başarıyla silindi!");

                        // Verileri güncelliyoruz
                        this.Form3_Load(sender, e);  // Form verilerini güncelle
                    }
                    else
                    {
                        MessageBox.Show("Personel bulunamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel silme hatası: " + ex.Message);
            }
        }

        // FillBy ToolStripButton Event'i
        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                // FillBy metoduyla veri çekme işlemi
                this.table_1TableAdapter.FillBy(this.hotelSystemDataSet.Table_1);
                dataGridView1.DataSource = this.hotelSystemDataSet.Table_1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("FillBy hatası: " + ex.Message);
            }
        }
    }
}
