using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {



        static int LCS(string P, string Q, int N, int M)
        {
            if (N == 0 || M == 0) { return 0; }
            else if (P[N] == Q[M])
            {
                return (1 + LCS(P, Q, N - 1, M - 1));
            }
            else
            {

                int tmp1 = LCS(P, Q, N - 1, M);
                int tmp2 = LCS(P, Q, N, M - 1);
                return Math.Max(tmp1, tmp2);
            }
            // O(2^(N+M))
        }


        // bottom up uproach 

        static int LCS_DP(string P, string Q, int N, int M)
        {
            int[,] Value = new int[N + 1, M + 1];
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= M; j++)
                {
                    if (i == 0 || j == 0) { Value[i, j] = 0; }
                    else if (P[i - 1] == Q[j - 1])
                    {
                        Value[i, j] = 1 + Value[i - 1, j - 1];
                    }
                    else
                    {
                        Value[i, j] = Math.Max(Value[i - 1, j], Value[i, j - 1]);
                    }

                }
            }
            return Value[N, M];
            //O(N*M)
        }


        
        
      
        static void Main(string[] args)
        {
            string P = "ahmed";
            string Q = "medical";

            int Result = LCS_DP(P, Q, P.Length, Q.Length);

            Console.WriteLine(Result);
          
        }
    }
}
