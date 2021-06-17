namespace ADFSProxyCertRenew.config
{
    partial class frm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.List_Certificates = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Btn_add_Certificate = new System.Windows.Forms.ToolStripButton();
            this.btn_remove_Certificate = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.Btn_bindToCertificate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.List_adfsbinding = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_actualExiresOn = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Lbl_ActualThumbprint = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Cb_AutoRenew = new System.Windows.Forms.CheckBox();
            this.Cb_BindToAdfsProxySSL = new System.Windows.Forms.CheckBox();
            this.Txt_title = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Txt_surname = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_State = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Txt_organizationUinit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Txt_Organization = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Txt_locality = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Txt_initals = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Txt_givenName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_eMail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Txt_description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_country = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_PFXPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_commonName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Txt_adminmail = new System.Windows.Forms.TextBox();
            this.List_ACMEServer = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Txt_workingDir = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.List_Certificates);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 526);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Certificate";
            // 
            // List_Certificates
            // 
            this.List_Certificates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.List_Certificates.FormattingEnabled = true;
            this.List_Certificates.Location = new System.Drawing.Point(6, 44);
            this.List_Certificates.Name = "List_Certificates";
            this.List_Certificates.Size = new System.Drawing.Size(175, 472);
            this.List_Certificates.TabIndex = 1;
            this.List_Certificates.SelectedIndexChanged += new System.EventHandler(this.List_Certificates_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_add_Certificate,
            this.btn_remove_Certificate});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(181, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Btn_add_Certificate
            // 
            this.Btn_add_Certificate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Btn_add_Certificate.Image = ((System.Drawing.Image)(resources.GetObject("Btn_add_Certificate.Image")));
            this.Btn_add_Certificate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_add_Certificate.Name = "Btn_add_Certificate";
            this.Btn_add_Certificate.Size = new System.Drawing.Size(23, 22);
            this.Btn_add_Certificate.Text = "toolStripButton1";
            this.Btn_add_Certificate.Click += new System.EventHandler(this.Btn_add_Certificate_Click);
            // 
            // btn_remove_Certificate
            // 
            this.btn_remove_Certificate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_remove_Certificate.Image = ((System.Drawing.Image)(resources.GetObject("btn_remove_Certificate.Image")));
            this.btn_remove_Certificate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_remove_Certificate.Name = "btn_remove_Certificate";
            this.btn_remove_Certificate.Size = new System.Drawing.Size(23, 22);
            this.btn_remove_Certificate.Text = "toolStripButton2";
            this.btn_remove_Certificate.Click += new System.EventHandler(this.btn_remove_Certificate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Controls.Add(this.List_adfsbinding);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(582, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 526);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADFS Binding";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_bindToCertificate,
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(568, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // Btn_bindToCertificate
            // 
            this.Btn_bindToCertificate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Btn_bindToCertificate.Image = ((System.Drawing.Image)(resources.GetObject("Btn_bindToCertificate.Image")));
            this.Btn_bindToCertificate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_bindToCertificate.Name = "Btn_bindToCertificate";
            this.Btn_bindToCertificate.Size = new System.Drawing.Size(23, 22);
            this.Btn_bindToCertificate.Text = "Add";
            this.Btn_bindToCertificate.Click += new System.EventHandler(this.Btn_bindToCertificate_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Remove";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // List_adfsbinding
            // 
            this.List_adfsbinding.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.List_adfsbinding.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.List_adfsbinding.FullRowSelect = true;
            this.List_adfsbinding.GridLines = true;
            this.List_adfsbinding.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.List_adfsbinding.HideSelection = false;
            this.List_adfsbinding.Location = new System.Drawing.Point(6, 44);
            this.List_adfsbinding.Name = "List_adfsbinding";
            this.List_adfsbinding.Size = new System.Drawing.Size(562, 476);
            this.List_adfsbinding.TabIndex = 0;
            this.List_adfsbinding.UseCompatibleStateImageBehavior = false;
            this.List_adfsbinding.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ExternalUrl";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ExternalCertificate";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(1081, 544);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_actualExiresOn);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.Lbl_ActualThumbprint);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.Cb_AutoRenew);
            this.groupBox3.Controls.Add(this.Cb_BindToAdfsProxySSL);
            this.groupBox3.Controls.Add(this.Txt_title);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.Txt_surname);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txt_State);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.Txt_organizationUinit);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.Txt_Organization);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.Txt_locality);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.Txt_initals);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.Txt_givenName);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.Txt_eMail);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.Txt_description);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.Txt_country);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.Txt_PFXPwd);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.Txt_commonName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(205, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 526);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CertificateOptions";
            // 
            // lbl_actualExiresOn
            // 
            this.lbl_actualExiresOn.AutoSize = true;
            this.lbl_actualExiresOn.Location = new System.Drawing.Point(149, 438);
            this.lbl_actualExiresOn.Name = "lbl_actualExiresOn";
            this.lbl_actualExiresOn.Size = new System.Drawing.Size(41, 13);
            this.lbl_actualExiresOn.TabIndex = 4;
            this.lbl_actualExiresOn.Text = "label15";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 438);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "ExpiresOn";
            // 
            // Lbl_ActualThumbprint
            // 
            this.Lbl_ActualThumbprint.AutoSize = true;
            this.Lbl_ActualThumbprint.Location = new System.Drawing.Point(149, 414);
            this.Lbl_ActualThumbprint.Name = "Lbl_ActualThumbprint";
            this.Lbl_ActualThumbprint.Size = new System.Drawing.Size(41, 13);
            this.Lbl_ActualThumbprint.TabIndex = 4;
            this.Lbl_ActualThumbprint.Text = "label15";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 414);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "ActualCertificateThumbprint";
            // 
            // Cb_AutoRenew
            // 
            this.Cb_AutoRenew.AutoSize = true;
            this.Cb_AutoRenew.Location = new System.Drawing.Point(9, 475);
            this.Cb_AutoRenew.Name = "Cb_AutoRenew";
            this.Cb_AutoRenew.Size = new System.Drawing.Size(82, 17);
            this.Cb_AutoRenew.TabIndex = 2;
            this.Cb_AutoRenew.Text = "AutoRenew";
            this.Cb_AutoRenew.UseVisualStyleBackColor = true;
            this.Cb_AutoRenew.CheckedChanged += new System.EventHandler(this.Cb_AutoRenew_CheckedChanged);
            // 
            // Cb_BindToAdfsProxySSL
            // 
            this.Cb_BindToAdfsProxySSL.AutoSize = true;
            this.Cb_BindToAdfsProxySSL.Location = new System.Drawing.Point(9, 375);
            this.Cb_BindToAdfsProxySSL.Name = "Cb_BindToAdfsProxySSL";
            this.Cb_BindToAdfsProxySSL.Size = new System.Drawing.Size(222, 17);
            this.Cb_BindToAdfsProxySSL.TabIndex = 2;
            this.Cb_BindToAdfsProxySSL.Text = "BindToWebApplicationProxySslCertificate";
            this.Cb_BindToAdfsProxySSL.UseVisualStyleBackColor = true;
            this.Cb_BindToAdfsProxySSL.CheckedChanged += new System.EventHandler(this.Cb_BindToAdfsProxySSL_CheckedChanged);
            // 
            // Txt_title
            // 
            this.Txt_title.Location = new System.Drawing.Point(96, 328);
            this.Txt_title.Name = "Txt_title";
            this.Txt_title.Size = new System.Drawing.Size(269, 20);
            this.Txt_title.TabIndex = 1;
            this.Txt_title.TextChanged += new System.EventHandler(this.Txt_title_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 331);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Title ";
            // 
            // Txt_surname
            // 
            this.Txt_surname.Location = new System.Drawing.Point(96, 302);
            this.Txt_surname.Name = "Txt_surname";
            this.Txt_surname.Size = new System.Drawing.Size(269, 20);
            this.Txt_surname.TabIndex = 1;
            this.Txt_surname.TextChanged += new System.EventHandler(this.Txt_surname_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 305);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Surname ";
            // 
            // txt_State
            // 
            this.txt_State.Location = new System.Drawing.Point(96, 276);
            this.txt_State.Name = "txt_State";
            this.txt_State.Size = new System.Drawing.Size(269, 20);
            this.txt_State.TabIndex = 1;
            this.txt_State.TextChanged += new System.EventHandler(this.txt_State_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 279);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "StateOrProvince ";
            // 
            // Txt_organizationUinit
            // 
            this.Txt_organizationUinit.Location = new System.Drawing.Point(96, 250);
            this.Txt_organizationUinit.Name = "Txt_organizationUinit";
            this.Txt_organizationUinit.Size = new System.Drawing.Size(269, 20);
            this.Txt_organizationUinit.TabIndex = 1;
            this.Txt_organizationUinit.TextChanged += new System.EventHandler(this.Txt_organizationUinit_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "OrganizationUnit ";
            // 
            // Txt_Organization
            // 
            this.Txt_Organization.Location = new System.Drawing.Point(96, 224);
            this.Txt_Organization.Name = "Txt_Organization";
            this.Txt_Organization.Size = new System.Drawing.Size(269, 20);
            this.Txt_Organization.TabIndex = 1;
            this.Txt_Organization.TextChanged += new System.EventHandler(this.Txt_Organization_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Organization ";
            // 
            // Txt_locality
            // 
            this.Txt_locality.Location = new System.Drawing.Point(96, 198);
            this.Txt_locality.Name = "Txt_locality";
            this.Txt_locality.Size = new System.Drawing.Size(269, 20);
            this.Txt_locality.TabIndex = 1;
            this.Txt_locality.TextChanged += new System.EventHandler(this.Txt_locality_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Locality ";
            // 
            // Txt_initals
            // 
            this.Txt_initals.Location = new System.Drawing.Point(96, 172);
            this.Txt_initals.Name = "Txt_initals";
            this.Txt_initals.Size = new System.Drawing.Size(269, 20);
            this.Txt_initals.TabIndex = 1;
            this.Txt_initals.TextChanged += new System.EventHandler(this.Txt_initals_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Initials ";
            // 
            // Txt_givenName
            // 
            this.Txt_givenName.Location = new System.Drawing.Point(96, 146);
            this.Txt_givenName.Name = "Txt_givenName";
            this.Txt_givenName.Size = new System.Drawing.Size(269, 20);
            this.Txt_givenName.TabIndex = 1;
            this.Txt_givenName.TextChanged += new System.EventHandler(this.Txt_givenName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "GivenName ";
            // 
            // Txt_eMail
            // 
            this.Txt_eMail.Location = new System.Drawing.Point(96, 120);
            this.Txt_eMail.Name = "Txt_eMail";
            this.Txt_eMail.Size = new System.Drawing.Size(269, 20);
            this.Txt_eMail.TabIndex = 1;
            this.Txt_eMail.TextChanged += new System.EventHandler(this.Txt_eMail_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email ";
            // 
            // Txt_description
            // 
            this.Txt_description.Location = new System.Drawing.Point(96, 94);
            this.Txt_description.Name = "Txt_description";
            this.Txt_description.Size = new System.Drawing.Size(269, 20);
            this.Txt_description.TabIndex = 1;
            this.Txt_description.TextChanged += new System.EventHandler(this.Txt_description_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Description ";
            // 
            // Txt_country
            // 
            this.Txt_country.Location = new System.Drawing.Point(96, 68);
            this.Txt_country.Name = "Txt_country";
            this.Txt_country.Size = new System.Drawing.Size(269, 20);
            this.Txt_country.TabIndex = 1;
            this.Txt_country.TextChanged += new System.EventHandler(this.Txt_country_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Country ";
            // 
            // Txt_PFXPwd
            // 
            this.Txt_PFXPwd.Location = new System.Drawing.Point(96, 42);
            this.Txt_PFXPwd.Name = "Txt_PFXPwd";
            this.Txt_PFXPwd.Size = new System.Drawing.Size(269, 20);
            this.Txt_PFXPwd.TabIndex = 1;
            this.Txt_PFXPwd.TextChanged += new System.EventHandler(this.Txt_PFXPwd_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "PFXPassword ";
            // 
            // Txt_commonName
            // 
            this.Txt_commonName.Location = new System.Drawing.Point(96, 16);
            this.Txt_commonName.Name = "Txt_commonName";
            this.Txt_commonName.Size = new System.Drawing.Size(269, 20);
            this.Txt_commonName.TabIndex = 1;
            this.Txt_commonName.TextChanged += new System.EventHandler(this.Txt_commonName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CommonName ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(330, 547);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Admin EMail";
            // 
            // Txt_adminmail
            // 
            this.Txt_adminmail.Location = new System.Drawing.Point(405, 545);
            this.Txt_adminmail.Name = "Txt_adminmail";
            this.Txt_adminmail.Size = new System.Drawing.Size(223, 20);
            this.Txt_adminmail.TabIndex = 4;
            this.Txt_adminmail.TextChanged += new System.EventHandler(this.txt_adminmail_TextChanged);
            // 
            // List_ACMEServer
            // 
            this.List_ACMEServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.List_ACMEServer.FormattingEnabled = true;
            this.List_ACMEServer.Items.AddRange(new object[] {
            "https://acme-staging.api.letsencrypt.org/",
            "https://acme-v01.api.letsencrypt.org/",
            "https://acme-staging-v02.api.letsencrypt.org/",
            "https://acme-v02.api.letsencrypt.org/"});
            this.List_ACMEServer.Location = new System.Drawing.Point(749, 544);
            this.List_ACMEServer.Name = "List_ACMEServer";
            this.List_ACMEServer.Size = new System.Drawing.Size(255, 21);
            this.List_ACMEServer.TabIndex = 5;
            this.List_ACMEServer.SelectedIndexChanged += new System.EventHandler(this.List_ACMEServer_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(653, 547);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "ACMEServerURL";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(15, 547);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "WorkingDir";
            // 
            // Txt_workingDir
            // 
            this.Txt_workingDir.Location = new System.Drawing.Point(90, 545);
            this.Txt_workingDir.Name = "Txt_workingDir";
            this.Txt_workingDir.Size = new System.Drawing.Size(223, 20);
            this.Txt_workingDir.TabIndex = 4;
            this.Txt_workingDir.TextChanged += new System.EventHandler(this.Txt_workingDir_TextChanged);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 575);
            this.Controls.Add(this.List_ACMEServer);
            this.Controls.Add(this.Txt_workingDir);
            this.Controls.Add(this.Txt_adminmail);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_main";
            this.Text = "frm_main";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView List_adfsbinding;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListBox List_Certificates;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Btn_add_Certificate;
        private System.Windows.Forms.ToolStripButton btn_remove_Certificate;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton Btn_bindToCertificate;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Txt_commonName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_title;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Txt_surname;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_State;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Txt_organizationUinit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Txt_Organization;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Txt_locality;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Txt_initals;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Txt_givenName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txt_eMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txt_description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_country;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_PFXPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_actualExiresOn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label Lbl_ActualThumbprint;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox Cb_AutoRenew;
        private System.Windows.Forms.CheckBox Cb_BindToAdfsProxySSL;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Txt_adminmail;
        private System.Windows.Forms.ComboBox List_ACMEServer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox Txt_workingDir;
    }
}