using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    record Person(string Name) : Entity { public string Id => Name; }
    record Employee(string Name):Person(Name);
    record RemoteEmployee(string Name, string Location):Employee(Name);

    //interface IRepository<out T> where T : Entity    // "T" stands for "data of some type"
    //{
    //    void Insert(T item);     // I want to insert some data.
    //    T Get(string id);        // and get it 
    //    IEnumerable<T> GetAll(); //            back later
    //}

    interface IWriteOnlyRepository<in T>
    {
        void Insert(T item);
    }

    interface IReadOnlyRepository<out T>
    {
        T Get(string id);
        IEnumerable<T> GetAll();
    }

    interface Entity { string Id { get; } }
}
