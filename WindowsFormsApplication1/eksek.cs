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
        public int[] dataReadMeta;

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

        public char[] ProsesConvertPasswordtoByte(string passwd)
        {
            string pwd = string.Empty;
            foreach (char x in passwd)
            {
                pwd += Convert.ToString(x, 2).PadLeft(8, '0');
            }

            char[] pwd_biner = pwd.ToCharArray();
            return pwd_biner;
        }

        public char[] ProsesConvertFiletoByte(byte[] fileHideArray)
        {         
            String bin_string = String.Empty;
            
            foreach (byte x in fileHideArray)
            {
                bin_string += Convert.ToString(x, 2).PadLeft(8, '0');
            }

            char[] bin = bin_string.ToCharArray();
            return bin;
        }

        public Bitmap ProsesStego(Bitmap BmpCover, char[] fileHide, char[] passwdCover)
        {
            Bitmap value;
            Rectangle rect = new Rectangle(0, 0, BmpCover.Width, BmpCover.Height);
            BitmapData bmpCoverData = BmpCover.LockBits(rect, ImageLockMode.ReadOnly, BmpCover.PixelFormat);
            IntPtr ptr = bmpCoverData.Scan0;
            int strideCover = Math.Abs(bmpCoverData.Stride);
            int bytes = strideCover * BmpCover.Height;
            byte[] rgbValue = new byte[bytes];
            Marshal.Copy(ptr, rgbValue, 0, bytes);


            char[] allData = new char[fileHide.Length + passwdCover.Length];
            Array.Copy(passwdCover, allData, passwdCover.Length);
            Array.Copy(fileHide, 0, allData, passwdCover.Length, fileHide.Length);


            for (int i = 0; i < allData.Length; i++)
            {
                if (allData[i] == 49 && ((byte)(rgbValue[i] % 2) == 1))
                {
                    rgbValue[i] = (byte)(rgbValue[i]);
                }
                if (allData[i] == 49 && ((byte)(rgbValue[i] % 2) == 0))
                {
                    rgbValue[i] = (byte)(rgbValue[i] + 1);
                }
                if (allData[i] == 48 && ((byte)(rgbValue[i] % 2) == 1))
                {
                    rgbValue[i] = (byte)(rgbValue[i] - 1);
                }
                if (allData[i] == 48 && ((byte)(rgbValue[i] % 2) == 0))
                {
                    rgbValue[i] = (byte)(rgbValue[i]);
                }
            }

            value = new Bitmap(BmpCover.Width, BmpCover.Height, strideCover, BmpCover.PixelFormat, Marshal.UnsafeAddrOfPinnedArrayElement(rgbValue, 0));
            
                   
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



        public void ProsesReadMetadata(Bitmap bmpExtract)
        {
            MemoryStream memoryStream = new MemoryStream();
            bmpExtract.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

            PngBitmapDecoder pngDecoder = new PngBitmapDecoder(memoryStream,BitmapCreateOptions.PreservePixelFormat,BitmapCacheOption.Default);
            BitmapFrame pngFrame = pngDecoder.Frames[0];
            InPlaceBitmapMetadataWriter pngInplace = pngFrame.CreateInPlaceBitmapMetadataWriter();
            memoryStream.Close();
            
            string val = (string)pngInplace.GetQuery("/tEXt/{str=Description}");
            string[] sVal = val.Split('|');
            dataReadMeta = new int[sVal.Length];
            int xx = -1;
            foreach (var x in sVal)
            {
                dataReadMeta[++xx] = int.Parse(x);
            }

            foreach (var f in dataReadMeta)
            {
                System.Diagnostics.Debug.WriteLine(f);
            }
           
        }


    }
}