using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper.IHelper
{
    public interface IJsonHelper
    {
        public string Serialize(object obj);
        public T Deserialize<T>(string json);
    }
}
