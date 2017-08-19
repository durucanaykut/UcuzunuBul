using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;


namespace YazılımProjesi {
    public class VatanComputer {
        private Stringim stringim;  // string islemlerini yapacak nesne
        private string siteAdi = "VATANCOMPUTER";
        private string siteLogo = "http://www.firmaurfa.com/wp-content/uploads/2017/07/vatan-bilgisayar-logo.jpg";
        private string urunAramaAdresi = "http://www.vatanbilgisayar.com/arama/";
        private string aranacakUrun = "";
        private string donenUrunAdi = "";
        private string donenUrunFiyati = "";
        private string donenUrunResimAdresi = "";
        private string donenUrunLinki = "";

        private HtmlWeb htmlWeb = new HtmlWeb();  // arama yaparken kullanılacak tarayıcı degiskeni
        private HtmlDocument htmlDocument = new HtmlDocument();  // siteden donen html kodlarının tutulacagı degisken


        public VatanComputer() {  //parametresiz yapici
            stringim = new Stringim();
        }

        public VatanComputer(string aranacakUrun) {  // parametreli yapici
            this.aranacakUrun = aranacakUrun;
            stringim = new Stringim();
        }


        public Task asenkronArama() {   // form kilitlenmesine karsin asenkron sekilde arama yapan fonksiyon
            return Task.Factory.StartNew(() => {
                ara();
                sonucAyikla();
            });
        }


        public void ara() {  // arama yapan fonksiyon
            aranacakUrun = stringim.boslukKarakteriniArtiYap(aranacakUrun);  // Orn: "iphone 5s" --> "iphone+5s"
            urunAramaAdresi = stringim.stringBirlestir(urunAramaAdresi, aranacakUrun);  // "http://www.vatanbilgisayar.com/arama/" + "iphone+5s"
            htmlDocument = htmlWeb.Load(urunAramaAdresi); // html kodlarını dokuman degiskene aktar
        }

        public void sonucAyikla() {   // tek tek string olarak ayıkla
            HtmlNode urunAdDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='ems-prd-name']").First();
            HtmlNode urunFiyatDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='urunListe_satisFiyat']").First();
            HtmlNode urunResimDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='ems-prd-image']//img").First();
            HtmlNode urunLinkDugumu = htmlDocument.DocumentNode.SelectNodes("//div[@class='ems-prd-image']//a").First();

            donenUrunAdi = urunResimDugumu.Attributes["title"].Value.ToString();  // arama sonucu donen urun adı
            donenUrunAdi = stringim.hepsiBuradaKarakterSorunuDuzelt(donenUrunAdi); // arama sonucu donen urun ismindeki Turkce karakter sorunu duzelt

            donenUrunFiyati = urunFiyatDugumu.InnerHtml.ToString();       // arama sonucu donen urun fiyati
            donenUrunFiyati = stringim.spanSil(donenUrunFiyati);
            donenUrunFiyati = stringim.virguldenSonraKirp(donenUrunFiyati);


            donenUrunResimAdresi = urunResimDugumu.Attributes["data-original"].Value.ToString(); // arama sonucu donen urun resim linki
            donenUrunLinki = "https://www.teknosa.com" + urunLinkDugumu.Attributes["href"].Value.ToString(); // arama sonucu donen urun linki


        }

        public string urunAramaAdresiSetGet {   // set get fonksiyonlari
            get { return urunAramaAdresi; }
            set { urunAramaAdresi = value; }
        }

        public string aranacakUrunSetGet {
            get { return aranacakUrun; }
            set { aranacakUrun = value; }
        }

        public string donenUrunAdiSetGet {
            get { return donenUrunAdi; }
            set { donenUrunAdi = value; }
        }

        public string donenUrunFiyatiSetGet {
            get { return donenUrunFiyati; }
            set { donenUrunFiyati = value; }
        }

        public string donenUrunResimAdresiSetGet {
            get { return donenUrunResimAdresi; }
            set { donenUrunResimAdresi = value; }
        }

        public string donenUrunLinkAdresiSetGet {
            get { return donenUrunLinki; }
            set { donenUrunLinki = value; }
        }

        public string siteAdiSetGet {
            get { return siteAdi; }
            set { siteAdi = value; }
        }

        public string siteLogoSetGet {
            get { return siteLogo; }
            set { siteLogo = value; }
        }
    }
}
