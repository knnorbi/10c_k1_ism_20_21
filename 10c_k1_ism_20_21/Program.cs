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
        static bool KisebbE(string ez, string ennel)
        {
            string ezIp = ez.Split(';')[1];
            string ennelIp = ennel.Split(';')[1];

            if (int.Parse(ezIp.Split('.')[0]) < int.Parse(ennelIp.Split('.')[0]))
            {
                return true;
            }
            else if (int.Parse(ezIp.Split('.')[0]) > int.Parse(ennelIp.Split('.')[0]))
            {
                return false;
            }
            else if (int.Parse(ezIp.Split('.')[1]) < int.Parse(ennelIp.Split('.')[1]))
            {
                return true;
            }
            else if (int.Parse(ezIp.Split('.')[1]) > int.Parse(ennelIp.Split('.')[1]))
            {
                return false;
            }
            else if (int.Parse(ezIp.Split('.')[2]) < int.Parse(ennelIp.Split('.')[2]))
            {
                return true;
            }
            else if (int.Parse(ezIp.Split('.')[2]) > int.Parse(ennelIp.Split('.')[2]))
            {
                return false;
            }
            else if (int.Parse(ezIp.Split('.')[3]) < int.Parse(ennelIp.Split('.')[3]))
            {
                return true;
            }
            else if (int.Parse(ezIp.Split('.')[3]) > int.Parse(ennelIp.Split('.')[3]))
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("csudh.html");

            // Fajl beolvasas
            string[] sorok = File.ReadAllLines(@"..\..\csudh.txt");
            
            // Elso elem torlese
            string[] tmp = new string[sorok.Length - 1];
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = sorok[i + 1];
            }
            sorok = tmp;

            // Rendezes
            for (int i = 0; i < sorok.Length - 1; i++)
            {
                int legkisebb = i;
                for (int j = i + 1; j < sorok.Length; j++)
                {
                    if (KisebbE(sorok[j],sorok[legkisebb]))
                    {
                        legkisebb = j;
                    }
                }

                if(i != legkisebb)
                {
                    string tmpcsere = sorok[i];
                    sorok[i] = sorok[legkisebb];
                    sorok[legkisebb] = tmpcsere;
                }

            }

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


            for (int k = 0; k < sorok.Length; k++)
            {
                string[] adatok = sorok[k].Split(';');
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
            //sr.Close();
        }
    }
}
