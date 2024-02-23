using FUJKYDATABASEPROJEKT;
using System;

public class Program
    {
    static void Main(string[] args)
    {
        ZakaznikDAO zakaznikDAO = new ZakaznikDAO();
        ObjednavkaDAO objednavkaDAO = new ObjednavkaDAO();

        Console.WriteLine("LIST ZAKAZNIKU:");
        foreach (var zakaznik in zakaznikDAO.GetAll())
        {
            Console.WriteLine(zakaznik);
        }

        Console.WriteLine("------------------------------------------------");

        Console.WriteLine("LIST OBJEDNAVEK");
        foreach (var objednavka in objednavkaDAO.GetAll())
        {
            Console.WriteLine(objednavka);
        }
    }
}
