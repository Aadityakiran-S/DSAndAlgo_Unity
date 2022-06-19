using System;
using System.Collections;
using System.Collections.Generic;
public class CustomArray2
{
    #region References and constructor

    private int _length;
    public int Length { get => _length; }
    private Object[] _data;

    public CustomArray2()
    {
        this._length = 0;
        this._data = new Object[0];
    }

    #endregion

    #region Public Methods

    public Object GetObject(int index)
    {
        CommonMethods.CheckIfIndexInBounds(index, Length);

        return _data[index];
    }

    public void Push(Object obj)
    {
        Object[] arrayWithElementPushed = new Object[Length + 1];

        for (int i = 0; i < Length; i++)    //Moving over all elements from pervious array
        {
            arrayWithElementPushed[i] = _data[i];
        }

        arrayWithElementPushed[Length] = obj;
        _data = arrayWithElementPushed;

        _length++;
    }

    public Object Pop()
    {
        if (Length == 0)
        {
            throw new ArgumentException("Array doesn't have any more elements to pop. Sorry");
        }

        Object[] arrayWithoutPoppedElement = new Object[Length - 1];

        for (int i = 0; i < Length - 1; i++)    //Moving over all elements from pervious array
        {
            arrayWithoutPoppedElement[i] = _data[i];
        }

        Object entryToPop = _data[Length - 1];
        _data = arrayWithoutPoppedElement;
        _length--;

        return entryToPop;
    }

    //TODO: Check if this is working
    public Object Delete(int index)
    {
        CommonMethods.CheckIfIndexInBounds(index, Length);

        Object[] arrayWithElementDeleted = new Object[Length - 1];
        Object elementToDelete = null;

        for (int i = 0; i < Length; i++)
        {
            if (i < index)
            {
                arrayWithElementDeleted[i] = _data[i];
            }
            else if (i == index)
            {
                elementToDelete = _data[i];
                continue;
            }
            else
            {
                arrayWithElementDeleted[i - 1] = _data[i];
            }
        }

        _data = arrayWithElementDeleted;
        _length--;
        return elementToDelete;
    }


    #endregion

    #region Private Functions



    #endregion
}
