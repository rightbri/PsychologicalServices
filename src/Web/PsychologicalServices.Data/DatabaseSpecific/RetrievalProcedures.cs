///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SqlServerSpecific.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlClient;
using SD.LLBLGen.Pro.ORMSupportClasses;
namespace PsychologicalServices.Data.DatabaseSpecific
{
	/// <summary>
	/// Class which contains the static logic to execute retrieval stored procedures in the database.
	/// </summary>
	public partial class RetrievalProcedures
	{
		/// <summary>
		/// private CTor so no instance can be created.
		/// </summary>
		private RetrievalProcedures()
		{
		}

	
		/// <summary>
		/// Calls stored procedure 'BookingData'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable BookingData(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return BookingData(companyId, months,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'BookingData'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable BookingData(System.Int32 companyId, Nullable<System.Int32> months, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[2];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months);

			DataTable toReturn = new DataTable("BookingData");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[BookingData]", parameters, toReturn);

			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'BookingData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable BookingData(System.Int32 companyId, Nullable<System.Int32> months, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return BookingData(companyId, months, ref returnValue, adapter);
			}
		}
	
	
		/// <summary>
		/// Calls stored procedure 'BookingData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable BookingData(System.Int32 companyId, Nullable<System.Int32> months, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[2 + 1];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months);

			parameters[2] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			DataTable toReturn = new DataTable("BookingData");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[BookingData]", parameters, toReturn);


			returnValue = (int)parameters[2].Value;
			return toReturn;
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'BookingData'.
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetBookingDataCallAsQuery( System.Int32 companyId, Nullable<System.Int32> months)
		{
			RetrievalQuery toReturn = new RetrievalQuery( new SqlCommand("[PsychologicalServices].[dbo].[BookingData]" ) );
			toReturn.Parameters.Add(new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId));
			toReturn.Parameters.Add(new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months));

			toReturn.Command.CommandType = CommandType.StoredProcedure;
			return toReturn;
		}
	

		/// <summary>
		/// Calls stored procedure 'CancellationData'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CancellationData(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return CancellationData(companyId, months,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'CancellationData'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CancellationData(System.Int32 companyId, Nullable<System.Int32> months, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[2];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months);

			DataTable toReturn = new DataTable("CancellationData");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[CancellationData]", parameters, toReturn);

			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'CancellationData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CancellationData(System.Int32 companyId, Nullable<System.Int32> months, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return CancellationData(companyId, months, ref returnValue, adapter);
			}
		}
	
	
		/// <summary>
		/// Calls stored procedure 'CancellationData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CancellationData(System.Int32 companyId, Nullable<System.Int32> months, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[2 + 1];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months);

			parameters[2] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			DataTable toReturn = new DataTable("CancellationData");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[CancellationData]", parameters, toReturn);


			returnValue = (int)parameters[2].Value;
			return toReturn;
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'CancellationData'.
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetCancellationDataCallAsQuery( System.Int32 companyId, Nullable<System.Int32> months)
		{
			RetrievalQuery toReturn = new RetrievalQuery( new SqlCommand("[PsychologicalServices].[dbo].[CancellationData]" ) );
			toReturn.Parameters.Add(new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId));
			toReturn.Parameters.Add(new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months));

			toReturn.Command.CommandType = CommandType.StoredProcedure;
			return toReturn;
		}
	

		/// <summary>
		/// Calls stored procedure 'CompletionData'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CompletionData(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return CompletionData(companyId, months,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'CompletionData'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CompletionData(System.Int32 companyId, Nullable<System.Int32> months, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[2];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months);

			DataTable toReturn = new DataTable("CompletionData");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[CompletionData]", parameters, toReturn);

			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'CompletionData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CompletionData(System.Int32 companyId, Nullable<System.Int32> months, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return CompletionData(companyId, months, ref returnValue, adapter);
			}
		}
	
	
		/// <summary>
		/// Calls stored procedure 'CompletionData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CompletionData(System.Int32 companyId, Nullable<System.Int32> months, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[2 + 1];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months);

			parameters[2] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			DataTable toReturn = new DataTable("CompletionData");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[CompletionData]", parameters, toReturn);


			returnValue = (int)parameters[2].Value;
			return toReturn;
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'CompletionData'.
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetCompletionDataCallAsQuery( System.Int32 companyId, Nullable<System.Int32> months)
		{
			RetrievalQuery toReturn = new RetrievalQuery( new SqlCommand("[PsychologicalServices].[dbo].[CompletionData]" ) );
			toReturn.Parameters.Add(new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId));
			toReturn.Parameters.Add(new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months));

			toReturn.Command.CommandType = CommandType.StoredProcedure;
			return toReturn;
		}
	

		#region Included Code

		#endregion
	}
}
