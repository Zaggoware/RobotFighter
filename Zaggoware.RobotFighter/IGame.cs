using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaggoware.RobotFighter.Environment;

namespace Zaggoware.RobotFighter
{
    public interface IGame : IDisposable
    {
        WorldDescriptor WorldDescriptor { get; }
    }
}
