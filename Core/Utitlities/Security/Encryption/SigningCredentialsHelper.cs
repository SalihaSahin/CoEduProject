using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utitlities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //JWT nın oluşturulabilmesi için Credentials(kullanıcıadı gibi ..)
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //hangi anahtar ve hangi algoritma kullanılacağı verilir.
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
