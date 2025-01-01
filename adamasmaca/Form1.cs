using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adamasmaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] il = {
            "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin",
            "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur",
            "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan",
            "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul",
            "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir",
            "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş",
            "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas",
            "Şanlıurfa", "Şırnak", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat",
            "Zonguldak"
        };

        string[] hangmanPics = {
            @"
  +---+
  |   |
      |
      |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
        };




        string Yazi = "";

        int random;

        int hak = 6;

        public void basla()
        {
            Random rnd = new Random();
            random = rnd.Next(0, il.Count());

            textBox1.MaxLength = il[random].Count();
            label2.Text = il[random].Count() + " harf";

            Yazi = "";

            for (int k = 0; k < il[random].Count(); k++)
            {
                Yazi += "#";
            }

            label1.Text = Yazi;

            label3.Text = hangmanPics[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            basla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 1)
            {
                bool hata = true;
                for (int i = 0; i < il[random].Count(); i++)
                {
                    if (textBox1.Text.ToLower() == il[random][i].ToString().ToLower())
                    {
                        TextReverse(i, Yazi);
                        hata = false;
                    }

                }

                switch (hata)
                {
                    case false: break;
                    case true: hak--; label3.Text = hangmanPics[-1 * (hak - 6)]; break;
                }

                if (hak == 0)
                {
                    MessageBox.Show("oyun bitti");
                    this.Close();
                }





                label1.Text = Yazi;
            }
            else
            {
                
                if (textBox1.Text == il[random])
                {
                    MessageBox.Show("doğru");
                    basla();

                    hak = 6;
                }
                else if(hak==0){
                    MessageBox.Show("oyun bitti");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("yanlış");
                    hak--;
                    label3.Text = hangmanPics[-1 * (hak - 6)];
                }

            }
        }

        public void  TextReverse(int i, string b)
        {
            int c = 0;
            Yazi = "";
            foreach (char item in b)
            {
                if (c != i)
                {
                    Yazi += item;
                }
                else
                {
                    Yazi += il[random][i].ToString();
                }

                c++;

            }


        }

    }
}
