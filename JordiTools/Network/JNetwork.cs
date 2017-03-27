using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace JordiTools.Network
{
    class JNetwork
    {
        private static String GenerateInterfaceAndIps()
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
                            Ips.Append(ni.Description.ToString());
                            Ips.Append("\n");
                            Ips.Append(ip.Address.ToString());
                            Ips.Append("\n");
                        }
                    }
                }
            }
            return Ips.ToString();
        }

        public static string GetIps()
        {
            return GenerateInterfaceAndIps();
        }
    }
}
