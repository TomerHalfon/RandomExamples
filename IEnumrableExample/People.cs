using System.Collections;
using System.Collections.Generic;

namespace IEnumrableExample
{
    /// <summary>
    /// A collection of people
    /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=netcore-3.1
    /// </summary>
    public class People: IEnumerable<Person>
    {
        Person[] _innerCollection;
        public People(params Person[] people) => _innerCollection = people;

        //Expose the generic enumerator
        public IEnumerator<Person> GetEnumerator() => new PeopleEnum(_innerCollection);
        //Expose the enumerator
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    /// <summary>
    /// an enumerator that recives a collection of person and map the movement of that collection
    /// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerator-1?view=netcore-3.1
    /// </summary>
    class PeopleEnum :IEnumerator<Person>
    {
        Person[] _innerCollection;
        int _position = -1;
        public PeopleEnum(Person[] people) => _innerCollection = people;

        //Return the current person we are observing
        public Person Current => _innerCollection[_position];
        //Return the current person we are observing (Explicit implemetation for the non generic request)
        object IEnumerator.Current => Current;
        //Incase we have an IDisposable type
        public void Dispose() {/*leave empty if no implemetation*/}
        //Move the position to the next position and return if it is a valid move(in the range)
        public bool MoveNext() => ++_position < _innerCollection.Length;
        //Reset the position to the start
        public void Reset() => _position = -1;
    }
}
