using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.Entity.Result
{
    public class HataBilgisi
    {
        public List<string> Hata { get; set; }
        public string HataAciklama { get; set; }

        public static HataBilgisi NotFound(string hataAciklama="Sonuç Bulunamadı", List<string> hata=null)
        {
            return new HataBilgisi() { HataAciklama = hataAciklama, Hata=hata };
        }
        public static HataBilgisi Error(List<string> hata = null, string hataAciklama = "Hata Oluştu")
        {
            return new HataBilgisi() { HataAciklama = hataAciklama, Hata= hata };
        }

        public static HataBilgisi FieldValidationError(List<string> hata = null, string hataAciklama = "Zorunlu Alanlar Eksik")
        {
            return new HataBilgisi { Hata = hata, HataAciklama = hataAciklama };
        }

        public static HataBilgisi TokenNotFoundError(List<string> hata = null, string hataAciklama = "Token Bilgisi Gelmedi")
        {
            return new HataBilgisi { Hata = hata, HataAciklama = hataAciklama };
        }
        public static HataBilgisi TokenValidationError(List<string> hata = null, string hataAciklama = "Token Geçerli Değil")
        {
            return new HataBilgisi { Hata = hata, HataAciklama = hataAciklama };
        }
    }
}
