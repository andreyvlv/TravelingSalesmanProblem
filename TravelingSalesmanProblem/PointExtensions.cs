using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TravelingSalesmanProblem
{ 
    public static class PointExtensions
    {
        public static double GetPathLength(this Point[] checkpoints, int[] order)
        {
            Point prevPoint = checkpoints[order[0]];
            var len = 0.0;
            foreach (int checkpointIndex in order.Skip(1))
            {
                len += prevPoint.DistanceTo(checkpoints[checkpointIndex]);
                prevPoint = checkpoints[checkpointIndex];
            }
            return len;
        }

        public static double GetPathLength(this List<Point> checkpoints)
        {
            Point prevPoint = checkpoints[0];
            var len = 0.0;           
            for (int i = 1; i < checkpoints.Count; i++)
            {
                len += prevPoint.DistanceTo(checkpoints[i]);
                prevPoint = checkpoints[i];
            }
            return len;
        }

        public static double DistanceTo(this Point a, Point b)
        {
            var dx = a.X - b.X;
            var dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

    }
}