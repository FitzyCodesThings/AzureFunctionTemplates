using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionHttpTrigger
{
    public class EmailRequestBody
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
