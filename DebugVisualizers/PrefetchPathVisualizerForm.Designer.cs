namespace SD.LLBLGen.Pro.DebugVisualizers
{
	partial class PrefetchPathVisualizerForm
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
			this._pathTreeView = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// _pathTreeView
			// 
			this._pathTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._pathTreeView.Location = new System.Drawing.Point( 5, 7 );
			this._pathTreeView.Name = "_pathTreeView";
			this._pathTreeView.Size = new System.Drawing.Size( 516, 332 );
			this._pathTreeView.TabIndex = 0;
			// 
			// PrefetchPathVisualizerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 526, 343 );
			this.Controls.Add( this._pathTreeView );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "PrefetchPathVisualizerForm";
			this.Text = "PrefetchPath Visualizer";
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.TreeView _pathTreeView;
	}
}