using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrariQzer.Domain.Entities
{

    public class GoogleToken
    {
        public GoogleToken()
        {
            
        }

        public GoogleToken(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
