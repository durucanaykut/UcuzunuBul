using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YazılımProjesi {
    public partial class Form1 : MetroFramework.Forms.MetroForm {
        public Form1() {
            InitializeComponent();
        }

        Teknosa tk;
        VatanComputer vc;  // Class tanımla
        classN11 n11;
        sanalPazar sp;
        double[] siraliFiyatDizi;
        string[] siraliSiteDizisi;

        public void fiyataGoreSirala() {  // Site isimlerini ve dondurdukleri fiyatlari diziye at bubble sort ile dizileri kucukten buyuge sirala
            double[] fiyatDizisi = { Convert.ToDouble(n11.donenUrunFiyatiSetGet), Convert.ToDouble(n11.donenUrunFiyatiSetGet), Convert.ToDouble(n11.donenUrunFiyatiSetGet),Convert.ToDouble(n11.donenUrunFiyatiSetGet) };
            string[] siteDizisi = { vc.siteAdiSetGet, n11.siteAdiSetGet,sp.siteAdiSetGet, tk.siteAdiSetGet };

            for (int i = 0; i < siteDizisi.Length; i++)
                for (int j = siteDizisi.Length - 1; j > i; j--) {
                    if (fiyatDizisi[j - 1] > fiyatDizisi[j]) {
                        double tempFiyat = fiyatDizisi[j - 1];
                        string tempSite = siteDizisi[j - 1];

                        fiyatDizisi[j - 1] = fiyatDizisi[j];
                        fiyatDizisi[j] = tempFiyat;

                        siteDizisi[j - 1] = siteDizisi[j];
                        siteDizisi[j] = tempSite;


                    }
                }

            siraliFiyatDizi = fiyatDizisi;
            siraliSiteDizisi = siteDizisi;
        }

        public void siraliGoster()    // kücükten buyuge siralanmis diziyi forma sirali sekilde aktar
        {
            for (int i = 0; i < siraliSiteDizisi.Length; i++)
            {
                if (siraliSiteDizisi[i].Equals("VATANCOMPUTER"))
                {
                    urunListesi.Items.Add(vc.donenUrunAdiSetGet);
                    if (i == 0)
                    {
                        pictureBox2.ImageLocation = vc.siteLogoSetGet;
                    }
                    else if (i == 1)
                    {
                        pictureBox3.ImageLocation = vc.siteLogoSetGet;
                    }
                    else if (i == 2)
                    {
                        pictureBox4.ImageLocation = vc.siteLogoSetGet;
                    }
                    else if (i == 3)
                    {
                        pictureBox5.ImageLocation = tk.siteLogoSetGet;
                    }
                    else if (i == 4)
                    {
                        pictureBox5.ImageLocation = tk.siteLogoSetGet;
                    }

                }
                else if (siraliSiteDizisi[i].Equals("N11"))
                {
                    urunListesi.Items.Add(n11.donenUrunAdiSetGet);
                    if (i == 0)
                    {
                        pictureBox2.ImageLocation = n11.siteLogoSetGet;
                    }
                    else if (i == 1)
                    {
                        pictureBox3.ImageLocation = n11.siteLogoSetGet;
                    }
                    else if (i == 2)
                    {
                        pictureBox4.ImageLocation = n11.siteLogoSetGet;
                    }
                    else if (i == 3)
                    {
                        pictureBox5.ImageLocation = tk.siteLogoSetGet;
                    }
                    else if (i == 4)
                    {
                        pictureBox5.ImageLocation = tk.siteLogoSetGet;
                    }
                }
                    else if (siraliSiteDizisi[i].Equals("SANALPAZAR"))
                    {
                        urunListesi.Items.Add(sp.donenUrunAdiSetGet);
                        if (i == 0)
                        {
                            pictureBox2.ImageLocation = sp.siteLogoSetGet;
                        }
                        else if (i == 1)
                        {
                            pictureBox3.ImageLocation = sp.siteLogoSetGet;
                        }
                        else if (i == 2)
                        {
                            pictureBox4.ImageLocation = sp.siteLogoSetGet;
                        }
                        else if (i == 3)
                        {
                            pictureBox5.ImageLocation = tk.siteLogoSetGet;
                        }
                        else if (i == 4)
                        {
                            pictureBox5.ImageLocation = tk.siteLogoSetGet;
                        }
                }
                    else if (siraliSiteDizisi[i].Equals("TEKNOSA"))
                    {
                        urunListesi.Items.Add(tk.donenUrunAdiSetGet);
                        if (i == 0)
                        {
                            pictureBox2.ImageLocation = tk.siteLogoSetGet;
                        }
                        else if (i == 1)
                        {
                            pictureBox3.ImageLocation = tk.siteLogoSetGet;
                        }
                        else if (i == 2)
                        {
                            pictureBox4.ImageLocation = tk.siteLogoSetGet;
                        }
                        else if (i == 3)
                        {
                            pictureBox5.ImageLocation = tk.siteLogoSetGet;
                        }
                        else if (i == 4)
                        {
                            pictureBox5.ImageLocation = tk.siteLogoSetGet;
                        }
                }
            }
            }


        public void linkResimFiyatGuncelle(int secilenUrununIndeksNumarası)
        {  // Listboxtaki tiklanan urunun index numarasini algila ve formu güncelle
            if (secilenUrununIndeksNumarası == -1)
                return;

            if (siraliSiteDizisi[secilenUrununIndeksNumarası].Equals("VATANCOMPUTER"))
            {

                metroLabel2.Text = vc.donenUrunFiyatiSetGet + "TL";
                pictureBox1.ImageLocation = vc.donenUrunResimAdresiSetGet;
                linkLabel1.Links.Clear();
                linkLabel1.Links.Add(6, 4, vc.donenUrunLinkAdresiSetGet);

            }
            else if (siraliSiteDizisi[secilenUrununIndeksNumarası].Equals("N11"))
            {

                metroLabel2.Text = n11.donenUrunFiyatiSetGet + "TL";
                pictureBox1.ImageLocation = n11.donenUrunResimAdresiSetGet;
                linkLabel1.Links.Clear();
                linkLabel1.Links.Add(6, 4, n11.donenUrunLinkAdresiSetGet);



            }
            else if (siraliSiteDizisi[secilenUrununIndeksNumarası].Equals("SANALPAZAR"))
            {

                metroLabel2.Text = sp.donenUrunFiyatiSetGet + "TL";
                pictureBox1.ImageLocation = n11.donenUrunResimAdresiSetGet;
                linkLabel1.Links.Clear();
                linkLabel1.Links.Add(6, 4, sp.donenUrunLinkAdresiSetGet);



            }
            else if (siraliSiteDizisi[secilenUrununIndeksNumarası].Equals("TEKNOSA"))
            {

                metroLabel2.Text = tk.donenUrunFiyatiSetGet + "TL";
                pictureBox1.ImageLocation = tk.donenUrunResimAdresiSetGet;
                linkLabel1.Links.Clear();
                linkLabel1.Links.Add(6, 4, tk.donenUrunLinkAdresiSetGet);

            }
        }

        void formTemizle() {  // form bilgilerini temizle
            urunListesi.Items.Clear();
            linkLabel1.Visible = false;
            metroLabel2.Text = "";

            pictureBox1.ImageLocation = null;
            pictureBox2.ImageLocation = null;
            pictureBox3.ImageLocation = null;
            pictureBox4.ImageLocation = null;
            pictureBox5.ImageLocation = null;
        }

        private void Form1_Load(object sender, EventArgs e) {
            vc = new VatanComputer();   // classları tek tek yarat
            n11 = new classN11();
            sp=new sanalPazar();
            tk = new Teknosa();
            this.ActiveControl = arama; // imleci textbox a odaklar

        }

        private async void metroButton1_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(arama.Text)) {  // textbox bos mu?
                MessageBox.Show("Boş Bırakılamaz!");  // uyarı mesajı
                return;
            }


            formTemizle();  // form temizle
            vc.aranacakUrunSetGet = arama.Text; // hepsiburada icin ilgili classa aranacak urun ismini gonder
            n11.aranacakUrunSetGet = arama.Text; // benzer sekilde
            sp.aranacakUrunSetGet=arama.Text; // benzer sekilde
            tk.aranacakUrunSetGet = arama.Text;
            metroProgressSpinner1.Visible = true;
            await vc.asenkronArama();  //classların arama yapma fonksiyonları
            await n11.asenkronArama();
            await sp.asenkronArama();
            await tk.asenkronArama();
            metroProgressSpinner1.Visible = false;  //arama bitince loading halkasının gorunurlugu pasif yap
            linkLabel1.Visible = true;  // linki gosterecek kısmı aktif yap
            fiyataGoreSirala();  // classlardaki urunleri ucuzdan pahalıya sırala
            siraliGoster();  // sıralanmıs urunleri forma aktar


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {  // linke tıklanınca
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());  // tarayıcıda ac
        }

        private void urunListesi_SelectedIndexChanged(object sender, EventArgs e) {
            linkResimFiyatGuncelle(urunListesi.SelectedIndex);  //Listboxtaki tiklanan urunun index numarasini algila ve formu güncelle
        }


    }
}
