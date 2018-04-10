using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TimelineComposite.SSA
{
    internal class PredefineFormatItemException : Exception
    {
        public PredefineFormatItemException() { }

        public PredefineFormatItemException(string message) : base(message) { }

        public PredefineFormatItemException(string message, Exception innerException) : base(message, innerException) { }

        protected PredefineFormatItemException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
