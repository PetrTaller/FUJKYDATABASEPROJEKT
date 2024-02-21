using FUJKYDATABASEPROJEKT;
using System;

public class Program
    {
        static void Main(string[] args)
    {
            ZakaznikDAO zakaznikDAO = new ZakaznikDAO();

            Console.WriteLine("List of customers:");
            foreach (var zakaznik in zakaznikDAO.GetAll())
            {
                Console.WriteLine(zakaznik);
            }
        }
    }