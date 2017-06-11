using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace WindowsFormsApplication1
{
    class ElGamal
    {

        #region Proses Cek Input
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
        #endregion

        #region Proses Enkripsi
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
            return val;
        }
        #endregion

        #region Proses Dekripsi
        public List<int> gamma_cipher = new List<int>();
        public List<int> delta_cipher = new List<int>();           

        public void Split_Cipher_Gamma_Delta(string msg)
        {
            string[] msg_arr;
            msg_arr = msg.Split(' ');
            Array.Resize(ref msg_arr, msg_arr.Length - 1); //Hapus "Spasi" pada akhir Array;

            gamma_cipher.Clear();
            delta_cipher.Clear();

            for (int i = 0; i < msg_arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    gamma_cipher.Add(int.Parse(msg_arr[i]));
                }
                else
                {
                    delta_cipher.Add(int.Parse(msg_arr[i]));
                }
            }            
        }

        public string Proses_Get_Message(List<int> gamma_list, List<int> delta_list, int p, int x)
        {
            int[] gamma = gamma_list.ToArray();
            int[] delta = delta_list.ToArray();
            byte[] val_byte = new byte[gamma.Length];
            string val;

            for (int i = 0; i < gamma.Length; i++)
            {
                val_byte[i] = (byte)((delta[i] * (BigInteger.Pow((BigInteger)gamma[i], (int)(p - 1 - x)))) % p);
            }
            val = System.Text.Encoding.ASCII.GetString(val_byte);
            return val;
        }
        #endregion

    }
}
