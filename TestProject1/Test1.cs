using lab7;

namespace TestProject1
{
    [TestClass]
    public class GpsTrackerTests
    {
        [TestMethod]
        public void UpdateLocation_DistanceIsZero_FiresArrivedDestinationEvent()
        {
            var tracker = new GpsTracker();
            bool isEventFired = false;

            tracker.arrivedDestination += () => { isEventFired = true; };

            tracker.UpdateLocation(0);

            Assert.IsTrue(isEventFired, "Подія arrivedDestination мала спрацювати, коли дистанція дорівнює 0.");
        }

        [TestMethod]
        public void UpdateLocation_DIstanceIsNegative_FiresDeviationEvent()
        {
            var tracker = new GpsTracker();
            bool isEventFired = false;

            tracker.deviationFromRoute += () => { isEventFired = true; };

            tracker.UpdateLocation(-5);

            Assert.IsTrue(isEventFired, "Подія deviationFromRoute мала спрацювати, коли дситанція менша за 0.");
        }

        [TestMethod]
        public void UpdateLocation_DistanceIsPositive_DoesNotFireArrivedEvent()
        {
            var tracker = new GpsTracker();
            bool isEventFired = false;

            tracker.arrivedDestination += () => { isEventFired = true; };

            tracker.UpdateLocation(15);

            Assert.IsFalse(isEventFired, "Подія прибуття НЕ повинна спрацьовувати, якщо дистанція більша за 0.");
        }

        [TestMethod]
        public void UpdateLocation_DistanceIsPositive_FiresLocationUpdatedEvent()
        {
            var tracker = new GpsTracker();
            bool isEventFired = false;

            tracker.locationUpdated += (dist) => { isEventFired = true; };

            tracker.UpdateLocation(10);

            Assert.IsTrue(isEventFired, "Подія оновлення локації мала спрацювати для додатних значень.");
        }

        [TestMethod]
        public void UpdateLocation_DistanceIsNegative_DoesNotFireLocationUpdatedEvent()
        {
            var tracker = new GpsTracker();
            bool isEventFired = false;

            tracker.locationUpdated += (dist) => { isEventFired = true; };

            tracker.UpdateLocation(-5);

            Assert.IsFalse(isEventFired, "Подія оновлення локації НЕ повинна спрацьовувати для від'ємної дистанції.");
        }

        [TestMethod]
        public void UpdateLocation_DistanceIsZero_FiresLocationUpdatedEvent()
        {
            var tracker = new GpsTracker();
            bool isEventFired = false;

            tracker.locationUpdated += (dist) => { isEventFired = true; };
            tracker.UpdateLocation(0);

            Assert.IsTrue(isEventFired, "Подія оновлення локації має спрацьовувати на точній межі 0 км.");
        }

        [TestMethod]
        public void UpdateLocation_DistanceIsZero_DoesNotFireDeviationEvent()
        {
            var tracker = new GpsTracker();
            bool isEventFired = false;

            tracker.deviationFromRoute += () => { isEventFired = true; };
            tracker.UpdateLocation(0);

            Assert.IsFalse(isEventFired, "Подія відхилення не повинна спрацьовувати при успішному прибутті.");
        }

        [TestMethod]
        public void UpdateLocation_DistanceIsPositive_DoesNotFireDeviationEvent()
        {
            var tracker = new GpsTracker();
            bool isEventFired = false;

            tracker.deviationFromRoute += () => { isEventFired = true; };
            tracker.UpdateLocation(10);

            Assert.IsFalse(isEventFired, "Подія відхилення не повинна спрацьовувати під час нормального руху.");
        }

        [TestMethod]
        public void UpdateLocation_NoSubscribers_DoesNotThrowException()
        {
            var tracker = new GpsTracker();

            try
            {
                tracker.UpdateLocation(10);
                tracker.UpdateLocation(0);
                tracker.UpdateLocation(-5);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail("Метод викликав виняток. Перевірте, чи є захист від null (знак ? або != null) при виклику подій.");
            }
        }
    }
}
