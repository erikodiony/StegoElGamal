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
        string getPathTeks1;
        string getPathImg1;
        string getPassExt;
        string getPathTeks2;

        string hasil_ext_confirm_null;
        string hasil_emb_confirm_null;
        string hasil_enk_confirm_null;
        string hasil_dek_confirm_null;


        string hasil_enkripsi;
        string hasil_dekripsi;

        eksek EX = new eksek();

        MessageBox mb_embed;
        OpenFileDialog opfile;
        SaveFileDialog svfile;
        DialogResult dlg;


        private void loadenk_Click(object sender, EventArgs e)
        {
            opfile = new OpenFileDialog();
            opfile.Filter = Notifikasi.TXT;
            if (opfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                getPathTeks = opfile.FileName;
                pathenk.Text = getPathTeks;
                msgenk.Text = File.ReadAllText(getPathTeks);
                //System.Diagnostics.Debug.WriteLine(getPathTeks);

            }
        }

        private void eksenk_Click(object sender, EventArgs e)
        {
            hasil_enk_confirm_null = EX.Cek_Tbox_2Kolom(msgenk.Text, String.Empty);
            if (hasil_enk_confirm_null == "Kosong")
            {
                dlg = MessageBox.Show(Notifikasi.InputNull, Notifikasi.Title_Err, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                hasil_enkripsi = EX.ProsesEnkripsi(msgenk.Text);
                msghslenk.Text = hasil_enkripsi;
            }

        }

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

        private void loadext_Click(object sender, EventArgs e)
        {
            opfile = new OpenFileDialog();
            opfile.Filter = Notifikasi.PNG;
            if (opfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                getPathImg1 = opfile.FileName;
                pathext.Text = getPathImg1;
                Bitmap bmpstego = new Bitmap(getPathImg1);
                tmplgbrext.Image = bmpstego;
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
                ProsesEmbedding();
                //ProsesConvertFiletoByte();
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

            }
        }

        private void loaddek_Click(object sender, EventArgs e)
        {
            opfile = new OpenFileDialog();
            opfile.Filter = " Teks File (CFiles Teks) |*.txt";
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
                hasil_dekripsi = EX.ProsesDekripsi(msgdek.Text);
                msghsldek.Text = hasil_dekripsi;
            }
        }

        private void savedek_Click(object sender, EventArgs e)
        {
            svfile = new SaveFileDialog();
            svfile.Filter = Notifikasi.TXT;
            svfile.RestoreDirectory = true;
            if (svfile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(svfile.FileName, msghsldek.Text);
                dlg = MessageBox.Show(Notifikasi.SaveSuccess, Notifikasi.Title_Success, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void saveenk_Click(object sender, EventArgs e)
        {
            svfile = new SaveFileDialog();
            svfile.Filter = Notifikasi.TXT;
            svfile.RestoreDirectory = true;
            if (svfile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(svfile.FileName, msghslenk.Text);
                dlg = MessageBox.Show(Notifikasi.SaveSuccess, Notifikasi.Title_Success, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        void ProsesEmbedding()
        {
            Bitmap BmpCover = new Bitmap(pathemb1.Text);
            Bitmap BmpCoverEdit = EX.ProsesStego(BmpCover, EX.ProsesConvertFiletoByte(System.IO.File.ReadAllBytes(pathemb2.Text)));

            svfile = new SaveFileDialog();
            svfile.Filter = Notifikasi.PNG;
            svfile.RestoreDirectory = true;
            if (svfile.ShowDialog() == DialogResult.OK)
            {
                BmpCoverEdit.Save(svfile.FileName);
                dlg = MessageBox.Show(Notifikasi.SaveImgSuccess, Notifikasi.Title_Success, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }        


        void ProsesExtract()
        {
            Bitmap BmpExtract = new Bitmap(pathext.Text);



        }


    }

}