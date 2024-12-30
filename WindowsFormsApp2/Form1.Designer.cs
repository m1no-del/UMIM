namespace WindowsFormsApp2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.searchBar = new System.Windows.Forms.FlowLayoutPanel();
            this.image = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDirection = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.location = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buildingName = new System.Windows.Forms.Label();
            this.resultContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.txSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.instruct = new Guna.UI2.WinForms.Guna2Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.directionPan = new System.Windows.Forms.Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.resultContainer2 = new System.Windows.Forms.FlowLayoutPanel();
            this.backBtn = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.resultContainer1 = new System.Windows.Forms.FlowLayoutPanel();
            this.searchTo = new Guna.UI2.WinForms.Guna2TextBox();
            this.directionBtn = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.searchFrom = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.distance = new System.Windows.Forms.Label();
            this.searchBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).BeginInit();
            this.panel1.SuspendLayout();
            this.directionPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBar
            // 
            this.searchBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.searchBar.Controls.Add(this.image);
            this.searchBar.Controls.Add(this.panel2);
            resources.ApplyResources(this.searchBar, "searchBar");
            this.searchBar.Name = "searchBar";
            // 
            // image
            // 
            resources.ApplyResources(this.image, "image");
            this.image.Name = "image";
            this.image.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.location);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.buildingName);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnDirection);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // btnDirection
            // 
            this.btnDirection.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDirection, "btnDirection");
            this.btnDirection.ImageRotate = 0F;
            this.btnDirection.Name = "btnDirection";
            this.btnDirection.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnDirection.TabStop = false;
            this.btnDirection.Click += new System.EventHandler(this.btnDirection_Click);
            // 
            // location
            // 
            this.location.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.location, "location");
            this.location.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.location.Name = "location";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // buildingName
            // 
            resources.ApplyResources(this.buildingName, "buildingName");
            this.buildingName.Name = "buildingName";
            // 
            // resultContainer
            // 
            this.resultContainer.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.resultContainer, "resultContainer");
            this.resultContainer.Name = "resultContainer";
            // 
            // txSearch
            // 
            this.txSearch.BorderColor = System.Drawing.Color.White;
            this.txSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txSearch.DefaultText = "Search for Building or Destination";
            this.txSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txSearch, "txSearch");
            this.txSearch.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txSearch.Name = "txSearch";
            this.txSearch.PasswordChar = '\0';
            this.txSearch.PlaceholderForeColor = System.Drawing.Color.White;
            this.txSearch.PlaceholderText = "";
            this.txSearch.SelectedText = "";
            this.txSearch.TextChanged += new System.EventHandler(this.txSearch_TextChanged);
            this.txSearch.Click += new System.EventHandler(this.txSearch_Click);
            this.txSearch.Enter += new System.EventHandler(this.txSearch_Enter);
            this.txSearch.Leave += new System.EventHandler(this.txSearch_Leave);
            // 
            // webView2
            // 
            this.webView2.AllowExternalDrop = true;
            this.webView2.CreationProperties = null;
            this.webView2.DefaultBackgroundColor = System.Drawing.Color.White;
            resources.ApplyResources(this.webView2, "webView2");
            this.webView2.Name = "webView2";
            this.webView2.ZoomFactor = 1D;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txSearch);
            this.panel1.Controls.Add(this.guna2Button1);
            this.panel1.Controls.Add(this.instruct);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.White;
            this.guna2Button1.CausesValidation = false;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.guna2Button1, "guna2Button1");
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageSize = new System.Drawing.Size(15, 15);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedColor = System.Drawing.Color.White;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // instruct
            // 
            this.instruct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.instruct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.instruct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.instruct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.instruct.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.instruct, "instruct");
            this.instruct.ForeColor = System.Drawing.Color.White;
            this.instruct.Image = ((System.Drawing.Image)(resources.GetObject("instruct.Image")));
            this.instruct.Name = "instruct";
            this.instruct.Click += new System.EventHandler(this.instruct_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // directionPan
            // 
            this.directionPan.BackColor = System.Drawing.Color.White;
            this.directionPan.Controls.Add(this.guna2Button2);
            this.directionPan.Controls.Add(this.resultContainer2);
            this.directionPan.Controls.Add(this.backBtn);
            this.directionPan.Controls.Add(this.pictureBox4);
            this.directionPan.Controls.Add(this.pictureBox3);
            this.directionPan.Controls.Add(this.resultContainer1);
            this.directionPan.Controls.Add(this.searchTo);
            this.directionPan.Controls.Add(this.directionBtn);
            this.directionPan.Controls.Add(this.pictureBox2);
            this.directionPan.Controls.Add(this.searchFrom);
            this.directionPan.Controls.Add(this.label3);
            this.directionPan.Controls.Add(this.label2);
            this.directionPan.Controls.Add(this.distance);
            resources.ApplyResources(this.directionPan, "directionPan");
            this.directionPan.Name = "directionPan";
            // 
            // guna2Button2
            // 
            this.guna2Button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.guna2Button2, "guna2Button2");
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.ImageSize = new System.Drawing.Size(16, 16);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // resultContainer2
            // 
            resources.ApplyResources(this.resultContainer2, "resultContainer2");
            this.resultContainer2.Name = "resultContainer2";
            // 
            // backBtn
            // 
            this.backBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.backBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.backBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.backBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.backBtn.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.backBtn, "backBtn");
            this.backBtn.ForeColor = System.Drawing.Color.Black;
            this.backBtn.Image = ((System.Drawing.Image)(resources.GetObject("backBtn.Image")));
            this.backBtn.Name = "backBtn";
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // resultContainer1
            // 
            this.resultContainer1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.resultContainer1, "resultContainer1");
            this.resultContainer1.Name = "resultContainer1";
            // 
            // searchTo
            // 
            this.searchTo.BorderColor = System.Drawing.Color.Firebrick;
            this.searchTo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchTo.DefaultText = "Choose Starting Point";
            this.searchTo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.searchTo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.searchTo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchTo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchTo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.searchTo, "searchTo");
            this.searchTo.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.searchTo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchTo.Name = "searchTo";
            this.searchTo.PasswordChar = '\0';
            this.searchTo.PlaceholderForeColor = System.Drawing.Color.White;
            this.searchTo.PlaceholderText = "";
            this.searchTo.SelectedText = "";
            this.searchTo.TextChanged += new System.EventHandler(this.searchTo_TextChanged);
            this.searchTo.Click += new System.EventHandler(this.searchTo_Click);
            this.searchTo.Enter += new System.EventHandler(this.searchTo_Enter);
            this.searchTo.Leave += new System.EventHandler(this.searchTo_Leave);
            // 
            // directionBtn
            // 
            this.directionBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.directionBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.directionBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.directionBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.directionBtn.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.directionBtn, "directionBtn");
            this.directionBtn.ForeColor = System.Drawing.Color.Black;
            this.directionBtn.Name = "directionBtn";
            this.directionBtn.Click += new System.EventHandler(this.guna2Button2_Click_1);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // searchFrom
            // 
            this.searchFrom.BorderColor = System.Drawing.Color.Firebrick;
            this.searchFrom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchFrom.DefaultText = "";
            this.searchFrom.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.searchFrom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.searchFrom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchFrom.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchFrom.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.searchFrom, "searchFrom");
            this.searchFrom.ForeColor = System.Drawing.Color.Black;
            this.searchFrom.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchFrom.Name = "searchFrom";
            this.searchFrom.PasswordChar = '\0';
            this.searchFrom.PlaceholderForeColor = System.Drawing.Color.White;
            this.searchFrom.PlaceholderText = "";
            this.searchFrom.SelectedText = "";
            this.searchFrom.TextChanged += new System.EventHandler(this.searchFrom_TextChanged);
            this.searchFrom.Click += new System.EventHandler(this.searchFrom_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // distance
            // 
            resources.ApplyResources(this.distance, "distance");
            this.distance.Name = "distance";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.directionPan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resultContainer);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.webView2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.searchBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.directionPan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        public System.Windows.Forms.FlowLayoutPanel searchBar;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label buildingName;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label location;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnDirection;
        private System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2TextBox txSearch;
        public Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        public System.Windows.Forms.PictureBox image;
        public System.Windows.Forms.FlowLayoutPanel resultContainer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel directionPan;
        public Guna.UI2.WinForms.Guna2TextBox searchFrom;
        public System.Windows.Forms.FlowLayoutPanel resultContainer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        public Guna.UI2.WinForms.Guna2Button directionBtn;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.FlowLayoutPanel resultContainer2;
        private System.Windows.Forms.Label distance;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        public Guna.UI2.WinForms.Guna2TextBox searchTo;
        private Guna.UI2.WinForms.Guna2Button instruct;
    }
}

