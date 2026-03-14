using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name , object key) 
            : base($"{name} with id:{key} not found.")
        {
        }
    }
}
