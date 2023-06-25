//////////////////////////////////////////////////////////////////////
// Part of the LLBLGen Pro debug visualizers for VS.NET 2005. 
// LLBLGen Pro is (c) 2002-2011 Solutions Design. All rights reserved.
// http://www.llblgen.com
//////////////////////////////////////////////////////////////////////
// The sourcecode for this debug visualizer is released as BSD2 licensed open source, so licensees and others can
// modify, update, extend or use it to write other debug visualizers. 
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2010 Solutions Design. All rights reserved.
// 
// This DQE is released under the following license: (BSD2)
// -------------------------------------------
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Frans Bouma [FB]
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.DebuggerVisualizers;

using SD.LLBLGen.Pro.ORMSupportClasses;

// type - visualizer binding
[assembly: DebuggerVisualizer(
		typeof( SD.LLBLGen.Pro.DebugVisualizers.RelationPredicateBucketVisualizer ),
		typeof( VisualizerObjectSource ),
		Target = typeof( SD.LLBLGen.Pro.ORMSupportClasses.RelationPredicateBucket ),
		Description = "RelationPredicateBucket Visualizer" )]

namespace SD.LLBLGen.Pro.DebugVisualizers
{
	/// <summary>
	/// A Visualizer for a RelationPredicateBucket
	/// </summary>
	public class RelationPredicateBucketVisualizer : DialogDebuggerVisualizer
	{
		/// <summary>
		/// </summary>
		/// <param name="windowService">An object of type <see cref="T:Microsoft.VisualStudio.DebuggerVisualizers.IDialogVisualizerService"></see>, which provides methods your visualizer can use to display Windows forms, controls, and dialogs.</param>
		/// <param name="objectProvider">An object of type <see cref="T:Microsoft.VisualStudio.DebuggerVisualizers.IVisualizerObjectProvider"></see>. This object provides communication from the debugger side of the visualizer to the object source (<see cref="T:Microsoft.VisualStudio.DebuggerVisualizers.VisualizerObjectSource"></see>) on the debuggee side.</param>
		protected override void Show( IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider )
		{
			IRelationPredicateBucket toVisualize = null;
			try
			{
				toVisualize = (IRelationPredicateBucket)objectProvider.GetObject();
			}
			catch
			{
				// try with fast serialization switched on
				SerializationHelper.Optimization = SerializationOptimization.Fast;
				toVisualize = (IRelationPredicateBucket)objectProvider.GetObject();
			}
			if(toVisualize == null)
			{
				return;
			}

			IDbSpecificCreator creatorToUse = new PseudoSpecificCreator();
			GeneralUtils utils = new GeneralUtils();
			utils.InsertPersistenceInfoObjects( toVisualize.Relations );
			utils.InsertPersistenceInfoObjects( toVisualize.PredicateExpression );

			toVisualize.PredicateExpression.DatabaseSpecificCreator = creatorToUse;
			toVisualize.Relations.DatabaseSpecificCreator = creatorToUse;

			using( RelationPredicateBucketVisualizerForm viewer = new RelationPredicateBucketVisualizerForm( toVisualize ) )
			{
				windowService.ShowDialog( viewer );
			}
		}
	}
}
