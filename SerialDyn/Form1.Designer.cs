namespace SerialDyn
	{
	partial class Form1
		{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
			{
			if (disposing && (components != null))
				{
				components.Dispose();
				}
			base.Dispose(disposing);
			}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
			{
			this.btOpen = new System.Windows.Forms.Button();
			this.btSave = new System.Windows.Forms.Button();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btImposta = new System.Windows.Forms.Button();
			this.tbContenuto = new System.Windows.Forms.TextBox();
			this.btNew = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btOpen
			// 
			this.btOpen.Location = new System.Drawing.Point(112, 61);
			this.btOpen.Name = "btOpen";
			this.btOpen.Size = new System.Drawing.Size(84, 43);
			this.btOpen.TabIndex = 0;
			this.btOpen.Text = "Open";
			this.btOpen.UseVisualStyleBackColor = true;
			this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
			// 
			// btSave
			// 
			this.btSave.Location = new System.Drawing.Point(207, 61);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(84, 43);
			this.btSave.TabIndex = 1;
			this.btSave.Text = "Save";
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// ofd
			// 
			this.ofd.FileName = "openFileDialog1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 177);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "Descrizione";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(19, 195);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(264, 23);
			this.textBox1.TabIndex = 3;
			// 
			// btImposta
			// 
			this.btImposta.Location = new System.Drawing.Point(19, 224);
			this.btImposta.Name = "btImposta";
			this.btImposta.Size = new System.Drawing.Size(116, 53);
			this.btImposta.TabIndex = 4;
			this.btImposta.Text = "Imposta";
			this.btImposta.UseVisualStyleBackColor = true;
			this.btImposta.Click += new System.EventHandler(this.btImposta_Click);
			// 
			// tbContenuto
			// 
			this.tbContenuto.Location = new System.Drawing.Point(322, 58);
			this.tbContenuto.Multiline = true;
			this.tbContenuto.Name = "tbContenuto";
			this.tbContenuto.ReadOnly = true;
			this.tbContenuto.Size = new System.Drawing.Size(392, 249);
			this.tbContenuto.TabIndex = 5;
			// 
			// btNew
			// 
			this.btNew.Location = new System.Drawing.Point(17, 61);
			this.btNew.Name = "btNew";
			this.btNew.Size = new System.Drawing.Size(84, 43);
			this.btNew.TabIndex = 6;
			this.btNew.Text = "New";
			this.btNew.UseVisualStyleBackColor = true;
			this.btNew.Click += new System.EventHandler(this.btNew_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(733, 325);
			this.Controls.Add(this.btNew);
			this.Controls.Add(this.tbContenuto);
			this.Controls.Add(this.btImposta);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSave);
			this.Controls.Add(this.btOpen);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

			}

        #endregion

        private Button btOpen;
        private Button btSave;
        private SaveFileDialog sfd;
        private OpenFileDialog ofd;
        private Label label1;
        private TextBox textBox1;
		private Button btImposta;
        private TextBox tbContenuto;
        private Button btNew;
        }
	}