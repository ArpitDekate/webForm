using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileRead
{
    public partial class Form1 : Form
    {
        String stemp = null;
        String ipfile, opfile,t = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            int size = -1;
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult result = openFile.ShowDialog(); 
            if (result == DialogResult.OK) 
            {
                string file = openFile.FileName;
                ipfile = file;
                try
                {
                    string text = File.ReadAllText(file);
           
                    stemp = text;
                }
                catch (IOException)
                {
                }
                File.WriteAllText("C:\\Users\\hp\\Desktop\\data1",stemp);
                textBox1.Text = ipfile;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String ss=null;
            int cnt = 0;
            Char[] a = stemp.ToCharArray();

            int i = 0;
            
            for(i=0;i<a.Length;i++)
            {
                if(cnt==2)
                {
                    if(a[i]=='-')
                    {
                        a[i] = ' ';
                       // ss = ss + a[i];
                    }
                    else
                    {
                        if (a[i] == ',') {
                            cnt++;
                            ss = ss + a[i];
                        }else
                        ss = ss + a[i];
                    }
                }
                else
                {
                    if (a[i] == ',')
                    {
                        cnt++;
                        if (cnt == 4)
                        {
                            ss = ss + a[i];
                            ss = ss + "\n";
                            cnt = 0;
                        }
                       else
                            ss = ss + a[i];
                     }
                    else
                        ss = ss + a[i];
                }
            }

            FolderBrowserDialog openf = new FolderBrowserDialog();
            openf.ShowNewFolderButton = true;
           
            DialogResult result = openf.ShowDialog();
            if (result == DialogResult.OK)
            {
              
                t = openf.SelectedPath;
                String x = t + "\\ans.txt";
                File.WriteAllText(x,ss);
                File.WriteAllText("C:\\Users\\hp\\Desktop\\Data1", t);
            }
            textBox2.Text = t;
            //*****************************************************************************\\
         /*   OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = String.Empty;
                DialogResult result = openFile.ShowDialog();
                 openFile.InitialDirectory = "E:\\";
                 if (result == DialogResult.OK)
                 {
                    
                    string file = openFile.FileName;
                     try
                     {
                         File.WriteAllText(file, ss);
                     }
                     catch (IOException)
                     {

                     }
                     textBox2.Text= file;
                     MessageBox.Show("Data Manipulated");
                 }*/
  
            MessageBox.Show("Output File Created.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
