using System;
using System.Linq;
using System.Windows.Forms;

namespace HotelSystemProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Butonun Click Olayı
        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan gelen giriş bilgilerini al
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Entity Framework ile veritabanına bağlan
            using (var context = new HotelSystemEntities()) // 'HotelSystemEntities' bağlam sınıfı kullanılır
            {
                // Kullanıcıyı veritabanında kontrol et
                var user = context.Table_1
                    .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    // Giriş başarılı
                    MessageBox.Show("Login Successful");

                    // Yeni formu aç ve eski formu kapat
                    MainScreen mainScreen = new MainScreen();
                    mainScreen.Show();  // MainScreen formunu göster
                    this.Hide();  // Eski formu gizle (Form1)
                }
                else
                {
                    // Giriş başarısız
                    MessageBox.Show("Wrong username or password");
                }
            }
        }

        // Form3'e geçiş için yeni buton ekleyelim
        private void personelManagementButton_Click(object sender, EventArgs e)
        {
            // Form3'ü açmak
            Form3 form3 = new Form3();
            form3.Show();  // Yeni bir Form3 örneği oluşturup açıyoruz
            this.Hide();   // Form1'i gizliyoruz
        }
    }
}
