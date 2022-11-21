using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OrariQzer.ApplicationCore.Interfaces.Repository;
using OrariQzer.Domain.Entities;

namespace OrariQzer.ApplicationCore.Services
{
    public class GoogleService : IGoogleService
    {

        private readonly NavigationManager _navigation;
        private readonly IConfiguration Configuration;
        private GoogleToken? _token;

        public GoogleService(NavigationManager navigation, IConfiguration configuration)
        {
            _navigation = navigation;
            Configuration = configuration;
        }

        public void promptGoogleAuth()
        {
            string url = Configuration["GoogleOAuthAddress"];
            _navigation.NavigateTo(url);
        }

        public void setGoogleToken(string token)
        {
            if (token.Contains("error")) return;
            var tokenDictionary = token.Split("#")[1].Split("&")
                .Select(part => part.Split('='))
                 .Where(part => part.Length == 2)
                 .ToDictionary(sp => sp[0], sp => sp[1]);

            _token = new GoogleToken(tokenDictionary["access_token"], DateTime.Now.AddSeconds(double.Parse(tokenDictionary["expires_in"])));
        }

        public GoogleToken GetGoogleToken()
        {
            if (_token is not null) return _token;
            throw new InvalidOperationException("The token is null");
        }

        public bool isGoogleAuthenticated()
        {
            if(_token is null) return false;
            if (DateTime.Now > _token.Expiration) return false;
            return true;
        }
    }
}
