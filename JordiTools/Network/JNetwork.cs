using System;
using System.Collections;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using JordiTools.Network;

namespace JordiTools.Network
{
    class JNetwork
    {
        private static ArrayList Interficies = new ArrayList();


        public static void GenerateInterfaceAndIps()
        {
            StringBuilder Ips = new StringBuilder();
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            /*
                             Ips.Append("- "+ni.Description.ToString());
                            Ips.Append("\n");
                            Ips.Append(ip.Address.ToString());
                            Ips.Append("\n");
                            */

                            Interficies.Add(new Interficie(ni.Description.ToString(),ip.Address.ToString()));
                        }  
                    }
                }
            }
            //return Ips.ToString();
        }


        public static string ToStringEE()
        {
            //return GenerateInterfaceAndIps();
            StringBuilder s = new StringBuilder();
            foreach(Interficie i in Interficies){
                s.Append("->  " + i.getIP());
                s.Append("\n");
                s.Append(i.getType());
                s.Append("\n");
            }
            return s.ToString();
        }

        public static ArrayList GetInterficies()
        {
            return Interficies;
        }

    }
}
