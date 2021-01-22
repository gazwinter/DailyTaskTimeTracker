using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskTimeTracker.Helpers
{
    public class Rfc2898
    {
        public Rfc2898(byte[] hash, byte[] salt, int iterations)
        {
            Hash = hash;
            Salt = salt;
            Iterations = iterations;
        }

        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
        public int Iterations { get; set; }
    }
}
