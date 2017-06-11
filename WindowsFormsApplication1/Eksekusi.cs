using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;
using System.IO;
using System.Numerics;

namespace WindowsFormsApplication1
{
    internal static class Notifikasi
    {
        public static readonly string InputNull = "Masih Terdapat Isian Yang Kosong !";
        public static readonly string SaveTxtSuccess = "Teks berhasil disimpan !";
        public static readonly string SaveImgSuccess = "Gambar Berhasil disimpan !";
        public static readonly string Err_InputStego = "File Stego Image tidak Valid !";
        public static readonly string Err_PasswdStego = "Password Stego Salah !";
        public static readonly string Err_InputGambar = "Gambar Tidak didukung !";
        public static readonly string Err_InputKunci_Publik = "Nilai (P) Harus > 255 !";
        public static readonly string Err_InputKunci_Publik2 = "Nilai (P) bukan Bilangan Prima !";
        public static readonly string Err_InputKunci_Privat = "Nilai (X) harus memenuhi (1 < x <= p-2) !";
        public static readonly string Title_Err = "Error";
        public static readonly string Title_Success = "Success";
        public static readonly string TXT = "Text Files (File Teks) |*.txt";
        public static readonly string PNG = "Image Files (File Image) |*.png";        
    }
    class Eksekusi
    {
        ElGamal EL = new ElGamal();

        public int[] dataReadMeta;
        public int strideCover;

        public byte[] passwd_rahasia;
        public byte[] data_rahasia;

        #region Proses Validasi Input
        public string Cek_Tbox_2Kolom(string pathExt, string passwd)
        {
            string val = String.Empty;
            if (pathExt == String.Empty || passwd == String.Empty)
            {
                val = "Kosong";
            }
            else
            {
                val = "AdaIsi";
            }
            return val;
        }
        public string Cek_Tbox_3Kolom(string pathCover, string pathHiddenFile, string passwd)
        {
            string val = String.Empty;
            if (pathCover == String.Empty || passwd == String.Empty || pathHiddenFile == String.Empty)
            {
                val = "Kosong";
            }
            else
            {
                val = "AdaIsi";
            }
            return val;
        }
        public string Cek_Gambar(string file)
        {
            string val = String.Empty;
            Bitmap bmp = new Bitmap(file);
            if (bmp.PixelFormat.ToString() == "Format32bppArgb")
            {
                val = "Valid";
            }
            else
            {
                val = "Invalid";
            }
            return val;
        }
        #endregion

        #region Proses Manipulasi Gambar
        public byte[] ProsesGetARGB(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpCoverData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
            IntPtr ptr = bmpCoverData.Scan0;
            strideCover = Math.Abs(bmpCoverData.Stride);
            int bytes = strideCover * bmp.Height;
            byte[] argbValue = new byte[bytes];
            Marshal.Copy(ptr, argbValue, 0, bytes);

            return argbValue;
        }
        public BitmapSource convertBitmap(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height, 96, 96, System.Windows.Media.PixelFormats.Bgra32, null,
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }
        #endregion
        
        #region Proses Embed
        public char[] ProsesConvertPassword_toBinary(string passwd)
        {
            string pwd = string.Empty;
            foreach (char x in passwd)
            {
                pwd += Convert.ToString(x, 2).PadLeft(8, '0');
            }

            char[] pwd_biner = pwd.ToCharArray();
            return pwd_biner;
        }
        public char[] ProsesConvertFile_toBinary(byte[] fileHideArray)
        {         
            String bin_string = String.Empty;
            
            foreach (byte x in fileHideArray)
            {
                bin_string += Convert.ToString(x, 2).PadLeft(8, '0');
            }

            char[] bin = bin_string.ToCharArray();
            return bin;
        }
        public Bitmap ProsesStego(Bitmap bmp, byte[] argbValue, char[] fileHide, char[] passwdCover)
        {
            Bitmap value;
            char[] allData = new char[fileHide.Length + passwdCover.Length];
            Array.Copy(passwdCover, allData, passwdCover.Length);
            Array.Copy(fileHide, 0, allData, passwdCover.Length, fileHide.Length);

            for (int i = 0; i < allData.Length; i++)
            {
                if (allData[i] == 49 && ((byte)(argbValue[i] % 2) == 1))
                {
                    argbValue[i] = (byte)(argbValue[i]);
                }
                if (allData[i] == 49 && ((byte)(argbValue[i] % 2) == 0))
                {
                    argbValue[i] = (byte)(argbValue[i] + 1);
                }
                if (allData[i] == 48 && ((byte)(argbValue[i] % 2) == 1))
                {
                    argbValue[i] = (byte)(argbValue[i] - 1);
                }
                if (allData[i] == 48 && ((byte)(argbValue[i] % 2) == 0))
                {
                    argbValue[i] = (byte)(argbValue[i]);
                }
            }

            value = new Bitmap(bmp.Width, bmp.Height, strideCover, bmp.PixelFormat, Marshal.UnsafeAddrOfPinnedArrayElement(argbValue, 0));
            return value;
        }
        public void ProsesWriteMetadata(string filepath, Bitmap bmp, int passwdSize, int fileSize)
        {
            BitmapSource bmpSource;
            BitmapMetadata meta;
            PngBitmapEncoder enc = new PngBitmapEncoder();

            bmpSource = convertBitmap(bmp);
            meta = new BitmapMetadata("png");
            meta.SetQuery("/tEXt/{str=Description}", String.Format("{0}|{1}", passwdSize, fileSize));

            enc.Frames.Add(BitmapFrame.Create(bmpSource, null, meta, null));

            using (var stream = File.Create(filepath))
            {
                enc.Save(stream);
            }
        }
        #endregion

