using System.Collections.Generic;
using System.Linq;

namespace Spear.Client.Internal.Utilities
{
    internal class ProblemDetailError
    {
        public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();

        public override string ToString()
        { 
            if(Errors.Any())
                return string.Join(',', Errors?.Select(t => $"{t.Key}:[{ string.Join(',', t.Value)}]"));
            
            return string.Empty;
        }
    }
}
