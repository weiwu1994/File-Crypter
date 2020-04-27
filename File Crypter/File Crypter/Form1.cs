using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Crypter
{
    public partial class Form1 : Form
    {

        private string _encryptSource;
        private string _encryptDestination;
        private string _decryptSource;
        private string _decryptDestination;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.encryptSource;
            textBox2.Text = Properties.Settings.Default.encryptDestination;
            textBox3.Text = Properties.Settings.Default.decryptSource;
            textBox4.Text = Properties.Settings.Default.decryptDestination;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Encrypt Button
            Encrypter.EncryptFolder(_encryptSource, _encryptDestination);
            label3.Text = "Completed Encryption";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Decrpyt Button
            Decrypter.DecrpytFolder(_decryptSource, _decryptDestination);
            label3.Text =  "Completed Decryption";
        }


        public string ChooseFolder()
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog1.SelectedPath;
            }
            else {
                return "Not Valid";
            }
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            _encryptSource = ChooseFolder();
            textBox1.Text = _encryptSource;
            Properties.Settings.Default.encryptSource = _encryptSource;
            Properties.Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _encryptDestination = ChooseFolder();
            textBox2.Text = _encryptDestination;
            Properties.Settings.Default.encryptDestination = _encryptDestination;
            Properties.Settings.Default.Save();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _encryptSource = textBox1.Text;
            Properties.Settings.Default.encryptSource = _encryptSource;
            Properties.Settings.Default.Save();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _encryptDestination = textBox2.Text;
            Properties.Settings.Default.encryptDestination = _encryptDestination;
            Properties.Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _decryptSource = ChooseFolder();
            textBox3.Text = _decryptSource;
            Properties.Settings.Default.decryptSource = _decryptSource;
            Properties.Settings.Default.Save();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            _decryptDestination = ChooseFolder();
            textBox4.Text = _decryptDestination;
            Properties.Settings.Default.decryptDestination = _decryptDestination;
            Properties.Settings.Default.Save();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            _decryptSource = textBox3.Text;
            Properties.Settings.Default.decryptSource = _decryptSource;
            Properties.Settings.Default.Save();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            _decryptDestination = textBox4.Text;
            Properties.Settings.Default.decryptDestination = _decryptDestination;
            Properties.Settings.Default.Save();
        }


    }
}
