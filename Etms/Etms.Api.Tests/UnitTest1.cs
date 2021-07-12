using Etms.Api.Core.Entities;
using Etms.Api.Core.Helpers;
using System;
using Xunit;

namespace Etms.Api.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var newLog = new TimeLog();
            var lastLog = new TimeLog();

            var endDate = DateTimeOffset.Parse("2000-01-01T01:00:00.000+03:00");
            var startDate = DateTimeOffset.Parse("2000-01-01T02:00:00.000+03:00");

            lastLog.EndTime = endDate;
            newLog.StartTime = startDate;

            Assert.True(TimeLogHelper.CanStoreLog(newLog, lastLog));
        }
    }
}
