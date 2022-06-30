using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomLinkedList
{
    #region References

    private List<AddressValuePair> _linkedList;
    private int _length;
    public int Length
    {
        get { return _length; }
        private set { }
    }

    [System.Serializable]
    private struct AddressValuePair
    {
        public System.Object value;
        public System.Object nextAddress;
    }

    #endregion

    public CustomLinkedList(System.Object firstValue)
    {
        AddressValuePair firstValuePair = new AddressValuePair
        {
            value = firstValue,
            nextAddress = null
        };

        _linkedList = new List<AddressValuePair>
        {
            firstValuePair
        };

        _length = 1;
    }

    #region Methods

    public void Append(System.Object valueToAppend)
    {
        AddressValuePair lastValuePair = _linkedList[_length - 1];
        AddressValuePair newEntry = new AddressValuePair
        {
            value = valueToAppend,
            nextAddress = null
        };
        _linkedList.Add(newEntry);
        lastValuePair.nextAddress = _linkedList[_length - 1];

        _length++;
    }

    public void Prepend(System.Object valueToPrepend)
    {
        AddressValuePair firstValueAddressPair = _linkedList[0];
        AddressValuePair newEntry = new AddressValuePair
        {
            value = valueToPrepend,
            nextAddress = firstValueAddressPair
        };
        _linkedList.Insert(0, newEntry);

        _length++;
    }

    public void Remove(System.Object valueToRemove)
    {
        AddressValuePair valuePairToRemove = _linkedList.FirstOrDefault(x => x.value == valueToRemove);
        if (valuePairToRemove.value == null)
        {
            Debug.LogError("The value you're looking to remove does not exist");
            return;
        }
        else
        {
            int indexToRemove = _linkedList.IndexOf(valuePairToRemove);

            //If removing head, just remove it, nothing else to be done
            if(indexToRemove == 0)
            {
                _linkedList.RemoveAt(indexToRemove);
            }
            //If removing in the middle, set previous entry's pointer to entry after the one to remove
            else
            {
                AddressValuePair previouToRemovedPair = _linkedList[indexToRemove - 1];
                AddressValuePair nextToRemovedPair = _linkedList[indexToRemove + 1];

                previouToRemovedPair.nextAddress = nextToRemovedPair;

                _linkedList.RemoveAt(indexToRemove);
            }

            _length--;
        }
    }

    public System.Object Retrieve(int index = 0)
    {
        return _linkedList[index].value;
    }

    #endregion

    #region Private Methods



    #endregion
}
