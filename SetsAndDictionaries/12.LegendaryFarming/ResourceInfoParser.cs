using System.Text;

namespace _12.LegendaryFarming
{
    public class ResourceInfoParser
    {
        private readonly StringBuilder _resourcesInfo;

        public ResourceInfoParser(string resourcesInfo)
        {
            _resourcesInfo = new StringBuilder(resourcesInfo);
        }

        public ResourceInfo GetNextResourceInfo()
        {
            var resourceInfoString = GetNextResourceInfoAsString();
            if (string.IsNullOrWhiteSpace(resourceInfoString))
            {
                return null;
            }

            var resourceName = GetResourceName(resourceInfoString);
            var resourceQuantity = GetResourceQuantity(resourceInfoString);

            return new ResourceInfo(resourceName, resourceQuantity);
        }

        private string GetNextResourceInfoAsString()
        {
            var resourceInfoBuilder = new StringBuilder();
            var numberOfWhitespaces = 0;

            while (numberOfWhitespaces < 2 && _resourcesInfo.Length > 0)
            {
                var currentSymbol = _resourcesInfo[0];
                resourceInfoBuilder.Append(currentSymbol);
                _resourcesInfo.Remove(0, 1);
                if (currentSymbol == ' ')
                {
                    ++numberOfWhitespaces;
                }
            }
            return resourceInfoBuilder.ToString().Trim();
        }

        private static string GetResourceName(string resourceInfoString)
        {
            return resourceInfoString.Substring(resourceInfoString.IndexOf(' ') + 1);
        }

        private static long GetResourceQuantity(string resourceInfoString)
        {
            return long.Parse(resourceInfoString.Substring(0, resourceInfoString.IndexOf(' ')));
        }
    }
}