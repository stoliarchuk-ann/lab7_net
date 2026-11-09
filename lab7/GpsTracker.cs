using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public delegate void GpsEventHandler();
    public class GpsTracker : ITrackable
    {
        public event GpsEventHandler arrivedDestination;

        public event GpsEventHandler deviationFromRoute;

        public event Action<double> locationUpdated;

        public void UpdateLocation(double distanceLeft) {
            if (distanceLeft >= 0)
            {
                locationUpdated?.Invoke(distanceLeft);
            }

            if (arrivedDestination != null && distanceLeft == 0)
            {
                arrivedDestination();
            }

            if (deviationFromRoute != null && distanceLeft < 0)
            {
                deviationFromRoute();
            }
        }
    }
}
