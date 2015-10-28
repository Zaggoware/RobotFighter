using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zaggoware.RobotFighter
{
    public static class MemoryLogger
    {
        public static IEnumerable<string> Logs => logs.ToList();

        private static readonly List<string> logs = new List<string>();

        public static void Log(string message, [CallerMemberName] string memberName = "", [CallerLineNumber] int sourceLinerNumber = 0)
        {
            logs.Add($"[{memberName}:{sourceLinerNumber}] {message}");
        }
    }
}
