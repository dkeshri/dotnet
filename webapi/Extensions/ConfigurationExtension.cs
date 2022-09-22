using System.Net;
using Microsoft.Extensions.Configuration;
namespace Webapi.Extensions
{
    public static class ConfigurationExtension
    {
        public static string getTokenSecret(this IConfiguration configuration)
        {
           return configuration.GetSection("Token:Secret").Value;
        }
        public static string getTokenExpireTime(this IConfiguration configuration){
            return configuration.GetSection("Token:TokenExpireInSec").Value;
        }
    }
}