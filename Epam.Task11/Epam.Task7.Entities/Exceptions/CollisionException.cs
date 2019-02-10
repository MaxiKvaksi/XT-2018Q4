using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Entities.Exceptions
{
    public class CollisionException : Exception
    {
        public CollisionException() : base("Element already exist")
        {
        }

        public CollisionException(string message) : base(message)
        {
        }

        public CollisionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CollisionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
