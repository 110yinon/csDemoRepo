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
            //var enumerator = arr.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    // opt 1 - casting
            //    Console.WriteLine(((Person)enumerator.Current).FirstName);
            //    //Or print by the toString()
            //    Console.WriteLine(enumerator.Current);
            //}

            var myList = new MyList();
            //foreach (var item in myList) { }//ERROR - not implement the interface
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            var myListUpdated = new MyListUPDATED();

            //foreach (var item in myListUpdated){}//ERROR - not implement the interface

            var myListEnumerator = new MyListEnumerator();
            foreach (var item in myListEnumerator)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // same
            var enumerator = myListEnumerator.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            Console.WriteLine("******************************");
            var kuni = new ListOfApiData.Kuni();
            foreach (var item in kuni)
            {
                //Console.WriteLine(new Random().Next(1, 100));
                Console.WriteLine(item);
            }
            //Console.WriteLine("foreach");
            //var a = new int[] { 13, 14, 15 };
            //foreach (var item in a)
            //{
            //    Console.WriteLine(new Random().Next(1, 1000));
            //    //Console.WriteLine(item);
            //}
            //Console.WriteLine("for");
            //for (int i = 0; i < a.Length; i++)
            //{
            //    Console.WriteLine(new Random().Next(1, 100));
            //    //Console.WriteLine(i);
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

public class MyList : IEnumerable
{
    int[] myInts = { 17, 18, 19 };
    int _index = -1;

    // indexer
    public int this[int index]
    {
        get { return myInts[index]; }
    }

    public IEnumerator GetEnumerator()
    {
        var numerator = myInts.GetEnumerator();
        return numerator;
    }
}
public class ListOfApiData : IEnumerator
{
    readonly int MAX_API_CALLS = 4;
    int apiCalls = 0;
    Random RandNumer = new Random();

    //IEnumerator implementation
    public object Current=>RandNumer.Next(1, 100);

    public bool MoveNext()
    {
        if (apiCalls < MAX_API_CALLS)
        {
            //var x = new Random().Next(1, 100);
            //Current = x;
            apiCalls++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        apiCalls = 0;
    }
    public class Kuni : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            return new ListOfApiData();
        }
    }
}

public class MyListUPDATED : IEnumerator
{
    int[] myInts = { 1, 2, 3 };
    int _index = -1;

    // indexer
    public int this[int index]
    {
        get { return myInts[index]; }
    }

    //IEnumerator implementation
    public object Current
    {
        get { return myInts[_index]; }
    }

    public bool MoveNext()
    {
        _index++;
        return _index < myInts.Length;
    }

    public void Reset()
    {
        _index = 0;
    }
}

public class MyListEnumerator : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        //return new int();// not an IEnumerator (not implement it)
        //return new bool();// not an IEnumerator (not implement it)
        //return new string[] { "bb", "sara", "avner" };// not an IEnumerator (not implement it)

        return new MyListUPDATED();
    }
}