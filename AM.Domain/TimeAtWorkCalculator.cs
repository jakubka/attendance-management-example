using System;
using System.Collections.Generic;
using System.Linq;
using AM.Data;
using AM.Data.Entities;

namespace AM.Domain
{
    public class TimeAtWorkCalculator : ITimeAtWorkCalculator
    {
        private readonly IPassRepository _passRepository;

        public TimeAtWorkCalculator(IPassRepository passRepository)
        {
            _passRepository = passRepository;
        }

        public TimeSpan ComputeTotalTimeAtWork(int employeeId)
        {
            var passes = _passRepository.Query.Where(p => p.EmployeeId == employeeId).OrderBy(p => p.Time).ToList();

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

        private class ArriveLeavePair
        {
            public DateTime Arrival { get; set; }

            public DateTime Leave { get; set; }
        }
    }
}