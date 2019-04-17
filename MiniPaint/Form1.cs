using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Point Last = Point.Empty;
        bool IsMouseDown = false;
        Bitmap stara=new Bitmap(10,10);
        Color aaa = Color.Black;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            stara = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            //ListViewItem lvi = new ListViewItem();
            //lvi.BackColor = Color.Green;
            //listView1.Items.Add(lvi);
            toolStripComboBox1.SelectedItem = toolStripComboBox1.Items[1];
            KnownColor known = new KnownColor();

            Color a=Color.FromKnownColor(known);
            
            foreach(KnownColor kc in Enum.GetValues(typeof(KnownColor)))
            {
                Button b = new Button();
                b.Height = 30;
                b.Width = 30;
                b.BackColor = Color.FromKnownColor(kc);

                flowLayoutPanel1.Controls.Add(b);
            }
            foreach (Button kol in flowLayoutPanel1.Controls)
            {
                kol.Click += Kol_Click;
            }

        }

        private void Kol_Click(object sender, EventArgs e)
        {
            aaa = ((Button)sender).BackColor;
            toolStripButton7.BackColor = aaa;
            //((Button)sender).FlatStyle = FlatStyle.Flat;

            //((Button)sender).FlatAppearance.BorderSize=2;

            //((Button)sender).FlatAppearance.BorderColor = Color.FromArgb(255-aaa.ToArgb());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(toolStripButton1.Checked == false)
                toolStripButton1.Checked = true;
            else
                toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            
                IsMouseDown = true;
                Last = e.Location;
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
     
           
            
            int a = int.Parse((string)toolStripComboBox1.SelectedItem);

            if (toolStripButton1.Checked == true)
            {
                if (IsMouseDown == true)//check to see if the mouse button is down
                {
                    Graphics g = Graphics.FromImage(pictureBox1.Image);
                    g.DrawLine(new Pen(aaa, a), Last, e.Location);

                    pictureBox1.Invalidate();//refreshes the picturebox
                    Last = e.Location;
                }
            }
            if (toolStripButton2.Checked == true)
            {
                
                Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                bm=(Bitmap)((Bitmap)pictureBox1.Image).Clone();
                if (IsMouseDown == true)//check to see if the mouse button is down
                {
                    bm = (Bitmap)stara.Clone();
                    Graphics g = Graphics.FromImage(bm);
                    
                   // g.DrawLine(new Pen(Color.Black, 1), Last, e.Location);
                   if(e.Location.X>Last.X&&e.Location.Y>Last.Y)
                        g.DrawRectangle(new Pen(aaa, a), new Rectangle(Last.X, Last.Y, Math.Abs(e.Location.X-Last.X), Math.Abs(e.Location.Y-Last.Y)));
                   else if((e.Location.X <= Last.X && e.Location.Y <= Last.Y))
                        g.DrawRectangle(new Pen(aaa, a), new Rectangle(e.Location.X,e.Location.Y, Last.X-e.Location.X,Last.Y-e.Location.Y));
                    else if((e.Location.X <= Last.X && e.Location.Y > Last.Y))
                        g.DrawRectangle(new Pen(aaa, a), new Rectangle(e.Location.X,Last.Y, Last.X-e.Location.X, e.Location.Y-Last.Y));
                   else
                        g.DrawRectangle(new Pen(aaa, a), new Rectangle(Last.X, e.Location.Y, e.Location.X-Last.X,  Last.Y-e.Location.Y));

                    //g.Clear(Color.White);
                    pictureBox1.Image = bm;
                    
             
                    pictureBox1.Invalidate();//refreshes the picturebox

                }
                //if (IsMouseDown==false)
                //    pictureBox1.Invalidate();//refreshes the picturebox

            }
            if (toolStripButton3.Checked == true)
            {
                Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                bm = (Bitmap)((Bitmap)pictureBox1.Image).Clone();
                if (IsMouseDown == true)//check to see if the mouse button is down
                {
                    bm = (Bitmap)stara.Clone();
                    Graphics g = Graphics.FromImage(bm);

                    if (e.Location.X > Last.X && e.Location.Y > Last.Y)
                        g.DrawEllipse(new Pen(aaa, a), new Rectangle(Last.X, Last.Y, Math.Abs(e.Location.X - Last.X), Math.Abs(e.Location.Y - Last.Y)));
                    else if ((e.Location.X <= Last.X && e.Location.Y <= Last.Y))
                        g.DrawEllipse(new Pen(aaa, a), new Rectangle(e.Location.X, e.Location.Y, Last.X - e.Location.X, Last.Y - e.Location.Y));
                    else if ((e.Location.X <= Last.X && e.Location.Y > Last.Y))
                        g.DrawEllipse(new Pen(aaa, a), new Rectangle(e.Location.X, Last.Y, Last.X - e.Location.X, e.Location.Y - Last.Y));
                    else
                        g.DrawEllipse(new Pen(aaa, a), new Rectangle(Last.X, e.Location.Y, e.Location.X - Last.X, Last.Y - e.Location.Y));
                    pictureBox1.Image = bm;


                    pictureBox1.Invalidate();//refreshes the picturebox

                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
            stara = (Bitmap)pictureBox1.Image.Clone();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (toolStripButton2.Checked == false)
                toolStripButton2.Checked = true;
            else
                toolStripButton2.Checked = false;
            toolStripButton1.Checked = false;
            toolStripButton3.Checked = false;

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (toolStripButton3.Checked == false)
                toolStripButton3.Checked = true;
            else
                toolStripButton3.Checked = false;
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            stara= new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;

        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Image small =(Image)stara;
            stara = new Bitmap(stara,pictureBox1.Size);
            //pictureBox1.DrawToBitmap(stara, new Rectangle(0,0,pictureBox1.Size.Width, pictureBox1.Size.Height));
            //stara.SetResolution(pictureBox1.Size.Width, pictureBox1.Size.Height);
            


            Graphics g = Graphics.FromImage(stara);
            g.Clear(Color.White);
            g.DrawImage(small, new Point(0, 0));

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (toolStripButton8.Checked == true) return;
            else
            {
                toolStripButton8.Checked = true;
                toolStripButton9.Checked = false;


             

            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (toolStripButton9.Checked == true) return;
            else
            {
                toolStripButton9.Checked = true;
                toolStripButton8.Checked = false;

                CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("PL");







            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Image Files(*.PNG;*.JPG;*.GIF)|*.PNG;*.JPG;*.GIF";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(fileDialog.FileName);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files(*.PNG;*.JPG;*.GIF)|*.PNG;*.JPG;*.GIF";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //pictureBox1.Image.FromFile(fileDialog.FileName);
                Image im= Image.FromFile(fileDialog.FileName);
                if(im.Size.Width>=this.MinimumSize.Width&&im.Size.Height>=this.MinimumSize.Height)
                    this.Size = im.Size;
                pictureBox1.Size = im.Size;
                pictureBox1.Image = im;
            }
        }
    }
}
