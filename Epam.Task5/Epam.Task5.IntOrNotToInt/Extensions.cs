using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.IntOrNotToInt
{
    public static class Extensions
    {
        public static bool IsInt(this string str)
        {
            return StateMachines.IsInteger(str);
        }
    }
}
