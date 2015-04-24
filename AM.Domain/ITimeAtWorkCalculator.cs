using System;

namespace AM.Domain
{
    public interface ITimeAtWorkCalculator
    {
        TimeSpan ComputeTotalTimeAtWork(int employeeId);
    }
}