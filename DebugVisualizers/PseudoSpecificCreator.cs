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
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.LLBLGen.Pro.DebugVisualizers
{
	/// <summary>
	/// Implements IDbSpecificCreator for pseudo code. This specific creator isn't usable for database code, it's used for visualization purposes:
	/// it produces pseudo code.
	/// </summary>
	/// <remarks>It's based on the SqlServer specific creator so here and there it uses Sqlserver specific objects, when no more generic substitute can be used</remarks>
	[Serializable]
	public class PseudoSpecificCreator : DbSpecificCreatorBase
	{
		#region Statics
		// this info is defined here and not in the base class because now a user can use more than one DQE at the same time with different providers.
		private static readonly DbProviderFactoryInfo _dbProviderFactoryInfo = new DbProviderFactoryInfo();
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public PseudoSpecificCreator()
		{
			// create dummy instance to avoid problems with traceswitches during debugging
			CreateDynamicQueryEngine();
		}


		/// <summary>
		/// Sets the db provider factory parameter data. This will influence which DbProviderFactory is used and which enum types the field persistence info
		/// field type names are resolved to.
		/// </summary>
		/// <param name="dbProviderFactoryInvariantName">Name of the db provider factory invariant.</param>
		/// <param name="dbProviderSpecificEnumTypeName">Name of the db provider specific enum type.</param>
		/// <param name="dbProviderSpecificEnumTypePropertyName">Name of the db provider specific enum type property.</param>
		public static void SetDbProviderFactoryParameterData(string dbProviderFactoryInvariantName, string dbProviderSpecificEnumTypeName,
													  string dbProviderSpecificEnumTypePropertyName)
		{
			_dbProviderFactoryInfo.SetDbProviderFactoryParameterData(dbProviderFactoryInvariantName, dbProviderSpecificEnumTypeName, dbProviderSpecificEnumTypePropertyName);
		}


		/// <summary>
		/// Sets the ADO.NET provider specific Enum type of the parameter, using the string presentation specified.
		/// </summary>
		/// <param name="parameter">The parameter.</param>
		/// <param name="parameterType">Type of the parameter as string.</param>
		protected override void SetParameterType(DbParameter parameter, string parameterType)
		{
			// null
		}


		/// <summary>
		/// Gets the DbProviderFactory instance to use.
		/// </summary>
		public override DbProviderFactory FactoryToUse
		{
			get { return _dbProviderFactoryInfo.FactoryToUse; }
		}
        
		/// <summary>
		/// Creates a valid Parameter based on the passed in IEntityFieldCore implementation and the passed in IFieldPersistenceInfo instance
		/// </summary>
		/// <param name="field">IEntityFieldCore instance used to base the parameter on.</param>
		/// <param name="persistenceInfo">Persistence information to create the parameter.</param>
		/// <param name="direction">The direction for the parameter</param>
		/// <param name="valueToSet">Value to set the parameter to.</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		public override DbParameter CreateParameter(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ParameterDirection direction, object valueToSet)
		{
			object value=base.GetRealValue(valueToSet, null, field.DataType);
			if(value==null)
			{
				value=System.DBNull.Value;
			}

			return new SqlParameter( CreateParameterName( field.Alias ), value );
		}


		/// <summary>
		/// Determines the db type name for value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="realValueToUse">The real value to use. Normally it's the same as value, but in cases where value as a type isn't supported, the 
		/// value is converted to a value which is supported.</param>
		/// <returns>The name of the provider specific DbType enum name for the value specified</returns>
		public override string DetermineDbTypeNameForValue(object value, out object realValueToUse)
		{
			realValueToUse = value;
			SqlDbType dbTypeToUse;

			switch(value.GetType().UnderlyingSystemType.FullName)
			{
				case "System.String":
					if(((string)value).Length < 4000)
					{
						dbTypeToUse = SqlDbType.NVarChar;
					}
					else
					{
						if(((string)value).Length < 8000)
						{
							dbTypeToUse = SqlDbType.VarChar;
						}
						else
						{
							dbTypeToUse = SqlDbType.Text;
						}
					}
					break;
				case "System.Byte":
					dbTypeToUse = SqlDbType.TinyInt;
					break;
				case "System.Int32":
					dbTypeToUse = SqlDbType.Int;
					break;
				case "System.Int16":
					dbTypeToUse = SqlDbType.SmallInt;
					break;
				case "System.Int64":
					dbTypeToUse = SqlDbType.BigInt;
					break;
				case "System.DateTime":
					dbTypeToUse = SqlDbType.DateTime;
					break;
				case "System.Decimal":
					dbTypeToUse = SqlDbType.Decimal;
					break;
				case "System.Double":
					dbTypeToUse = SqlDbType.Float;
					break;
				case "System.Single":
					dbTypeToUse = SqlDbType.Real;
					break;
				case "System.Boolean":
					dbTypeToUse = SqlDbType.Bit;
					break;
				case "System.Byte[]":
					byte[] valueAsArray = (byte[])value;
					if(valueAsArray.Length < 8000)
					{
						dbTypeToUse = SqlDbType.VarBinary;
					}
					else
					{
						dbTypeToUse = SqlDbType.Image;
					}
					break;
				case "System.Guid":
					dbTypeToUse = SqlDbType.UniqueIdentifier;
					break;
				default:
					dbTypeToUse = SqlDbType.VarChar;
					break;
			}
			return dbTypeToUse.ToString();
		}


		/// <summary>
		/// Creates a valid Parameter for the pattern in a LIKE statement. This is a special case, because it shouldn't rely on the type of the
		/// field the LIKE statement is used with but should be the unicode varchar type.
		/// </summary>
		/// <param name="pattern">The pattern to be passed as the value for the parameter. Is used to determine length of the parameter.</param>
		/// <returns>
		/// Valid parameter for usage with the target database.
		/// </returns>
		public override DbParameter CreateLikeParameter(string pattern)
		{
			return CreateLikeParameter(pattern, "NVarChar");
		}


		/// <summary>
		/// Creates a valid Parameter for the pattern in a LIKE statement. This is a special case, because it shouldn't rely on the type of the
		/// field the LIKE statement is used with but should be the unicode varchar type.
		/// </summary>
		/// <param name="pattern">The pattern to be passed as the value for the parameter. Is used to determine length of the parameter.</param>
		/// <param name="targetFieldDbType">Type of the target field db</param>
		/// <returns>
		/// Valid parameter for usage with the target database.
		/// </returns>
		/// <remarks>This version ignores targetFieldDbType and calls CreateLikeParameter(fieldname, pattern). When you override this one, also
		/// override the other.</remarks>
		public override DbParameter CreateLikeParameter(string pattern, string targetFieldDbType)
		{
			SqlDbType typeOfParameter = SqlDbType.VarChar;
			switch(targetFieldDbType)
			{
				case "NText":
					typeOfParameter = SqlDbType.NVarChar;
					break;
				case "Text":
					typeOfParameter = SqlDbType.VarChar;
					break;
				case "Char":
				case "NChar":
				case "NVarChar":
				case "VarChar":
					// keep type
					break;
				default:
					typeOfParameter = SqlDbType.NVarChar;
					break;
			}

			return new SqlParameter(CreateParameterName(), typeOfParameter, pattern.Length, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pattern);
		}


		/// <summary>
		/// Creats a valid field name based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. 
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance used to formulate the fieldname</param>
		/// <param name="fieldName">name of the entity field, to determine if an alias is required</param>
		/// <param name="objectAlias">Alias of object the field maps to. Only specified when called from a predicate.</param>
		/// <param name="appendAlias">When true, the routine should construct an alias construction statement.</param>
		/// <param name="containingObjectName">Name of the containing object which defined the field with name fieldName.</param>
		/// <param name="actualContainingObjectName">Name of the containing object which actually holds the field with the name fieldname.</param>
		/// <returns>Valid field name for usage with the target database.</returns>
		public override string CreateFieldName(IFieldPersistenceInfo persistenceInfo, string fieldName, string objectAlias, bool appendAlias,
			string containingObjectName, string actualContainingObjectName)
		{
			// Produce EntityName.Field name if no alias is specified, otherwise ObjectAlias.FieldName
			StringBuilder name = new StringBuilder(128);

			if(objectAlias.Length<=0)
			{
				name.AppendFormat("{0}.", containingObjectName);
			}
			else
			{
				name.AppendFormat("{0}.", this.FindRealAlias(containingObjectName, objectAlias, actualContainingObjectName));
			}

			name.AppendFormat("[{0}]", fieldName);

			return name.ToString();
		}


		/// <summary>
		/// Creats a valid field name based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. The fieldname is 'simple' in that
		/// it doesn't contain any catalog, schema or table references. 
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance used to formulate the fieldname</param>
		/// <param name="fieldName">name of the entity field, to determine if an alias is required</param>
		/// <param name="appendAlias">When true, the routine should construct an alias construction statement.</param>
		/// <returns>Valid field name for usage with the target database.</returns>
		public override string CreateFieldNameSimple(IFieldPersistenceInfo persistenceInfo, string fieldName, bool appendAlias)
		{
			return fieldName;
		}


		/// <summary>
		/// Creates a name usable for a Parameter, based on "p" and a unique marker.
		/// </summary>
		/// <returns>Usable parameter name.</returns>
		protected override string CreateParameterName()
		{
			return this.CreateParameterName("@");
		}


		/// <summary>
		/// Strips the object name chars from the name passed in. For example [name] will become name
		/// </summary>
		/// <param name="toStrip">To strip.</param>
		/// <returns>
		/// name without the name's object name chars (Which are db specific)
		/// </returns>
		protected override string StripObjectNameChars(string toStrip)
		{
			string toMatch = toStrip;
			if(toStrip.StartsWith("["))
			{
				toMatch = toStrip.Substring(1, toStrip.Length-2);
			}
			return toMatch;
		}
        


		/// <summary>
		/// Creates a new dynamic query engine instance
		/// </summary>
		/// <returns></returns>
		protected override DynamicQueryEngineBase CreateDynamicQueryEngine()
		{
			return new DynamicQueryEngine();
		}
	}
}
