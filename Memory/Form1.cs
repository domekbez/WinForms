using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool isStart = false;
        bool Zaznaczona = false;
        bool poczatek = true;
        int ilepar = 0;
        int ostatniozaznaczona=0;
        Button ostatni;
        int czas = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            if ((Button)sender != ostatni)
            ((Button)sender).BackColor = Color.Blue;

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if((Button)sender!=ostatni)
            ((Button)sender).BackColor = Color.AliceBlue;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(poczatek)
            {
                isStart = true;
                ((Button)sender).Text = "Pause";
                poczatek = false;
                return;
            }
            if(isStart)
            {
                isStart = false;
                ((Button)sender).Text = "Start";
            }
            else
            {
                isStart = true;
                ((Button)sender).Text = "Pause";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isStart = false;
            button1.Text = "Start";
            Zainicjuj();
        }

        private void Zainicjuj()
        {
            Random rnd = new Random();
            List<int> losowanie = new List<int>();
            losowanie.Add(0);
            losowanie.Add(0);
            losowanie.Add(1);
            losowanie.Add(1);
            losowanie.Add(2);
            losowanie.Add(2);
            losowanie.Add(3);
            losowanie.Add(3);
            losowanie.Add(4);
            losowanie.Add(4);
            losowanie.Add(5);
            losowanie.Add(5);
            losowanie.Add(6);
            losowanie.Add(6);
            losowanie.Add(7);
            losowanie.Add(7);
            List<int> pom = new List<int>();
            while(losowanie.Count!=0)
            {
                int a = rnd.Next(0, losowanie.Count-1);
                pom.Add(losowanie[a]);
                losowanie.RemoveAt(a);
            }
            button3.Text = pom[0].ToString();
            button4.Text = pom[1].ToString();

            button5.Text = pom[2].ToString();
            button6.Text = pom[3].ToString();
            button7.Text = pom[4].ToString();
            button8.Text = pom[5].ToString();
            button9.Text = pom[6].ToString();
            button10.Text = pom[7].ToString();
            button11.Text = pom[8].ToString();
            button12.Text = pom[9].ToString();
            button13.Text = pom[10].ToString();
            button14.Text = pom[11].ToString();
            button15.Text = pom[12].ToString();
            button16.Text = pom[13].ToString();
            button17.Text = pom[14].ToString();
            button18.Text = pom[15].ToString();


            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
            button17.Visible = true;
            button18.Visible = true;

            button3.BackColor = Color.AliceBlue;
            button4.BackColor = Color.AliceBlue;
            button5.BackColor = Color.AliceBlue; 
            button6.BackColor = Color.AliceBlue; 
            button7.BackColor = Color.AliceBlue; 
            button8.BackColor = Color.AliceBlue; 
            button9.BackColor = Color.AliceBlue; 
            button10.BackColor = Color.AliceBlue; 
            button11.BackColor = Color.AliceBlue; 
            button12.BackColor = Color.AliceBlue; 
            button13.BackColor = Color.AliceBlue;
            button14.BackColor = Color.AliceBlue; 
            button15.BackColor = Color.AliceBlue; 
            button16.BackColor = Color.AliceBlue; 
            button17.BackColor = Color.AliceBlue;
            button18.BackColor = Color.AliceBlue;
            ilepar = 0;
            Zaznaczona = false;
            czas = 0;
            label1.Text = "0";
            poczatek = true;


        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (isStart == false) return;
            if(Zaznaczona)
            {
                if(ostatniozaznaczona==int.Parse(((Button)sender).Text)&&ostatni!= (Button)sender)
                {
                    ((Button)sender).Visible = false;
                    ostatni.Visible = false;
                    ilepar++;
                    if(ilepar==8)
                    {
                        isStart = false;
                        DialogResult dialogResult = MessageBox.Show("Your Time: "+label1.Text+ " Do you want to play again?", "The End", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            button2_Click(sender,e);
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                    Zaznaczona = false;
                }
                else if((Button)sender!=ostatni)
                {
                    Zaznaczona = false;
                    ostatniozaznaczona = 0;
                    ostatni.BackColor = Color.AliceBlue;
                }
            }
            else
            {
                ((Button)sender).BackColor = Color.IndianRed;
                ostatni = (Button)sender;
                Zaznaczona = true;
                ostatniozaznaczona = int.Parse(((Button)sender).Text);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isStart)
            {
                czas++;
                label1.Text = czas.ToString();
            }
        }
    }
}
