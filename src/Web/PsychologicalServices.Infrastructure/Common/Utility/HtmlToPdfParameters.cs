using System;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class HtmlToPdfParameters
    {
        /// <summary>
        /// Timeout for PDF generation
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// A4, Letter, etc.
        /// </summary>
        public string PageSize { get; set; }

        public string Proxy { get; set; }

        /// <summary>
        /// Milliseconds to wait for javascript to run
        /// </summary>
        public int? JavascriptDelay { get; set; }

        /*
         * https://wkhtmltopdf.org/usage/wkhtmltopdf.txt
         * 
         * bool GrayScale   //--grayscale
         * int ImageDpi     //--image-dpi <int>
         * int ImageQuality //--image-quality <int>
         * double MarginBottom //--margin-bottom <unitreal>
         * double MarginLeft //--margin-left <unitreal>
         * double MarginRight //--margin-right <unitreal>
         * double MarginTop //--margin-top <unitreal>
         * string Orientation //--orientation <orientation> (Landscape or Portrait) (default Portrait)
         * double PageHeight //--page-height <unitreal>
         * string PageSize //--page-size <Size> (A4, Letter, etc.) (default A4)
         * double PageWidth //--page-width <unitreal>
         * string Title //--title <text>
         * bool Outline //--outline (default true)
         * bool NoOutline //--no-outline
         * IEnumerable<string> AllowPaths //--allow <path> (repeatable)
         * bool Background //--background (default true)
         * bool NoBackground //--no-background
         * IEnumerable<KeyValuePair<string, string>> Cookies //--cookie <name> <value>
         * IEnumerable<KeyValuePair<string, string>> Headers //--custom-header <name> <value>
         * IEnumerable<string> ProxyBypasses //--bypass-proxy-for <value>
         * string WebCacheDir //--cache-dir <path>
         * bool CustomHeaderPropagation //--custom-header-propagation
         * bool NoCustomHeaderPropagation //--no-custom-header-propagation
         * bool DebugJavascript //--debug-javascript
         * bool NoDebugJavascript //--no-debug-javascript (default true)
         * bool DefaultHeader //--default-header
         * bool DisableExternalLinks //--disable-external-links
         * bool EnableExternalLinks //--enable-external-links (default true)
         * bool DisableForms //--disable-forms (default true)
         * bool EnableForms //--enable-forms
         * bool Images //--images (default true)
         * bool NoImages //--no-images
         * bool DisableInternalLinks //--disable-internal-links
         * bool EnableInternalLinks //--enable-internal-links (default true)
         * bool DisableJavascript //--disable-javascript
         * bool EnableJavascript //--enable-javascript (default true)
         * int JavascriptDelay //--javascript-delay <milliseconds> (default 200)
         * int PageOffset //--page-offset <offset> (page starting number: default 0)
         * bool KeepRelativeExternalLinks //--keep-relative-links
         * bool ResolveRelativeLinks //--resolve-relative-links
         * IEnumerable<string> RunScript //--run-script <js> (repeatable)
         * bool PrintMediaType //--print-media-type
         * bool NoPrintMediaType //--no-print-media-type (default true)
         * bool StopSlowScripts //--stop-slow-scripts (default true)
         * bool NoStopSlowScripts //--no-stop-slow-scripts
         * bool DisableTocBackLinks //--disable-toc-back-links
         * bool EnableTocBackLinks //--enable-toc-back-links
         * string UserStyleSheet //--user-style-sheet <url>
         * IEnumerable<KeyValuePair<string, string>> PostValues //--post <name> <value> (repeatable)
         * 
         * string FooterCenter //--footer-center <text>
         * string FooterFont //--footer-font-name <name>
         * int FooterFontSize //--footer-font-size <size>
         * string FooterHtml //--footer-html <url>
         * string FooterLeft //--footer-left <text>
         * bool FooterLine //--footer-line
         * bool NoFooterLine //--no-footer-line (default true)
         * string FooterRight //--footer-right <text>
         * int FooterSpacing //--footer-spacing <real> (millimeters, default: 0)
         * string HeaderCenter //--header-center <text>
         * string HeaderFont //--header-font-name <name>
         * int HeaderFontSize //--header-font-size <size>
         * string HeaderHtml //--header-html <url>
         * string HeaderLeft //--header-left <text>
         * bool HeaderLine //--header-line
         * bool NoHeaderLine //--no-header-line (default true)
         * string HeaderRight //--header-right <text>
         * int HeaderSpacing //--header-spacing <real> (millimeters, default: 0)
         * IEnumerable<KeyValuePair<string, string>> HeaderFooterReplacements //--replace <name> <value> (repeatable)
         */

    }
}
