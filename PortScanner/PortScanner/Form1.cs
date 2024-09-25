using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace PortScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string ipadresi = textBox1.Text;
            listBox1.Items.Add(ipadresi);

            int baslangıcportu = Convert.ToInt32(textBox2.Text);
            int bitisportu = Convert.ToInt32(textBox3.Text);
            
            
            progressBar1.Value = 0;


            for (int i = baslangıcportu; i <= bitisportu; i++)
            {
                progressBar1.Value = ((i - baslangıcportu) * 100) / (bitisportu - baslangıcportu);
                
                if (progressBar1.Value == 100)
                {
                    MessageBox.Show("Tarama işlemi başarıyla bitmiştir.");
                }
                
                TcpClient TcpScan = new TcpClient();

                try
                {
                    TcpScan.Connect(ipadresi, i);
                    listBox1.Items.Add("Port " + i + " Açık");
                }
                catch
                {
                    listBox1.Items.Add("Port " + i + " Kapalı");
                }
                finally {
                    TcpScan.Dispose();
                }

                backgroundWorker1.RunWorkerAsync();


                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
