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
		/// Calls stored procedure 'ArbitrationsData'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable ArbitrationsData(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return ArbitrationsData(companyId, months,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'ArbitrationsData'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable ArbitrationsData(System.Int32 companyId, Nullable<System.Int32> months, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[2];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months);

			DataTable toReturn = new DataTable("ArbitrationsData");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[ArbitrationsData]", parameters, toReturn);

			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'ArbitrationsData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable ArbitrationsData(System.Int32 companyId, Nullable<System.Int32> months, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return ArbitrationsData(companyId, months, ref returnValue, adapter);
			}
		}
	
	
		/// <summary>
		/// Calls stored procedure 'ArbitrationsData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable ArbitrationsData(System.Int32 companyId, Nullable<System.Int32> months, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[2 + 1];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months);

			parameters[2] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			DataTable toReturn = new DataTable("ArbitrationsData");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[ArbitrationsData]", parameters, toReturn);


			returnValue = (int)parameters[2].Value;
			return toReturn;
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'ArbitrationsData'.
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetArbitrationsDataCallAsQuery( System.Int32 companyId, Nullable<System.Int32> months)
		{
			RetrievalQuery toReturn = new RetrievalQuery( new SqlCommand("[PsychologicalServices].[dbo].[ArbitrationsData]" ) );
			toReturn.Parameters.Add(new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId));
			toReturn.Parameters.Add(new SqlParameter("@months", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, months));

			toReturn.Command.CommandType = CommandType.StoredProcedure;
			return toReturn;
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
	

		/// <summary>
		/// Calls stored procedure 'InvoiceableAppointmentData'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="startSearch">Input parameter of stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceableAppointmentData(System.Int32 companyId, Nullable<System.Int32> invoiceTypeId, Nullable<System.DateTimeOffset> startSearch)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return InvoiceableAppointmentData(companyId, invoiceTypeId, startSearch,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'InvoiceableAppointmentData'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="startSearch">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceableAppointmentData(System.Int32 companyId, Nullable<System.Int32> invoiceTypeId, Nullable<System.DateTimeOffset> startSearch, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[3];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@invoiceTypeId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, invoiceTypeId);
			parameters[2] = new SqlParameter("@startSearch", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, startSearch);

			DataTable toReturn = new DataTable("InvoiceableAppointmentData");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[InvoiceableAppointmentData]", parameters, toReturn);

			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'InvoiceableAppointmentData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="startSearch">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceableAppointmentData(System.Int32 companyId, Nullable<System.Int32> invoiceTypeId, Nullable<System.DateTimeOffset> startSearch, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return InvoiceableAppointmentData(companyId, invoiceTypeId, startSearch, ref returnValue, adapter);
			}
		}
	
	
		/// <summary>
		/// Calls stored procedure 'InvoiceableAppointmentData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="startSearch">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceableAppointmentData(System.Int32 companyId, Nullable<System.Int32> invoiceTypeId, Nullable<System.DateTimeOffset> startSearch, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[3 + 1];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@invoiceTypeId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, invoiceTypeId);
			parameters[2] = new SqlParameter("@startSearch", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, startSearch);

			parameters[3] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			DataTable toReturn = new DataTable("InvoiceableAppointmentData");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[InvoiceableAppointmentData]", parameters, toReturn);


			returnValue = (int)parameters[3].Value;
			return toReturn;
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'InvoiceableAppointmentData'.
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="startSearch">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetInvoiceableAppointmentDataCallAsQuery( System.Int32 companyId, Nullable<System.Int32> invoiceTypeId, Nullable<System.DateTimeOffset> startSearch)
		{
			RetrievalQuery toReturn = new RetrievalQuery( new SqlCommand("[PsychologicalServices].[dbo].[InvoiceableAppointmentData]" ) );
			toReturn.Parameters.Add(new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId));
			toReturn.Parameters.Add(new SqlParameter("@invoiceTypeId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, invoiceTypeId));
			toReturn.Parameters.Add(new SqlParameter("@startSearch", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, startSearch));

			toReturn.Command.CommandType = CommandType.StoredProcedure;
			return toReturn;
		}
	

		/// <summary>
		/// Calls stored procedure 'InvoiceSearch'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="appointmentId">Input parameter of stored procedure</param>
		/// <param name="identifier">Input parameter of stored procedure</param>
		/// <param name="invoiceDate">Input parameter of stored procedure</param>
		/// <param name="invoiceMonth">Input parameter of stored procedure</param>
		/// <param name="invoiceStatusId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="payableToId">Input parameter of stored procedure</param>
		/// <param name="claimantId">Input parameter of stored procedure</param>
		/// <param name="needsRefresh">Input parameter of stored procedure</param>
		/// <param name="needsToBeSentToReferralSource">Input parameter of stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceSearch(System.Int32 companyId, Nullable<System.Int32> appointmentId, System.String identifier, Nullable<System.DateTimeOffset> invoiceDate, Nullable<System.DateTimeOffset> invoiceMonth, Nullable<System.Int32> invoiceStatusId, Nullable<System.Int32> invoiceTypeId, Nullable<System.Int32> payableToId, Nullable<System.Int32> claimantId, Nullable<System.Boolean> needsRefresh, Nullable<System.Boolean> needsToBeSentToReferralSource 
)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return InvoiceSearch(companyId, appointmentId, identifier, invoiceDate, invoiceMonth, invoiceStatusId, invoiceTypeId, payableToId, claimantId, needsRefresh, needsToBeSentToReferralSource 
,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'InvoiceSearch'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="appointmentId">Input parameter of stored procedure</param>
		/// <param name="identifier">Input parameter of stored procedure</param>
		/// <param name="invoiceDate">Input parameter of stored procedure</param>
		/// <param name="invoiceMonth">Input parameter of stored procedure</param>
		/// <param name="invoiceStatusId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="payableToId">Input parameter of stored procedure</param>
		/// <param name="claimantId">Input parameter of stored procedure</param>
		/// <param name="needsRefresh">Input parameter of stored procedure</param>
		/// <param name="needsToBeSentToReferralSource">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceSearch(System.Int32 companyId, Nullable<System.Int32> appointmentId, System.String identifier, Nullable<System.DateTimeOffset> invoiceDate, Nullable<System.DateTimeOffset> invoiceMonth, Nullable<System.Int32> invoiceStatusId, Nullable<System.Int32> invoiceTypeId, Nullable<System.Int32> payableToId, Nullable<System.Int32> claimantId, Nullable<System.Boolean> needsRefresh, Nullable<System.Boolean> needsToBeSentToReferralSource 
, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[11];
			parameters[0] = new SqlParameter("@CompanyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@AppointmentId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, appointmentId);
			parameters[2] = new SqlParameter("@Identifier", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, identifier);
			parameters[3] = new SqlParameter("@InvoiceDate", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, invoiceDate);
			parameters[4] = new SqlParameter("@InvoiceMonth", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, invoiceMonth);
			parameters[5] = new SqlParameter("@InvoiceStatusId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, invoiceStatusId);
			parameters[6] = new SqlParameter("@InvoiceTypeId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, invoiceTypeId);
			parameters[7] = new SqlParameter("@PayableToId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, payableToId);
			parameters[8] = new SqlParameter("@ClaimantId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, claimantId);
			parameters[9] = new SqlParameter("@NeedsRefresh", SqlDbType.Bit, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, needsRefresh);
			parameters[10] = new SqlParameter("@NeedsToBeSentToReferralSource", SqlDbType.Bit, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, needsToBeSentToReferralSource);

			DataTable toReturn = new DataTable("InvoiceSearch");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[InvoiceSearch]", parameters, toReturn);

			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'InvoiceSearch'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="appointmentId">Input parameter of stored procedure</param>
		/// <param name="identifier">Input parameter of stored procedure</param>
		/// <param name="invoiceDate">Input parameter of stored procedure</param>
		/// <param name="invoiceMonth">Input parameter of stored procedure</param>
		/// <param name="invoiceStatusId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="payableToId">Input parameter of stored procedure</param>
		/// <param name="claimantId">Input parameter of stored procedure</param>
		/// <param name="needsRefresh">Input parameter of stored procedure</param>
		/// <param name="needsToBeSentToReferralSource">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceSearch(System.Int32 companyId, Nullable<System.Int32> appointmentId, System.String identifier, Nullable<System.DateTimeOffset> invoiceDate, Nullable<System.DateTimeOffset> invoiceMonth, Nullable<System.Int32> invoiceStatusId, Nullable<System.Int32> invoiceTypeId, Nullable<System.Int32> payableToId, Nullable<System.Int32> claimantId, Nullable<System.Boolean> needsRefresh, Nullable<System.Boolean> needsToBeSentToReferralSource 
, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return InvoiceSearch(companyId, appointmentId, identifier, invoiceDate, invoiceMonth, invoiceStatusId, invoiceTypeId, payableToId, claimantId, needsRefresh, needsToBeSentToReferralSource 
, ref returnValue, adapter);
			}
		}
	
	
		/// <summary>
		/// Calls stored procedure 'InvoiceSearch'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="appointmentId">Input parameter of stored procedure</param>
		/// <param name="identifier">Input parameter of stored procedure</param>
		/// <param name="invoiceDate">Input parameter of stored procedure</param>
		/// <param name="invoiceMonth">Input parameter of stored procedure</param>
		/// <param name="invoiceStatusId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="payableToId">Input parameter of stored procedure</param>
		/// <param name="claimantId">Input parameter of stored procedure</param>
		/// <param name="needsRefresh">Input parameter of stored procedure</param>
		/// <param name="needsToBeSentToReferralSource">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceSearch(System.Int32 companyId, Nullable<System.Int32> appointmentId, System.String identifier, Nullable<System.DateTimeOffset> invoiceDate, Nullable<System.DateTimeOffset> invoiceMonth, Nullable<System.Int32> invoiceStatusId, Nullable<System.Int32> invoiceTypeId, Nullable<System.Int32> payableToId, Nullable<System.Int32> claimantId, Nullable<System.Boolean> needsRefresh, Nullable<System.Boolean> needsToBeSentToReferralSource 
, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[11 + 1];
			parameters[0] = new SqlParameter("@CompanyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@AppointmentId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, appointmentId);
			parameters[2] = new SqlParameter("@Identifier", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, identifier);
			parameters[3] = new SqlParameter("@InvoiceDate", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, invoiceDate);
			parameters[4] = new SqlParameter("@InvoiceMonth", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, invoiceMonth);
			parameters[5] = new SqlParameter("@InvoiceStatusId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, invoiceStatusId);
			parameters[6] = new SqlParameter("@InvoiceTypeId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, invoiceTypeId);
			parameters[7] = new SqlParameter("@PayableToId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, payableToId);
			parameters[8] = new SqlParameter("@ClaimantId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, claimantId);
			parameters[9] = new SqlParameter("@NeedsRefresh", SqlDbType.Bit, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, needsRefresh);
			parameters[10] = new SqlParameter("@NeedsToBeSentToReferralSource", SqlDbType.Bit, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, needsToBeSentToReferralSource);

			parameters[11] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			DataTable toReturn = new DataTable("InvoiceSearch");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[InvoiceSearch]", parameters, toReturn);


			returnValue = (int)parameters[11].Value;
			return toReturn;
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'InvoiceSearch'.
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="appointmentId">Input parameter of stored procedure</param>
		/// <param name="identifier">Input parameter of stored procedure</param>
		/// <param name="invoiceDate">Input parameter of stored procedure</param>
		/// <param name="invoiceMonth">Input parameter of stored procedure</param>
		/// <param name="invoiceStatusId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="payableToId">Input parameter of stored procedure</param>
		/// <param name="claimantId">Input parameter of stored procedure</param>
		/// <param name="needsRefresh">Input parameter of stored procedure</param>
		/// <param name="needsToBeSentToReferralSource">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetInvoiceSearchCallAsQuery( System.Int32 companyId, Nullable<System.Int32> appointmentId, System.String identifier, Nullable<System.DateTimeOffset> invoiceDate, Nullable<System.DateTimeOffset> invoiceMonth, Nullable<System.Int32> invoiceStatusId, Nullable<System.Int32> invoiceTypeId, Nullable<System.Int32> payableToId, Nullable<System.Int32> claimantId, Nullable<System.Boolean> needsRefresh, Nullable<System.Boolean> needsToBeSentToReferralSource 
)
		{
			RetrievalQuery toReturn = new RetrievalQuery( new SqlCommand("[PsychologicalServices].[dbo].[InvoiceSearch]" ) );
			toReturn.Parameters.Add(new SqlParameter("@CompanyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId));
			toReturn.Parameters.Add(new SqlParameter("@AppointmentId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, appointmentId));
			toReturn.Parameters.Add(new SqlParameter("@Identifier", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, identifier));
			toReturn.Parameters.Add(new SqlParameter("@InvoiceDate", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, invoiceDate));
			toReturn.Parameters.Add(new SqlParameter("@InvoiceMonth", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, invoiceMonth));
			toReturn.Parameters.Add(new SqlParameter("@InvoiceStatusId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, invoiceStatusId));
			toReturn.Parameters.Add(new SqlParameter("@InvoiceTypeId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, invoiceTypeId));
			toReturn.Parameters.Add(new SqlParameter("@PayableToId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, payableToId));
			toReturn.Parameters.Add(new SqlParameter("@ClaimantId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, claimantId));
			toReturn.Parameters.Add(new SqlParameter("@NeedsRefresh", SqlDbType.Bit, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, needsRefresh));
			toReturn.Parameters.Add(new SqlParameter("@NeedsToBeSentToReferralSource", SqlDbType.Bit, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, needsToBeSentToReferralSource));

			toReturn.Command.CommandType = CommandType.StoredProcedure;
			return toReturn;
		}
	

		/// <summary>
		/// Calls stored procedure 'OutstandingReports'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="daysOutstanding">Input parameter of stored procedure</param>
		/// <param name="searchStart">Input parameter of stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable OutstandingReports(System.Int32 companyId, Nullable<System.Int32> daysOutstanding, Nullable<System.DateTimeOffset> searchStart)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return OutstandingReports(companyId, daysOutstanding, searchStart,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'OutstandingReports'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="daysOutstanding">Input parameter of stored procedure</param>
		/// <param name="searchStart">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable OutstandingReports(System.Int32 companyId, Nullable<System.Int32> daysOutstanding, Nullable<System.DateTimeOffset> searchStart, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[3];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@daysOutstanding", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, daysOutstanding);
			parameters[2] = new SqlParameter("@searchStart", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, searchStart);

			DataTable toReturn = new DataTable("OutstandingReports");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[OutstandingReports]", parameters, toReturn);

			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'OutstandingReports'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="daysOutstanding">Input parameter of stored procedure</param>
		/// <param name="searchStart">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable OutstandingReports(System.Int32 companyId, Nullable<System.Int32> daysOutstanding, Nullable<System.DateTimeOffset> searchStart, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return OutstandingReports(companyId, daysOutstanding, searchStart, ref returnValue, adapter);
			}
		}
	
	
		/// <summary>
		/// Calls stored procedure 'OutstandingReports'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="daysOutstanding">Input parameter of stored procedure</param>
		/// <param name="searchStart">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable OutstandingReports(System.Int32 companyId, Nullable<System.Int32> daysOutstanding, Nullable<System.DateTimeOffset> searchStart, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[3 + 1];
			parameters[0] = new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId);
			parameters[1] = new SqlParameter("@daysOutstanding", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, daysOutstanding);
			parameters[2] = new SqlParameter("@searchStart", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, searchStart);

			parameters[3] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			DataTable toReturn = new DataTable("OutstandingReports");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[PsychologicalServices].[dbo].[OutstandingReports]", parameters, toReturn);


			returnValue = (int)parameters[3].Value;
			return toReturn;
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'OutstandingReports'.
		/// 
		/// </summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="daysOutstanding">Input parameter of stored procedure</param>
		/// <param name="searchStart">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetOutstandingReportsCallAsQuery( System.Int32 companyId, Nullable<System.Int32> daysOutstanding, Nullable<System.DateTimeOffset> searchStart)
		{
			RetrievalQuery toReturn = new RetrievalQuery( new SqlCommand("[PsychologicalServices].[dbo].[OutstandingReports]" ) );
			toReturn.Parameters.Add(new SqlParameter("@companyId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, companyId));
			toReturn.Parameters.Add(new SqlParameter("@daysOutstanding", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, daysOutstanding));
			toReturn.Parameters.Add(new SqlParameter("@searchStart", SqlDbType.DateTimeOffset, 0, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, searchStart));

			toReturn.Command.CommandType = CommandType.StoredProcedure;
			return toReturn;
		}
	

		#region Included Code

		#endregion
	}
}
