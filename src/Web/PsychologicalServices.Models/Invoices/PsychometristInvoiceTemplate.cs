﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 12.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace PsychologicalServices.Models.Invoices
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class PsychometristInvoiceTemplate : PsychometristInvoiceTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n<!doctype html>\r\n<html lang=\"en\">\r\n<head>\r\n    <title></title>\r\n    <meta chars" +
                    "et=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scal" +
                    "e=1, maximum-scale=1, minimum-scale=1, user-scalable=no\" />\r\n\t<style>\r\n\t\tbody {\r" +
                    "\n\t\t\tfont-family: Arial, sans-serif;\r\n\t\t\t\r\n\t\t\tfont-size: 12pt;\r\n\t\t}\r\n\t\t\r\n\t\ttable " +
                    "{\r\n\t\t\tfont-family:\"Times New Roman\",serif;\r\n\t\t\tborder-collapse: collapse;\r\n\t\t\tma" +
                    "rgin-left: auto;\r\n\t\t\tmargin-right: auto;\r\n\t\t\twidth: 80%;\r\n\t\t}\r\n\t\t\r\n\t\tth {\r\n\t\t\tbo" +
                    "rder-width: 1px;\r\n\t\t\tborder-style: solid;\r\n\t\t\tborder-color: #000;\r\n\t\t\tpadding: 5" +
                    "px;\r\n\t\t\tvertical-align: top;\r\n\t\t}\r\n\r\n\t\ttd {\r\n\t\t\tborder-width: 1px;\r\n\t\t\tborder-st" +
                    "yle: none solid none solid;\r\n\t\t\tborder-color: #000;\r\n\t\t\tpadding: 5px;\r\n\t\t\tvertic" +
                    "al-align: top;\r\n\t\t}\r\n\t\t\r\n\t\t.label {\r\n\t\t\tfont-weight: bold;\r\n\t\t\tfont-style: itali" +
                    "c;\r\n\t\t\twidth: 25%;\r\n\t\t}\r\n\t\t\r\n\t\t.title {\r\n\t\t\tfont-size: 24pt;\r\n\t\t\ttext-decoration" +
                    ": underline;\r\n\t\t\tline-height: 0.8;\r\n\t\t}\r\n\t\t.subtitle {\r\n\t\t\tfont-size: 16pt;\r\n\t\t\t" +
                    "text-align: right;\r\n\t\t\tline-height: 0.8;\r\n\t\t}\r\n\t\t.referral-source-address {\r\n\t\t\t" +
                    "font-size: 12pt;\r\n\t\t\tline-height: 1.25;\r\n\t\t\tmargin-left: 10%;\r\n\t\t}\r\n\t\t.message {" +
                    "\r\n\t\t\ttext-align: center;\r\n\t\t\tline-height: 1;\r\n\t\t}\r\n\r\n\t\t.invoice-data {\r\n\t\t\tfont-" +
                    "size: 12pt;\r\n\t\t\tfont-weight: bold;\r\n\t\t\tline-height: 1;\r\n\t\t\tmargin-left: 55%;\r\n\t\t" +
                    "}\r\n\t\t\r\n\t\t.invoice-amount {\r\n\t\t\ttext-align: right;\r\n\t\t\tpadding-right: 5px;\r\n\t\t\twi" +
                    "dth: 5%;\r\n\t\t\tfont-weight: bold;\r\n\t\t}\r\n\r\n\t\t.summary-row td {\r\n\t\t\ttext-align: righ" +
                    "t;\r\n\t\t}\r\n\r\n\t\t.summary-row .description {\r\n\t\t\tborder-style: none;\r\n\t\t}\r\n\r\n\t\t.summ" +
                    "ary-row .invoice-amount {\r\n\t\t\tborder-style: none solid none solid;\r\n\t\t}\r\n\r\n\t\t.su" +
                    "mmary-row.subtotal .description {\r\n\t\t\tborder-style: solid none none none;\r\n\t\t}\r\n" +
                    "\r\n\t\t.summary-row.subtotal .invoice-amount {\r\n\t\t\tborder-style: solid solid none s" +
                    "olid;\r\n\t\t}\r\n\r\n\t\t.summary-row.total .description {\r\n\t\t\tfont-weight: bold;\r\n\t\t}\r\n\r" +
                    "\n\t\t.summary-row.total .invoice-amount {\r\n\t\t\tborder-width: 3px;\r\n\t\t\tborder-style:" +
                    " solid;\r\n\t\t}\r\n\t\t\r\n\t</style>\r\n</head>\r\n<body>\r\n\t");
            
            #line 118 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"

		var psychometrist = Model.PayableTo;
		var company = Model.Appointments.First().Appointment.Assessment.Company;
	
            
            #line default
            #line hidden
            this.Write("\r\n\t<header>\r\n\t\t<h1 class=\"title\">\r\n\t\t\t");
            
            #line 125 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0} {1}", psychometrist.FirstName, psychometrist.LastName)));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t</h1>\r\n\t\t<p>\r\n\t\t\t");
            
            #line 128 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 if (null != psychometrist.Address) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t");
            
            #line 129 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 if (!string.IsNullOrWhiteSpace(psychometrist.Address.Street)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t");
            
            #line 130 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(psychometrist.Address.Street));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t");
            
            #line 131 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t");
            
            #line 132 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(psychometrist.Address.Street));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t");
            
            #line 133 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 if (!string.IsNullOrWhiteSpace(psychometrist.Address.Suite)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<br>");
            
            #line 134 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(psychometrist.Address.Suite));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t");
            
            #line 135 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t");
            
            #line 136 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 if (null != psychometrist.Address.City) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<br>");
            
            #line 137 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(psychometrist.Address.City.Name));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 137 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(psychometrist.Address.City.Province));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t");
            
            #line 138 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t");
            
            #line 139 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 if (!string.IsNullOrWhiteSpace(psychometrist.Address.PostalCode)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<br>");
            
            #line 140 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(psychometrist.Address.PostalCode));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t");
            
            #line 141 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 142 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t<a href=\"mailto:");
            
            #line 143 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(psychometrist.Email));
            
            #line default
            #line hidden
            this.Write("\">");
            
            #line 143 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(psychometrist.Email));
            
            #line default
            #line hidden
            this.Write("</a>\r\n\t\t</p>\r\n\t</header>\r\n\r\n\t<p class=\"invoice-data\">\r\n\t\tInvoice Number:&nbsp;");
            
            #line 148 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Identifier));
            
            #line default
            #line hidden
            this.Write("\r\n\t</p>\r\n\t<p class=\"invoice-data\">\r\n\t\tDate of Invoice:&nbsp;");
            
            #line 151 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0:MMMM d, yyyy}", Model.InvoiceDate)));
            
            #line default
            #line hidden
            this.Write("\r\n\t</p>\r\n\t\r\n\t<p class=\"bill-to\">\r\n\t\tBill To:\r\n\t\t<br>");
            
            #line 156 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t");
            
            #line 157 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 if (null != company.Address) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 158 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 if (!string.IsNullOrWhiteSpace(company.Address.Street)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t<br>");
            
            #line 159 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.Street));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t");
            
            #line 160 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 161 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 if (!string.IsNullOrWhiteSpace(company.Address.Suite)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t<br>");
            
            #line 162 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.Suite));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t");
            
            #line 163 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 164 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 if (null != company.Address.City) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t<br>");
            
            #line 165 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.City.Name));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 165 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.City.Province));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t");
            
            #line 166 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 167 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 if (!string.IsNullOrWhiteSpace(company.Address.PostalCode)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t<br>");
            
            #line 168 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.PostalCode));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t");
            
            #line 169 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 170 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t</p>\r\n\r\n\t<table>\r\n\t\t<thead>\r\n\t\t\t<tr>\r\n\t\t\t\t<th>Patient Name</th>\r\n\t\t\t\t<th>Assessm" +
                    "ent Date</th>\r\n\t\t\t\t<th>Description</th>\r\n\t\t\t\t<th>Assessment Centre</th>\r\n\t\t\t\t<th" +
                    ">Amount</th>\r\n\t\t\t</tr>\r\n\t\t</thead>\r\n\t\t<tbody>\r\n\t\t\t");
            
            #line 184 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"

				var subtotal = 0.0m;

				foreach (var invoiceAppointment in Model.Appointments)
				{
					var appointment = invoiceAppointment.Appointment;
					var firstClaim = appointment.Assessment.Claims.OrderByDescending(claim => claim.DateOfLoss.HasValue ? claim.DateOfLoss.Value : DateTime.MinValue).FirstOrDefault();

					foreach (var line in invoiceAppointment.Lines)
					{
						subtotal += line.Amount;
			
            
            #line default
            #line hidden
            this.Write("\t\t\t<tr>\r\n\t\t\t\t<td>");
            
            #line 197 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(firstClaim != null ? string.Format("{0} {1}", firstClaim.Claimant.FirstName, firstClaim.Claimant.LastName) : ""));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t<td>");
            
            #line 198 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0:dddd, MMMM d, yyyy}", appointment.AppointmentTime)));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t<td>");
            
            #line 199 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(line.Description));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t<td>");
            
            #line 200 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(appointment.Location.Name));
            
            #line default
            #line hidden
            this.Write("</td>\r\n\t\t\t\t<td class=\"invoice-amount\">\r\n\t\t\t\t\t");
            
            #line 202 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0:$#,##0.00}", line.Amount / 100)));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t</td>\r\n\t\t\t</tr>\r\n\t\t\t");
            
            #line 205 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"

					}
				}
			
            
            #line default
            #line hidden
            this.Write("\t\t\t<tr class=\"summary-row subtotal\">\r\n\t\t\t\t<td class=\"description\" colspan=\"4\">Sub" +
                    "total</td>\r\n\t\t\t\t<td class=\"invoice-amount\">\r\n\t\t\t\t\t");
            
            #line 212 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0:$#,##0.00}", subtotal / 100)));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t</td>\r\n\t\t\t</tr>\r\n\t\t\t<tr class=\"summary-row tax\">\r\n\t\t\t\t<td class=\"descriptio" +
                    "n\" colspan=\"4\">HST</td>\r\n\t\t\t\t<td class=\"invoice-amount\">\r\n\t\t\t\t\t");
            
            #line 218 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0:$#,##0.00}", subtotal * Model.TaxRate / 100)));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t</td>\r\n\t\t\t</tr>\r\n\t\t\t<tr class=\"summary-row total\">\r\n\t\t\t\t<td class=\"descript" +
                    "ion\" colspan=\"4\">Total</td>\r\n\t\t\t\t<td class=\"invoice-amount\">\r\n\t\t\t\t\t");
            
            #line 224 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0:$#,##0.00}", Model.Total / 100)));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t</td>\r\n\t\t\t</tr>\r\n\t\t</tbody>\r\n\t</table>\r\n</body>\r\n</html>");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\Users\DEY9875\Documents\Visual Studio 2013\Projects\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\PsychometristInvoiceTemplate.tt"

private global::PsychologicalServices.Models.Invoices.Invoice _ModelField;

/// <summary>
/// Access the Model parameter of the template.
/// </summary>
private global::PsychologicalServices.Models.Invoices.Invoice Model
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
    this._ModelField = ((global::PsychologicalServices.Models.Invoices.Invoice)(this.Session["Model"]));
    ModelValueAcquired = true;
}
if ((ModelValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Model");
    if ((data != null))
    {
        this._ModelField = ((global::PsychologicalServices.Models.Invoices.Invoice)(data));
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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public class PsychometristInvoiceTemplateBase
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
