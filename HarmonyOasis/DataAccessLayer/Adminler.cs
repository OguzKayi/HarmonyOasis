using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Adminler
    {
        public int ID { get; set; }
        public int Tur_ID { get; set; }
        public string Tur { get; set; }
        public string KullaniciAdi { get; set; }
        public string Isim { get; set; }
        public string SoyIsim { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public DateTime Tarih { get; set; }
        public bool Durum { get; set; }
    }
}
