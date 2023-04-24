using JwtApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
        //we are going to define bunch of endpoints in this usercontroller and we are gonna see that if we are authenticated
        //then are we able to hit those endpoints or if we are not then what would happen next
    {
       
        //***Admins***//

        //defining end point
        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        //at this point if we have a valid jwt token generated and passed along with the request then we will be able to access this
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName}, you are an {currentUser.Role}");
        }


        //***Sellers***//

        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller")]
        //at this point if we have a valid jwt token generated and passed along with the request then we will be able to access this
        public IActionResult SellersAdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName}, you are a {currentUser.Role}");
        }


        //***Admins and SEllers***//
        [HttpGet("AdminsAndSellers")]
        [Authorize(Roles = "Administrator, Seller")]
        //at this point if we have a valid jwt token generated and passed along with the request then we will be able to access this
        public IActionResult AdminsAndSellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName}, you are a {currentUser.Role}");
        }



        [HttpGet("Public")]
       public IActionResult Public()
        {
            return Ok("Hi, you're on public property");
        }

        //now lets add a helper function that will allow us to grab the user details based on the jwt token passed in

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if(identity != null)
            {
                var userClaims = identity.Claims;

                //returning the new usermodel based on the claims that we have stored.
                return new UserModel
                {
                   Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                };
            }

            return null;
        }
        //final step
    }


}
