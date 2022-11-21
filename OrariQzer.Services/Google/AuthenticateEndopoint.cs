using OrariQzer.Services.Configuration;

namespace OrariQzer.Services.Google
{
    public static class AuthenticateEndPoint
    {
        public static RouteGroupBuilder MapAuthenticateEndPoint(this RouteGroupBuilder group)
        {
            group.MapGet("/getToken", (GoogleApiConfiguration googleApiConfiguration) => { return Results.Ok(googleApiConfiguration); });


            return group;
        }
    }
}
