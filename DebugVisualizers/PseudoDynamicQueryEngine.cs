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
using System.Data.Common;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Configuration;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.LLBLGen.Pro.DebugVisualizers
{
	/// <summary>
	/// DynamicQueryEngine for Pseudo SQL. This isn't a usable DQE for database activity, it's used for visualization of elements during debug sessions,
	/// and it can deal with objects without persistence info. This DQE is only used for Select statements in subqueries. 
	/// </summary>
	public class DynamicQueryEngine : DynamicQueryEngineBase
	{
		/// <summary>
		/// Creates a new <see cref="DynamicQueryEngine"/> instance.
		/// </summary>
		public DynamicQueryEngine():base()
		{
		}

		/// <summary>
		/// Static CTor for initializing TraceSwitch and name overwrites
		/// </summary>
		static DynamicQueryEngine()
		{
			Switch = new TraceSwitch( "PseudoDQE", "Tracer for Pseudo Dynamic Query Engine, used for visualization" );
			PseudoSpecificCreator.SetDbProviderFactoryParameterData("System.Data.SqlClient", "System.Data.SqlDbType", "SqlDbType");
		}
		

		#region Dynamic Select Query construction methods.
		/// <summary>
		/// Creates a new Select Query which is ready to use, based on the specified select list and the specified set of relations.
		/// If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of IEntityFieldCore objects to select</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the select query</param>
		/// <param name="query">The query to fill.</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="relationsSpecified">flag to signal if relations are specified, this is a result of a check. This routine should
		/// simply assume the value of this flag is correct.</param>
		/// <param name="sortClausesSpecified">flag to signal if sortClauses are specified, this is a result of a check. This routine should
		/// simply assume the value of this flag is correct.</param>
		/// <exception cref="System.ArgumentNullException">When selectList is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		protected override void CreateSelectDQ(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldsPersistenceInfo, 
												IRetrievalQuery query, IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, 
												IRelationCollection relationsToWalk, bool allowDuplicates, IGroupByCollection groupByClause, 
												bool relationsSpecified, bool sortClausesSpecified)
		{
			QueryFragments fragments = new QueryFragments();
			fragments.AddFragment("SELECT");
			StringPlaceHolder distinctPlaceholder = fragments.AddPlaceHolder();
			StringPlaceHolder topPlaceholder = fragments.AddPlaceHolder();
			DelimitedStringList projection = fragments.AddCommaFragmentList(false);
			fragments.AddFragment("FROM");

			UniqueList<string> fieldNamesInSelectList;
			bool distinctViolatingTypesFound;
			bool pkFieldSeen;
			AppendResultsetFields(selectList, fieldsPersistenceInfo, relationsToWalk, projection, sortClausesSpecified, allowDuplicates, true, 
									new UniqueList<string>(), query, out fieldNamesInSelectList, out distinctViolatingTypesFound, out pkFieldSeen);
			bool groupByClauseSpecified = ((groupByClause != null) && (groupByClause.Count > 0));

			bool resultsCouldContainDuplicates = this.DetermineIfDuplicatesWillOccur(relationsToWalk);
			bool distinctEmitted = this.HandleDistinctEmit(sortClauses, allowDuplicates, sortClausesSpecified, query, distinctPlaceholder, false,
										(pkFieldSeen && !resultsCouldContainDuplicates), fieldNamesInSelectList);

			if(maxNumberOfItemsToReturn > 0)
			{
				// row limits are emitted always, unless duplicates are required but DISTINCT wasn't emitable. If not emitable, switch to client-side row limitation
				if(distinctEmitted || !resultsCouldContainDuplicates || groupByClauseSpecified || allowDuplicates)
				{
					topPlaceholder.SetFormatted("TOP {0}", maxNumberOfItemsToReturn);
				}
				else
				{
					query.RequiresClientSideLimitation=true;
					query.MaxNumberOfItemsToReturnClientSide = maxNumberOfItemsToReturn;
				}
			}
			if(relationsSpecified)
			{
				fragments.AddFragment(relationsToWalk.ToQueryText());
				query.AddParameters(((RelationCollection)relationsToWalk).CustomFilterParameters);
			}
			else
			{
				fragments.AddFragment(selectList[0].ContainingObjectName);
				string targetAlias = this.DetermineTargetAlias(selectList[0], relationsToWalk);
				if(targetAlias.Length>0)
				{
					fragments.AddFormatted(" AS [{0}]", targetAlias);
				}
			}
			AppendWhereClause(selectFilter, fragments, query);
			AppendGroupByClause(groupByClause, fragments, query);
			AppendOrderByClause(sortClauses, fragments, query);
			query.SetCommandText(fragments.ToString());
		}
		#endregion


		/// <summary>
		/// Creates a new IDbSpecificCreator and initializes it
		/// </summary>
		/// <returns></returns>
		protected override IDbSpecificCreator CreateDbSpecificCreator()
		{
			return new PseudoSpecificCreator();
		}

		/// <summary>
		/// Gets the function mappings for the particular DQE. These function mappings are static and therefore not changeable.
		/// </summary>
		public override FunctionMappingStore FunctionMappings 
		{
			get { return new FunctionMappingStore(); }
		}
	}
}
