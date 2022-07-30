﻿using System;
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
            //foreach (var item in myList){}//ERROR - not implement the interface

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

public class MyList
{
    int[] myInts = { 1, 2, 3 };
    int _index = -1;

    // indexer
    public int this[int index]
    {
        get { return myInts[index]; }
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

