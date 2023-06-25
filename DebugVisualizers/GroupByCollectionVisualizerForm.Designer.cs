namespace SD.LLBLGen.Pro.DebugVisualizers
{
	partial class GroupByCollectionVisualizerForm
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
			this._groupByVisualizerControl = new SD.LLBLGen.Pro.DebugVisualizers.StringParametersVisualizerControl();
			this.SuspendLayout();
			// 
			// _groupByVisualizerControl
			// 
			this._groupByVisualizerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._groupByVisualizerControl.Location = new System.Drawing.Point( 0, 0 );
			this._groupByVisualizerControl.Name = "_groupByVisualizerControl";
			this._groupByVisualizerControl.Size = new System.Drawing.Size( 554, 466 );
			this._groupByVisualizerControl.TabIndex = 0;
			// 
			// GroupByCollectionVisualizerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 554, 466 );
			this.Controls.Add( this._groupByVisualizerControl );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "GroupByCollectionVisualizerForm";
			this.Text = "GroupByCollection Visualizer";
			this.ResumeLayout( false );

		}

		#endregion

		private StringParametersVisualizerControl _groupByVisualizerControl;
	}
}