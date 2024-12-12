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

        
        private void button1_Click(object sender, EventArgs e)
        {
            
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            
            using (var context = new HotelSystemEntities()) 
            {
                
                var user = context.Table_1
                    .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    
                    MessageBox.Show("Login Successful");

                    
                    MainScreen mainScreen = new MainScreen();
                    mainScreen.Show();  
                    this.Hide();  
                }
                else
                {
                    
                    MessageBox.Show("Wrong username or password");
                }
            }
        }

       
        private void personelManagementButton_Click(object sender, EventArgs e)
        {
            
            Form3 form3 = new Form3();
            form3.Show();  
            this.Hide();   
        }
    }
}
