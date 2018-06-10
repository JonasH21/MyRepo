using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeforces
{
    class Program
    {
        static List<Tuple<bool,int>> parities = new List<Tuple<bool, int>>();

        static void Print(string toprint) => Console.WriteLine(toprint);

        static void Main()
        {
            Print("Hello world!");

            while(true)
                ProblemC();

            return;
            var first = Console.ReadLine();
            var second = Console.ReadLine();
            ProblemB(first, second);
            //ProblemB("7 1000000","1 1 1 1 1 1 1");
        }

        static void ProblemC()
        {
            var n = Int32.Parse(Console.ReadLine());
            var inputs = new List<string>();

            for(int i = 0; i < n; i++)
            {
                inputs.Add(Console.ReadLine());
            }
            //Console.WriteLine("Read complete");

            var solns = 0;

            for (var i = 0; i < n; i++)
                parities.Add(Parity(inputs[i]));

            for(var i = 0; i < n; i++)
                for(var j = 0; j < n; j++)
                {
                    if (parities[i].Item2 + parities[j].Item2 == 0 && Parity(i,j).Item1)
                        solns++;
                }

            Console.WriteLine(solns);
        }

        static Tuple<bool, int> Parity(int a, int b)
        {
            return new Tuple<bool, int>(parities[a].Item1 && parities[b].Item1, parities[a].Item2 + parities[b].Item2);
        }

        static Tuple<bool, int> Parity(string input)
        {
            var arr = input.ToCharArray();
            var parity = 0;
            var isValid = true;

            foreach (var c in arr)
            {
                if (c == '(')
                    parity++;
                else if (c == ')')
                    parity--;
                else
                    throw new ArgumentException();

                if (isValid && parity < 0)
                    isValid = false;
            }
            return new Tuple<bool, int>(isValid, parity);
        }

        static int GetBracketParity(string input)
        {
            var inputArr = input.ToCharArray();
            var parity = 0;

            foreach(var c in inputArr)
            {
                if (c == '(')
                    parity++;
                else if (c == ')')
                    parity--;
                else
                    throw new ArgumentException();
            }

            return parity;
        }

        static void ProblemB(string A, string B)
        {
            var first = A.Split(' ').Select(x => Int32.Parse(x)).ToList<int>();
            var sizes = B.Split(' ').Select(x => Int32.Parse(x)).ToList<int>();

            var n = first[0]; //bacteria
            var K = first[1];

            sizes.Sort();
            var bacteriaLeft = new List<int>();

            var thisBatch = 1; //count identical sizes

            for (var i = 0; i < n - 1; i++)
            {
                if(sizes[i] == sizes[i + 1])
                {
                    thisBatch++;
                    continue;
                }
                else
                {
                    if (sizes[i] + K < sizes[i+1])
                        bacteriaLeft.AddRange(Enumerable.Repeat<int>(sizes[i], thisBatch));

                    thisBatch = 1;
                }
            }
            bacteriaLeft.AddRange(Enumerable.Repeat(sizes[n - 1], thisBatch));
            Console.WriteLine(bacteriaLeft.Count);
            

        }

        static void ProblemA()
        {
            var first = Console.ReadLine().Split(' ');
            //var second = Console.ReadLine();

            var numBoxes = Int64.Parse(first[0]);
            var numDeleg = Int64.Parse(first[1]);

            var buildFee = Int32.Parse(first[2]);
            var demolFee = Int32.Parse(first[3]);


            //need numBoxes to be divisible by numDeleg
            var r = numBoxes % numDeleg;
            var q = numBoxes / numDeleg;
            //Console.WriteLine(r + " " + q);

            //first calculate the cost of demolishing.
            var demolCost = r * demolFee;
            //Console.WriteLine("Demolish for " + demolCost);

            //and building
            var buildCost = (numDeleg - r) * buildFee;
            //Console.WriteLine("Build for " + buildCost

            if (buildCost < demolCost)
                Console.WriteLine(buildCost);
            else
                Console.WriteLine(demolCost);
        }
    }
}
