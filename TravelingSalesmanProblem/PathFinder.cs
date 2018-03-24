using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TravelingSalesmanProblem
{
    class PathFinder
    {
        public static List<List<Point>> GetPermutation(List<Point> pointList)
        {
            var pointListWithountFirst = pointList.Skip(1).ToList();
            var permutations = Permute.GetPermutation(pointListWithountFirst);
            var result = new List<List<Point>>();
            foreach (var item in permutations)
            {
                var simpleList = new List<Point> { pointList[0] };
                simpleList.AddRange(item);
                result.Add(new List<Point>(simpleList));
            }
            return result;
        }

        //public static IEnumerable<List<Point>> GetPermutation(List<Point> pointList)
        //{
        //    var pointListWithountFirst = pointList.Skip(1).ToList();
        //    var permutations = Permute.GetPermutation(pointListWithountFirst);
        //    foreach (var item in permutations)
        //    {
        //        var simpleList = new List<Point> { pointList[0] };
        //        simpleList.AddRange(item);
        //        yield return new List<Point>(simpleList);
        //    }
        //}

        public static List<Point> GetBestPointOrder(List<List<Point>> permutation)
        {
            double bestWay = permutation[0].GetPathLength();
            int bestWayIndex = 0;
            for (int i = 0; i < permutation.Count; i++)
            {
                var pathLength = permutation[i].GetPathLength();
                if (pathLength < bestWay)
                {
                    bestWay = pathLength;
                    bestWayIndex = i;
                }
            }
            return permutation[bestWayIndex];
        }

        //public static List<Point> GetBestPointOrder(List<List<Point>> permutation)
        //{
        //    var bestPath = permutation.Select(x => x.GetPathLength()).Min();
        //    var result = permutation.Where(x => x.GetPathLength() == bestPath).First();
        //    return result;
        //}

        public static List<int> GetBestOrderByIndex(List<Point> best, List<Point> original)
        {
            var result = new List<int>();
            foreach (var item in best)
            {
                result.Add(original.IndexOf(item));
            }
            return result;
        }

        public static double GetAveragePathLength(List<List<Point>> permutation)
        {            
            return permutation.Select(x => x.GetPathLength()).Average();
        }
    }
}
