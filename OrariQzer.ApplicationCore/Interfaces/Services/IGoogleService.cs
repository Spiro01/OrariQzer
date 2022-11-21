using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrariQzer.Domain.Entities;

namespace OrariQzer.ApplicationCore.Interfaces.Repository
{
    public interface IGoogleService
    {
        public void promptGoogleAuth();
        public void setGoogleToken(string token);
        public bool isGoogleAuthenticated();
        public GoogleToken GetGoogleToken();
    }
}
