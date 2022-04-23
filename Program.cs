using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace NumberOfFamilies
{
    internal class Program
    {
        List<Tuple<string, string>> list = new List<Tuple<string, string>>
            {
                Tuple.Create("john","jane"),
                Tuple.Create("john","peter"),
                Tuple.Create("john","samuel"),
                Tuple.Create("peter","mark"),
                Tuple.Create("mark","sasha"),
                Tuple.Create("kirk","tom"),
                Tuple.Create("tom","erica"),

            };
        static void Main(string[] args)
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>
            {
                Tuple.Create("john","jane"),
                Tuple.Create("john","peter"),
                Tuple.Create("john","samuel"),
                Tuple.Create("peter","mark"),
                Tuple.Create("mark","sasha"),
                Tuple.Create("kirk","tom"),
                Tuple.Create("tom","erica"),

            };
            Program p = new Program();
            Console.WriteLine("Choose an option (Number):");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Insert People");
            Console.WriteLine("2. Distinguish Families");
            
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine("The Option is: " + option);
            switch (option)
            {
                case 1:
                    p.insert();
                    break;
                case 2:
                    var count=p.DistinctFamilies(list);
                    Console.WriteLine("Number of Families : "+count);
                    break;
                default:
                    Console.WriteLine("Invalid Selection!");
                    break;
            }
            

            

        }
        public void insert()
        {
            

            string name1;
            string name2;
            Console.WriteLine("Name 1");
            name1 = Console.ReadLine();
            Console.WriteLine("Name 2");
            name2 = Console.ReadLine();
            var aux = 0;
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].Item1 == name1 & list[i].Item2 == name2)
                {
                    aux = 1;
                    Console.WriteLine("This pair is already added");
                }
                
            }
            if(aux == 0)
            {
                list.Add(new Tuple<string, string>(name1, name2));
            }
            var count = DistinctFamilies(list);
            Console.WriteLine("Number of Families : " + count);
        }
        private int DistinctFamilies(List<Tuple<string, string>> relations)
        {
            string[] v1=new string[relations.Count];
            string[] v2 = new string[relations.Count];
            int[] v3 = new int[relations.Count];
            int[] v4 = new int[relations.Count];
            for (int i = 0; i < relations.Count; i++)
            {
                v1[i]=relations[i].Item1;
                v3[i] = 0;
            }
            for (int i = 0; i < relations.Count; i++)
            {
                v2[i] = relations[i].Item2;
                v4[i] = 0;
            }
            

            string nombre1 = relations[0].Item1;

            int a = 0;
            int b = 0;
            int c = 0;

            while (v3[a] == 0)
            {

                for (int i = 0; i <= v1.Length-1; i++)
                {

                    if (v1[i] == nombre1)
                    {
                        v3[i] = 1;
                        v4[i] = 1;
                    }
                    if (v2[i] == nombre1)
                    {
                        v4[i] = 1;
                    }



                }
                for (int k = 0; k < v1.Length - 2; k++)
                {
                    if (v3[k] == 0 && v4[k] == 0) { nombre1 = v1[k]; a = k; c = c + 1; break; }

                }


            }
            return c;
        }
        public void print(List<Tuple<string, string>> relations)
        {
            foreach (var item in relations)
            {
                Console.WriteLine(item);
            }
        }

       


    }


}
