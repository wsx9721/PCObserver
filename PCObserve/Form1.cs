using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Net;
using System.IO;

namespace PCObserve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                MessageBox.Show(colorDialog1.Color.Name);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llButton_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Config config = new Config();
            int mode = config.check(); //blacklist:0  whitelist:1
            Console.WriteLine(mode);
            Stopwatch watch = Stopwatch.StartNew();
            ArrayList process = new ArrayList();
            foreach (Process ps in Process.GetProcesses())
            {
                if (!process.Contains(ps.ProcessName)) process.Add(ps.ProcessName);
            }
            string ans = "";
            if(mode == 0)
            {
                BlackList checker = new BlackList();
                ans = checker.Check(process);
            }
            else
            {
                foreach (Process ps in Process.GetProcesses())
                {
                    WhiteList checker = new WhiteList();
                    ans = checker.check(process);
                }
            }
            Guid Guid = Guid.NewGuid();
            string guid = Guid.ToString();
            string hostname = System.Net.Dns.GetHostName();
            IPAddress ddr = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
            string ip = ddr.ToString();
            string postData = string.Format("s={0}&guid={1}&hostname={2}&ip={3}&mode={4}", ans, guid, hostname, ip, mode);
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytepostData = encoding.GetBytes(postData);
            string URL = "http://localhost/20180803/test.php";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            ((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            request.Method = "POST";
            request.ContentLength = bytepostData.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(bytepostData, 0, bytepostData.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            //Stream data = response.GetResponseStream();
            //response.Close();
        }
    }
}
