using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TravelingSalesmanProblem
{
    class Permute
    {
        public static List<List<T>> GetPermutation<T>(List<T> array)
        {
            var permutationResult = new List<List<T>>();
            PermutationAlgorithm(array.Count - 1, array, permutationResult);
            return permutationResult;
        }

        static void PermutationAlgorithm<T>(int n, List<T> array, List<List<T>> list)
        {
            if (n == 0)
            {                                        
                list.Add(new List<T>(array));
            }
            else
            {
                for (int i = 0; i <= n; i++)
                {
                    PermutationAlgorithm(n - 1, array, list);
                    Swap(array, n % 2 == 0 ? i : 0, n);
                }
            }
        }

        static void Swap<T>(List<T> str, int i, int j)
        {
            var temp = str[i];
            str[i] = str[j];
            str[j] = temp;
        }       
    }
}
