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

public class webdenal
{
    public webdenal()
    {
    }
   
    public string replaceText(string _text) //karakter sorunu giderildi
    {

        _text = _text.Replace("Ä°", "İ").Replace("Ä±", "ı").Replace("Ã¼", "ü").Replace("ÅŸ", "ş").Replace("Å", "Ş").Replace("Ã§", "ç").Replace("Ã¶", "ö").Replace("ÄŸ", "ğ").Replace("Ã‡", "Ç").Replace("Ã–", "Ö").Replace("Ãœ", "Ü");
        return _text;
    }

    public List<string> webdenalSitesiUzerindeAramaYap(string aranacakSiteLinki)
    {
        Uri url;
        // Web client oluşturma
        WebClient client = new WebClient();

        HtmlNodeCollection cekilecekIsim;
        HtmlNodeCollection cekilecekPara;

        List<string> tagdenGelenIsim = new List<string>();
        List<string> tagdenGelenPara = new List<string>();
        List<string> toplamVeri = new List<string>();

        try
        {
            url = new Uri(aranacakSiteLinki); //Bağlanılacak Sitenin Linki

            //Bağlanılan siteden html kodları indiriliyor.
            string html = client.DownloadString(url);

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); // html kodlarını bir HtmlDocment nesnesine yüklüyoruz.
            document.LoadHtml(html); //Document içerisinde tüm html kodları bulunmaktadır.

            cekilecekIsim = document.DocumentNode.SelectNodes("//h6[@itemprop='name']"); //Aranan kelime isimleri h6 da olduğu bilgisi girildi
            cekilecekPara = document.DocumentNode.SelectNodes("//span[@itemprop='price']");   //Aranan para span içindeki itemprop= price te olduğu bilgisi girildi.

            foreach (var cekilenIsmiParcala in cekilecekIsim) //Çektiğimiz bilgeler dizi halinde listeleniyor.
            {
                tagdenGelenIsim.Add(cekilenIsmiParcala.InnerText); 
            }
            foreach (var cekilenParayiParcala in cekilecekPara) 
            {
                tagdenGelenPara.Add(cekilenParayiParcala.InnerText); 
            }
        }
        catch (Exception error)
        {
            MessageBox.Show("Hata : " + error);
        }
        //türkçe karakter sorunu giderilip, tek stringe çekiliyor ve stringlerin başında sonunda boşluk varsa siliniyor
        for (int i = 0; i < tagdenGelenPara.Count; i++)
            toplamVeri.Add(replaceText(tagdenGelenIsim[i].Trim()) + " --> " + replaceText(tagdenGelenPara[i].Trim()));

        return toplamVeri; //aranan text "isim --> para" olarak string geri döndürülüyor

    }
}