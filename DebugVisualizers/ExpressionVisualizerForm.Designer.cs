namespace SD.LLBLGen.Pro.DebugVisualizers
{
	partial class ExpressionVisualizerForm
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
			this._expressionVisualizerControl = new SD.LLBLGen.Pro.DebugVisualizers.StringParametersVisualizerControl();
			this.SuspendLayout();
			// 
			// _expressionVisualizerControl
			// 
			this._expressionVisualizerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._expressionVisualizerControl.Location = new System.Drawing.Point( 0, 0 );
			this._expressionVisualizerControl.Name = "_expressionVisualizerControl";
			this._expressionVisualizerControl.Size = new System.Drawing.Size( 571, 447 );
			this._expressionVisualizerControl.TabIndex = 0;
			// 
			// ExpressionVisualizerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 571, 447 );
			this.Controls.Add( this._expressionVisualizerControl );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "ExpressionVisualizerForm";
			this.Text = "Expression Visualizer";
			this.ResumeLayout( false );

		}

		#endregion

		private StringParametersVisualizerControl _expressionVisualizerControl;
	}
}