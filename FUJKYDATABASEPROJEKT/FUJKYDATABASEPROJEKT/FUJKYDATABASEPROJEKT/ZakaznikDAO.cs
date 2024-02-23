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
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "DELETE FROM Zakaznik WHERE ID = "+ zakaznik.ID;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Zakaznik> GetAll()
        {
            List<Zakaznik> zakaznici = new List<Zakaznik>();

            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT ID, Jmeno, Email FROM Zakaznik";
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
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "SELECT ID, Jmeno, Email FROM Zakaznik WHERE ID = "+id;
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string jmeno = reader.GetString(1);
                            string email = reader.GetString(2);
                            return new Zakaznik(id, jmeno, email);
                        }
                    }
                }
            }
            return null;
        }

        public void Save(Zakaznik zakaznik)
        {
            using (SqlConnection conn = DatabaseSingleton.GetInstance())
            {
                string query = "INSERT INTO Zakaznik (Jmeno, Email) VALUES (" + zakaznik.Jmeno + zakaznik.Email+")";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

