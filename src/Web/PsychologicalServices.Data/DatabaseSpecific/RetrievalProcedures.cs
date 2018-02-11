﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.3.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Collections.Generic;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace PsychologicalServices.Data.DatabaseSpecific
{
	/// <summary>Class which contains the static logic to execute retrieval stored procedures in the database.</summary>
	public static partial class RetrievalProcedures
	{


		/// <summary>Calls stored procedure 'ArbitrationsData'.<br/><br/></summary>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="months">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable ArbitrationsData(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return ArbitrationsData(companyId, months, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'ArbitrationsData'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="months">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable ArbitrationsData(System.Int32 companyId, Nullable<System.Int32> months, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateArbitrationsDataCall(dataAccessProvider, companyId, months))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'ArbitrationsData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetArbitrationsDataCallAsQuery(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(var dataAccessProvider = new DataAccessAdapter())
			{
				return GetArbitrationsDataCallAsQuery(companyId, months, dataAccessProvider);
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'ArbitrationsData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetArbitrationsDataCallAsQuery(System.Int32 companyId, Nullable<System.Int32> months, IDataAccessCore dataAccessProvider)
		{
			return CreateArbitrationsDataCall(dataAccessProvider, companyId, months).ToRetrievalQuery();
		}

		/// <summary>Calls stored procedure 'BookingData'.<br/><br/></summary>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="months">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable BookingData(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return BookingData(companyId, months, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'BookingData'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="months">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable BookingData(System.Int32 companyId, Nullable<System.Int32> months, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateBookingDataCall(dataAccessProvider, companyId, months))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'BookingData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetBookingDataCallAsQuery(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(var dataAccessProvider = new DataAccessAdapter())
			{
				return GetBookingDataCallAsQuery(companyId, months, dataAccessProvider);
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'BookingData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetBookingDataCallAsQuery(System.Int32 companyId, Nullable<System.Int32> months, IDataAccessCore dataAccessProvider)
		{
			return CreateBookingDataCall(dataAccessProvider, companyId, months).ToRetrievalQuery();
		}

		/// <summary>Calls stored procedure 'CancellationData'.<br/><br/></summary>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="months">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CancellationData(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CancellationData(companyId, months, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'CancellationData'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="months">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CancellationData(System.Int32 companyId, Nullable<System.Int32> months, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateCancellationDataCall(dataAccessProvider, companyId, months))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'CancellationData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetCancellationDataCallAsQuery(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(var dataAccessProvider = new DataAccessAdapter())
			{
				return GetCancellationDataCallAsQuery(companyId, months, dataAccessProvider);
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'CancellationData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetCancellationDataCallAsQuery(System.Int32 companyId, Nullable<System.Int32> months, IDataAccessCore dataAccessProvider)
		{
			return CreateCancellationDataCall(dataAccessProvider, companyId, months).ToRetrievalQuery();
		}

		/// <summary>Calls stored procedure 'CompletionData'.<br/><br/></summary>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="months">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CompletionData(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CompletionData(companyId, months, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'CompletionData'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="months">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CompletionData(System.Int32 companyId, Nullable<System.Int32> months, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateCompletionDataCall(dataAccessProvider, companyId, months))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'CompletionData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetCompletionDataCallAsQuery(System.Int32 companyId, Nullable<System.Int32> months)
		{
			using(var dataAccessProvider = new DataAccessAdapter())
			{
				return GetCompletionDataCallAsQuery(companyId, months, dataAccessProvider);
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'CompletionData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="months">Input parameter of stored procedure</param>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetCompletionDataCallAsQuery(System.Int32 companyId, Nullable<System.Int32> months, IDataAccessCore dataAccessProvider)
		{
			return CreateCompletionDataCall(dataAccessProvider, companyId, months).ToRetrievalQuery();
		}

		/// <summary>Calls stored procedure 'CredibilityData'.<br/><br/></summary>
		/// <param name="companyId">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CredibilityData(System.Int32 companyId)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CredibilityData(companyId, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'CredibilityData'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CredibilityData(System.Int32 companyId, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateCredibilityDataCall(dataAccessProvider, companyId))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'CredibilityData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetCredibilityDataCallAsQuery(System.Int32 companyId)
		{
			using(var dataAccessProvider = new DataAccessAdapter())
			{
				return GetCredibilityDataCallAsQuery(companyId, dataAccessProvider);
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'CredibilityData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetCredibilityDataCallAsQuery(System.Int32 companyId, IDataAccessCore dataAccessProvider)
		{
			return CreateCredibilityDataCall(dataAccessProvider, companyId).ToRetrievalQuery();
		}

		/// <summary>Calls stored procedure 'InvoiceableAppointmentData'.<br/><br/></summary>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="invoiceTypeId">Input parameter. </param>
		/// <param name="startSearch">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceableAppointmentData(System.Int32 companyId, Nullable<System.Int32> invoiceTypeId, Nullable<System.DateTimeOffset> startSearch)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return InvoiceableAppointmentData(companyId, invoiceTypeId, startSearch, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'InvoiceableAppointmentData'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="invoiceTypeId">Input parameter. </param>
		/// <param name="startSearch">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceableAppointmentData(System.Int32 companyId, Nullable<System.Int32> invoiceTypeId, Nullable<System.DateTimeOffset> startSearch, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateInvoiceableAppointmentDataCall(dataAccessProvider, companyId, invoiceTypeId, startSearch))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'InvoiceableAppointmentData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="startSearch">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetInvoiceableAppointmentDataCallAsQuery(System.Int32 companyId, Nullable<System.Int32> invoiceTypeId, Nullable<System.DateTimeOffset> startSearch)
		{
			using(var dataAccessProvider = new DataAccessAdapter())
			{
				return GetInvoiceableAppointmentDataCallAsQuery(companyId, invoiceTypeId, startSearch, dataAccessProvider);
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'InvoiceableAppointmentData'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="invoiceTypeId">Input parameter of stored procedure</param>
		/// <param name="startSearch">Input parameter of stored procedure</param>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetInvoiceableAppointmentDataCallAsQuery(System.Int32 companyId, Nullable<System.Int32> invoiceTypeId, Nullable<System.DateTimeOffset> startSearch, IDataAccessCore dataAccessProvider)
		{
			return CreateInvoiceableAppointmentDataCall(dataAccessProvider, companyId, invoiceTypeId, startSearch).ToRetrievalQuery();
		}

		/// <summary>Calls stored procedure 'InvoiceSearch'.<br/><br/></summary>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="appointmentId">Input parameter. </param>
		/// <param name="identifier">Input parameter. </param>
		/// <param name="invoiceDate">Input parameter. </param>
		/// <param name="invoiceMonth">Input parameter. </param>
		/// <param name="invoiceStatusId">Input parameter. </param>
		/// <param name="invoiceTypeId">Input parameter. </param>
		/// <param name="payableToId">Input parameter. </param>
		/// <param name="claimantId">Input parameter. </param>
		/// <param name="needsRefresh">Input parameter. </param>
		/// <param name="needsToBeSentToReferralSource">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceSearch(System.Int32 companyId, Nullable<System.Int32> appointmentId, System.String identifier, Nullable<System.DateTimeOffset> invoiceDate, Nullable<System.DateTimeOffset> invoiceMonth, Nullable<System.Int32> invoiceStatusId, Nullable<System.Int32> invoiceTypeId, Nullable<System.Int32> payableToId, Nullable<System.Int32> claimantId, Nullable<System.Boolean> needsRefresh, Nullable<System.Boolean> needsToBeSentToReferralSource 
)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return InvoiceSearch(companyId, appointmentId, identifier, invoiceDate, invoiceMonth, invoiceStatusId, invoiceTypeId, payableToId, claimantId, needsRefresh, needsToBeSentToReferralSource 
, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'InvoiceSearch'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="appointmentId">Input parameter. </param>
		/// <param name="identifier">Input parameter. </param>
		/// <param name="invoiceDate">Input parameter. </param>
		/// <param name="invoiceMonth">Input parameter. </param>
		/// <param name="invoiceStatusId">Input parameter. </param>
		/// <param name="invoiceTypeId">Input parameter. </param>
		/// <param name="payableToId">Input parameter. </param>
		/// <param name="claimantId">Input parameter. </param>
		/// <param name="needsRefresh">Input parameter. </param>
		/// <param name="needsToBeSentToReferralSource">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable InvoiceSearch(System.Int32 companyId, Nullable<System.Int32> appointmentId, System.String identifier, Nullable<System.DateTimeOffset> invoiceDate, Nullable<System.DateTimeOffset> invoiceMonth, Nullable<System.Int32> invoiceStatusId, Nullable<System.Int32> invoiceTypeId, Nullable<System.Int32> payableToId, Nullable<System.Int32> claimantId, Nullable<System.Boolean> needsRefresh, Nullable<System.Boolean> needsToBeSentToReferralSource 
, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateInvoiceSearchCall(dataAccessProvider, companyId, appointmentId, identifier, invoiceDate, invoiceMonth, invoiceStatusId, invoiceTypeId, payableToId, claimantId, needsRefresh, needsToBeSentToReferralSource 
))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'InvoiceSearch'.</summary>
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
		public static IRetrievalQuery GetInvoiceSearchCallAsQuery(System.Int32 companyId, Nullable<System.Int32> appointmentId, System.String identifier, Nullable<System.DateTimeOffset> invoiceDate, Nullable<System.DateTimeOffset> invoiceMonth, Nullable<System.Int32> invoiceStatusId, Nullable<System.Int32> invoiceTypeId, Nullable<System.Int32> payableToId, Nullable<System.Int32> claimantId, Nullable<System.Boolean> needsRefresh, Nullable<System.Boolean> needsToBeSentToReferralSource 
)
		{
			using(var dataAccessProvider = new DataAccessAdapter())
			{
				return GetInvoiceSearchCallAsQuery(companyId, appointmentId, identifier, invoiceDate, invoiceMonth, invoiceStatusId, invoiceTypeId, payableToId, claimantId, needsRefresh, needsToBeSentToReferralSource 
, dataAccessProvider);
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'InvoiceSearch'.</summary>
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
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetInvoiceSearchCallAsQuery(System.Int32 companyId, Nullable<System.Int32> appointmentId, System.String identifier, Nullable<System.DateTimeOffset> invoiceDate, Nullable<System.DateTimeOffset> invoiceMonth, Nullable<System.Int32> invoiceStatusId, Nullable<System.Int32> invoiceTypeId, Nullable<System.Int32> payableToId, Nullable<System.Int32> claimantId, Nullable<System.Boolean> needsRefresh, Nullable<System.Boolean> needsToBeSentToReferralSource 
, IDataAccessCore dataAccessProvider)
		{
			return CreateInvoiceSearchCall(dataAccessProvider, companyId, appointmentId, identifier, invoiceDate, invoiceMonth, invoiceStatusId, invoiceTypeId, payableToId, claimantId, needsRefresh, needsToBeSentToReferralSource 
).ToRetrievalQuery();
		}

		/// <summary>Calls stored procedure 'OutstandingReports'.<br/><br/></summary>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="daysOutstanding">Input parameter. </param>
		/// <param name="searchStart">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable OutstandingReports(System.Int32 companyId, Nullable<System.Int32> daysOutstanding, Nullable<System.DateTimeOffset> searchStart)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return OutstandingReports(companyId, daysOutstanding, searchStart, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'OutstandingReports'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter. </param>
		/// <param name="daysOutstanding">Input parameter. </param>
		/// <param name="searchStart">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable OutstandingReports(System.Int32 companyId, Nullable<System.Int32> daysOutstanding, Nullable<System.DateTimeOffset> searchStart, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateOutstandingReportsCall(dataAccessProvider, companyId, daysOutstanding, searchStart))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'OutstandingReports'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="daysOutstanding">Input parameter of stored procedure</param>
		/// <param name="searchStart">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetOutstandingReportsCallAsQuery(System.Int32 companyId, Nullable<System.Int32> daysOutstanding, Nullable<System.DateTimeOffset> searchStart)
		{
			using(var dataAccessProvider = new DataAccessAdapter())
			{
				return GetOutstandingReportsCallAsQuery(companyId, daysOutstanding, searchStart, dataAccessProvider);
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'OutstandingReports'.</summary>
		/// <param name="companyId">Input parameter of stored procedure</param>
		/// <param name="daysOutstanding">Input parameter of stored procedure</param>
		/// <param name="searchStart">Input parameter of stored procedure</param>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetOutstandingReportsCallAsQuery(System.Int32 companyId, Nullable<System.Int32> daysOutstanding, Nullable<System.DateTimeOffset> searchStart, IDataAccessCore dataAccessProvider)
		{
			return CreateOutstandingReportsCall(dataAccessProvider, companyId, daysOutstanding, searchStart).ToRetrievalQuery();
		}

		/// <summary>Creates the call object for the call 'ArbitrationsData' to stored procedure 'ArbitrationsData'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter</param>
		/// <param name="months">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateArbitrationsDataCall(IDataAccessCore dataAccessProvider, System.Int32 companyId, Nullable<System.Int32> months)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[PsychologicalServices].[dbo].[ArbitrationsData]", "ArbitrationsData")
							.AddParameter("@companyId", "Int", 0, ParameterDirection.Input, true, 10, 0, companyId)
							.AddParameter("@months", "Int", 0, ParameterDirection.Input, true, 10, 0, months);
		}

		/// <summary>Creates the call object for the call 'BookingData' to stored procedure 'BookingData'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter</param>
		/// <param name="months">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateBookingDataCall(IDataAccessCore dataAccessProvider, System.Int32 companyId, Nullable<System.Int32> months)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[PsychologicalServices].[dbo].[BookingData]", "BookingData")
							.AddParameter("@companyId", "Int", 0, ParameterDirection.Input, true, 10, 0, companyId)
							.AddParameter("@months", "Int", 0, ParameterDirection.Input, true, 10, 0, months);
		}

		/// <summary>Creates the call object for the call 'CancellationData' to stored procedure 'CancellationData'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter</param>
		/// <param name="months">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateCancellationDataCall(IDataAccessCore dataAccessProvider, System.Int32 companyId, Nullable<System.Int32> months)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[PsychologicalServices].[dbo].[CancellationData]", "CancellationData")
							.AddParameter("@companyId", "Int", 0, ParameterDirection.Input, true, 10, 0, companyId)
							.AddParameter("@months", "Int", 0, ParameterDirection.Input, true, 10, 0, months);
		}

		/// <summary>Creates the call object for the call 'CompletionData' to stored procedure 'CompletionData'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter</param>
		/// <param name="months">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateCompletionDataCall(IDataAccessCore dataAccessProvider, System.Int32 companyId, Nullable<System.Int32> months)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[PsychologicalServices].[dbo].[CompletionData]", "CompletionData")
							.AddParameter("@companyId", "Int", 0, ParameterDirection.Input, true, 10, 0, companyId)
							.AddParameter("@months", "Int", 0, ParameterDirection.Input, true, 10, 0, months);
		}

		/// <summary>Creates the call object for the call 'CredibilityData' to stored procedure 'CredibilityData'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateCredibilityDataCall(IDataAccessCore dataAccessProvider, System.Int32 companyId)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[PsychologicalServices].[dbo].[CredibilityData]", "CredibilityData")
							.AddParameter("@companyId", "Int", 0, ParameterDirection.Input, true, 10, 0, companyId);
		}

		/// <summary>Creates the call object for the call 'InvoiceableAppointmentData' to stored procedure 'InvoiceableAppointmentData'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter</param>
		/// <param name="invoiceTypeId">Input parameter</param>
		/// <param name="startSearch">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateInvoiceableAppointmentDataCall(IDataAccessCore dataAccessProvider, System.Int32 companyId, Nullable<System.Int32> invoiceTypeId, Nullable<System.DateTimeOffset> startSearch)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[PsychologicalServices].[dbo].[InvoiceableAppointmentData]", "InvoiceableAppointmentData")
							.AddParameter("@companyId", "Int", 0, ParameterDirection.Input, true, 10, 0, companyId)
							.AddParameter("@invoiceTypeId", "Int", 0, ParameterDirection.Input, true, 10, 0, invoiceTypeId)
							.AddParameter("@startSearch", "DateTimeOffset", 0, ParameterDirection.Input, true, 0, 0, startSearch);
		}

		/// <summary>Creates the call object for the call 'InvoiceSearch' to stored procedure 'InvoiceSearch'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter</param>
		/// <param name="appointmentId">Input parameter</param>
		/// <param name="identifier">Input parameter</param>
		/// <param name="invoiceDate">Input parameter</param>
		/// <param name="invoiceMonth">Input parameter</param>
		/// <param name="invoiceStatusId">Input parameter</param>
		/// <param name="invoiceTypeId">Input parameter</param>
		/// <param name="payableToId">Input parameter</param>
		/// <param name="claimantId">Input parameter</param>
		/// <param name="needsRefresh">Input parameter</param>
		/// <param name="needsToBeSentToReferralSource">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateInvoiceSearchCall(IDataAccessCore dataAccessProvider, System.Int32 companyId, Nullable<System.Int32> appointmentId, System.String identifier, Nullable<System.DateTimeOffset> invoiceDate, Nullable<System.DateTimeOffset> invoiceMonth, Nullable<System.Int32> invoiceStatusId, Nullable<System.Int32> invoiceTypeId, Nullable<System.Int32> payableToId, Nullable<System.Int32> claimantId, Nullable<System.Boolean> needsRefresh, Nullable<System.Boolean> needsToBeSentToReferralSource 
)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[PsychologicalServices].[dbo].[InvoiceSearch]", "InvoiceSearch")
							.AddParameter("@CompanyId", "Int", 0, ParameterDirection.Input, true, 10, 0, companyId)
							.AddParameter("@AppointmentId", "Int", 0, ParameterDirection.Input, true, 10, 0, appointmentId)
							.AddParameter("@Identifier", "NVarChar", 20, ParameterDirection.Input, true, 0, 0, identifier)
							.AddParameter("@InvoiceDate", "DateTimeOffset", 0, ParameterDirection.Input, true, 0, 0, invoiceDate)
							.AddParameter("@InvoiceMonth", "DateTimeOffset", 0, ParameterDirection.Input, true, 0, 0, invoiceMonth)
							.AddParameter("@InvoiceStatusId", "Int", 0, ParameterDirection.Input, true, 10, 0, invoiceStatusId)
							.AddParameter("@InvoiceTypeId", "Int", 0, ParameterDirection.Input, true, 10, 0, invoiceTypeId)
							.AddParameter("@PayableToId", "Int", 0, ParameterDirection.Input, true, 10, 0, payableToId)
							.AddParameter("@ClaimantId", "Int", 0, ParameterDirection.Input, true, 10, 0, claimantId)
							.AddParameter("@NeedsRefresh", "Bit", 0, ParameterDirection.Input, true, 0, 0, needsRefresh)
							.AddParameter("@NeedsToBeSentToReferralSource", "Bit", 0, ParameterDirection.Input, true, 0, 0, needsToBeSentToReferralSource) 
;
		}

		/// <summary>Creates the call object for the call 'OutstandingReports' to stored procedure 'OutstandingReports'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="companyId">Input parameter</param>
		/// <param name="daysOutstanding">Input parameter</param>
		/// <param name="searchStart">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateOutstandingReportsCall(IDataAccessCore dataAccessProvider, System.Int32 companyId, Nullable<System.Int32> daysOutstanding, Nullable<System.DateTimeOffset> searchStart)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[PsychologicalServices].[dbo].[OutstandingReports]", "OutstandingReports")
							.AddParameter("@companyId", "Int", 0, ParameterDirection.Input, true, 10, 0, companyId)
							.AddParameter("@daysOutstanding", "Int", 0, ParameterDirection.Input, true, 10, 0, daysOutstanding)
							.AddParameter("@searchStart", "DateTimeOffset", 0, ParameterDirection.Input, true, 0, 0, searchStart);
		}


		#region Included Code

		#endregion
	}
}
