﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace PsychologicalServices.Models.Schedule
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using PsychologicalServices.Models.Addresses;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class PsychometristScheduleTemplate : PsychometristScheduleTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"
<!doctype html>
<html lang=""en"">
<head>
    <title></title>
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
</head>
<body style=""font-family: 'Martel', Helvetica, sans-serif; font-size: 16px;"">
	<table style=""border-collapse: collapse; border-spacing: 0; border-style: solid; border-width: 1px; border-color: #e0e0e0;  color: #444444;"">
		<thead>
		");
            
            #line 19 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"

		var headerCellStyles = "padding: 10px; text-align: left; vertical-align: top; text-transform: uppercase; background-color: #f8f8f8; font-weight: normal; border-style: none none solid none; border-width: 2px; border-color: #d8d8d8;";
		
            
            #line default
            #line hidden
            this.Write("\t\t\t<tr>\r\n\t\t\t\t<th style=\"");
            
            #line 23 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(headerCellStyles));
            
            #line default
            #line hidden
            this.Write("\">Date</th>\r\n\t\t\t\t<th style=\"");
            
            #line 24 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(headerCellStyles));
            
            #line default
            #line hidden
            this.Write("\">Time</th>\r\n\t\t\t\t<th style=\"");
            
            #line 25 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(headerCellStyles));
            
            #line default
            #line hidden
            this.Write("\">Location</th>\r\n\t\t\t\t<th style=\"");
            
            #line 26 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(headerCellStyles));
            
            #line default
            #line hidden
            this.Write("\">Referral Source</th>\r\n\t\t\t\t<th style=\"");
            
            #line 27 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(headerCellStyles));
            
            #line default
            #line hidden
            this.Write("\">Claimant</th>\r\n\t\t\t\t<th style=\"");
            
            #line 28 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(headerCellStyles));
            
            #line default
            #line hidden
            this.Write("\">Info</th>\r\n\t\t\t</tr>\r\n\t\t</thead>\r\n\t\t<tbody>\r\n\t\t");
            
            #line 32 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"

		var bodyCellStyles = "padding: 10px; white-space: nowrap; vertical-align: top; border-style: none none solid none; border-width: 2px; border-color: #d8d8d8;";
		
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 35 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 foreach (var appointment in Model.User.PsychometristAppointments.OrderBy(a => a.AppointmentTime)) {
		var timezone = Model.TimezoneService.GetTimeZoneInfo(Model.DisplayTimezoneId);
		var time = Model.TimezoneService.ConvertTime(appointment.AppointmentTime, timezone);
	
            
            #line default
            #line hidden
            this.Write("\t\t\t<tr>\r\n\t\t\t\t<td style=\"");
            
            #line 40 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(bodyCellStyles));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t\t");
            
            #line 41 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0:dddd}", time)));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t<br>");
            
            #line 42 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0:MMMM d, yyyy}", time)));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td style=\"");
            
            #line 44 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(bodyCellStyles));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t\t");
            
            #line 45 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0:hh:mmtt}", time)));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t<br>");
            
            #line 46 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(appointment.Assessment.AssessmentType.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t");
            
            #line 47 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (appointment.AppointmentStatus.ShowOnSchedule) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<br>");
            
            #line 48 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(appointment.AppointmentStatus.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t");
            
            #line 49 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t");
            
            #line 50 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (appointment.IsCompletion) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<br>Completion\r\n\t\t\t\t\t");
            
            #line 52 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t</td>\r\n\t\t\t\t<td style=\"");
            
            #line 54 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(bodyCellStyles));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t\t");
            
            #line 55 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(appointment.Location.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t");
            
            #line 56 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (!string.IsNullOrWhiteSpace(appointment.Location.Street)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<br>");
            
            #line 57 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(appointment.Location.Street));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t");
            
            #line 58 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t");
            
            #line 59 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (!string.IsNullOrWhiteSpace(appointment.Location.Suite)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<br>");
            
            #line 60 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(appointment.Location.Suite));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t");
            
            #line 61 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t");
            
            #line 62 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (
						!string.IsNullOrWhiteSpace(appointment.Location.City.Name) ||
						!string.IsNullOrWhiteSpace(appointment.Location.City.Province) ||
						!string.IsNullOrWhiteSpace(appointment.Location.PostalCode)
					) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<br>\r\n\t\t\t\t\t");
            
            #line 68 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (!string.IsNullOrWhiteSpace(appointment.Location.City.Name)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t");
            
            #line 69 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(appointment.Location.City.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t");
            
            #line 70 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t");
            
            #line 71 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (!string.IsNullOrWhiteSpace(appointment.Location.City.Province)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t");
            
            #line 72 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(appointment.Location.City.Province));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t");
            
            #line 73 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t");
            
            #line 74 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (!string.IsNullOrWhiteSpace(appointment.Location.PostalCode)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t");
            
            #line 75 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(appointment.Location.PostalCode));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t");
            
            #line 76 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t");
            
            #line 77 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<br><a href=\"");
            
            #line 78 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(appointment.Location.ToGoogleMapsAddressString()));
            
            #line default
            #line hidden
            this.Write("\">Map</a>\r\n\t\t\t\t</td>\r\n\t\t\t\t<td style=\"");
            
            #line 80 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(bodyCellStyles));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t\t");
            
            #line 81 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(appointment.Assessment.ReferralSource.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t</td>\r\n\t\t\t\t<td style=\"");
            
            #line 83 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(bodyCellStyles));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t\t");
            
            #line 84 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 foreach (var claim in appointment.Assessment.Claims) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t<p>\r\n\t\t\t\t\t\t");
            
            #line 86 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(claim.Claimant.FirstName));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t&nbsp;");
            
            #line 87 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(claim.Claimant.LastName.FirstOrDefault()));
            
            #line default
            #line hidden
            this.Write(".\r\n\t\t\t\t\t\t&nbsp;&#45;\r\n\t\t\t\t\t\t&nbsp;");
            
            #line 89 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(claim.Claimant.Age));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t&nbsp;");
            
            #line 90 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(claim.Claimant.Gender));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t</p>\r\n\t\t\t\t\t");
            
            #line 92 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t</td>\r\n\t\t\t\t<td style=\"");
            
            #line 94 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(bodyCellStyles));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t\t<ul style=\"padding: 0; list-style-type: none;\">\r\n\t\t\t\t\t\t");
            
            #line 96 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 foreach (var attributeValue in appointment.Attributes.Where(attributeValue => new[] { 1 }.Contains(attributeValue.Attribute.AttributeType.AttributeTypeId))) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t");
            
            #line 97 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (null == attributeValue.Value || attributeValue.Value.Value) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t<li>\r\n\t\t\t\t\t\t\t\t");
            
            #line 99 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attributeValue.Attribute.Name));
            
            #line default
            #line hidden
            
            #line 99 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (null == attributeValue.Value) { 
            
            #line default
            #line hidden
            
            #line 99 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(": ?"));
            
            #line default
            #line hidden
            
            #line 99 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t</li>\r\n\t\t\t\t\t\t\t");
            
            #line 101 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t");
            
            #line 102 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t");
            
            #line 103 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 foreach (var attributeValue in appointment.Assessment.Attributes.Where(attributeValue => new[] { 5, 6 }.Contains(attributeValue.Attribute.AttributeType.AttributeTypeId))) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t");
            
            #line 104 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (null == attributeValue.Value || attributeValue.Value.Value) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t<li>\r\n\t\t\t\t\t\t\t\t");
            
            #line 106 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(attributeValue.Attribute.Name));
            
            #line default
            #line hidden
            
            #line 106 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 if (null == attributeValue.Value) { 
            
            #line default
            #line hidden
            
            #line 106 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(": ?"));
            
            #line default
            #line hidden
            
            #line 106 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\t</li>\r\n\t\t\t\t\t\t\t");
            
            #line 108 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t");
            
            #line 109 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t</ul>\r\n\t\t\t\t</td>\r\n\t\t\t</tr>\r\n\t");
            
            #line 113 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t</tbody>\r\n\t</table>\r\n</body>\r\n</html>");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Schedule\PsychometristScheduleTemplate.tt"

private global::PsychologicalServices.Models.Schedule.PsychometristScheduleModel _ModelField;

/// <summary>
/// Access the Model parameter of the template.
/// </summary>
private global::PsychologicalServices.Models.Schedule.PsychometristScheduleModel Model
{
    get
    {
        return this._ModelField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool ModelValueAcquired = false;
if (this.Session.ContainsKey("Model"))
{
    this._ModelField = ((global::PsychologicalServices.Models.Schedule.PsychometristScheduleModel)(this.Session["Model"]));
    ModelValueAcquired = true;
}
if ((ModelValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Model");
    if ((data != null))
    {
        this._ModelField = ((global::PsychologicalServices.Models.Schedule.PsychometristScheduleModel)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class PsychometristScheduleTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
