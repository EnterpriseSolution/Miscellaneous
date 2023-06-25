namespace SD.LLBLGen.Pro.DebugVisualizers
{
	partial class SortExpressionVisualizerForm
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
			this._sortExpressionVisualizerControl = new SD.LLBLGen.Pro.DebugVisualizers.StringParametersVisualizerControl();
			this.SuspendLayout();
			// 
			// _sortExpressionVisualizerControl
			// 
			this._sortExpressionVisualizerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._sortExpressionVisualizerControl.Location = new System.Drawing.Point( 0, 0 );
			this._sortExpressionVisualizerControl.Name = "_sortExpressionVisualizerControl";
			this._sortExpressionVisualizerControl.Size = new System.Drawing.Size( 590, 535 );
			this._sortExpressionVisualizerControl.TabIndex = 0;
			// 
			// SortExpressionVisualizerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 590, 535 );
			this.Controls.Add( this._sortExpressionVisualizerControl );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "SortExpressionVisualizerForm";
			this.Text = "SortExpression Visualizer";
			this.ResumeLayout( false );

		}

		#endregion

		private StringParametersVisualizerControl _sortExpressionVisualizerControl;
	}
}