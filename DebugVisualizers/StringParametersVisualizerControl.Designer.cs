namespace SD.LLBLGen.Pro.DebugVisualizers
{
	partial class StringParametersVisualizerControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this._descriptionLabel = new System.Windows.Forms.Label();
			this._toQueryTextTextBox = new System.Windows.Forms.TextBox();
			this._splitContainerControl = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._parametersGrid = new System.Windows.Forms.DataGridView();
			this.parameterNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this._parameterBindingSource = new System.Windows.Forms.BindingSource( this.components );
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this._splitContainerControl.Panel1.SuspendLayout();
			this._splitContainerControl.Panel2.SuspendLayout();
			this._splitContainerControl.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._parametersGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._parameterBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// _descriptionLabel
			// 
			this._descriptionLabel.AutoSize = true;
			this._descriptionLabel.Location = new System.Drawing.Point( 0, 2 );
			this._descriptionLabel.Name = "_descriptionLabel";
			this._descriptionLabel.Size = new System.Drawing.Size( 0, 13 );
			this._descriptionLabel.TabIndex = 3;
			this._descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _toQueryTextTextBox
			// 
			this._toQueryTextTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._toQueryTextTextBox.BackColor = System.Drawing.SystemColors.Window;
			this._toQueryTextTextBox.Font = new System.Drawing.Font( "Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
			this._toQueryTextTextBox.Location = new System.Drawing.Point( 3, 18 );
			this._toQueryTextTextBox.MaxLength = 65535;
			this._toQueryTextTextBox.Multiline = true;
			this._toQueryTextTextBox.Name = "_toQueryTextTextBox";
			this._toQueryTextTextBox.ReadOnly = true;
			this._toQueryTextTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this._toQueryTextTextBox.Size = new System.Drawing.Size( 535, 281 );
			this._toQueryTextTextBox.TabIndex = 2;
			// 
			// _splitContainerControl
			// 
			this._splitContainerControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this._splitContainerControl.Location = new System.Drawing.Point( 0, 0 );
			this._splitContainerControl.Name = "_splitContainerControl";
			this._splitContainerControl.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// _splitContainerControl.Panel1
			// 
			this._splitContainerControl.Panel1.Controls.Add( this._toQueryTextTextBox );
			this._splitContainerControl.Panel1.Controls.Add( this._descriptionLabel );
			// 
			// _splitContainerControl.Panel2
			// 
			this._splitContainerControl.Panel2.Controls.Add( this.groupBox1 );
			this._splitContainerControl.Size = new System.Drawing.Size( 545, 463 );
			this._splitContainerControl.SplitterDistance = 306;
			this._splitContainerControl.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add( this._parametersGrid );
			this.groupBox1.Location = new System.Drawing.Point( 3, 3 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 535, 143 );
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Parameters";
			// 
			// _parametersGrid
			// 
			this._parametersGrid.AllowUserToAddRows = false;
			this._parametersGrid.AllowUserToDeleteRows = false;
			this._parametersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._parametersGrid.AutoGenerateColumns = false;
			this._parametersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this._parametersGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this._parametersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._parametersGrid.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.parameterNameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn} );
			this._parametersGrid.DataSource = this._parameterBindingSource;
			this._parametersGrid.Location = new System.Drawing.Point( 6, 19 );
			this._parametersGrid.MultiSelect = false;
			this._parametersGrid.Name = "_parametersGrid";
			this._parametersGrid.ReadOnly = true;
			this._parametersGrid.Size = new System.Drawing.Size( 523, 118 );
			this._parametersGrid.TabIndex = 0;
			// 
			// parameterNameDataGridViewTextBoxColumn
			// 
			this.parameterNameDataGridViewTextBoxColumn.DataPropertyName = "ParameterName";
			this.parameterNameDataGridViewTextBoxColumn.HeaderText = "ParameterName";
			this.parameterNameDataGridViewTextBoxColumn.Name = "parameterNameDataGridViewTextBoxColumn";
			this.parameterNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// valueDataGridViewTextBoxColumn
			// 
			this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
			this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
			this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
			this.valueDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// _parameterBindingSource
			// 
			this._parameterBindingSource.DataSource = typeof( System.Data.SqlClient.SqlParameter );
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Value";
			this.dataGridViewTextBoxColumn1.HeaderText = "Value";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 59;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Value";
			this.dataGridViewTextBoxColumn2.HeaderText = "Value";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 240;
			// 
			// StringParametersVisualizerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this._splitContainerControl );
			this.Name = "StringParametersVisualizerControl";
			this.Size = new System.Drawing.Size( 545, 463 );
			this._splitContainerControl.Panel1.ResumeLayout( false );
			this._splitContainerControl.Panel1.PerformLayout();
			this._splitContainerControl.Panel2.ResumeLayout( false );
			this._splitContainerControl.ResumeLayout( false );
			this.groupBox1.ResumeLayout( false );
			((System.ComponentModel.ISupportInitialize)(this._parametersGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._parameterBindingSource)).EndInit();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Label _descriptionLabel;
		private System.Windows.Forms.TextBox _toQueryTextTextBox;
		private System.Windows.Forms.SplitContainer _splitContainerControl;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView _parametersGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn parameterNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource _parameterBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
	}
}
