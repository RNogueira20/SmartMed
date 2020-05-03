
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace SmartMedAPI
{
    public class ServiceResult
    {
        public List<string> Errors { get; set; }
        public bool Ok => Errors.Any();
    }
}
