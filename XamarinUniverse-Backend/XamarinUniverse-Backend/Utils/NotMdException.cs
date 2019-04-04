using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinUniverse_Backend.Utils
{
    public class NotMdException: Exception
    {
        public NotMdException() : base("The result file does not have .md extension")
        {

        }
    }
}
