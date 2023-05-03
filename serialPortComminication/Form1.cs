using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serialPortComminication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var serialPort in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(serialPort);
            }
        
            comboBox1.SelectedIndex =0;
            buttonDisconnect.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = Parity.Even;
            serialPort1.StopBits = StopBits.One;
            serialPort1.DataBits = 8;
            try
            {
                serialPort1.Open();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Seriail port connection error" +
                                $"\n  Error:{exception.Message}","Problem",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            if (serialPort1.IsOpen)
            {
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
            }
                

        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
            }
              
             
        }
    }
}