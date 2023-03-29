using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Encodings.Web;
using System.Net.Http.Headers;
using System.Security.Claims;

using SwiftOrder_Server.Data;

namespace SwiftOrder_Server.Handlers
{
    public class RestaurantHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ISwiftOrderRepo _repository;

        public RestaurantHandler(ISwiftOrderRepo repository, 
                                IOptionsMonitor<AuthenticationSchemeOptions> options,
                                ILoggerFactory logger,
                                UrlEncoder encoder,
                                ISystemClock clock):base(options, logger, encoder, clock)
        {
            _repository = repository;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // credentials provided
            if (Request.Headers.ContainsKey("Authorization"))
            {
                // extract authentication header
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(":");
                var emailAddress = credentials[0];
                var password = credentials[1];

                // valid login
                if (_repository.ValidateLogin(emailAddress, password))
                {
                    var claims = new[] { new Claim("emailAddress", emailAddress) };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Basic");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    AuthenticationTicket authenticationTicket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

                    return AuthenticateResult.Success(authenticationTicket);
                }

                // invalid login
                else
                {
                    return AuthenticateResult.Fail("Account does not exist.");
                }
            }

            // credentials not provided
            else
            {
                Response.Headers.Add("WWW-Authenticate", "Basic");

                return AuthenticateResult.Fail("Authorization header not found.");
            }
        }
    }
}
