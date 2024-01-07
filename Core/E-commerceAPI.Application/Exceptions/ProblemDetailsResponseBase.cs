using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceAPI.Application.Middlewares.Exceptions
{
    public class ProblemDetailsResponseBase
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public string? InnerException { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
