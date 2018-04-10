using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerGUI
{
    
    public partial class Form1 : Form
    {
        ServiceHost service;

        public Form1()
        {
            InitializeComponent();
            button1.Text = "Start";
            StateIndicator(Color.Red);
        }

        bool isOn;
        private void button1_Click(object sender, EventArgs e)
        {
            isOn = !isOn;
            ServerStateChange();
        }
        private void ServerStateChange()
        {
            if (isOn)
            {
                StateIndicator(Color.Green);
                StartService();
            }
            else
            {
                StateIndicator(Color.Red);
                CloseService();
            }
        }
        private CommunicationState StartService()
        {
            Uri address = new Uri("");
            NetTcpBinding binding = new NetTcpBinding();

            //service = new ServiceHost(typeof(UserService), address);
            //service.AddServiceEndpoint(typeof(IService), binding, address);

            service.Open();
            return service.State;
        }
        private CommunicationState CloseService()
        {
            service.Close();
            return service.State;
        }
        private void StateIndicator(Color color)
        {
            using(SolidBrush brush = new SolidBrush(color))
            {
                using(Graphics circle = pBox.CreateGraphics())
                {
                    circle.FillEllipse(brush, new Rectangle(0, 0, 25, 25));
                }
            }
            
        }
    }
}
