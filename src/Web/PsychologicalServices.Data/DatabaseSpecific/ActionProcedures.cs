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

namespace PsychologicalServices.Data.DatabaseSpecific
{
	/// <summary>
	/// Class which contains the static logic to execute action stored procedures in the database.
	/// </summary>
	public partial class ActionProcedures
	{
		/// <summary>
		/// private CTor so no instance can be created.
		/// </summary>
		private ActionProcedures()
		{
		}

	
		/// <summary>
		/// Delegate definition for stored procedure 'DeleteAssessment' to be used in combination of a UnitOfWork2 object. 
		/// </summary>
		public delegate int DeleteAssessmentCallBack(System.Int32 assessmentId, DataAccessAdapter adapter);

		/// <summary>
		/// Calls stored procedure 'DeleteAssessment'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="assessmentId">Input parameter of stored procedure</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int DeleteAssessment(System.Int32 assessmentId)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter())
			{
				return DeleteAssessment(assessmentId,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'DeleteAssessment'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="assessmentId">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int DeleteAssessment(System.Int32 assessmentId, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[1];
			parameters[0] = new SqlParameter("@AssessmentId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, assessmentId);

			int toReturn = adapter.CallActionStoredProcedure("[PsychologicalServices].[dbo].[DeleteAssessment]", parameters);

			return toReturn;
		}
		

		/// <summary>
		/// Calls stored procedure 'DeleteAssessment'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="assessmentId">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int DeleteAssessment(System.Int32 assessmentId, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter())
			{
				return DeleteAssessment(assessmentId, ref returnValue, adapter);
			}
		}

		
		/// <summary>
		/// Calls stored procedure 'DeleteAssessment'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="assessmentId">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int DeleteAssessment(System.Int32 assessmentId, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[1 + 1];
			parameters[0] = new SqlParameter("@AssessmentId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "",  DataRowVersion.Current, assessmentId);

			parameters[1] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			int toReturn = adapter.CallActionStoredProcedure("[PsychologicalServices].[dbo].[DeleteAssessment]", parameters);

			
			returnValue = (int)parameters[1].Value;
			return toReturn;
		}
	

		#region Included Code

		#endregion
	}
}
