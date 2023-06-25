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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Reflection;

namespace SD.LLBLGen.Pro.DebugVisualizers
{
	public partial class PrefetchPathVisualizerForm : Form
	{
		private Type _entityTypeEnum = null;

		/// <summary>
		/// Initializes a new instance of the <see cref="PrefetchPathVisualizerForm"/> class.
		/// </summary>
		/// <param name="toVisualize">To visualize.</param>
		/// <remarks>selfservicing constructor</remarks>
		public PrefetchPathVisualizerForm(IPrefetchPath toVisualize)
		{
			InitializeComponent();

			if( (toVisualize == null) || (toVisualize.Count <= 0) )
			{
				return;
			}

			// first load the enum type for EntityType
			// pass entity factory in relationcollection, which is defined in the assembly which also contains the EntityType enum.
			LoadEntityTypeEnum( toVisualize[0].RetrievalCollection.EntityFactoryToUse );

			// walk the prefetch path, and all subpaths and produce tree nodes, one per node. Because of the nature of the prefetch path nodes,
			// entity names of the root are stored in the subnodes.
			TreeNode rootNode = new TreeNode( "Path element" );
			if( _entityTypeEnum != null )
			{
				rootNode.Text += string.Format( " for RootEntityType '{0}'", Enum.GetName( _entityTypeEnum, toVisualize.RootEntityType ) );
			}
			_pathTreeView.Nodes.Add( rootNode );
			VisualizePath( rootNode, toVisualize );
			rootNode.ExpandAll();
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="PrefetchPathVisualizerForm"/> class.
		/// </summary>
		/// <param name="toVisualize">To visualize.</param>
		/// <remarks>adapter constructor</remarks>
		public PrefetchPathVisualizerForm( IPrefetchPath2 toVisualize )
		{
			InitializeComponent();

			if( (toVisualize == null) || (toVisualize.Count <= 0) )
			{
				return;
			}

			// first load the enum type for EntityType
			// pass entity factory in relationcollection, which is defined in the assembly which also contains the EntityType enum.
			LoadEntityTypeEnum( toVisualize[0].RetrievalCollection.EntityFactoryToUse );

			// walk the prefetch path, and all subpaths and produce tree nodes, one per node. Because of the nature of the prefetch path nodes,
			// entity names of the root are stored in the subnodes.
			TreeNode rootNode = new TreeNode( "Path element" );
			if( _entityTypeEnum != null )
			{
				rootNode.Text += string.Format( " for RootEntityType '{0}'", Enum.GetName( _entityTypeEnum, toVisualize.RootEntityType ) );
			}
			_pathTreeView.Nodes.Add( rootNode );
			VisualizePath( rootNode, toVisualize );
			rootNode.ExpandAll();
		}


		/// <summary>
		/// Visualizes the path specified, using recursion.
		/// </summary>
		/// <param name="rootNode">The root node.</param>
		/// <param name="toVisualize">To visualize.</param>
		private void VisualizePath(TreeNode rootNode, IPrefetchPath2 toVisualize)
		{
			Dictionary<int, TreeNode> typeToNode = new Dictionary<int, TreeNode>();
			foreach( IPrefetchPathElement2 element in (PrefetchPath2)toVisualize )
			{
				string rootEntityName = string.Empty;
				string toLoadEntityName = string.Empty;

				if(_entityTypeEnum==null)
				{
					if( element.Relation.StartEntityIsPkSide )
					{
						rootEntityName = element.Relation.GetPKEntityFieldCore( 0 ).ContainingObjectName;
						toLoadEntityName = element.Relation.GetFKEntityFieldCore(0).ContainingObjectName;
					}
					else
					{
						rootEntityName = element.Relation.GetFKEntityFieldCore( 0 ).ContainingObjectName;
						toLoadEntityName = element.Relation.GetPKEntityFieldCore( 0 ).ContainingObjectName;
					}
				}
				else
				{
					rootEntityName = Enum.GetName( _entityTypeEnum, element.DestinationEntityType );
					toLoadEntityName = Enum.GetName( _entityTypeEnum, element.ToFetchEntityType );
				}

				TreeNode elementRootNode = null;
				if( typeToNode.ContainsKey( element.DestinationEntityType ) )
				{
					elementRootNode = typeToNode[element.DestinationEntityType];
				}
				else
				{
					elementRootNode = new TreeNode(rootEntityName);
					typeToNode.Add( element.DestinationEntityType, elementRootNode );
					rootNode.Nodes.Add( elementRootNode );
				}
				TreeNode elementToLoadNode = new TreeNode( string.Format( "{0} ({1}, {2})", element.PropertyName, toLoadEntityName, element.TypeOfRelation.ToString() ) );
				elementRootNode.Nodes.Add( elementToLoadNode );
				if( element.SubPath.Count > 0 )
				{
					TreeNode subPathNode = new TreeNode("Path element");
					elementToLoadNode.Nodes.Add( subPathNode );
					if( _entityTypeEnum != null )
					{
						subPathNode.Text += string.Format(" for RootEntityType '{0}'", Enum.GetName( _entityTypeEnum, element.SubPath.RootEntityType ));
					}

					VisualizePath( subPathNode, element.SubPath );
				}
			}
		}


		/// <summary>
		/// Visualizes the path specified, using recursion.
		/// </summary>
		/// <param name="rootNode">The root node.</param>
		/// <param name="toVisualize">To visualize.</param>
		private void VisualizePath( TreeNode rootNode, IPrefetchPath toVisualize )
		{
			Dictionary<int, TreeNode> typeToNode = new Dictionary<int, TreeNode>();
			foreach( IPrefetchPathElement element in (PrefetchPath)toVisualize )
			{
				string rootEntityName = string.Empty;
				string toLoadEntityName = string.Empty;

				if( _entityTypeEnum == null )
				{
					if( element.Relation.StartEntityIsPkSide )
					{
						rootEntityName = element.Relation.GetPKEntityFieldCore( 0 ).ContainingObjectName;
						toLoadEntityName = element.Relation.GetFKEntityFieldCore( 0 ).ContainingObjectName;
					}
					else
					{
						rootEntityName = element.Relation.GetFKEntityFieldCore( 0 ).ContainingObjectName;
						toLoadEntityName = element.Relation.GetPKEntityFieldCore( 0 ).ContainingObjectName;
					}
				}
				else
				{
					rootEntityName = Enum.GetName( _entityTypeEnum, element.DestinationEntityType );
					toLoadEntityName = Enum.GetName( _entityTypeEnum, element.ToFetchEntityType );
				}

				TreeNode elementRootNode = null;
				if( typeToNode.ContainsKey( element.DestinationEntityType ) )
				{
					elementRootNode = typeToNode[element.DestinationEntityType];
				}
				else
				{
					elementRootNode = new TreeNode( rootEntityName );
					typeToNode.Add( element.DestinationEntityType, elementRootNode );
					rootNode.Nodes.Add( elementRootNode );
				}
				TreeNode elementToLoadNode = new TreeNode( string.Format( "{0} ({1}, {2})", element.PropertyName, toLoadEntityName, element.TypeOfRelation.ToString() ) );
				elementRootNode.Nodes.Add( elementToLoadNode );
				if( element.SubPath.Count > 0 )
				{
					TreeNode subPathNode = new TreeNode( "Path element" );
					elementToLoadNode.Nodes.Add( subPathNode );
					if( _entityTypeEnum != null )
					{
						subPathNode.Text += string.Format( " for RootEntityType '{0}'", Enum.GetName( _entityTypeEnum, element.SubPath.RootEntityType ) );
					}

					VisualizePath( subPathNode, element.SubPath );
				}
			}
		}


		/// <summary>
		/// Loads the entity type enum.
		/// </summary>
		/// <param name="entityFactory">The entity factory.</param>
		private void LoadEntityTypeEnum( IEntityFactory2 entityFactory )
		{
			Assembly entityContainingAssembly = entityFactory.GetType().Assembly;
			if( entityContainingAssembly != null )
			{
				Type[] allTypes = entityContainingAssembly.GetTypes();
				// now walk all types. If a type's name ends with .EntityType, we have a winner.
				foreach( Type foundType in allTypes )
				{
					if( foundType.FullName.EndsWith( ".EntityType" ) )
					{
						// found it.
						_entityTypeEnum = foundType;
						break;
					}
				}
			}
		}


		/// <summary>
		/// Loads the entity type enum.
		/// </summary>
		/// <param name="entityFactory">The entity factory.</param>
		private void LoadEntityTypeEnum( IEntityFactory entityFactory )
		{
			Assembly entityContainingAssembly = entityFactory.GetType().Assembly;
			if( entityContainingAssembly != null )
			{
				Type[] allTypes = entityContainingAssembly.GetTypes();
				// now walk all types. If a type's name ends with .EntityType, we have a winner.
				foreach( Type foundType in allTypes )
				{
					if( foundType.FullName.EndsWith( ".EntityType" ) )
					{
						// found it.
						_entityTypeEnum = foundType;
						break;
					}
				}
			}
		}
	}
}