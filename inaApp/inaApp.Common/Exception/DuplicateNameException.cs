using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.Exception
{
    public class DuplicateNameException : System.Exception
    {
        public DuplicateNameException() {
        }

        public DuplicateNameException(string? message) : base(message) {
        }

    }//end CLASS

}//end NAMESPACE
