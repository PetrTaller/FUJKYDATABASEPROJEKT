using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUJKYDATABASEPROJEKT
{
    public class Zakaznik : IBaseClass
    {
        public int ID { get; set; }
        public string Jmeno { get; set; }
        public string Email { get; set; }

        public Zakaznik (int id, string jmeno, string email)
        {
            ID = id;
            Jmeno = jmeno;
            Email = email;
        }
        public override string ToString()
        {
            return ID+ Jmeno+ Email;
        }
    }    
}

