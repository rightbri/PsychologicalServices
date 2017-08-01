using System;
using System.Text;

namespace PsychologicalServices.Models.Addresses
{
    public static class AddressExtensions
    {
        public static string AddressString(this Address address)
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(address.Street))
            {
                sb.Append(address.Street);
            }

            if (!string.IsNullOrWhiteSpace(address.Suite))
            {
                sb.Append(" ").Append(address.Suite);
            }

            if (!string.IsNullOrWhiteSpace(address.City.Name))
            {
                sb.Append(", ").Append(address.City);
            }

            if (!string.IsNullOrWhiteSpace(address.City.Province))
            {
                sb.Append(", ").Append(address.City.Province);
            }

            if (!string.IsNullOrWhiteSpace(address.PostalCode))
            {
                sb.Append(" ").Append(address.PostalCode);
            }

            return sb.ToString();
        }

        public static string ToGoogleMapsAddressString(this Address address)
        {
            var sb = new StringBuilder("https://www.google.com/maps/place/");

            sb.Append(address.Street.Replace(' ', '+'));

            if (!string.IsNullOrWhiteSpace(address.Suite))
            {
                sb.Append("+").Append(address.Suite.Replace(' ', '+'));
            }

            sb.Append(",+").Append(address.City.Name.Replace(' ', '+'));

            sb.Append(",+").Append(address.City.Province.Replace(' ', '+'));

            sb.Append("+").Append(address.PostalCode.Replace(' ', '+'));

            sb.Append("/");

            return System.Text.RegularExpressions.Regex.Replace(sb.ToString(), @"\([\s\S]*\)", "");
        }
    }
}
