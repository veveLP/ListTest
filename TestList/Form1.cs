using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public void vypis(List<String> list, ListBox listBox)
        {
            listBox.Items.AddRange(list.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            textBox1.Text = "";
            Random random = new Random();
            String txt = String.Empty;
            for (int i = 0;i<(int)numericUpDown1.Value;i++)
            {
                txt += ((char)random.Next(32, 127)).ToString();
            }
            textBox1.Text = txt.Replace(" ", "");
            List<String> slova = new List<string>();
            List<String> cisla = new List<string>();
            List<String> ostatni = new List<string>();
            String temp = String.Empty;
            foreach (char c in txt.Replace(" ", ""))
            {
                if(Char.IsLetter(c)) { temp += c; continue; }
                if(temp.Length > 1) { slova.Add(temp); temp = ""; }
                if (Char.IsDigit(c)) { cisla.Add(c.ToString()); continue; }
                if(!(Char.IsLetterOrDigit(c))) { ostatni.Add(c.ToString()); continue; }
            }
            foreach (String str in txt.Split(' '))
            {
                //if(str.All(Char.IsLetter) && str.Length > 1) { slova.Add(str); continue; }
                //if(str.All(Char.IsDigit) && str.Length > 0) { cisla.Add(str); MessageBox.Show(str); continue; }
                //if(!str.All(Char.IsLetterOrDigit)) { ostatni.Add(str); }
            }
            cisla.Sort();
            ostatni.Sort();
            //ostatni.OrderBy(s => s, StringComparer.Ordinal);
            /*bool sorted = false;
            bool sorted2 = false;
            while (sorted)
            {
                sorted = sorted2;
                sorted2 = true;
                for (int i = 0;i<ostatni.Count-1;i++)
                {
                    if((int)ostatni[i].ToCharArray()[0] > (int)ostatni[i+1].ToCharArray()[0])
                    {
                        char tmp = ostatni[i].ToCharArray()[0];
                        ostatni[i].ToCharArray()[0] = ostatni[i+1].ToCharArray()[0];
                        ostatni[i + 1].ToCharArray()[0] = tmp;
                        sorted2 = false;
                    }
                }
            }*/
            vypis(slova, listBox1);
            vypis(cisla, listBox2);
            vypis(ostatni, listBox3);
            if(cisla.Count %2 == 0) { MessageBox.Show("Medián = " + ((Double.Parse(cisla[cisla.Count / 2]) + Double.Parse(cisla[(cisla.Count/2)-1]))/2).ToString()); return; }
            MessageBox.Show("Medián = "+cisla[cisla.Count / 2]);
            
        }
    }
}
