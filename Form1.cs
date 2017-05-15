using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        int  noofbuttons=1;

        private List<TextBox> textboxes1 = new List<TextBox>();
       private List<TextBox> textboxes2 = new List<TextBox>();

        int text1x = 3, gridy=40,text2x=119,text3x= 239;
        List<String> selectedfiles=new List<String>();
        public Form1()
        {
            
            InitializeComponent();
            textboxes1.Add(this.textBox1);
            textboxes2.Add(this.textBox2);

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Upload_Click(object sender, EventArgs e)
        {
            foreach (string file in selectedfiles)
            {
                string path = Path.GetFullPath(file);
                string outputpath = Path.ChangeExtension(path, ".xls");

                string[] CSVDump = File.ReadAllLines(path);
                List<List<string>> records = CSVDump.Select(x => x.Split(';').ToList()).ToList();
                for (int recordno = 0; recordno < records.Count; recordno++)
                {
                    records[recordno].RemoveAt(20);
                    records[recordno].RemoveAt(18);
                    records[recordno].RemoveAt(17);
                    records[recordno].RemoveAt(16);
                    records[recordno].RemoveAt(15);
                    records[recordno].RemoveAt(14);
                    records[recordno].RemoveAt(13);
                    records[recordno].RemoveAt(12);
                    records[recordno].RemoveAt(11);
                    records[recordno].RemoveAt(10);
                    records[recordno].RemoveAt(9);
                    records[recordno].RemoveAt(8);
                    records[recordno].RemoveAt(7);
                    records[recordno].RemoveAt(6);
                    records[recordno].RemoveAt(4);
                    records[recordno].Insert(1, recordno == 0 ? "location" : "delhi");
                    records[recordno].Insert(7, recordno == 0 ? "CTRLCOMPANY" : "delhi");
                    records[recordno].Insert(8, recordno == 0 ? "EMPLOCAL" : "delhi");

                }
                File.WriteAllLines(outputpath, records.Select(x => string.Join(";", x)));
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            //if (sender.Name == "hi")
            //{ }
            // 
            Button button = (Button)sender;
            int index = button.Name.IndexOf("button");
            int selectedbuttonno = Convert.ToInt32(button.Name.Remove(index, 6));
            
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "csv files (*.csv)|*.csv";
            
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {   selectedfiles.Add(openfiledialog.FileName);
                
                textboxes1[selectedbuttonno-1].Text = openfiledialog.FileName;
                textboxes2[selectedbuttonno-1].Text = "Selected";

              //  i++;
            }
            else
            {
                textboxes1[selectedbuttonno - 1].Text = "";

                textboxes2[selectedbuttonno-1].Text = "Not Selected";
            }
          }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            noofbuttons++;
            TextBox newtextbox = new TextBox();
            newtextbox.Location = new System.Drawing.Point(text1x, gridy);
            //y += 30;
            newtextbox.Name = "newtextbox";
            newtextbox.Size = new System.Drawing.Size(99, 20);
            newtextbox.TabIndex = 0;
            textboxes1.Add(newtextbox);
            panel1.Controls.Add(newtextbox);
            TextBox newtextbox2 = new TextBox();
            newtextbox2.Location = new System.Drawing.Point(text3x, gridy);
            newtextbox2.Name = "newtextbox2";
            newtextbox2.Size = new System.Drawing.Size(99, 20);
            newtextbox2.TabIndex = 0;
            textboxes2.Add(newtextbox2);
            panel1.Controls.Add(newtextbox2);
            List<Button> buttons = new List<Button>();
            Button button = new Button();
            button.Location = new System.Drawing.Point(text2x, gridy);
            button.Name = "button"+noofbuttons;
            button.Size = new System.Drawing.Size(114, 20);
            button.TabIndex = 0;
            button.Text = "Browse";
            button.UseVisualStyleBackColor = true;
            button.Click += new System.EventHandler(this.button1_Click);
            buttons.Add(button);
            panel1.Controls.Add(button);

            gridy += 30;

        }


    }
    }

