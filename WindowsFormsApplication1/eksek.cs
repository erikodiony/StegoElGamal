using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace WindowsFormsApplication1
{
    internal static class Notifikasi
    {
        public static readonly string InputNull = "Masih Terdapat Isian Yang Kosong !";
        public static readonly string SaveSuccess = "Teks berhasil disimpan !";
        public static readonly string SaveImgSuccess = "Gambar Berhasil disimpan !";
        public static readonly string Title_Err = "Error";
        public static readonly string Title_Success = "Success";
        public static readonly string TXT = "Text Files (File Teks) |*.txt";
        public static readonly string PNG = "Image Files (Cover Image) |*.png";        
    }
    class eksek
    {
        public string Cek_Tbox_2Kolom(string pathExt, string passwd)
        {
            string val = String.Empty;
            if (pathExt == String.Empty && passwd == String.Empty)
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
            if (pathCover == String.Empty && passwd == String.Empty && pathHiddenFile == String.Empty)
            {
                val = "Kosong";
            }
            else
            {
                val = "AdaIsi";
            }
            return val;
        }

        public string ProsesEnkripsi(string text_asli)
        {
            string val = String.Empty;
            val = text_asli;
            return val;
        }

        public string ProsesDekripsi(string text_enkripsi)
        {
            string val = String.Empty;
            val = text_enkripsi;
            return val;
        }

        public char[] ProsesConvertFiletoByte(byte[] fileHideArray)
        {
         
            String bin_string = String.Empty;
            byte[] tambahBatas = new byte[1];
            tambahBatas[0] = (byte)0;

            foreach (byte x in fileHideArray)
            {
                bin_string += Convert.ToString(x, 2).PadLeft(8, '0');
            }

            foreach (byte c in tambahBatas)
            {
                bin_string += Convert.ToString(c, 2).PadLeft(8, '0');
            }

            char[] bin = bin_string.ToCharArray();

            foreach (var f in bin)
            {
                System.Diagnostics.Debug.WriteLine(f);
            }

            System.Diagnostics.Debug.WriteLine(bin_string);

            return bin;
        }

        public Bitmap ProsesStego(Bitmap BmpCover, char[] fileHide)
        {
            Bitmap value;
            Rectangle rect = new Rectangle(0, 0, BmpCover.Width, BmpCover.Height);
            BitmapData bmpCoverData = BmpCover.LockBits(rect, ImageLockMode.ReadOnly, BmpCover.PixelFormat);
            IntPtr ptr = bmpCoverData.Scan0;
            int strideCover = Math.Abs(bmpCoverData.Stride);
            int bytes = strideCover * BmpCover.Height;
            byte[] rgbValue = new byte[bytes];
            Marshal.Copy(ptr, rgbValue, 0, bytes);

            for (int i = 0; i < fileHide.Length; i++)
            {
                if (fileHide[i] == 49 && ((byte)(rgbValue[i] % 2) == 1))
                {
                    rgbValue[i] = (byte)(rgbValue[i]);
                }
                if (fileHide[i] == 49 && ((byte)(rgbValue[i] % 2) == 0))
                {
                    rgbValue[i] = (byte)(rgbValue[i] + 1);
                }
                if (fileHide[i] == 48 && ((byte)(rgbValue[i] % 2) == 1))
                {
                    rgbValue[i] = (byte)(rgbValue[i] - 1);
                }
                if (fileHide[i] == 48 && ((byte)(rgbValue[i] % 2) == 0))
                {
                    rgbValue[i] = (byte)(rgbValue[i]);
                }
            }

            value = new Bitmap(BmpCover.Width, BmpCover.Height, strideCover, BmpCover.PixelFormat, Marshal.UnsafeAddrOfPinnedArrayElement(rgbValue, 0));

            return value;
        }


    }
}