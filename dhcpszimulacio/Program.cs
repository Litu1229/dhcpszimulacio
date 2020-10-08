using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dhcpszimulacio
{
    class Program
    {
        static List<string> exclueded = new List<string>();
        static List<string> reserved = new List<string>();

        static void BeolvasExcluded()
        {
            try
            {
                StreamReader file = new StreamReader("excluded.csv");
                try
                {
                    while (!file.EndOfStream)
                    {
                        exclueded.Add(file.ReadLine());
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    file.Close();
                }
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static string cimEggyelNo(string cim)
        {
            /*cim 192.168.10.100
             * visszaadott 192.168.10.101
             * split '.'
             255 ot ne lépje túl*/
            string[] adatok = cim.Split('.');
            int okt4 = Convert.ToInt32(adatok[3]);
            if (okt4 < 255)
            {
                okt4++;
            }
            return adatok[0] + "." + adatok[1] + "." + adatok[2] + "." + okt4.ToString();
        }
            static void Main(string[] args)
            {
                BeolvasExcluded();
            /*foreach (var e in exclueded)
            {
                Console.WriteLine(e);
            }*/
            Console.WriteLine(cimEggyelNo("192.168.10.100"));
                Console.WriteLine("\nVége..");
                Console.ReadLine();
            }
        }
    }

