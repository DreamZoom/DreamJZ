using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.SSO
{
    public class SSOProviders
    {
        private static ISSOProvider _current = null;
        public static ISSOProvider Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SSOProvider();
                }
                return _current;
            }
            set
            {
                _current = value;
            }
        }
    }
}
