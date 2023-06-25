namespace SD.LLBLGen.Pro.DebugVisualizers
{
	partial class RelationPredicateBucketVisualizerForm
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
			this._tabs = new System.Windows.Forms.TabControl();
			this._relationCollectionTab = new System.Windows.Forms.TabPage();
			this._predicateExpressionTab = new System.Windows.Forms.TabPage();
			this._relationCollectionVisualizerControl = new SD.LLBLGen.Pro.DebugVisualizers.StringParametersVisualizerControl();
			this._predicateExpressionVisualizerControl = new SD.LLBLGen.Pro.DebugVisualizers.StringParametersVisualizerControl();
			this._tabs.SuspendLayout();
			this._relationCollectionTab.SuspendLayout();
			this._predicateExpressionTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// _tabs
			// 
			this._tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._tabs.Controls.Add( this._relationCollectionTab );
			this._tabs.Controls.Add( this._predicateExpressionTab );
			this._tabs.Location = new System.Drawing.Point( 3, 7 );
			this._tabs.Name = "_tabs";
			this._tabs.SelectedIndex = 0;
			this._tabs.Size = new System.Drawing.Size( 592, 568 );
			this._tabs.TabIndex = 0;
			// 
			// _relationCollectionTab
			// 
			this._relationCollectionTab.Controls.Add( this._relationCollectionVisualizerControl );
			this._relationCollectionTab.Location = new System.Drawing.Point( 4, 22 );
			this._relationCollectionTab.Name = "_relationCollectionTab";
			this._relationCollectionTab.Padding = new System.Windows.Forms.Padding( 3 );
			this._relationCollectionTab.Size = new System.Drawing.Size( 644, 648 );
			this._relationCollectionTab.TabIndex = 0;
			this._relationCollectionTab.Text = "RelationCollection";
			this._relationCollectionTab.UseVisualStyleBackColor = true;
			// 
			// _predicateExpressionTab
			// 
			this._predicateExpressionTab.Controls.Add( this._predicateExpressionVisualizerControl );
			this._predicateExpressionTab.Location = new System.Drawing.Point( 4, 22 );
			this._predicateExpressionTab.Name = "_predicateExpressionTab";
			this._predicateExpressionTab.Padding = new System.Windows.Forms.Padding( 3 );
			this._predicateExpressionTab.Size = new System.Drawing.Size( 584, 542 );
			this._predicateExpressionTab.TabIndex = 1;
			this._predicateExpressionTab.Text = "PredicateExpression";
			this._predicateExpressionTab.UseVisualStyleBackColor = true;
			// 
			// _relationCollectionVisualizerControl
			// 
			this._relationCollectionVisualizerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._relationCollectionVisualizerControl.Location = new System.Drawing.Point( 3, 3 );
			this._relationCollectionVisualizerControl.Name = "_relationCollectionVisualizerControl";
			this._relationCollectionVisualizerControl.Size = new System.Drawing.Size( 638, 642 );
			this._relationCollectionVisualizerControl.TabIndex = 0;
			// 
			// _predicateExpressionVisualizerControl
			// 
			this._predicateExpressionVisualizerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._predicateExpressionVisualizerControl.Location = new System.Drawing.Point( 3, 3 );
			this._predicateExpressionVisualizerControl.Name = "_predicateExpressionVisualizerControl";
			this._predicateExpressionVisualizerControl.Size = new System.Drawing.Size( 578, 536 );
			this._predicateExpressionVisualizerControl.TabIndex = 0;
			// 
			// RelationPredicateBucketVisualizerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 597, 578 );
			this.Controls.Add( this._tabs );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "RelationPredicateBucketVisualizerForm";
			this.Text = "RelationPredicateBucket Visualizer";
			this._tabs.ResumeLayout( false );
			this._relationCollectionTab.ResumeLayout( false );
			this._predicateExpressionTab.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.TabControl _tabs;
		private System.Windows.Forms.TabPage _relationCollectionTab;
		private System.Windows.Forms.TabPage _predicateExpressionTab;
		private StringParametersVisualizerControl _relationCollectionVisualizerControl;
		private StringParametersVisualizerControl _predicateExpressionVisualizerControl;
	}
}