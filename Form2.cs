using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSystemProject
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Form3'ü açmak
            Form3 form3 = new Form3();
            form3.Show();  // Yeni bir Form3 örneği oluşturup açıyoruz
            this.Hide();   // MainScreen formunu gizliyoruz
        }

        // button2_Click Olayı
        private void button2_Click(object sender, EventArgs e)
        {
            // Form4'ü açmak
            Form4 form4 = new Form4();
            form4.Show();  // Yeni bir Form4 örneği oluşturup açıyoruz
            this.Hide();   // MainScreen formunu gizliyoruz
        }

       
    }
}
