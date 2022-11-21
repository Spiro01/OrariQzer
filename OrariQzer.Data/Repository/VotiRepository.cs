using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrariQzer.ApplicationCore.Interfaces.Repository;

namespace OrariQzer.Data.Repository
{
    public class VotiRepository : IVotiRepository
    {
        private readonly IGoogleService _googleService;
        private readonly HttpClient _httpClient;

        public VotiRepository(IGoogleService googleService, HttpClient httpClient)
        {
            _googleService = googleService;
            _httpClient = httpClient;
        }

        
    }
}
