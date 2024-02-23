using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUJKYDATABASEPROJEKT
{
    public class Objednavka : IBaseClass
    {
        public int ID { get; set; }
        public string CasDodani { get; set; }
        public string NazevProduktu { get; set; }
        public bool VipZakaznik { get; set; }
        public int Zakaznik_ID { get; set; }

        public Objednavka(int id, string casDodani, string nazevProduktu,bool vipZakaznik,int zakaznik_ID)
        {
            ID = id;
            CasDodani = casDodani;
            NazevProduktu = nazevProduktu;
            VipZakaznik = vipZakaznik;
            Zakaznik_ID = zakaznik_ID;
        }
        public override string ToString()
        {
            return ID + CasDodani + NazevProduktu + VipZakaznik + Zakaznik_ID;
        }
    }
}
