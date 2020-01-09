using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeApp
{
    public class AgeCheak
    {
        private DateTime now;

        public AgeCheak() => Now = DateTime.Now;

        public DateTime Now { get => now; set => now = value; }

        public TimeSpan Cheak(DateTime arg)
        {
            if (arg > Now)
                throw new ArgumentException(String.Format("Age can't be less than null"));
            else
               if (arg == Now)
                throw new ArgumentException(String.Format("Age can't be equel to now"));
            else
                return Now - arg;
        }
    }
}
