using System;
using System.Collections.Generic;
using System.Linq;
using AM.Data;

namespace AM.Domain
{
    public class TimeAtWorkCalculator
    {
        public TimeSpan ComputeTotalTimeAtWork(int employeeId)
        {
            using (var context = new AMDbContext())
            {
                var passes = context.Passes.Where(p => p.EmployeeId == employeeId).OrderBy(p => p.Time).ToList();

                var pairs = new List<ArriveLeavePair>();

                for (int i = 0; i < passes.Count; i += 2)
                {
                    pairs.Add(new ArriveLeavePair()
                    {
                        Arrival = passes[i].Time,
                        Leave = passes[i + 1].Time,
                    });
                }

                return pairs.Aggregate(TimeSpan.Zero, (total, pair) => total + (pair.Leave - pair.Arrival));
            }
        }

        private class ArriveLeavePair
        {
            public DateTime Arrival { get; set; }

            public DateTime Leave { get; set; }
        }

    }
}
