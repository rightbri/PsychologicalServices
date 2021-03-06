﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
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
    
    #line 1 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ConsultingInvoiceTemplate : ConsultingInvoiceTemplateBase
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
                    "e=1, maximum-scale=1, minimum-scale=1, user-scalable=no\" />\r\n\t<!--\r\n\t<link href=" +
                    "\"https://fonts.googleapis.com/css?family=Martel\" rel=\"stylesheet\">\r\n\t-->\r\n    <s" +
                    "tyle>\r\n\t\tbody {\r\n\t\t\tfont-family: \'Martel\', serif;\r\n\t\t\t\r\n\t\t\tfont-size: 12pt;\r\n\t\t}" +
                    "\r\n\t\t\r\n\t\ttable {\r\n\t\t\tfont-family:\"Times New Roman\",serif;\r\n\t\t\tborder-collapse: co" +
                    "llapse;\r\n\t\t\tmargin-left: auto;\r\n\t\t\tmargin-right: auto;\r\n\t\t\twidth: 80%;\r\n\t\t}\r\n\t\t\r" +
                    "\n\t\ttd {\r\n\t\t\tborder-width: 1px 3px;\r\n\t\t\tborder-style: solid;\r\n\t\t\tborder-color: #0" +
                    "00;\r\n\t\t\tpadding: 1px 5px;\r\n\t\t\tvertical-align: top;\r\n\t\t}\r\n\r\n\t\t.label {\r\n\t\t\tfont-w" +
                    "eight: bold;\r\n\t\t\tfont-style: italic;\r\n\t\t\twidth: 25%;\r\n\t\t}\r\n\t\t\r\n\t\t.title {\r\n\t\t\tfo" +
                    "nt-size: 24pt;\r\n\t\t\ttext-decoration: underline;\r\n\t\t\tline-height: 0.8;\r\n\t\t}\r\n\t\t.su" +
                    "btitle {\r\n\t\t\tfont-size: 16pt;\r\n\t\t\ttext-align: right;\r\n\t\t\tline-height: 0.8;\r\n\t\t}\r" +
                    "\n\t\t.referral-source-address {\r\n\t\t\tfont-size: 12pt;\r\n\t\t\tline-height: 1.25;\r\n\t\t\tma" +
                    "rgin-left: 10%;\r\n\t\t}\r\n\t\t.message {\r\n\t\t\ttext-align: center;\r\n\t\t\tline-height: 1;\r\n" +
                    "\t\t}\r\n\t\t\r\n\t\tfooter {\r\n\t\t\ttext-align: center;\r\n\t\t}\r\n\t\t\r\n\t\t.invoice-title {\r\n\t\t\tfon" +
                    "t-size: 16pt;\r\n\t\t\ttext-transform: uppercase;\r\n\t\t\tfont-weight: bold;\r\n\t\t\ttext-ali" +
                    "gn: center;\r\n\t\t}\r\n\t\t\r\n\t\t.invoice-data {\r\n\t\t\tfont-size: 12pt;\r\n\t\t\tfont-weight: bo" +
                    "ld;\r\n\t\t\tline-height: 1;\r\n\t\t\tmargin-left: 55%;\r\n\t\t}\r\n\t\t\r\n\t\t.invoice-amount {\r\n\t\t\t" +
                    "text-align: right;\r\n\t\t\tpadding-right: 5px;\r\n\t\t\twidth: 5%;\r\n\t\t}\r\n\t\t\r\n\t\t.spacer {\r" +
                    "\n\t\t\tbackground-color: #f5f5f5;\r\n\t\t\tborder-width: 3px;\r\n\t\t}\r\n\t\t\r\n\t\t.separator-top" +
                    " {\r\n\t\t\tborder-top-width: 3px;\r\n\t\t}\r\n\t\t.total td {\r\n\t\t\tborder-width: 3px;\r\n\t\t}\r\n\t" +
                    "\t\r\n\t\ttr:first-child td,\r\n\t\ttr:last-child td {\r\n\t\t\tborder-width: 3px;\r\n\t\t}\r\n\r\n\t\t." +
                    "claims {\r\n\t\t\tmargin-left: 0;\r\n\t\t}\r\n\r\n\t\t.claims th {\r\n\t\t\ttext-align: left;\r\n\t\t\tfo" +
                    "nt-weight: normal;\r\n\t\t}\r\n\t\t\r\n\t\t.claims td,\r\n\t\t.claims tr:first-child td,\r\n\t\t.cla" +
                    "ims tr:last-child td {\r\n\t\t\tborder-width: 0;\r\n\t\t}\r\n\t\t\r\n\t\t/* Sticky footer styles\r" +
                    "\n\t\t-------------------------------------------------- */\r\n\t\thtml {\r\n\t\t  position" +
                    ": relative;\r\n\t\t  min-height: 100%;\r\n\t\t}\r\n\t\tbody {\r\n\t\t  /* Margin bottom by foote" +
                    "r height */\r\n\t\t  margin-bottom: 75px;\r\n\t\t}\r\n\r\n\t\tfooter {\r\n\t\t  position: absolute" +
                    ";\r\n\t\t  bottom: 0;\r\n\t\t  width: 100%;\r\n\t\t  /* Set the fixed height of the footer h" +
                    "ere */\r\n\t\t  height: 75px;\r\n\t\t  border-width: 1px 0 0 0;\r\n\t\t  border-style: solid" +
                    ";\r\n\t\t  border-color: #666;\r\n\t\t  color: #666;\r\n\t\t}\r\n\r\n\t\t.footer > div > div {\r\n\t\t" +
                    "\tpadding-top: 20px;   \r\n\t\t}\r\n\t\t\r\n\t</style>\r\n</head>\r\n<body>\r\n\t");
            
            #line 153 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"

		var consultingAgreement = Model.LineGroups.First(lineGroup => null != lineGroup.ConsultingAgreement).ConsultingAgreement;
		var company = Model.PayableTo.Company;
	
            
            #line default
            #line hidden
            this.Write("\t<header>\r\n\t\t<h1 class=\"title\">\r\n\t\t\t");
            
            #line 159 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t</h1>\r\n\t</header>\r\n\r\n\t<p class=\"bill-to-address\">\r\n\t\t");
            
            #line 164 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
 var billToReferralSource = consultingAgreement.BillToReferralSource; 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 165 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(billToReferralSource.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t");
            
            #line 166 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
 if (null != billToReferralSource.Address) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t<br />");
            
            #line 167 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(billToReferralSource.Address.Street));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t");
            
            #line 168 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
 if (!string.IsNullOrWhiteSpace(billToReferralSource.Address.Suite)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t<br />");
            
            #line 169 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(billToReferralSource.Address.Suite));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t");
            
            #line 170 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t<br />");
            
            #line 171 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(billToReferralSource.Address.City.Name));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 171 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(billToReferralSource.Address.City.Province));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 171 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(billToReferralSource.Address.PostalCode));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t");
            
            #line 172 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t<br />&nbsp;\r\n\t</p>\r\n\r\n\t<p class=\"invoice-data\">\r\n\t\tInvoice Number:&nbsp;");
            
            #line 177 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Identifier));
            
            #line default
            #line hidden
            this.Write("\r\n\t</p>\r\n\t<p class=\"invoice-data\">\r\n\t\tDate of Invoice:&nbsp;");
            
            #line 180 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{Model.InvoiceDate:MMMM d, yyyy}"));
            
            #line default
            #line hidden
            this.Write("\r\n\t</p>\r\n\t\r\n\t<section>\r\n\t\r\n\t\t<p class=\"invoice-title\">Invoice For Services</p>\r\n\t" +
                    "\t\r\n\t\t<table>\r\n\t\t\t<tbody>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td class=\"label\">Bill to:</td>\r\n\t\t\t\t\t<" +
                    "td colspan=\"3\">\r\n\t\t\t\t\t\t");
            
            #line 192 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(billToReferralSource.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t</tr>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td colspan=\"4\" class=\"spacer\">&nbsp;</td" +
                    ">\r\n\t\t\t\t</tr>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td class=\"label\">\r\n\t\t\t\t\t\tPlease Remit<br />Payment" +
                    " to:\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td colspan=\"1\">\r\n\t\t\t\t\t\t");
            
            #line 203 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t<br />");
            
            #line 204 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.Street));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t");
            
            #line 205 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
 if (!string.IsNullOrWhiteSpace(company.Address.Suite)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t<br />");
            
            #line 206 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.Suite));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t");
            
            #line 207 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t<br />");
            
            #line 208 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.City.Name));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 208 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.City.Province));
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 208 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.PostalCode));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t<br />&nbsp;\r\n\t\t\t\t\t</td>\r\n\t\t\t\t\t<td colspan=\"2\">\r\n\t\t\t\t\t\tOffice No.: ");
            
            #line 212 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Phone));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t<br />Email: <a href=\"mailto:");
            
            #line 213 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Email));
            
            #line default
            #line hidden
            this.Write("\">\r\n\t\t\t\t\t\t\t");
            
            #line 214 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Email));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t</a>\r\n\t\t\t\t\t\t<br />&nbsp;\r\n\t\t\t\t\t</td>\r\n\t\t\t\t</tr>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td colsp" +
                    "an=\"4\" class=\"spacer\">&nbsp;</td>\r\n\t\t\t\t</tr>\r\n\r\n\t\t\t\t");
            
            #line 223 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"

				for (var i = 0; i < Model.LineGroups.Count(); i++)
				{
					var lineGroup = Model.LineGroups.ElementAt(i);
				
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t<td class=\"label\"></td>\r\n\t\t\t\t\t\t<td colspan=\"3\">\r\n\t\t\t\t\t\t\t");
            
            #line 231 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(lineGroup.Description));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t</td>\r\n\t\t\t\t\t</tr>\r\n\t\t\t\t");
            
            #line 234 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"

					for (var j = 0; j < lineGroup.Lines.Count(); j++)
					{
						var line = lineGroup.Lines.ElementAt(j);
					
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t<td class=\"label\">&nbsp;</td>\r\n\t\t\t\t\t\t\t<td colspan=\"2\">\r\n\t\t\t\t\t\t" +
                    "\t\t");
            
            #line 242 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(line.Description));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t<td class=\"invoice-amount\">\r\n\t\t\t\t\t\t\t\t");
            
            #line 245 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{(line.Amount / 100.0m):$#,##0.00}"));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t</tr>\r\n\t\t\t\t\t");
            
            #line 248 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"

					}
				}
				
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\r\n\t\t\t\t");
            
            #line 253 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"

					var subtotal = Model.Subtotal;
				
            
            #line default
            #line hidden
            this.Write("\t\t\t\t<tr>\r\n\t\t\t\t\t<td>&nbsp;</td>\r\n\t\t\t\t\t<td colspan=\"2\">Subtotal</td>\r\n\t\t\t\t\t<td clas" +
                    "s=\"invoice-amount separator-top\">\r\n\t\t\t\t\t\t");
            
            #line 260 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture($"{(subtotal / 100.0m):$#,##0.00}"));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t</tr>\r\n\t\t\t\t<tr>\r\n\t\t\t\t\t<td>&nbsp;</td>\r\n\t\t\t\t\t<td colspan=\"2\">+H." +
                    "S.T.</td>\r\n\t\t\t\t\t<td class=\"invoice-amount\">\r\n\t\t\t\t\t\t");
            
            #line 267 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0:$#,##0.00}", ((subtotal * Model.TaxRate) / 100.0m))));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t</tr>\r\n\t\t\t\t<tr class=\"invoice-amount total\">\r\n\t\t\t\t\t<td class=\"l" +
                    "abel\" colspan=\"3\">Total Invoice Amount:</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
            
            #line 273 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("{0:$#,##0.00}", Model.Total / 100.0m)));
            
            #line default
            #line hidden
            this.Write(@"
					</td>
				</tr>

				<tr>
					<td colspan=""4"">&nbsp;</td>
				</tr>
			</tbody>
		</table>
	</section>
	
	<section>
		<p class=""message"">
			Thank you for your business.
			<br />Payment upon receipt would be appreciated.
		</p>
	</section>

	<br />
	
	<section>
		<p class=""message"">
			H.S.T. Number ");
            
            #line 295 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.TaxId));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t</p>\r\n\t</section>\r\n\t\r\n\t<br />\r\n\t\r\n\t<footer>\r\n\t\t<div>\r\n\t\t\t<div>\r\n\t\t\t\t<p>\r\n\t\t\t\t" +
                    "\t");
            
            #line 305 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.Street));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t");
            
            #line 306 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
 if (!string.IsNullOrWhiteSpace(company.Address.Suite)) { 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t~ ");
            
            #line 307 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.Suite));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t");
            
            #line 308 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t~ ");
            
            #line 309 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.City.Name));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t~ ");
            
            #line 310 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.City.Province));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t\t~ ");
            
            #line 311 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Address.PostalCode));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t\t<br />Phone:&nbsp;");
            
            #line 312 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(company.Phone));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t</p>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</footer>\r\n\t\r\n</body>\r\n</html>");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\Users\brian\Documents\GitHub\PsychologicalServices\src\Web\PsychologicalServices.Models\Invoices\ConsultingInvoiceTemplate.tt"

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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class ConsultingInvoiceTemplateBase
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
