	**Proje adı						  :**  En ucuzu bul
  
	**Proje Geliştiricileri :** Ahmet İlgin       : 279967
  												  Aykut Arıcıoğlu   : 279998
  												  Aykut Durucan     : 279988
  												  İlker Yasin Aksoy : 279975
  
  **Proje konusu:**
  
  Projemiz satın alınacak ürünlerin ucuzunu bulmak ve müşterinin site site gezmesine çözüm olması için tasarlanmıştır. Projede, en popüler alışveriş 
siteleri olduğundan; Hepsiburada, Sanalpazar, N11 sitelerinin kullanılması kararlaştırıldı. Bahsedilen web siteleri incelendi;
kütüphanelerinin html parse yeteneği ve grafiksel arayüz yeteneği göz önüne alınarak C# dili tercih edildi. Projeye uygunluğu sebebi ile nesne 
yönelimli programlama mimarisi kullanıldı. Daha iyi bir arayüz görünümü için metro framework kullanıldı. Form tepkisizliği sorununa  karşın thread 
kullanma kararı alındı. HtmlAgilityPack, Fizzler, AngleSharp hazır .NET kütüphaneleri incelenerek, HtmlAgilityPack kütüphanesinin kullanılması kararlaştırıldı.

![picture](img/girisekrani.png)

Program çalıştırıldığında bizi hoş bir ekran karşılıyor. Kullanıcı dostu bir tasarım olup, kullanıcının sadece arama yapacağı kelime girmesi yeterli oluyor. 
Ara buttonuna tıklandığında belirtilen siteler üzerinde asenkron olarak arama yapılıp liste biçiminde, ürünler fiyata göre sıralı gelerek karşımıza çıkarıyor.
Listeden eleman seçtiğimizde ürün resmi ve fiyatı sol tarafta karşımıza çıkıyor. Ürüne git dediğimizde ürünün bulunduğu linke gidiyor. 

![picture](img/aramayapildi.png)

Projemizi bitbucket ortamında git versiyon kontrol sistemini kullanarak gerçekleştirdik. Takım çalışmasının nasıl olması gerektiği bir proje üzerinde nasıl toplu
çalışılacağı hakkında fikir sahibi olduk. 

![picture](img/branchTree.png)