using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10c_k1_ism_20_21
{
    class Program
    {
        static void Main(string[] args)
        {
            // abszolut utvonal
            //StreamReader sr = new StreamReader(@"C:\Users\Norbi\Desktop\csudh.txt");

            // relativ utvonal
            StreamReader sr = new StreamReader(@"..\..\csudh.txt");
            StreamWriter sw = new StreamWriter("csudh.html");

            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine("<html>");
            sw.WriteLine("<head>");
            sw.WriteLine("<title>Domains</title>");
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");
            sw.WriteLine("<table>");

            sw.WriteLine("<tr>");
            sw.WriteLine("<th>Ssz</th>");
            sw.WriteLine("<th>Host domainneve</th>");
            sw.WriteLine("<th>Host IP címe</th>");
            for (int i = 1; i <= 5; i++)
            {
                sw.WriteLine($"<th>{i}. szint</th>");
            }
            sw.WriteLine("</tr>");

            int sszor = 1;
            string sor;
            sr.ReadLine();
            while ((sor = sr.ReadLine()) != null)
            {
                string[] adatok = sor.Split(';');
                string[] dns = adatok[0].Split('.');

                sw.WriteLine("<tr>");
                sw.WriteLine($"<th>{sszor}.</th>");
                sw.WriteLine($"<td>{adatok[0]}</td>");
                sw.WriteLine($"<td>{adatok[1]}</td>");
                for (int i = 0; i < 5; i++)
                {
                    int idx = dns.Length - 1 - i;
                    if (idx >= 0) {
                        sw.WriteLine($"<td>{dns[idx]}</td>");
                    }
                    else
                    {
                        sw.WriteLine("<td>nincs</td>");
                    }
                }
                sw.WriteLine("</tr>");

                sszor++;
            }

            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");



            sw.Close();
            sr.Close();
        }
    }
}