        #region Proses Extract
        public byte[] ProsesConvertPasswd_toByte(string passwd)
        {
            string msg = string.Empty;
            foreach (char x in passwd)
            {
                msg += Convert.ToString(x, 2).PadLeft(8, '0');
            }
            int num = msg.Length / 8;
            byte[] passwd_Byte = new byte[num];
            for (int i = 0; i < num; ++i)
            {
                passwd_Byte[i] = Convert.ToByte(msg.Substring(8 * i, 8), 2);
            }
            return passwd_Byte;
        }
        public string ProsesCheckStegoValid(Bitmap bmpExtract)
        {
            MemoryStream memoryStream = new MemoryStream();
            InPlaceBitmapMetadataWriter meta;
            PngBitmapDecoder pngDecoder;
            BitmapFrame pngFrame;
            string metaVal;
            string val;

            bmpExtract.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            pngDecoder = new PngBitmapDecoder(memoryStream,BitmapCreateOptions.PreservePixelFormat,BitmapCacheOption.Default);
            pngFrame = pngDecoder.Frames[0];
            meta = pngFrame.CreateInPlaceBitmapMetadataWriter();
            
            metaVal = (String)meta.GetQuery("/tEXt/{str=Description}");

            if (metaVal != null)
            {
                val = "Valid";
                string[] sVal = metaVal.Split('|');
                dataReadMeta = new int[sVal.Length];
                int xx = -1;
                foreach (var x in sVal)
                {
                    dataReadMeta[++xx] = int.Parse(x);
                }
            }

            else
            {
                val = "Invalid";
            }

            memoryStream.Close();
            return val;
        }
        public string ProsesCheckStegoPasswd(byte[] argbStego, byte[]passwd)
        {
            string value = String.Empty;
            string Steg_String;
            char[] Steg_Char = new char[argbStego.Length];            

            //LSB Data
            for (int i = 0; i < argbStego.Length; i++)
            {
                if (argbStego[i] % 2 == 0)
                {
                    Steg_Char[i] = (char)48;
                }
                else
                {
                    Steg_Char[i] = (char)49;
                }
            }

            //LSB data to Byte
            Steg_String = new string(Steg_Char);

            int num = Steg_String.Length / 8;
            byte[] fileSteg_Byte = new byte[num];
            for (int i = 0; i < num; ++i)
            {
                fileSteg_Byte[i] = Convert.ToByte(Steg_String.Substring(8 * i, 8), 2);
            }

            //Inizialize Array Data
            passwd_rahasia = new byte[dataReadMeta[0] / 8];
            data_rahasia = new byte[dataReadMeta[1] / 8];

            //Spliting LSB Value to Array Byte
            Array.Copy(fileSteg_Byte, 0, passwd_rahasia, 0, dataReadMeta[0] / 8);
            Array.Copy(fileSteg_Byte, (dataReadMeta[0] / 8), data_rahasia, 0, dataReadMeta[1] / 8);

            //Check Password Encrypt is Same
            if (passwd_rahasia.SequenceEqual(passwd) == true)
            {
                value = "Correct";
            }
            else
            {
                value = "Incorrect";
            }

            return value;

        }
        #endregion

        #region Proses Enkripsi
        public string[] ProsesEnkripsi(string msg, int nilaiP, int nilaiX)
        {
            int nilai_P = nilaiP;
            int nilai_X = nilaiX;
            int nilai_G;
            int nilai_Y;
            int[] nilai_K;
            int[] msg_ascii;
            int[] hasil_gamma;
            int[] hasil_delta;
            string[] hasil_enkripsi;

            nilai_G = EL.GetNilai_G(nilaiP);
            nilai_Y = EL.GetNilai_Y(nilai_P, nilai_G, nilai_X);
            nilai_K = EL.GetNilai_K(msg, nilai_P);
            
            msg_ascii = EL.SplitPesan_ASCII(msg);
            
            hasil_gamma = EL.GetNilai_Gamma(nilai_G, nilai_K, nilai_P);
            hasil_delta = EL.GetNilai_Delta(nilai_Y, nilai_K, nilai_P, msg_ascii);
            hasil_enkripsi = EL.Gabungan_NilaiGamma_NilaiDelta(hasil_gamma, hasil_delta);

            return hasil_enkripsi;
        }
        #endregion

        #region Proses Dekripsi
        public string ProsesDekripsi(string msg, int nilaiP, int nilaiX)
        {
            string hasil_dekripsi;
            EL.Split_Cipher_Gamma_Delta(msg);
            hasil_dekripsi = EL.Proses_Get_Message(EL.gamma_cipher, EL.delta_cipher, nilaiP, nilaiX);
            return hasil_dekripsi;
        }
        #endregion

        #region Proses Pixel Lookup
        public List<byte> a_val = new List<byte>();
        public List<byte> r_val = new List<byte>();
        public List<byte> g_val = new List<byte>();
        public List<byte> b_val = new List<byte>();

        public void SplitArgbPixel(byte[] argb)
        {
            for (int i = 0; i < argb.Length / 4; i++)
            {
                b_val.Add(argb[i]);
                g_val.Add(argb[i+1]);
                r_val.Add(argb[i+2]);
                a_val.Add(argb[i+3]);
                i = i+3;
            }
        }

        #endregion

    }
}