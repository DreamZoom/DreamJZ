using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.Utility
{
    public sealed class Check
    {
        public static bool IsNull(object objVar)
        {
            return null == objVar;
        }

        public static void CheckNull(object objVar)
        {
            if (IsNull(objVar))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
