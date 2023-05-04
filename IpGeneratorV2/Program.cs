using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpGeneratorV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bit;
            Console.WriteLine("Inserisci numero bit");

            if(!int.TryParse(Console.ReadLine(), out bit))
            {
                Console.WriteLine("Bit errati");
            }
            else
            {
                AddressGenerator ip1 = new AddressGenerator(bit);
                Console.WriteLine($"Indirizzo Ip {ip1.generateIpv4()}");
                Console.WriteLine($"Subnet Mask {ip1.generateSubnet()}");
            }
            Console.ReadLine();
        }
    }
    interface IAddress
    {
        string generateIpv4();
        string generateSubnet();
    }
    public class AddressGenerator : IAddress
    {
        string _indStringa;
        string _subnetStringa;
        int _bit;
        public AddressGenerator(int bit)
        {
            if (bit < 1 || bit > 32)
            {
                throw new Exception("Bit invalidi");
            }
            else
            {
                _bit = bit;
            }
        }
        public string generateIpv4()
        {
            string indStringa;
            int[] indirizzo = new int[4];
            Random nRandom = new Random();
            for (int i = 0; i < 4; i++)
            {
                indirizzo[i] = nRandom.Next(256);
            }
            indStringa = $"{indirizzo[0]}.{indirizzo[1]}.{indirizzo[2]}.{indirizzo[3]}";
            _indStringa = indStringa;
            return indStringa;
        }

        public string generateSubnet()
        {
            int temp2 = 0;
            string subnetStringa, temp = "";
            int bit = GetBit();
            int contatore = 0;
            int[] subnetMask = new int[4];
            for (int i = 0; i < 4; i++)
            {
                byte[] otteto = new byte[8];
                for (int j = 0; j < 8; j++)
                {
                    contatore++;
                    if (contatore <= bit)
                    {
                        otteto[j] = 1;
                    }
                    else
                    {
                        otteto[j] = 0;
                    }
                }
                for (int k = 0; k < 8; k++)
                {
                    temp = temp + otteto[k];
                }
                for (int l = 0; l < 8; l++)
                {
                    if (temp[l] == '1')
                    {
                        temp2 += (int)Math.Pow(2, (7 - l));
                    }
                }
                subnetMask[i] = temp2;
                temp = "";
                temp2 = 0;
            }
            subnetStringa = $"{subnetMask[0]}.{subnetMask[1]}.{subnetMask[2]}.{subnetMask[3]}";
            _subnetStringa = subnetStringa;
            return subnetStringa;
        }
        public int GetBit()
        {
            return _bit;
        }
        public string GetSubnet()
        {
            return _subnetStringa;
        }
        public string GetIp()
        {
            return _indStringa;
        }
    }
}
