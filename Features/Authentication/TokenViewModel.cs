using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AspVue.Features.Authentication
{
    public class TokenViewModel
    {
        //JsonProperty - demonstrating how to override the default generated JSON property names should you wish to follow the OAuth naming conventions
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("access_token_expiration")]
        public DateTime AccessTokenExpiration { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}