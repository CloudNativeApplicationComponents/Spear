using System.Text;

namespace Spear.Client.Services
{
    public class ServiceCatalogDefinitionFilter
    {
        public string? Name { get; set; }
        public string? DataPlane { get; set; }

        internal string GetAsUrlFilter()
        {
            var stringBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(Name))
                AddParameter(nameof(Name), Name);

            if (!string.IsNullOrWhiteSpace(DataPlane))
                AddParameter(nameof(DataPlane), DataPlane);

            return stringBuilder.ToString();

            void AddParameter(string key, string value)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append($"&{key}={value}");
                else
                    stringBuilder.Append($"{key}={value}");
            };
        }
    }
}
