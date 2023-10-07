using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper.IHelper
{
    public interface IStopwatchHelper
    {
        public void Timer(Stopwatch sw, Action action);
        public void Timer(Stopwatch sw, Action action, int iterations);
    }
}
