using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HarcosProjekt
{
    class Program
    {
       
        
        static void Main(string[] args)
        {
            Beolvas();
            
        }

        public static void Beolvas()

        {
            List<Harcos> lista = new List<Harcos>(); 
            StreamReader sr = new StreamReader("harcosok.csv");
            string sor = sr.ReadLine();
            string[] tsor = sor.Split(';');
            Harcos adatok = new Harcos(tsor[0], Convert.ToInt32(tsor[1]));
            lista.Add(adatok);
            sr.Close();
        }
    }
}
