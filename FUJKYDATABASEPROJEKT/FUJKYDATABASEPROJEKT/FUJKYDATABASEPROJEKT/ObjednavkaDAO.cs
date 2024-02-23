using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUJKYDATABASEPROJEKT
{
    internal class ObjednavkaDAO : IDAO<Objednavka>
    {
        public void Delete(Objednavka objednavka)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "DELETE FROM Objednavka WHERE ID = "+ objednavka.ID;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Objednavka> GetAll()
        {
            List<Objednavka> objednavky = new List<Objednavka>();

            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT ID, CasDodani, NazevProduktu, VipZakaznik, Zakaznik_ID FROM Objednavka";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string casDodani = reader.GetString(1);
                            string nazevProduktu = reader.GetString(2);
                            bool vipZakaznik = reader.GetBoolean(3);
                            int zakaznikId = reader.GetInt32(4);

                            Objednavka objednavka = new Objednavka(id, casDodani, nazevProduktu, vipZakaznik, zakaznikId);
                            objednavky.Add(objednavka);
                        }
                    }
                }
            }

            return objednavky;
        }

        public Objednavka GetByID(int id)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT ID, CasDodani, NazevProduktu, VipZakaznik, Zakaznik_ID FROM Objednavky WHERE ID = "+ id;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string casDodani = reader.GetString(1);
                            string nazevProduktu = reader.GetString(2);
                            bool vipZakaznik = reader.GetBoolean(3);
                            int zakaznikId = reader.GetInt32(4);
                            return new Objednavka(id, casDodani, nazevProduktu, vipZakaznik, zakaznikId);
                        }
                    }
                }
            }
            return null;
        }

        public void Save(Objednavka objednavka)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "INSERT INTO Objednavka (CasDodani, NazevProduktu, VipZakaznik, Zakaznik_ID) VALUES " +
                    "("+ objednavka.CasDodani+ objednavka.NazevProduktu +objednavka.VipZakaznik+ objednavka.Zakaznik_ID+")";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}