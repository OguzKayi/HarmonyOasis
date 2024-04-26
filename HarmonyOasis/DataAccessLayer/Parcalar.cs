using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Parcalar
    {
        public int ID { get; set; }
        public int Muzisyen_ID { get; set; }
        public string Muzisyen { get; set; }
        public int Kategori_ID { get; set; }
        public string Kategori { get; set; }
        public string Isim { get; set; }
        public string Nota { get; set; }
        public DateTime Tarih { get; set; }
        public string TarihStr { get; set; }
        public bool Durum { get; set; }
    }
}
