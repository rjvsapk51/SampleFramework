using Microsoft.OpenApi.Models;

namespace BeeHive.L10.API.Loaders
{
    internal class OpenApiSecuritySchemey : OpenApiSecurityScheme
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string In { get; set; }
        public string Type { get; set; }
    }
}