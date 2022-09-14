using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace SerialDyn
	{
	public partial class Form1 : Form
		{

		Doc? _doc;

		public Form1()
			{
			InitializeComponent();
			_doc = null;
			}

		private void Form1_Load(object sender, EventArgs e)
			{
			_doc = new Doc();
			}
	

        private void btSave_Click(object sender, EventArgs e)
            {
			bool ok = false;
			Stream stream;
			sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			sfd.FilterIndex = 1;
			sfd.RestoreDirectory = true;
			sfd.FileName = _doc.Filename;
			if(sfd.ShowDialog() == DialogResult.OK)
				{
				if((stream = sfd.OpenFile()) != null)
					{
					ok = _doc.Save(stream,sfd.FileName);
					stream.Close();
					}
				}
			if(!ok)
				{
				MessageBox.Show($"Errore nel salvataggio del file: {sfd.FileName} !");
				}
            }

		private void btOpen_Click(object sender, EventArgs e)
			{
			bool ok = false;
			Stream stream;
			ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			ofd.FilterIndex = 1;
			ofd.RestoreDirectory = true;
			if(ofd.ShowDialog() == DialogResult.OK)
				{
				ChiudiDoc();
				NuovoDoc();
				if((stream = ofd.OpenFile()) != null)
					{
					ok = _doc.Open(stream,ofd.FileName);     // Apre normalmente
					stream.Close();
					}
				}
			if(!ok)
				{
				MessageBox.Show($"Errore nel caricamento del file: {ofd.FileName} !");
				ChiudiDoc();
				}
			else
				{
				Aggiorna();
				}
			}

		private void ChiudiDoc()
			{
			if(_doc != null)
				{
				_doc.Chiudi();
				}
			}

		private void NuovoDoc()
			{
			ChiudiDoc();
			_doc = new Doc();
			Aggiorna();
			}

		private void Aggiorna()
			{
			if(_doc != null)
				{
				textBox1.Text = _doc.Dati.Descrizione;
				tbContenuto.Text = _doc.Dati.ToString();
				}
			}

		private void btImposta_Click(object sender, EventArgs e)
			{
			if(_doc.Descrizione != textBox1.Text)
				{
				_doc.Descrizione = textBox1.Text;
				}
			}

		private void btNew_Click(object sender, EventArgs e)
			{
			NuovoDoc();
			Aggiorna();
			}
		}
	}