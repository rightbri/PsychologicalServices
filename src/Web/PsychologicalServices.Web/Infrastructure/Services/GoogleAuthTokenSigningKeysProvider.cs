using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
using Google.Apis.Services;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Common.Configuration;

namespace PsychologicalServices.Web.Infrastructure.Services
{
    public class GoogleAuthTokenSigningKeysProvider : IGoogleAuthTokenSigningKeysProvider
    {
        public const string CertificatesConfigurationSettingKey = "OpenIdConnectVerificationCertificatesCacheKey";
        private readonly IConfigurationService _configurationService = null;
        private readonly ICacheService _cacheService = null;
        private readonly IDate _date = null;
        
        public GoogleAuthTokenSigningKeysProvider(
            IConfigurationService configurationService,
            ICacheService cacheService,
            IDate date
        )
        {
            _configurationService = configurationService;
            _cacheService = cacheService;
            _date = date;
        }

        public IEnumerable<SecurityKey> GetSecurityKeys()
        {
            return GetSecurityKeys(_date.Today.AddDays(1));
        }

        public IEnumerable<SecurityKey> GetSecurityKeys(DateTime cacheUntilTime)
        {
            var cacheKey = _configurationService.AppSettingValue(CertificatesConfigurationSettingKey);

            return _cacheService.Get(
                CertificatesConfigurationSettingKey,
                () => GetKeys(),
                cacheUntilTime
            );
        }

        private IEnumerable<SecurityKey> GetKeys()
        {
            var oauthService = new Oauth2Service(new BaseClientService.Initializer
                {
                    ApiKey = _configurationService.AppSettingValue("GoogleOAuthServerApiKey"),
                });

            var certificates = oauthService.GetCertForOpenIdConnect().Execute();
            
            var keys = certificates.Keys.Select(CreateSecurityKeyFromPublicKey);

            return keys;
        }

        private SecurityKey CreateSecurityKeyFromPublicKey(Jwk.KeysData key)
        {
            //http://stackoverflow.com/a/37287772
            var rsa = RSA.Create();
            
            rsa.ImportParameters(
                new RSAParameters
                {
                    Exponent = Base64UrlEncoder.DecodeBytes(key.E),
                    Modulus = Base64UrlEncoder.DecodeBytes(key.N),
                }
            );
            
            return new RsaSecurityKey(rsa);
        }
    }
}