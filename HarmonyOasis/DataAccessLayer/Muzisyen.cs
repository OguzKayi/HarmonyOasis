using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Muzisyen
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Ozet { get; set; }
        public string Biyografi { get; set; }
        public string Resim { get; set; }
        public bool Durum { get; set; }
    }
}
