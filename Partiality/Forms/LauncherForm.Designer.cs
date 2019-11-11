namespace PartialityLauncher
{
	partial class LauncherForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pb_game_header = new System.Windows.Forms.PictureBox();
			this.l_game_name = new System.Windows.Forms.Label();
			this.tb_appid = new System.Windows.Forms.TextBox();
			this.tp_appid_hint = new System.Windows.Forms.ToolTip(this.components);
			this.btn_refresh = new System.Windows.Forms.Button();
			this.btn_clear_metadata = new System.Windows.Forms.Button();
			this.btn_uninstall = new System.Windows.Forms.Button();
			this.btn_apply_mods = new System.Windows.Forms.Button();
			this.modList = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btn_open_game_folder = new System.Windows.Forms.Button();
			this.btn_run_game = new System.Windows.Forms.Button();
			this.Type = new System.Windows.Forms.DataGridViewImageColumn();
			this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ModName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.pb_game_header)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.modList)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pb_game_header
			// 
			this.pb_game_header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pb_game_header.Image = global::PartialityLauncher.Properties.Resources.header;
			this.pb_game_header.Location = new System.Drawing.Point(12, 78);
			this.pb_game_header.Name = "pb_game_header";
			this.pb_game_header.Size = new System.Drawing.Size(347, 161);
			this.pb_game_header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pb_game_header.TabIndex = 0;
			this.pb_game_header.TabStop = false;
			// 
			// l_game_name
			// 
			this.l_game_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.l_game_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.l_game_name.Location = new System.Drawing.Point(7, 24);
			this.l_game_name.Name = "l_game_name";
			this.l_game_name.Size = new System.Drawing.Size(352, 25);
			this.l_game_name.TabIndex = 1;
			this.l_game_name.Text = "GameName";
			// 
			// tb_appid
			// 
			this.tb_appid.Location = new System.Drawing.Point(12, 52);
			this.tb_appid.Name = "tb_appid";
			this.tb_appid.ReadOnly = true;
			this.tb_appid.Size = new System.Drawing.Size(100, 20);
			this.tb_appid.TabIndex = 2;
			this.tp_appid_hint.SetToolTip(this.tb_appid, "Steam AppID");
			// 
			// btn_refresh
			// 
			this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_refresh.Location = new System.Drawing.Point(12, 245);
			this.btn_refresh.Name = "btn_refresh";
			this.btn_refresh.Size = new System.Drawing.Size(142, 23);
			this.btn_refresh.TabIndex = 3;
			this.btn_refresh.Text = "Save && Reload Mod List";
			this.btn_refresh.UseVisualStyleBackColor = true;
			this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
			// 
			// btn_clear_metadata
			// 
			this.btn_clear_metadata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_clear_metadata.Location = new System.Drawing.Point(160, 245);
			this.btn_clear_metadata.Name = "btn_clear_metadata";
			this.btn_clear_metadata.Size = new System.Drawing.Size(92, 23);
			this.btn_clear_metadata.TabIndex = 4;
			this.btn_clear_metadata.Text = "Clear Metadata";
			this.btn_clear_metadata.UseVisualStyleBackColor = true;
			this.btn_clear_metadata.Click += new System.EventHandler(this.btn_clear_metadata_Click);
			// 
			// btn_uninstall
			// 
			this.btn_uninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_uninstall.Location = new System.Drawing.Point(258, 245);
			this.btn_uninstall.Name = "btn_uninstall";
			this.btn_uninstall.Size = new System.Drawing.Size(101, 23);
			this.btn_uninstall.TabIndex = 5;
			this.btn_uninstall.Text = "Uninstall Partiality";
			this.btn_uninstall.UseVisualStyleBackColor = true;
			this.btn_uninstall.Click += new System.EventHandler(this.btn_uninstall_Click);
			// 
			// btn_apply_mods
			// 
			this.btn_apply_mods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_apply_mods.Location = new System.Drawing.Point(12, 602);
			this.btn_apply_mods.Name = "btn_apply_mods";
			this.btn_apply_mods.Size = new System.Drawing.Size(264, 23);
			this.btn_apply_mods.TabIndex = 6;
			this.btn_apply_mods.Text = "Apply Mods && Patches";
			this.btn_apply_mods.UseVisualStyleBackColor = true;
			this.btn_apply_mods.Click += new System.EventHandler(this.btn_apply_mods_Click);
			// 
			// modList
			// 
			this.modList.AllowUserToAddRows = false;
			this.modList.AllowUserToDeleteRows = false;
			this.modList.AllowUserToResizeRows = false;
			this.modList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.modList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.modList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.modList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Active,
            this.ModName});
			this.modList.Location = new System.Drawing.Point(12, 274);
			this.modList.MultiSelect = false;
			this.modList.Name = "modList";
			this.modList.RowHeadersVisible = false;
			this.modList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.modList.Size = new System.Drawing.Size(347, 322);
			this.modList.TabIndex = 8;
			this.modList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.modList_CellContentClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(371, 24);
			this.menuStrip1.TabIndex = 9;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGameToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openGameToolStripMenuItem
			// 
			this.openGameToolStripMenuItem.Name = "openGameToolStripMenuItem";
			this.openGameToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.openGameToolStripMenuItem.Text = "Open Game";
			this.openGameToolStripMenuItem.Click += new System.EventHandler(this.openGameToolStripMenuItem_Click);
			// 
			// preferencesToolStripMenuItem
			// 
			this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
			this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.preferencesToolStripMenuItem.Text = "Preferences...";
			this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.aboutToolStripMenuItem.Text = "About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// btn_open_game_folder
			// 
			this.btn_open_game_folder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_open_game_folder.Location = new System.Drawing.Point(249, 49);
			this.btn_open_game_folder.Name = "btn_open_game_folder";
			this.btn_open_game_folder.Size = new System.Drawing.Size(110, 23);
			this.btn_open_game_folder.TabIndex = 10;
			this.btn_open_game_folder.Text = "Open Game Folder";
			this.btn_open_game_folder.UseVisualStyleBackColor = true;
			this.btn_open_game_folder.Click += new System.EventHandler(this.btn_open_game_folder_Click);
			// 
			// btn_run_game
			// 
			this.btn_run_game.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_run_game.Location = new System.Drawing.Point(282, 602);
			this.btn_run_game.Name = "btn_run_game";
			this.btn_run_game.Size = new System.Drawing.Size(77, 23);
			this.btn_run_game.TabIndex = 11;
			this.btn_run_game.Text = "Run Game";
			this.btn_run_game.UseVisualStyleBackColor = true;
			this.btn_run_game.Click += new System.EventHandler(this.btn_run_game_Click);
			// 
			// Type
			// 
			this.Type.FillWeight = 0.1F;
			this.Type.HeaderText = "Type";
			this.Type.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.Type.Name = "Type";
			this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Type.Width = 38;
			// 
			// Active
			// 
			this.Active.FillWeight = 0.1F;
			this.Active.HeaderText = "Is Active";
			this.Active.Name = "Active";
			this.Active.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Active.Width = 54;
			// 
			// ModName
			// 
			this.ModName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ModName.HeaderText = "Mod Name";
			this.ModName.Name = "ModName";
			this.ModName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// LauncherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(371, 637);
			this.Controls.Add(this.btn_run_game);
			this.Controls.Add(this.btn_open_game_folder);
			this.Controls.Add(this.modList);
			this.Controls.Add(this.btn_apply_mods);
			this.Controls.Add(this.btn_uninstall);
			this.Controls.Add(this.btn_clear_metadata);
			this.Controls.Add(this.btn_refresh);
			this.Controls.Add(this.tb_appid);
			this.Controls.Add(this.l_game_name);
			this.Controls.Add(this.pb_game_header);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximumSize = new System.Drawing.Size(387, 1000000);
			this.MinimumSize = new System.Drawing.Size(387, 470);
			this.Name = "LauncherForm";
			this.Text = "Partiality Launcher";
			((System.ComponentModel.ISupportInitialize)(this.pb_game_header)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.modList)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pb_game_header;
		private System.Windows.Forms.ToolTip tp_appid_hint;
		private System.Windows.Forms.DataGridView modList;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openGameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btn_apply_mods;
		private System.Windows.Forms.Button btn_refresh;
		private System.Windows.Forms.Button btn_clear_metadata;
		private System.Windows.Forms.Button btn_uninstall;
		private System.Windows.Forms.TextBox tb_appid;
		private System.Windows.Forms.Label l_game_name;
		private System.Windows.Forms.Button btn_open_game_folder;
		private System.Windows.Forms.Button btn_run_game;
		private System.Windows.Forms.DataGridViewImageColumn Type;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
		private System.Windows.Forms.DataGridViewTextBoxColumn ModName;
	}
}