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

        
        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                z
                using (var context = new HotelSystemEntities())
                {
                    
                    var personelListesi = context.Table_1.ToList();

                    
                    dataGridView1.DataSource = personelListesi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme hatası: " + ex.Message);
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                using (var context = new HotelSystemEntities())
                {
                    var newPersonel = new Table_1
                    {
                        Username = txtUsername.Text,  
                        Password = txtPassword.Text
                    };

                    
                    context.Table_1.Add(newPersonel);
                    context.SaveChanges();
                    MessageBox.Show("Yeni personel başarıyla eklendi");

                    
                    this.Form3_Load(sender, e);  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel ekleme hatası: " + ex.Message);
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                var personelId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                using (var context = new HotelSystemEntities())
                {
                    
                    var personel = context.Table_1.FirstOrDefault(p => p.PersonelID == personelId);

                    if (personel != null)
                    {
                        
                        personel.Username = txtUsername.Text;
                        personel.Password = txtPassword.Text;

                        
                        context.SaveChanges();
                        MessageBox.Show("Personel başarıyla güncellendi!");

                        
                        this.Form3_Load(sender, e);  
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

        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                var personelId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                using (var context = new HotelSystemEntities())
                {
                    
                    var personel = context.Table_1.FirstOrDefault(p => p.PersonelID == personelId);

                    if (personel != null)
                    {
                        
                        context.Table_1.Remove(personel);
                        context.SaveChanges();
                        MessageBox.Show("Personel başarıyla silindi!");

                        
                        this.Form3_Load(sender, e);  
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

        
        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
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
