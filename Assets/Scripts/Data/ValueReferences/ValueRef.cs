using UnityEngine;

namespace Data.ValueReferences
{
    //Used for serializing a reference to a value that needs to be passed around.
    //Create a derived class of the type you need if you cannot find a specific type 
    public abstract class ValueRef<T> : ScriptableObject
    {
        public T Value
        {
            get;
            set;
        }
    }
}