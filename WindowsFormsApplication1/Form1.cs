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
                getPathTeks = opfile.FileName;
                pathenk.Text = getPathTeks;
                msgenk.Text = File.ReadAllText(getPathTeks);
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
                getPathTeks2 = opfile.FileName;
                pathdek.Text = getPathTeks2;
                msgdek.Text = File.ReadAllText(getPathTeks2);
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

        #endregion

        #region Event Handler Tbox
        private void tbox_pub_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void tbox_priv_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        #endregion


    }

}