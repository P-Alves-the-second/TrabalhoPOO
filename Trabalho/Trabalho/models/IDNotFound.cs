using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.models
{
    public class IDNotFoundException : Exception
    {
        public IDNotFoundException() { }
        public IDNotFoundException(string message) : base(message) { }
        public IDNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
