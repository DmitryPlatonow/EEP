using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public interface IOperationResult
    {
         bool Succeeded { get; }
         string Message { get;  }
         string Property { get; }
    }
}
