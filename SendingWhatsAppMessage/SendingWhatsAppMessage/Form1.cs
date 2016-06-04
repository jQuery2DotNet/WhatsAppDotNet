using System;
using System.Windows.Forms;
using WhatsAppApi;

namespace SendingWhatsAppMessage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string from = "91**********"; //(Enter your mobile number with country code)
            string to = txtTo.Text;
            string msg = txtMessage.Text;

            // Generate WhatsApp password form this url => http://www.watools.es/pwd.html
            WhatsApp wa = new WhatsApp(from, "WhatsAppPassword", "NickName", false, false);

            // Connect Success
            wa.OnConnectSuccess += () =>
            {
                MessageBox.Show("Connected to WhatsApp...");
                // Login Success
                wa.OnLoginSuccess += (phonenumber, data) =>
                {
                    wa.SendMessage(to, msg);
                    MessageBox.Show("Message Sent...");
                };
                // Login Fail
                wa.OnLoginFailed += (data) =>
                {
                    MessageBox.Show("Login Failed : {0} : ", data);
                };
                wa.Login();
            };
            // Connet Fail
            wa.OnConnectFailed += (Exception) =>
            {
                MessageBox.Show("Connection Failed...");
            };
        }
    }
}
