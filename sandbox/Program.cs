using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var arr = new int[] { 1, 2, 3, 4 };
            var arr = new Person[]
            {
                new Person(){FirstName = "avi",LastName="1"},
                new Person(){FirstName = "benny",LastName="2"},
                new Person(){FirstName = "charlie",LastName="3"}
            };
            var enumerator = arr.GetEnumerator();
            while (enumerator.MoveNext())
            {
                // opt 1 - casting
                Console.WriteLine(((Person)enumerator.Current).FirstName);
                //Or print by the toString()
                Console.WriteLine(enumerator.Current);
            }

            //while (enumerator.MoveNext())
            //{
            //    // opt 1 - casting
            //    Console.WriteLine(((Person)enumerator.Current).FirstName);
            //    //Or print by the toString()
            //    Console.WriteLine(enumerator.Current);
            //}


            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);

            //}

        }
    }
}
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string ToString()
    {
        return $"Person: {this.FirstName}, {this.LastName}";
    }
}
public class MyList : IEnumerator<Person>
{
    Array
    public Person Current => throw new NotImplementedException();

    object IEnumerator.Current => throw new NotImplementedException();

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}