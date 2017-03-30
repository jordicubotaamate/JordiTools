using System;

namespace JordiTools.Network
{
    internal class Interficie
    {
        //private String IP;
        //private String Type;

        public string IP { get; set; }

        public string Type { get; set; }


        public Interficie(String Type, String IP)
        {
            this.IP = IP;
            this.Type = Type;
        }

        public String getIP()
        {
            return this.IP;
        }

        public String getType()
        {
            return this.Type;
        }

        
    }
}