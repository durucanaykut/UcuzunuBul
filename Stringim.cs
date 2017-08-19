using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazılımProjesi {
    public class Stringim {


        public Stringim() {

        }

        public string boslukKarakteriniArtiYap(string s) // string icindeki bosluk karakterini arti ile degistir
        {
            return s.Replace(" ", "+");
        }

        public string stringBirlestir(string s1, string s2) // stringleri topla
        {
            return s1 + s2;
        }

        public string hepsiBuradaKarakterSorunuDuzelt(string s) // Hepsiburada donen urun isim karakter sorunu duzelt
        {
            return s.Replace("#231;", "ç").Replace("#199;", "Ç").Replace("#252;", "ü").Replace("#220;", "Ü").Replace("#246;", "ö").Replace("#214;", "Ö");
        }

        public string n11KarakterSorunuDuzelt(string s) // N11 donen urun isim karakter sorunu duzelt
        {
            return s.Replace("Ä°", "İ").Replace("Ä±", "ı").Replace("Ã¼", "ü").Replace("ÅŸ", "ş").Replace("Å", "Ş").Replace("Ã§", "ç").Replace("Ã¶", "ö").Replace("ÄŸ", "ğ").Replace("Ã‡", "Ç").Replace("Ã–", "Ö").Replace("Ãœ", "Ü");

        }

        public string n11SpanSil(string s) // N11 urun fiyatindaki fazlalik karakterleri sil
        {
            return s.Substring(0, s.IndexOf(" <span"));
        }

        public string virguldenSonraKirp(string s) // Donen urun fiyatindaki virgullu kismi at
        {
            return s.Substring(0, s.IndexOf(","));
        }

        public string subSil(string _text)
        {
            string a = "<sup>";
            string b = "</sup>";
            _text = _text.Replace(a, "");
            _text = _text.Replace(b, "");
            return _text;
        }

        public string spanSil(string _text)
        {
            string a = "<span>";
            string b = "</span>";
            _text = _text.Replace(a, "");
            _text = _text.Replace(b, "");
            return _text;
        }
    }
}
