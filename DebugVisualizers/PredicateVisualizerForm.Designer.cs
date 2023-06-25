namespace SD.LLBLGen.Pro.DebugVisualizers
{
	partial class PredicateVisualizerForm
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
			this._predicateVisualizerControl = new SD.LLBLGen.Pro.DebugVisualizers.StringParametersVisualizerControl();
			this.SuspendLayout();
			// 
			// _predicateVisualizerControl
			// 
			this._predicateVisualizerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._predicateVisualizerControl.Location = new System.Drawing.Point( 0, 0 );
			this._predicateVisualizerControl.Name = "_predicateVisualizerControl";
			this._predicateVisualizerControl.Size = new System.Drawing.Size( 626, 449 );
			this._predicateVisualizerControl.TabIndex = 0;
			// 
			// PredicateVisualizerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 626, 449 );
			this.Controls.Add( this._predicateVisualizerControl );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "PredicateVisualizerForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Predicate Visualizer";
			this.ResumeLayout( false );

		}

		#endregion

		private StringParametersVisualizerControl _predicateVisualizerControl;


	}
}