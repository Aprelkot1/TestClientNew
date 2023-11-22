using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient.DictionaryService
{
    internal class RequestService
    {
        public string type { get; set; }
        public string dict { get; set; }
        public string text { get; set; }
        public string options { get; set; }
    }

}
