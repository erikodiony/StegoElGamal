using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string getPathTeks;
        string getPathImg;
        string getPathImg2; 
        string getPathTeks1;
        string getPassExt;
        string getPathTeks2;

        string hasil_ext_confirm_null;
        string hasil_emb_confirm_null;
        string hasil_enk_confirm_null;
        string hasil_dek_confirm_null;

        string hasil_enkripsi;
        string hasil_dekripsi;

        int bmpCoverW;
        int bmpCoverH;
        int bmpStegoW;
        int bmpStegoH;

        Eksekusi EX = new Eksekusi();
        ElGamal EL = new ElGamal();

        OpenFileDialog opfile;
        SaveFileDialog svfile;
        DialogResult dlg;

        #region Proses Enkripsi
        private void loadenk_Click(object sender, EventArgs e)
        {
            opfile = new OpenFileDialog();
            opfile.Filter = Notifikasi.TXT;
            if (opfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                msgenk.Lines = null;
                getPathTeks = opfile.FileName;
                pathenk.Text = getPathTeks;
                msgenk.Lines = File.ReadAllLines(getPathTeks);
            }
        }
        private void saveenk_Click(object sender, EventArgs e)
        {
            hasil_enk_confirm_null = EX.Cek_Tbox_2Kolom(msgenk.Text, msghslenk.Text);
            if (hasil_enk_confirm_null == "Kosong")
            {
                dlg = MessageBox.Show(Notifikasi.InputNull, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                svfile = new SaveFileDialog();
                svfile.Filter = Notifikasi.TXT;
                svfile.RestoreDirectory = true;
                svfile.FileName = String.Format("Enkripsi_{0}_{1}_{2}", DateTime.Now.ToString("dd-M-yyyy"), tbox_pub_enk.Text, tbox_pri_enk.Text);
                if (svfile.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllLines(svfile.FileName, msghslenk.Lines);
                    dlg = MessageBox.Show(Notifikasi.SaveTxtSuccess, Notifikasi.Title_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }             
        private void eksenk_Click(object sender, EventArgs e)
        {
            hasil_enk_confirm_null = EX.Cek_Tbox_2Kolom(msgenk.Text, "1");
            if (hasil_enk_confirm_null == "Kosong")
            {
                dlg = MessageBox.Show(Notifikasi.InputNull, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (tbox_pub_enk.Text == String.Empty || tbox_pri_enk.Text == String.Empty)
                {
                    dlg = MessageBox.Show(Notifikasi.InputNull, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ProsesValidasi_Enkripsi();
                }
            }

        }
        #endregion

        #region Proses Embed
        private void loademb1_Click(object sender, EventArgs e)
        {
            opfile = new OpenFileDialog();
            opfile.Filter = Notifikasi.PNG;
            if (opfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                getPathImg = opfile.FileName;
                pathemb1.Text = getPathImg;
                Bitmap bmpcover = new Bitmap(getPathImg);
                tmplgbremb.Image = bmpcover;
            }
        }
        private void loademb2_Click(object sender, EventArgs e)
        {
            opfile = new OpenFileDialog();
            opfile.Filter = Notifikasi.TXT;
            if (opfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                getPathTeks1 = opfile.FileName;
                pathemb2.Text = getPathTeks1;
            }
        }
        private void eksemb_Click(object sender, EventArgs e)
        {
            hasil_emb_confirm_null = EX.Cek_Tbox_3Kolom(pathemb1.Text, pathemb2.Text, passemb.Text);
            if (hasil_emb_confirm_null == "Kosong")
            {
                dlg = MessageBox.Show(Notifikasi.InputNull, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (EX.Cek_Gambar(pathemb1.Text) == "Invalid")
                {
                    dlg = MessageBox.Show(Notifikasi.Err_InputGambar, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ProsesEmbedding();
                }
            }
        }
        #endregion

        #region Proses Extract
        private void loadext_Click(object sender, EventArgs e)
        {
            opfile = new OpenFileDialog();
            opfile.Filter = Notifikasi.PNG;
            if (opfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                getPathImg2 = opfile.FileName;
                pathext.Text = getPathImg2;
                Bitmap bmpcover = new Bitmap(getPathImg2);
                tmplgbrext.Image = bmpcover;
            }
        }
        private void eksext_Click(object sender, EventArgs e)
        {
            getPassExt = passext.Text;
            hasil_ext_confirm_null = EX.Cek_Tbox_2Kolom(pathext.Text, passext.Text);
            if (hasil_ext_confirm_null == "Kosong")
            {
                dlg = MessageBox.Show(Notifikasi.InputNull, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ProsesExtract();
            }
        }
        #endregion

        #region Proses Dekripsi
        private void loaddek_Click(object sender, EventArgs e)
        {
            opfile = new OpenFileDialog();
            opfile.Filter = Notifikasi.TXT;
            if (opfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                msgdek.Lines = null;
                getPathTeks2 = opfile.FileName;
                pathdek.Text = getPathTeks2;
                msgdek.Lines = File.ReadAllLines(getPathTeks2);
            }
        }
        private void eksdek_Click(object sender, EventArgs e)
        {
            hasil_dek_confirm_null = EX.Cek_Tbox_2Kolom(pathdek.Text, msgdek.Text);
            if (hasil_dek_confirm_null == "Kosong")
            {
                dlg = MessageBox.Show(Notifikasi.InputNull, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (tbox_pub_dek.Text == String.Empty || tbox_pri_dek.Text == String.Empty)
                {
                    dlg = MessageBox.Show(Notifikasi.InputNull, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    ProsesValidasi_Dekripsi();
                }
            }
        }
        private void savedek_Click(object sender, EventArgs e)
        {
            svfile = new SaveFileDialog();
            svfile.Filter = Notifikasi.TXT;
            svfile.RestoreDirectory = true;
            svfile.FileName = String.Format("Dekripsi_{0}_{1}_{2}", DateTime.Now.ToString("dd-M-yyyy"), tbox_pub_dek.Text, tbox_pri_dek.Text);
            if (svfile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(svfile.FileName, msghsldek.Lines);
                dlg = MessageBox.Show(Notifikasi.SaveTxtSuccess, Notifikasi.Title_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Proses Pixel Lookup
        public List<BGRA_Cover> data_cover = new List<BGRA_Cover>();
        public List<BGRA_Stego> data_stego = new List<BGRA_Stego>();

        private void btn_cover_Click(object sender, EventArgs e)
        {
            Bitmap bmp_Cover;
            opfile = new OpenFileDialog();
            opfile.Filter = Notifikasi.PNG;
            if (opfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbox_path_cover.Text = opfile.FileName;
                bmp_Cover = new Bitmap(opfile.FileName);
                ProsesTampilDataGrid_Cover(opfile.FileName, bmp_Cover);
            }
        }
        private void btn_stego_Click(object sender, EventArgs e)
        {
            Bitmap bmp_Stego;
            opfile = new OpenFileDialog();
            opfile.Filter = Notifikasi.PNG;
            if (opfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbox_path_stego.Text = opfile.FileName;
                bmp_Stego = new Bitmap(opfile.FileName);
                ProsesTampilDataGrid_Stego(opfile.FileName, bmp_Stego);
            }
        }
        private void btn_TampilPixel_Click(object sender, EventArgs e)
        {
            if (tbox_X.Text != String.Empty || tbox_Y.Text != String.Empty)
            {
                int Xval = int.Parse(tbox_X.Text);
                int Yval = int.Parse(tbox_Y.Text);
                if (Xval <= 0 || Xval > bmpCoverW || Xval > bmpStegoW)
                {
                    dlg = MessageBox.Show(Notifikasi.Err_Input_Xval, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Yval <= 0 || Yval > bmpCoverH || Yval > bmpStegoH)
                {
                    dlg = MessageBox.Show(Notifikasi.Err_Input_Yval, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int stride_cover = bmpCoverW * 4;
                    int stride_stego = bmpStegoW * 4;
                    Bitmap bmpCover = new Bitmap(tbox_path_cover.Text);
                    Bitmap bmpStego = new Bitmap(tbox_path_stego.Text);

                    byte[] argb_cover = EX.ProsesGetARGB(bmpCover);
                    byte[] argb_stego = EX.ProsesGetARGB(bmpStego);

                    System.Diagnostics.Debug.WriteLine(stride_cover);
                    System.Diagnostics.Debug.WriteLine(stride_stego);

                    ProsesTitikXY(Xval, Yval, argb_cover, argb_stego, stride_cover, stride_stego);

                }
            }
            else
            {
                dlg = MessageBox.Show(Notifikasi.InputNull, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Fungsi-Fungsi
        void ProsesEmbedding()
        {
            Bitmap bmpCover = new Bitmap(pathemb1.Text);
            Bitmap bmpCoverEditPixel;
            char[] passwd_biner;
            char[] fileHide_biner;
            byte[] argbVal;

            fileHide_biner = EX.ProsesConvertFile_toBinary(System.IO.File.ReadAllBytes(pathemb2.Text));
            passwd_biner = EX.ProsesConvertPassword_toBinary(passemb.Text);
            argbVal = EX.ProsesGetARGB(bmpCover);
            bmpCoverEditPixel = EX.ProsesStego(bmpCover, argbVal, fileHide_biner, passwd_biner);

            svfile = new SaveFileDialog();
            svfile.Filter = Notifikasi.PNG;
            svfile.RestoreDirectory = true;
            if (svfile.ShowDialog() == DialogResult.OK)
            {
                EX.ProsesWriteMetadata(svfile.FileName, bmpCoverEditPixel, passwd_biner.Length, fileHide_biner.Length);
                dlg = MessageBox.Show(Notifikasi.SaveImgSuccess, Notifikasi.Title_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void ProsesExtract()
        {
            Bitmap bmp = new Bitmap(pathext.Text);
            if (EX.ProsesCheckStegoValid(bmp) == "Invalid")
            {
                dlg = MessageBox.Show(Notifikasi.Err_InputStego, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                byte[] passwd_Byte = EX.ProsesConvertPasswd_toByte(passext.Text);
                byte[] bmp_Byte = EX.ProsesGetARGB(bmp);
                if (EX.ProsesCheckStegoPasswd(bmp_Byte, passwd_Byte) == "Incorrect")
                {
                    dlg = MessageBox.Show(Notifikasi.Err_PasswdStego, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    svfile = new SaveFileDialog();
                    svfile.Filter = Notifikasi.TXT;
                    svfile.RestoreDirectory = true;
                    if (svfile.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(svfile.FileName, EX.data_rahasia);
                        dlg = MessageBox.Show(Notifikasi.SaveTxtSuccess, Notifikasi.Title_Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        void ProsesValidasi_Enkripsi()
        {

            if (int.Parse(tbox_pub_enk.Text) < 255)
            {
                dlg = MessageBox.Show(Notifikasi.Err_InputKunci_Publik, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (EL.cekPrima(tbox_pub_enk.Text) == false)
            {
                dlg = MessageBox.Show(Notifikasi.Err_InputKunci_Publik2, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (int.Parse(tbox_pri_enk.Text) < 1 | int.Parse(tbox_pri_enk.Text) >= int.Parse(tbox_pub_enk.Text) - 2)
            {
                dlg = MessageBox.Show(Notifikasi.Err_InputKunci_Privat, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ProsesTampilEnkripsi(EX.ProsesEnkripsi(msgenk.Text, int.Parse(tbox_pub_enk.Text), int.Parse(tbox_pri_enk.Text)));
            }

        }
        void ProsesValidasi_Dekripsi()
        {
            if (int.Parse(tbox_pub_dek.Text) < 255)
            {
                dlg = MessageBox.Show(Notifikasi.Err_InputKunci_Publik, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (EL.cekPrima(tbox_pub_dek.Text) == false)
            {
                dlg = MessageBox.Show(Notifikasi.Err_InputKunci_Publik2, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (int.Parse(tbox_pri_dek.Text) < 1 | int.Parse(tbox_pri_dek.Text) >= int.Parse(tbox_pub_dek.Text) - 2)
            {
                dlg = MessageBox.Show(Notifikasi.Err_InputKunci_Privat, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                hasil_dekripsi = EX.ProsesDekripsi(msgdek.Text, int.Parse(tbox_pub_dek.Text), int.Parse(tbox_pri_dek.Text));
                msghsldek.Text = hasil_dekripsi;
            }
        }
        void ProsesTampilEnkripsi(string[] enkripsi)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var x in enkripsi)
            {
                builder.Append(x);
                builder.Append(" ");
            }
            hasil_enkripsi = builder.ToString();
            msghslenk.Text = hasil_enkripsi;
        }
        void ProsesTampilDataGrid_Cover(string path, Bitmap bmp)
        {
            byte[] argb;
            argb = EX.ProsesGetARGB(bmp);
            EX.SplitArgbPixel(argb, bmp);

            bmpCoverW = bmp.Width;
            bmpCoverH = bmp.Height;

            label_sampel_cover.Text = String.Format("Sampel Data : 100 dari {0}", EX.nilai_xy.Length);
            label_dimensi_cover.Text = String.Format("Gambar Cover : ({0} X {1})", bmpCoverW, bmpCoverH);

            data_cover.Clear(); //Reset

            for (int i = 0; i < 100; i++)
            {
                data_cover.Add(new BGRA_Cover() { XY_Cover = EX.nilai_xy[i], B_Cover = EX.nilai_b[i].ToString(), G_Cover = EX.nilai_g[i].ToString(), R_Cover = EX.nilai_r[i].ToString(), A_Cover = EX.nilai_a[i].ToString() });
            }
            ResetDatagrid_Cover();
        }
        void ProsesTampilDataGrid_Stego(string path, Bitmap bmp)
        {
            byte[] argb;
            argb = EX.ProsesGetARGB(bmp);
            EX.SplitArgbPixel(argb, bmp);
            
            bmpStegoW = bmp.Width;
            bmpStegoH = bmp.Height;

            label_sampel_stego.Text = String.Format("Sampel Data : 100 dari {0}", EX.nilai_xy.Length);
            label_dimensi_stego.Text = String.Format("Gambar Cover : ({0} X {1})", bmpStegoW, bmpStegoH);

            data_stego.Clear(); //Reset

            for (int i = 0; i < 100; i++)
            {
                data_stego.Add(new BGRA_Stego() { XY_Stego = EX.nilai_xy[i], B_Stego = EX.nilai_b[i].ToString(), G_Stego = EX.nilai_g[i].ToString(), R_Stego = EX.nilai_r[i].ToString(), A_Stego = EX.nilai_a[i].ToString() });
            }
            ResetDatagrid_Stego();
        }
        void ProsesTitikXY(int PointX, int PointY, byte[] pixel_cover, byte[] pixel_stego, int stride_cover, int stride_stego)
        {
            int index_cover = (PointY - 1) * stride_cover + 4 * (PointX - 1); //-1 for array index
            byte blue_cover = pixel_cover[index_cover];
            byte green_cover = pixel_cover[index_cover + 1];
            byte red_cover = pixel_cover[index_cover + 2];
            byte alpha_cover = pixel_cover[index_cover + 3];
            data_cover.Clear();
            data_cover.Add(new BGRA_Cover() { XY_Cover = String.Format("({0},{1})", PointX.ToString(), PointY.ToString()), B_Cover = blue_cover.ToString(), G_Cover = green_cover.ToString(), R_Cover = red_cover.ToString(), A_Cover = alpha_cover.ToString() });
            ResetDatagrid_Cover();

            int index_stego = (PointY - 1) * stride_stego + 4 * (PointX - 1); //-1 for array index
            byte blue_stego = pixel_stego[index_stego];
            byte green_stego = pixel_stego[index_stego + 1];
            byte red_stego = pixel_stego[index_stego + 2];
            byte alpha_stego = pixel_stego[index_stego + 3];
            data_stego.Clear();
            data_stego.Add(new BGRA_Stego() { XY_Stego = String.Format("({0},{1})", PointX.ToString(), PointY.ToString()), B_Stego = blue_stego.ToString(), G_Stego = green_stego.ToString(), R_Stego = red_stego.ToString(), A_Stego = alpha_stego.ToString() });
            ResetDatagrid_Stego();
        }
        void ResetDatagrid_Cover()
        {
            dGV_cover.DataSource = null; //Reset

            dGV_cover.DataSource = data_cover;
            dGV_cover.Columns[0].HeaderText = "(X,Y)";
            dGV_cover.Columns[1].HeaderText = "Blue";
            dGV_cover.Columns[2].HeaderText = "Green";
            dGV_cover.Columns[3].HeaderText = "Red";
            dGV_cover.Columns[4].HeaderText = "Alpha";
        }
        void ResetDatagrid_Stego()
        {
            dGV_stego.DataSource = null; //Reset

            dGV_stego.DataSource = data_stego;
            dGV_stego.Columns[0].HeaderText = "(X,Y)";
            dGV_stego.Columns[1].HeaderText = "Blue";
            dGV_stego.Columns[2].HeaderText = "Green";
            dGV_stego.Columns[3].HeaderText = "Red";
            dGV_stego.Columns[4].HeaderText = "Alpha";
        }
        #endregion

        #region for Data Binding Pixel Lookup
        public class BGRA_Cover
        {
            public string XY_Cover { get; set; }
            public string B_Cover { get; set; }
            public string G_Cover { get; set; }
            public string R_Cover { get; set; }
            public string A_Cover { get; set; }
        }

        public class BGRA_Stego
        {
            public string XY_Stego { get; set; }
            public string B_Stego { get; set; }
            public string G_Stego { get; set; }
            public string R_Stego { get; set; }
            public string A_Stego { get; set; }
        }
        #endregion

        #region Event Handler Tbox Publik dan Privat
        private void tbox_pub_enk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void tbox_pri_enk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void tbox_pub_dek_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void tbox_pri_dek_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void tbox_X_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void tbox_Y_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

    }

}