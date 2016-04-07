using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlarmClock
{
    [Flags]
    public enum  DaysOfTheWeek
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }

    public struct Alarm
    {
       public  DaysOfTheWeek day;
       public int hour;
       public int minute;

    public Alarm (DaysOfTheWeek day, int hour, int minute)
        {
            this.day = day;
            this.hour = hour;
            this.minute = minute;
        }
    }

    [TestClass]
    public class AlarmTest
    {
        [TestMethod]
        public void AlarmTest1()
        {
            var alarm = new Alarm[] {
            new Alarm(DaysOfTheWeek.Monday | DaysOfTheWeek.Friday,6,0)};
            Assert.AreEqual(true, CheckAlarmStatus(alarm, DaysOfTheWeek.Monday, 6, 0));
            Assert.AreEqual(true, CheckAlarmStatus(alarm, DaysOfTheWeek.Friday, 6, 0));
            Assert.AreEqual(false, CheckAlarmStatus(alarm, DaysOfTheWeek.Monday, 6, 15));
            Assert.AreEqual(false, CheckAlarmStatus(alarm, DaysOfTheWeek.Thursday, 6, 0));
        }

        [TestMethod]
        public void AlarmTest2()
        {
            var alarm = new Alarm[] {
            new Alarm(DaysOfTheWeek.Saturday | DaysOfTheWeek.Sunday,8,0)};
            Assert.AreEqual(false, CheckAlarmStatus(alarm, DaysOfTheWeek.Monday, 8, 0));
            Assert.AreEqual(true, CheckAlarmStatus(alarm, DaysOfTheWeek.Sunday, 8, 0));
            Assert.AreEqual(false, CheckAlarmStatus(alarm, DaysOfTheWeek.Wednesday, 15, 45));
            Assert.AreEqual(false, CheckAlarmStatus(alarm, DaysOfTheWeek.Saturday, 12,25));
        }

        bool CheckAlarmStatus (Alarm[] alarm, DaysOfTheWeek day, int hour, int minute)
        {
            for (int i=0; i<alarm.Length; i++)
            {
                if ((alarm[i].day & day) != 0 && (alarm[i].hour == hour) && (alarm[i].minute == minute))
                    return true;
            }
            return false;
        }
    }
}
