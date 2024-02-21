using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUJKYDATABASEPROJEKT
{
    internal class ZakaznikDAO : IDAO<Zakaznik>
    {
        public void Delete(Zakaznik zakaznik)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Zakaznik> GetAll()
        {
            List<Zakaznik> zakaznici = new List<Zakaznik>();

            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT CustomerID, Jmeno, Email FROM Zakaznici";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string jmeno = reader.GetString(1);
                            string email = reader.GetString(2);

                            Zakaznik zakaznik = new Zakaznik(id, jmeno, email);
                            zakaznici.Add(zakaznik);
                        }
                    }
                }
            }

            return zakaznici;
        }

        public Zakaznik GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Zakaznik e)
        {
            throw new NotImplementedException();
        }
    }
}

