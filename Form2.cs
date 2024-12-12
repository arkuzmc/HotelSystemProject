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
            
            Form3 form3 = new Form3();
            form3.Show();  
            this.Hide();   
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            
            Form4 form4 = new Form4();
            form4.Show();  
            this.Hide();   
        }

       
    }
}
