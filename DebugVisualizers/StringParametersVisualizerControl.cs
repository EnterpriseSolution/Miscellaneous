using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.LLBLGen.Pro.DebugVisualizers
{
	public partial class StringParametersVisualizerControl : UserControl
	{
		public StringParametersVisualizerControl()
		{
			InitializeComponent();
		}


		/// <summary>
		/// Visualizes the groupbycollection
		/// </summary>
		/// <param name="toVisualize">To visualize.</param>
		/// <param name="description">The description.</param>
		public void VisualizeGroupByCollection( IGroupByCollection toVisualize, string description )
		{
			PseudoSpecificCreator creator = new PseudoSpecificCreator();
			StringBuilder groupByText = new StringBuilder();
			for( int i = 0; i < toVisualize.Count; i++ )
			{
				if( i > 0 )
				{
					groupByText.AppendFormat( ",{0}", Environment.NewLine );
				}
				groupByText.Append( creator.CreateFieldName( toVisualize.GetEntityFieldCore( i ), toVisualize.GetFieldPersistenceInfo( i ), toVisualize[i].Name,
															toVisualize[i].ObjectAlias, false ) );
			}

			if( toVisualize.HavingClause != null )
			{
				toVisualize.HavingClause.DatabaseSpecificCreator = creator;
				string havingClauseText = toVisualize.HavingClause.ToQueryText(true );
				groupByText.AppendFormat("{0}HAVING{1}", Environment.NewLine, BeautifyBracketedText(havingClauseText));
				_parameterBindingSource.DataSource = toVisualize.HavingClause.Parameters;
			}
			_toQueryTextTextBox.Text = groupByText.ToString();
			_toQueryTextTextBox.Select( 0, 0 );
			_descriptionLabel.Text = description;
		}


		
		/// <summary>
		/// Visualizes the sort expression.
		/// </summary>
		/// <param name="toVisualize">To visualize.</param>
		/// <param name="description">The description.</param>
		public void VisualizeSortExpression( ISortExpression toVisualize, string description )
		{
			string queryText = toVisualize.ToQueryText();
			_toQueryTextTextBox.Text = Environment.NewLine + queryText;
			_splitContainerControl.Panel2Collapsed = true;
			_toQueryTextTextBox.Select( 0, 0 );
			_descriptionLabel.Text = description;
		}


		/// <summary>
		/// Visualizes the predicate.
		/// </summary>
		/// <param name="toVisualize">To visualize.</param>
		/// <param name="description">The description.</param>
		public void VisualizePredicate( IPredicate toVisualize, string description )
		{
			string queryText = toVisualize.ToQueryText();
			_toQueryTextTextBox.Text = BeautifyBracketedText( queryText );
			_parameterBindingSource.DataSource = toVisualize.Parameters;
			_toQueryTextTextBox.Select( 0, 0 );
			_descriptionLabel.Text = description;
		}
		

		/// <summary>
		/// Visualizes the relation collection.
		/// </summary>
		/// <param name="toVisualize">To visualize.</param>
		/// <param name="description">The description.</param>
		public void VisualizeRelationCollection( IRelationCollection toVisualize, string description )
		{
			string relationText = toVisualize.ToQueryText();
			_toQueryTextTextBox.Text = BeautifyBracketedText( relationText );
			_parameterBindingSource.DataSource = ((RelationCollection)toVisualize).CustomFilterParameters;
			_toQueryTextTextBox.Select( 0, 0 );
			_descriptionLabel.Text = description;
		}


		/// <summary>
		/// Visualizes the expression passed in.
		/// </summary>
		/// <param name="toVisualize">To visualize.</param>
		/// <param name="description">The description.</param>
		public void VisualizeExpression( IExpression toVisualize, string description )
		{
			string expressionText = toVisualize.ToQueryText();
			_toQueryTextTextBox.Text = BeautifyBracketedText( expressionText );
			_parameterBindingSource.DataSource = toVisualize.Parameters;
			_toQueryTextTextBox.Select( 0, 0 );
			_descriptionLabel.Text = description;
		}


		/// <summary>
		/// Beautifies text which contains brackets (). Every ( starts on a new line and increases indentation, every ) starts on a new line and decreases
		/// indentation.
		/// </summary>
		/// <param name="toBeautify">To beautify.</param>
		/// <returns>beautified text</returns>
		private string BeautifyBracketedText( string toBeautify )
		{
			if( toBeautify.Trim().Length <= 0 )
			{
				return "<empty>";
			}

			StringBuilder builder = new StringBuilder();
			int indentLevel = 0;
			bool stripWhitespace = false;
			bool previousWasBracketClose = false;
			bool alreadyNonWhiteSpaceEmitted = false;
			foreach( char c in toBeautify )
			{
				switch( c )
				{
					case '(':
						if( alreadyNonWhiteSpaceEmitted )
						{
							builder.Append( Environment.NewLine );
							builder.Append( new string( ' ', indentLevel * 4 ) );
						}
						builder.Append( "(" );
						indentLevel++;
						builder.Append( Environment.NewLine );
						builder.Append( new string( ' ', indentLevel * 4 ) );
						stripWhitespace = true;
						previousWasBracketClose = false;
						break;
					case ')':
						indentLevel--;
						if( previousWasBracketClose )
						{
							// remove indent of 4 spaces
							builder.Remove( builder.Length - 4, 4 );
						}
						else
						{
							builder.Append( Environment.NewLine );
							builder.Append( new string( ' ', indentLevel * 4 ) );
						}
						builder.Append( ")" );
						builder.Append( Environment.NewLine );
						builder.Append( new string( ' ', indentLevel * 4 ) );
						stripWhitespace = true;
						previousWasBracketClose = true;
						break;
					case ' ':
						if( stripWhitespace )
						{
							continue;
						}
						builder.Append( c );
						previousWasBracketClose = false;
						break;
					default:
						builder.Append( c );
						stripWhitespace = false;
						alreadyNonWhiteSpaceEmitted = true;
						previousWasBracketClose = false;
						break;
				}
			}

			return builder.ToString();
		}
	}
}
