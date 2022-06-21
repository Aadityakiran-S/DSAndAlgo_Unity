using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomHashTableImplementation : MonoBehaviour
{
    [SerializeField] private CustomHashTable hashTable;

    private void Awake()
    {
        ////Add relevant data here   
        hashTable = new CustomHashTable(4);
        hashTable.AddHashCell("Aaditya", 100f);
        hashTable.AddHashCell("Midhun", 200f);
        hashTable.AddHashCell("Amal", 150f);
        hashTable.AddHashCell("Abhijith", 100f);
        hashTable.AddHashCell("Allen", 90f);
        hashTable.AddHashCell("Adarsh", 80f);
    }

    private void Start()
    {
        hashTable.AddHashCell("Suvaneethan", 10f);
        Debug.Log("Key: Suvaneethan has value: " + hashTable.GetValue_ForGivenKey("Suvaneethan"));

        List<string> keyList = hashTable.GetAllKeys();
        foreach (var item in keyList)
        {
            Debug.Log(item);
        }

        hashTable.AddHashCell("Midhun", 10f);
        Debug.Log("Key: Midhun has value: " + hashTable.GetValue_ForGivenKey("Midhun"));
    }
}


