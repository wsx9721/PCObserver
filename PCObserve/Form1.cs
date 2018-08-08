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
            Hashtable blacklist = new Hashtable();
            Stopwatch watch = Stopwatch.StartNew();
            string s = "";
            ArrayList process = new ArrayList();
            foreach (Process ps in Process.GetProcesses())
            {
                //PerformanceCounter pf1 = new PerformanceCounter("Process", "Working Set - Private", ps.ProcessName);
                //PerformanceCounter pf2 = new PerformanceCounter("Process", "Working Set", ps.ProcessName);
                //s = s + "进程名:" + ps.ProcessName + "\r\n";
                //if (ps.ProcessName == "QQPCTray") MessageBox.Show("不许使用QQ");
                //if (ps.ProcessName == "") MessageBox.Show("不许使用STEAM");
                Console.WriteLine(ps.ProcessName);
                if (!process.Contains(ps.ProcessName)) process.Add(ps.ProcessName);
            }
            foreach(String pro in process)
            {
                s = s + "进程:" + pro + "\r\n";
            }
            richTextBox1.Text = s;
            MessageBox.Show(Convert.ToString(process.Count));
        }
    }
}
