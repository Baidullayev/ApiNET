using ApiNET.Auth;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WEBAPIJWT.Controllers
{
    public class RequestTokenController : ApiController
    {
        public HttpResponseMessage Get(string username, string password)
        {
            if (CheckUser(username, password))
            {
                return Request.CreateResponse(HttpStatusCode.OK,
             JwtAuthManager.GenerateJWTToken(username));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized,
             "Invalid Request");
            }
        }
        public bool CheckUser(string username, string password)
        {
            // for demo purpose, I am simply checking username and password with predefined strings. you can have your own logic as per requirement.
            if (username == "testuser" && password == "test123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}