using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcuzunuBul
{
    class Hepsiburada
    {
        Stringim stringim;
        private string siteAdi;
        private string siteLogo;
        private string urunAramaAdresi;
        private string aranacakUrun = "";
        private string donenUrunAdi = "";
        private string donenUrunFiyati = "";
        private string donenUrunResimAdresi;
        private string donenUrunLinki = "";
        private string ineHtmlKodlari;
        private HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
        



        private string siteUrunIsimHtmlTag;
        private string siteUrunParaHtmlTag;
        private string siteUrunLinkHtmlTag;
        private string donenUrunResimHtmlTag;


        private Uri aranacakSiteurl;
        private WebClient client = new WebClient();// Web istemcisi oluştur

        public Hepsiburada()
        {
            stringim = new Stringim();  //String duzenleme fonksiyonlarini barindiran class
            siteAdi = "Hepsiburada";
            siteLogo = "http://images.hepsiburada.net/assets/hepsiburada-logo.png";
            urunAramaAdresi = "http://www.hepsiburada.com/ara?q=";
            siteUrunIsimHtmlTag = "//div[@class='product-detail']";    //Aranan kelime isimleri a/h3 te olduğundan
            siteUrunParaHtmlTag = "//span[@class='price product-price']";  //Aranan para ins içindeki itemprop = price te olduğundan            
            siteUrunLinkHtmlTag = "//div[@class='box product no-hover']//a";
            donenUrunResimHtmlTag = "//img[@class='search-top-banner']";



            azalanSiralamaEklenti = "&srt=PRICE_LOW&pg=";

        }

        public Task asenkronArama()  // Form tepkisizliğine karşın asenkron arama yapacak fonksiyon
        {
            return Task.Factory.StartNew(() =>
            {
                ara();
            });
        }

        private void ara()
        {
            try
            {
                aranacakUrun = stringim.boslukKarakteriniArtiYap(aranacakUrun);
                this.aranacakSiteurl = new Uri(urunAramaAdresi + aranacakUrun); //Bağlanılacak Site
                this.ineHtmlKodlari = this.client.DownloadString(aranacakSiteurl);// html kodları indiriyoruz.

                // html kodlarını bir HtmlDocment nesnesine yüklüyoruz.
                this.document.LoadHtml(ineHtmlKodlari); //Document içerisinde tüm html kodları bulunmaktadır.

                HtmlNode urunAdDugumu = document.DocumentNode.SelectNodes(siteUrunIsimHtmlTag).First();  //gereken dugumleri tek tek sec
                HtmlNode urunFiyatDugumu = document.DocumentNode.SelectNodes(siteUrunParaHtmlTag).First();
                HtmlNode urunResimDugumu = document.DocumentNode.SelectNodes(donenUrunResimHtmlTag).First();
                HtmlNode urunLinkDugumu = document.DocumentNode.SelectNodes(siteUrunLinkHtmlTag).First();

                donenUrunAdi = urunLinkDugumu.Attributes["title"].Value.ToString(); ;  //urun adini setle
                donenUrunAdi = donenUrunAdi.Trim(); // urun adindaki bosluk karakterlerini temizle
                donenUrunAdi = stringim.n11KarakterSorunuDuzelt(donenUrunAdi); // karakter sorunu duzelt

                donenUrunFiyati = urunFiyatDugumu.InnerHtml.ToString(); //urun fiyati setle
                donenUrunFiyati = stringim.n11SpanSil(donenUrunFiyati); //N11 urun fiyatindaki fazlalik karakterleri sil
                donenUrunFiyati = stringim.virguldenSonraKirp(donenUrunFiyati); //fiyattaki virgullu kismi at

                donenUrunLinki = urunLinkDugumu.Attributes["href"].Value.ToString(); //urun linki setle
                donenUrunResimAdresi = urunResimDugumu.Attributes["data-original"].Value.ToString(); //urun resim linkini setle

            }
            catch (Exception error)
            {
                MessageBox.Show("Hata : " + error);
            }
        }

        public string urunAramaAdresiSetGet
        {
            get { return urunAramaAdresi; }
            set { urunAramaAdresi = value; }
        }

        public string aranacakUrunSetGet
        {
            get { return aranacakUrun; }
            set { aranacakUrun = value; }
        }

        public string donenUrunAdiSetGet
        {
            get { return donenUrunAdi; }
            set { donenUrunAdi = value; }
        }

        public string donenUrunFiyatiSetGet
        {
            get { return donenUrunFiyati; }
            set { donenUrunFiyati = value; }
        }

        public string donenUrunResimAdresiSetGet
        {
            get { return donenUrunResimAdresi; }
            set { donenUrunResimAdresi = value; }
        }

        public string donenUrunLinkAdresiSetGet
        {
            get { return donenUrunLinki; }
            set { donenUrunLinki = value; }
        }

        public string siteAdiSetGet
        {
            get { return siteAdi; }
            set { siteAdi = value; }
        }

        public string siteLogoSetGet
        {
            get { return siteLogo; }
            set { siteLogo = value; }
        }


    }
}