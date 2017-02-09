using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PsychologicalServices.Web.Infrastructure.Services
{
    public class FirebaseTokenSigningKeys : IFirebaseTokenSigningKeys
    {
        private readonly List<SecurityKey> _keys = null;
        private bool _keysFetched = false;

        public FirebaseTokenSigningKeys()
        {
            _keys = new List<SecurityKey>();
        }

        public SecurityKey[] GetSecurityKeys()
        {
            if (!_keysFetched)
            {
                //GetKeyData().Wait();
                GetRawData();
            }

            return _keys.ToArray();
        }

        private async Task GetKeyData()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.googleapis.com/robot/v1/metadata/"),
            };

            var response = await httpClient.GetAsync("x509/securetoken@system.gserviceaccount.com");

            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            var x509Data = await response.Content.ReadAsAsync<Dictionary<string, string>>();
            var keys = x509Data.Values.Select(CreateSecurityKeyFromPublicKey);

            _keys.AddRange(keys);
            _keysFetched = true;
        }

        private SecurityKey CreateSecurityKeyFromPublicKey(string data)
        {
            return
                new X509SecurityKey(
                    new X509Certificate2(
                        Encoding.UTF8.GetBytes(data)
                    )
                );
        }

        private void GetRawData()
        {
            var data = new[]
            {
                "-----BEGIN CERTIFICATE-----\nMIIDHDCCAgSgAwIBAgIIIOcSqcyaifMwDQYJKoZIhvcNAQEFBQAwMTEvMC0GA1UE\nAxMmc2VjdXJldG9rZW4uc3lzdGVtLmdzZXJ2aWNlYWNjb3VudC5jb20wHhcNMTcw\nMTI5MDA0NTI2WhcNMTcwMjAxMDExNTI2WjAxMS8wLQYDVQQDEyZzZWN1cmV0b2tl\nbi5zeXN0ZW0uZ3NlcnZpY2VhY2NvdW50LmNvbTCCASIwDQYJKoZIhvcNAQEBBQAD\nggEPADCCAQoCggEBAKqlOrzJZEn3z8oy3AePV0Zy3avcN5iIgjBDaHpsL2nbQ3/j\nysehA3HcWMI9ceZjBMX8uV68ph1yv+5Mj+E6zl5EVlnpfpvjxvT+PIt4jrXw86tg\nTrTw2z76Mr/TE9HU84hPboyj5wziwKVWjB9e5Fb75njeBkgZ52N5bWxvN25pLxhQ\ntLHT7iGPDx0Eb7SbR9B8lhIcg2H4EsO9sZg0UWSs4HAQA67jgNRSRSn/PYNrz1SA\nzcf5Wicob2hlEdC5iEvhg0cNL5mLJUMHyzg79z8cnY+jJijhL5cdr8mQIwHk/xvz\nLiHEn7M/Vzi9eXtZEFK5hK46ZS5Kp6PO7DtnZucCAwEAAaM4MDYwDAYDVR0TAQH/\nBAIwADAOBgNVHQ8BAf8EBAMCB4AwFgYDVR0lAQH/BAwwCgYIKwYBBQUHAwIwDQYJ\nKoZIhvcNAQEFBQADggEBAIsLr9BfVBR9SgeSJG4j1py8FQf2AmMQPngJQNCFsbnz\npmI33FM9M+FaZwt49mcLeNfRCBliPZTvvaSDGGPtbVyT3L+qoOdb1N6gd17t05F2\n+rEaFt+KhmlQn1gXAzWBBBvqLoZof963ffdGblz9p0F09+/timXu+BnIR6DJUHIg\nvkHiymeefsrE2Mt8Ud8b5KcQAsOHO78w5VfO6NwWKjoMRe/kXh/1KhmbsXVENW8v\nrvziJnMqn1dALKtbK0msYN/Efrm/ejKhCQHQPBef88wdlhtnz0xYm1EyGb12XEWB\nD4ntM7msKiQP2FTYaWCwMT6G8DO2BAWJ+pnyIwxw1hg=\n-----END CERTIFICATE-----\n",
                "-----BEGIN CERTIFICATE-----\nMIIDHDCCAgSgAwIBAgIIJv4xWLsvnP8wDQYJKoZIhvcNAQEFBQAwMTEvMC0GA1UE\nAxMmc2VjdXJldG9rZW4uc3lzdGVtLmdzZXJ2aWNlYWNjb3VudC5jb20wHhcNMTcw\nMTI3MDA0NTI2WhcNMTcwMTMwMDExNTI2WjAxMS8wLQYDVQQDEyZzZWN1cmV0b2tl\nbi5zeXN0ZW0uZ3NlcnZpY2VhY2NvdW50LmNvbTCCASIwDQYJKoZIhvcNAQEBBQAD\nggEPADCCAQoCggEBAPOjwDjBY4Iw5M2bVajzemYJrXWtF1mHtd6G1quhUXMwlGHA\nVzKgiPif+dLd2iqlDWgSIG9P+kAoJM1Ec+mWx/RCTk/wNB+VPY3Lw0Rl5OKhZh3i\nVG/dQvE4J6wLFOYSutcadDQPD19ekSP0sTPg0AEphxgjIQNV4lnFj9p5Yo7I8tJc\nssz9xFJchjURcvbBFBnrTm/VSFuO6VazX3a0uLQpkIJoaW8GET7/n76GankAeCVU\n4BFURvDLlmKv5NSBsS12NJogJpdp8kL32O6n7lufTdtN4BlJB4thuTP+td8m08UA\nlgWGHQS/vGsc7ODDvFA3aJjmpp0cDu1+cicUikcCAwEAAaM4MDYwDAYDVR0TAQH/\nBAIwADAOBgNVHQ8BAf8EBAMCB4AwFgYDVR0lAQH/BAwwCgYIKwYBBQUHAwIwDQYJ\nKoZIhvcNAQEFBQADggEBAACnr3vS2g3ip6TgVIQtWlj30wThCAnEtnttktu0dboW\nEP4nQqie96l63yhFlT9rB4HY+b0RXnH60XSb40Bv4v4hppSqhQ4U2YIf0nZGM8Ra\nEHMtkDc6c9Jd/9+oEa/+w/eivm11A/HObbO2Ev32K7VQ6Q9kh26+uALirVF2ngZD\nxCEHvMy3pVZusFprC5V0KHGGpu1u+sENC6r1TGPh87zGj4l5tEGMGSdYjaRmUmu0\nr1wCTW0b8O8Hp3cZ1Hnc1ykByAdPwSdbJ8oC1Tt/9Lcfla/HHwr9KgZIHrxFjT+K\nj8OeQaKLyzCs6q08KilhGQZEP2Vg8o/tyLDKpNt8NmI=\n-----END CERTIFICATE-----\n",
                "-----BEGIN CERTIFICATE-----\nMIIDHDCCAgSgAwIBAgIIBeJvlHL1KAYwDQYJKoZIhvcNAQEFBQAwMTEvMC0GA1UE\nAxMmc2VjdXJldG9rZW4uc3lzdGVtLmdzZXJ2aWNlYWNjb3VudC5jb20wHhcNMTcw\nMTI4MDA0NTI2WhcNMTcwMTMxMDExNTI2WjAxMS8wLQYDVQQDEyZzZWN1cmV0b2tl\nbi5zeXN0ZW0uZ3NlcnZpY2VhY2NvdW50LmNvbTCCASIwDQYJKoZIhvcNAQEBBQAD\nggEPADCCAQoCggEBAOI3grPdj6CZ6Jc7TKQBqWvL5Cg/diKNGpPEuHoHjn8YaKCc\nIqCgfNluiGuIytzcli8Y9YYUR6PF0W72O5A9fDrBKl9VkRPHb6ARau+0H4m7OvRW\nZVMnmznRv84I3cqSOKbp1RTsrOYxaFKKFV3ceMREBaqxtcidHXVXmawc4JaEFnj/\n1n/HzA48ZUbwYNWVymMFo97s3pYHLHUYsWvvXwiOgf1kvCN1ctNAyk0eNesU45DP\niOYBmTIcOJqC5qEOlUuyjeFIgFt+kWuehm6uEbtYWmBMR/CpVD5JSwiPO7Jpa4/g\nDn0OGAPaS7ENxSgxZ50sRtBGto92i9i4UWcc/4cCAwEAAaM4MDYwDAYDVR0TAQH/\nBAIwADAOBgNVHQ8BAf8EBAMCB4AwFgYDVR0lAQH/BAwwCgYIKwYBBQUHAwIwDQYJ\nKoZIhvcNAQEFBQADggEBAJy+gkMqzLDxOsICaXiVrsg0aGyUckkV9Tzcdg/0lkhS\n7AoBK8d5NQab6SMWOIKQX57QBgXPjdTuQXeX7Kxceu2AdgdwHFMFLzayJWtS8a1F\npR7nCyuhG3T0WyY+JLyVWyfyeCKeNRLNIjrDo3dntBvutChmThhB9ATgBLrrhia+\nmaOstoKIg8J9voMYcuQ9BwWN4VBsennbvawzW4XJf6mBsDIHx1MoJbDBmYyCKLe+\njlBbhZaSn02TK0vwdFHQ/0Es/tnYyJNu7FjWDyajQe+irwnCguXsNVbpG61H/aeI\n38La5U5gLkkDzu47YKsSLTU3pqpdlSY0TQcM5lQV57A=\n-----END CERTIFICATE-----\n",
                "-----BEGIN CERTIFICATE-----\nMIIDHDCCAgSgAwIBAgIIbjU1oLBMCFEwDQYJKoZIhvcNAQEFBQAwMTEvMC0GA1UE\nAxMmc2VjdXJldG9rZW4uc3lzdGVtLmdzZXJ2aWNlYWNjb3VudC5jb20wHhcNMTcw\nMTMwMDA0NTI2WhcNMTcwMjAyMDExNTI2WjAxMS8wLQYDVQQDEyZzZWN1cmV0b2tl\nbi5zeXN0ZW0uZ3NlcnZpY2VhY2NvdW50LmNvbTCCASIwDQYJKoZIhvcNAQEBBQAD\nggEPADCCAQoCggEBALNZYzlnahMf2xAxEmATJzHlrFmN3BU3RCPsnMdQdwlffCnB\nr/bR53CFmv9rEg3G6lmIiYJFw1A7atBtFHV62GtibdvEsZZEEUXvRd0T1R67BZZg\nmGz4jb7c1Me5CGynjfwmPD6YcLTtS+f6/XPxSstPsc55y4ApzJM6V+YDEizKjpH8\nnYnKs87vvDISJPBy3q7VKlPUwfKV+tmapfL7yOJLHMeQtLpjX58F60054fvGIO4f\nyCOWYKki9zOSMJvG7DS3zAQZpNUXVKMYso4Jt4CxAlTRn3sPzmj88TG7tdVOBjyl\nFX34PhLDLBObHGOC1jDaGdBDPIFUEn5OK75oz4cCAwEAAaM4MDYwDAYDVR0TAQH/\nBAIwADAOBgNVHQ8BAf8EBAMCB4AwFgYDVR0lAQH/BAwwCgYIKwYBBQUHAwIwDQYJ\nKoZIhvcNAQEFBQADggEBAEIse1YaommudtjWrb1lIqnnrJbuL9/PBh0X8OFNAz2e\neRldRjeH+bZgj/8FjNkB6Y1yZW35olAU8IHmLSUTF25T1ysx0Gu+Xx/DttEd5x2g\nUMXOjSXrdGTda52wSbpFIh+xmWgO4MLtn03/MTGWCpwzkloX7ZRGUWnZ19M8NLAY\nX4WbBWOVUrj2M7h7UiSzaN81wv/+XHWJshqxGUnTOgjQaW8rCMcxzQORX86oBNkY\nNPksF416OqEm3OXs5KwVtnMUOCLZGeRr2tK7PVt3klaPt4tQx5KWE7JsD6n/jbJz\nsK61vD2wO+Ymfr6TexklDr4KHmdOj7DSnYq3C47fmXA=\n-----END CERTIFICATE-----\n"
            };

            _keysFetched = true;
            _keys.AddRange(
                data.Select(CreateSecurityKeyFromPublicKey)
            );
        }

        /*{
  "4f2db209d3373e158308cc4554a4d7ca0b5997e9": "-----BEGIN CERTIFICATE-----\nMIIDHDCCAgSgAwIBAgIIIOcSqcyaifMwDQYJKoZIhvcNAQEFBQAwMTEvMC0GA1UE\nAxMmc2VjdXJldG9rZW4uc3lzdGVtLmdzZXJ2aWNlYWNjb3VudC5jb20wHhcNMTcw\nMTI5MDA0NTI2WhcNMTcwMjAxMDExNTI2WjAxMS8wLQYDVQQDEyZzZWN1cmV0b2tl\nbi5zeXN0ZW0uZ3NlcnZpY2VhY2NvdW50LmNvbTCCASIwDQYJKoZIhvcNAQEBBQAD\nggEPADCCAQoCggEBAKqlOrzJZEn3z8oy3AePV0Zy3avcN5iIgjBDaHpsL2nbQ3/j\nysehA3HcWMI9ceZjBMX8uV68ph1yv+5Mj+E6zl5EVlnpfpvjxvT+PIt4jrXw86tg\nTrTw2z76Mr/TE9HU84hPboyj5wziwKVWjB9e5Fb75njeBkgZ52N5bWxvN25pLxhQ\ntLHT7iGPDx0Eb7SbR9B8lhIcg2H4EsO9sZg0UWSs4HAQA67jgNRSRSn/PYNrz1SA\nzcf5Wicob2hlEdC5iEvhg0cNL5mLJUMHyzg79z8cnY+jJijhL5cdr8mQIwHk/xvz\nLiHEn7M/Vzi9eXtZEFK5hK46ZS5Kp6PO7DtnZucCAwEAAaM4MDYwDAYDVR0TAQH/\nBAIwADAOBgNVHQ8BAf8EBAMCB4AwFgYDVR0lAQH/BAwwCgYIKwYBBQUHAwIwDQYJ\nKoZIhvcNAQEFBQADggEBAIsLr9BfVBR9SgeSJG4j1py8FQf2AmMQPngJQNCFsbnz\npmI33FM9M+FaZwt49mcLeNfRCBliPZTvvaSDGGPtbVyT3L+qoOdb1N6gd17t05F2\n+rEaFt+KhmlQn1gXAzWBBBvqLoZof963ffdGblz9p0F09+/timXu+BnIR6DJUHIg\nvkHiymeefsrE2Mt8Ud8b5KcQAsOHO78w5VfO6NwWKjoMRe/kXh/1KhmbsXVENW8v\nrvziJnMqn1dALKtbK0msYN/Efrm/ejKhCQHQPBef88wdlhtnz0xYm1EyGb12XEWB\nD4ntM7msKiQP2FTYaWCwMT6G8DO2BAWJ+pnyIwxw1hg=\n-----END CERTIFICATE-----\n",
  "3861326c20e8d79806155ba7f6e57f758085df0e": "-----BEGIN CERTIFICATE-----\nMIIDHDCCAgSgAwIBAgIIJv4xWLsvnP8wDQYJKoZIhvcNAQEFBQAwMTEvMC0GA1UE\nAxMmc2VjdXJldG9rZW4uc3lzdGVtLmdzZXJ2aWNlYWNjb3VudC5jb20wHhcNMTcw\nMTI3MDA0NTI2WhcNMTcwMTMwMDExNTI2WjAxMS8wLQYDVQQDEyZzZWN1cmV0b2tl\nbi5zeXN0ZW0uZ3NlcnZpY2VhY2NvdW50LmNvbTCCASIwDQYJKoZIhvcNAQEBBQAD\nggEPADCCAQoCggEBAPOjwDjBY4Iw5M2bVajzemYJrXWtF1mHtd6G1quhUXMwlGHA\nVzKgiPif+dLd2iqlDWgSIG9P+kAoJM1Ec+mWx/RCTk/wNB+VPY3Lw0Rl5OKhZh3i\nVG/dQvE4J6wLFOYSutcadDQPD19ekSP0sTPg0AEphxgjIQNV4lnFj9p5Yo7I8tJc\nssz9xFJchjURcvbBFBnrTm/VSFuO6VazX3a0uLQpkIJoaW8GET7/n76GankAeCVU\n4BFURvDLlmKv5NSBsS12NJogJpdp8kL32O6n7lufTdtN4BlJB4thuTP+td8m08UA\nlgWGHQS/vGsc7ODDvFA3aJjmpp0cDu1+cicUikcCAwEAAaM4MDYwDAYDVR0TAQH/\nBAIwADAOBgNVHQ8BAf8EBAMCB4AwFgYDVR0lAQH/BAwwCgYIKwYBBQUHAwIwDQYJ\nKoZIhvcNAQEFBQADggEBAACnr3vS2g3ip6TgVIQtWlj30wThCAnEtnttktu0dboW\nEP4nQqie96l63yhFlT9rB4HY+b0RXnH60XSb40Bv4v4hppSqhQ4U2YIf0nZGM8Ra\nEHMtkDc6c9Jd/9+oEa/+w/eivm11A/HObbO2Ev32K7VQ6Q9kh26+uALirVF2ngZD\nxCEHvMy3pVZusFprC5V0KHGGpu1u+sENC6r1TGPh87zGj4l5tEGMGSdYjaRmUmu0\nr1wCTW0b8O8Hp3cZ1Hnc1ykByAdPwSdbJ8oC1Tt/9Lcfla/HHwr9KgZIHrxFjT+K\nj8OeQaKLyzCs6q08KilhGQZEP2Vg8o/tyLDKpNt8NmI=\n-----END CERTIFICATE-----\n",
  "7df3ebc66ed8bab05a4c7e5911434becee5e0dbc": "-----BEGIN CERTIFICATE-----\nMIIDHDCCAgSgAwIBAgIIBeJvlHL1KAYwDQYJKoZIhvcNAQEFBQAwMTEvMC0GA1UE\nAxMmc2VjdXJldG9rZW4uc3lzdGVtLmdzZXJ2aWNlYWNjb3VudC5jb20wHhcNMTcw\nMTI4MDA0NTI2WhcNMTcwMTMxMDExNTI2WjAxMS8wLQYDVQQDEyZzZWN1cmV0b2tl\nbi5zeXN0ZW0uZ3NlcnZpY2VhY2NvdW50LmNvbTCCASIwDQYJKoZIhvcNAQEBBQAD\nggEPADCCAQoCggEBAOI3grPdj6CZ6Jc7TKQBqWvL5Cg/diKNGpPEuHoHjn8YaKCc\nIqCgfNluiGuIytzcli8Y9YYUR6PF0W72O5A9fDrBKl9VkRPHb6ARau+0H4m7OvRW\nZVMnmznRv84I3cqSOKbp1RTsrOYxaFKKFV3ceMREBaqxtcidHXVXmawc4JaEFnj/\n1n/HzA48ZUbwYNWVymMFo97s3pYHLHUYsWvvXwiOgf1kvCN1ctNAyk0eNesU45DP\niOYBmTIcOJqC5qEOlUuyjeFIgFt+kWuehm6uEbtYWmBMR/CpVD5JSwiPO7Jpa4/g\nDn0OGAPaS7ENxSgxZ50sRtBGto92i9i4UWcc/4cCAwEAAaM4MDYwDAYDVR0TAQH/\nBAIwADAOBgNVHQ8BAf8EBAMCB4AwFgYDVR0lAQH/BAwwCgYIKwYBBQUHAwIwDQYJ\nKoZIhvcNAQEFBQADggEBAJy+gkMqzLDxOsICaXiVrsg0aGyUckkV9Tzcdg/0lkhS\n7AoBK8d5NQab6SMWOIKQX57QBgXPjdTuQXeX7Kxceu2AdgdwHFMFLzayJWtS8a1F\npR7nCyuhG3T0WyY+JLyVWyfyeCKeNRLNIjrDo3dntBvutChmThhB9ATgBLrrhia+\nmaOstoKIg8J9voMYcuQ9BwWN4VBsennbvawzW4XJf6mBsDIHx1MoJbDBmYyCKLe+\njlBbhZaSn02TK0vwdFHQ/0Es/tnYyJNu7FjWDyajQe+irwnCguXsNVbpG61H/aeI\n38La5U5gLkkDzu47YKsSLTU3pqpdlSY0TQcM5lQV57A=\n-----END CERTIFICATE-----\n",
  "bdcc81f5a9d0b0034fe0f721dbe1cb436844c55c": "-----BEGIN CERTIFICATE-----\nMIIDHDCCAgSgAwIBAgIIbjU1oLBMCFEwDQYJKoZIhvcNAQEFBQAwMTEvMC0GA1UE\nAxMmc2VjdXJldG9rZW4uc3lzdGVtLmdzZXJ2aWNlYWNjb3VudC5jb20wHhcNMTcw\nMTMwMDA0NTI2WhcNMTcwMjAyMDExNTI2WjAxMS8wLQYDVQQDEyZzZWN1cmV0b2tl\nbi5zeXN0ZW0uZ3NlcnZpY2VhY2NvdW50LmNvbTCCASIwDQYJKoZIhvcNAQEBBQAD\nggEPADCCAQoCggEBALNZYzlnahMf2xAxEmATJzHlrFmN3BU3RCPsnMdQdwlffCnB\nr/bR53CFmv9rEg3G6lmIiYJFw1A7atBtFHV62GtibdvEsZZEEUXvRd0T1R67BZZg\nmGz4jb7c1Me5CGynjfwmPD6YcLTtS+f6/XPxSstPsc55y4ApzJM6V+YDEizKjpH8\nnYnKs87vvDISJPBy3q7VKlPUwfKV+tmapfL7yOJLHMeQtLpjX58F60054fvGIO4f\nyCOWYKki9zOSMJvG7DS3zAQZpNUXVKMYso4Jt4CxAlTRn3sPzmj88TG7tdVOBjyl\nFX34PhLDLBObHGOC1jDaGdBDPIFUEn5OK75oz4cCAwEAAaM4MDYwDAYDVR0TAQH/\nBAIwADAOBgNVHQ8BAf8EBAMCB4AwFgYDVR0lAQH/BAwwCgYIKwYBBQUHAwIwDQYJ\nKoZIhvcNAQEFBQADggEBAEIse1YaommudtjWrb1lIqnnrJbuL9/PBh0X8OFNAz2e\neRldRjeH+bZgj/8FjNkB6Y1yZW35olAU8IHmLSUTF25T1ysx0Gu+Xx/DttEd5x2g\nUMXOjSXrdGTda52wSbpFIh+xmWgO4MLtn03/MTGWCpwzkloX7ZRGUWnZ19M8NLAY\nX4WbBWOVUrj2M7h7UiSzaN81wv/+XHWJshqxGUnTOgjQaW8rCMcxzQORX86oBNkY\nNPksF416OqEm3OXs5KwVtnMUOCLZGeRr2tK7PVt3klaPt4tQx5KWE7JsD6n/jbJz\nsK61vD2wO+Ymfr6TexklDr4KHmdOj7DSnYq3C47fmXA=\n-----END CERTIFICATE-----\n"
}*/

    }
}