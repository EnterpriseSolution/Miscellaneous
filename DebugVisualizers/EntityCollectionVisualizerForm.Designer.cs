namespace SD.LLBLGen.Pro.DebugVisualizers
{
	partial class EntityCollectionVisualizerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this._entityTypeTextBox = new System.Windows.Forms.TextBox();
			this._contentsGrid = new System.Windows.Forms.DataGrid();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._contentsGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this._contentsGrid);
			this.groupBox1.Location = new System.Drawing.Point(2, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(565, 371);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Contents";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 382);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Defined for entity type";
			// 
			// _entityTypeTextBox
			// 
			this._entityTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._entityTypeTextBox.Location = new System.Drawing.Point(134, 379);
			this._entityTypeTextBox.Name = "_entityTypeTextBox";
			this._entityTypeTextBox.ReadOnly = true;
			this._entityTypeTextBox.Size = new System.Drawing.Size(427, 20);
			this._entityTypeTextBox.TabIndex = 2;
			// 
			// _contentsGrid
			// 
			this._contentsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._contentsGrid.DataMember = "";
			this._contentsGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this._contentsGrid.Location = new System.Drawing.Point(6, 19);
			this._contentsGrid.Name = "_contentsGrid";
			this._contentsGrid.Size = new System.Drawing.Size(553, 346);
			this._contentsGrid.TabIndex = 0;
			// 
			// EntityCollectionVisualizerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 404);
			this.Controls.Add(this._entityTypeTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "EntityCollectionVisualizerForm";
			this.Text = "Entity collection Visualizer";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._contentsGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _entityTypeTextBox;
		private System.Windows.Forms.DataGrid _contentsGrid;
	}
}