namespace OrariQzer.Services.Interfaces
{
    public interface IGoogleService
    {
        public Task<string> GetBearerToken();
    }
}
