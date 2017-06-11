using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace WindowsFormsApplication1
{
    class ElGamal
    {
        public bool cekPrima(string angka)
        {
            int prima = int.Parse(angka);
            if (prima == 1) return false;
            if (prima == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(prima));

            for (int i = 2; i <= boundary; ++i)
            {
                if (prima % i == 0)
                {
                    return false;
                }
            }
            return true; 
        }

        public int[] SplitPesan_ASCII(string msg)
        {
            //ASCII adalah sama dengan Konversi ke Byte
            byte[] ascii = Encoding.ASCII.GetBytes(msg);
            int[] val = Array.ConvertAll(ascii, x => (int)x);           
            return val;
        }

        public int GetNilai_G(int p)
        {
            int val;
            Random rd = new Random();
            val = rd.Next(1, p - 1);
            return val;
        }

        public int GetNilai_Y(BigInteger p, BigInteger g, BigInteger x)
        {
            int val;
            val = (int)BigInteger.ModPow(g, x, p);
            return val;
        }

        public int[] GetNilai_K(string msg, BigInteger p)
        {
            int[] val = new int[msg.Length];
            int newP = (int)p - 2;
            Random rd = new Random();
            for (int i = 0; i < msg.Length; i++)
            {
                int rand = (int)(rd.Next(10,newP));
                val[i] = rand;
            }
            return val;
        }

        public int[] GetNilai_Gamma(int g, int[] k, int p)
        {
            int[] val = new int[k.Length];
            for (int i = 0; i < k.Length; i++)
            {
                val[i] = (int)BigInteger.ModPow(g, (BigInteger)k[i], p);
            }
            return val;
        }

        public int[] GetNilai_Delta(int y, int[] k, int p, int[] msg)
        {
            int[] val = new int[msg.Length];
            for (int i = 0; i < msg.Length; i++)
            {
                val[i] = (int)((BigInteger.Pow((BigInteger)y, (int)k[i]) * (BigInteger)msg[i]) % (BigInteger)p);
                //val[i] = (int)BigInteger.po                
            }
                return val;
        }

        public string[] Gabungan_NilaiGamma_NilaiDelta(int[] gamma, int[] delta)
        {
            string[] val = new string[gamma.Length * 2];
            int count = 0;
            for (int i = 0; i < gamma.Length; i++)
            {
                val[count] = gamma[i].ToString();
                val[++count] = delta[i].ToString();
                ++count;
            }

            foreach (var f in gamma)
            {
                System.Diagnostics.Debug.WriteLine(f);
            }

            foreach (var f in delta)
            {
                System.Diagnostics.Debug.WriteLine(f);
            }
            return val;
        }


    }
}
