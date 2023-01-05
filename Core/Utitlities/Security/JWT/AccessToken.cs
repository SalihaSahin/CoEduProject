using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utitlities.Security.JWT
{
    //kullancı api üzerinden kullanıc adı ve parolası verildikten sonra bir token ve o tokenın süresi verilecek
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
