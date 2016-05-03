using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimbalInterface
{
    public static class TrackingMath
    {
        internal static double Distance(double x0, double y0, double z0, double x1, double y1, double z1)
        {
            return Math.Sqrt( (x0 - x1) * (x0 - x1)
                            + (y0 - y1) * (y0 - y1)
                            + (z0 - z1) * (z0 - z1));
        }

        internal static double Distance(double x0, double y0, double x1, double y1)
        {
            return Math.Sqrt( (x0 - x1) * (x0 - x1)
                            + (y0 - y1) * (y0 - y1));
        }

        // algorithm adapted from: http://ieeexplore.ieee.org/stamp/stamp.jsp?arnumber=7097209&tag=1
        public static void TrackToTarget(double acX, double acY, double acZ, double tX, double tY, double tZ, out double pitchT, out double yawT)
        {
            double D = Distance(acX, acY, acZ, tX, tY, tZ);
            double DH = Distance(acX, acY, tX, tY);

            if (D == 0.0 || DH == 0.0)
            {
                pitchT = 0.0;
                yawT = 0.0;
            }
            yawT = Math.Acos((acY - tY) / DH) * Units.RAD_TO_DEG;
            if ((acX - tX) > 0)
            {
                yawT = 360.0 - yawT;
            }
            pitchT = Math.Acos(DH / D) * Units.RAD_TO_DEG;
            if ((acZ - tZ) > 0)
            {
                pitchT = -pitchT;
            }
        }
    }
}
