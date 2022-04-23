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
            DistinctFamilies(list);
        }
        private int DistinctFamilies(List<Tuple<string, string>> relations)
        {
            var fam = 1;
            var aux = 0;
            int[] myArray = new int[relations.Count];
            var count = 0;
            for (var i = 0; i < relations.Count; i++)
            {
                if (i == 0)
                {
                    myArray[i] = fam;
                }
                else
                {
                    foreach (var rel in relations)
                    {
                        if (rel.Item1 == relations[i].Item1 || rel.Item1 == relations[i].Item2 || rel.Item2 == relations[i].Item1 || rel.Item2 == relations[i].Item2)
                        {
                            aux = 1;
                            if(myArray[i] == 0)
                            {
                                
                                myArray[relations.IndexOf(rel)] = myArray[i-1];
                            }
                            
                        }
                        
                    }
                    if (aux != 0)
                    {
                        fam++;
                        aux = 0;
                    }
                }
                
            }
            foreach (var a in myArray)
            {
                Console.WriteLine(a);
            }

            var nombre1 = relations[0].Item1;
            var nombre2 = relations[0].Item2;                     
            relations.Sort();
            foreach (var rel in relations)
            {
                Console.WriteLine(rel);
            }
            HashSet<Tuple<string, string>> hashWithoutDuplicates = new HashSet<Tuple<string, string>>(relations);
            List<Tuple<string, string>> listWithoutDuplicates = hashWithoutDuplicates.ToList();
            ////print(listWithoutDuplicates);
            return count;
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
