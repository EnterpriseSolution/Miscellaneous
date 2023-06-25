namespace SD.LLBLGen.Pro.DebugVisualizers
{
	partial class RelationCollectionVisualizerForm
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
			this._relationCollectionVisualizerControl = new SD.LLBLGen.Pro.DebugVisualizers.StringParametersVisualizerControl();
			this.SuspendLayout();
			// 
			// _relationCollectionVisualizerControl
			// 
			this._relationCollectionVisualizerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._relationCollectionVisualizerControl.Location = new System.Drawing.Point( 0, 0 );
			this._relationCollectionVisualizerControl.Name = "_relationCollectionVisualizerControl";
			this._relationCollectionVisualizerControl.Size = new System.Drawing.Size( 672, 549 );
			this._relationCollectionVisualizerControl.TabIndex = 0;
			// 
			// RelationCollectionVisualizerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 672, 549 );
			this.Controls.Add( this._relationCollectionVisualizerControl );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "RelationCollectionVisualizerForm";
			this.Text = "RelationCollection Visualizer";
			this.ResumeLayout( false );

		}

		#endregion

		private StringParametersVisualizerControl _relationCollectionVisualizerControl;
	}
}