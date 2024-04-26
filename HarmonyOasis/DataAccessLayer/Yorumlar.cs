using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorumlar
    {
        public int ID { get; set; }
        public int Uye_ID { get; set; }
        public string Uye { get; set; }
        public int Parca_ID { get; set; }
        public string Parca { get; set; }
        public int Kategori_ID { get; set; }
        public string Kategori { get; set; }
        public int Muzisyen_ID { get; set; }
        public string Muzisyen { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public bool Durum { get; set; }
        public bool Kontrol { get; set; }
    }
}
