using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CustomArray2EditModeTest
{
    [Test]
    public void CustomArray2EditModeTestSimplePasses()
    {
        CustomArray2 tempArray = new CustomArray2();
        tempArray.Push("Bijoy");
        tempArray.Push("Midhun");
        tempArray.Push("Allen");
        tempArray.Push("Aaditya");
        tempArray.Push("Amal");
        tempArray.Push("Abhijith");
        tempArray.Push("Adarsh");

        Assert.AreEqual("Bijoy", tempArray.GetObject(0));
        Assert.AreEqual(7, tempArray.Length);
        Assert.AreEqual("Adarsh", tempArray.Pop());
        Assert.AreEqual("Abhijith", tempArray.Delete(5));
    }
}
