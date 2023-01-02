using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Monarchy
{
    #region Question
    //Google question: Build a monarchy
    #endregion

    #region References and Constructor

    [SerializeField]
    private Person _originalMonarch;

    [SerializeField]
    private Dictionary<string, Person> _internalFamilyLedger;

    public Monarchy(string monarchName)
    {
        Person newMonarch = new Person(monarchName);
        this._originalMonarch = newMonarch;

        _internalFamilyLedger = new Dictionary<string, Person>();
        _internalFamilyLedger.Add(monarchName, newMonarch);
    }

    #endregion

    #region Public Methods

    public void Birth(string childName, string parentName)
    {
        //List<Person> personList = new List<Person>();
        //RecursivelyFindPerson(parentName, _originalMonarch, personList);

        //if (personList.Count == 0)
        //{
        //    Debug.Log("Such a person called " + parentName + " DNE in the current Monarchy");
        //    return;
        //}

        //personList[0].AddChild(childName, _internalFamilyLedger);

        if (!_internalFamilyLedger.ContainsKey(parentName))
        {
            Debug.Log("Such a person DNE in the current Monarchy");
            return;
        }

        Person parent = _internalFamilyLedger[parentName];
        parent.AddChild(childName, _internalFamilyLedger);
    }

    public void Death(string personName)
    {
        //List<Person> personList = new List<Person>();
        //RecursivelyFindPerson(personName, _originalMonarch, personList);

        //if (personList.Count == 0)
        //{
        //    Debug.Log("Such a person called " + personName + " DNE in the current Monarchy");
        //    return;
        //}

        //personList[0].Kill();

        if (!_internalFamilyLedger.ContainsKey(personName))
        {
            Debug.Log("Such a person DNE in the current Monarchy");
            return;
        }

        Person personToKill = _internalFamilyLedger[personName];
        personToKill.Kill();
    }

    public List<string> GetOrderOfSuccession()
    {
        List<string> succList = new List<string>();

        RecursivelyAccumulateSuccession(succList, _originalMonarch);

        return succList;
    }

    #endregion

    #region Helper Functions

    private void RecursivelyFindPerson(string personName, Person currentPerson, List<Person> outputPersonList)
    {
        if (currentPerson.Name == personName)
        {
            outputPersonList.Add(currentPerson);
            return;
        }

        foreach (Person child in currentPerson.children)
        {
            RecursivelyFindPerson(personName, child, outputPersonList);
        }
    }

    private void RecursivelyAccumulateSuccession(List<string> outputList, Person currentPerson)
    {
        if (currentPerson.IsAlive == true)
        {
            outputList.Add(currentPerson.Name);
        }

        foreach (Person child in currentPerson.children)
        {
            RecursivelyAccumulateSuccession(outputList, child);
        }
    }

    #endregion    
}

[System.Serializable]
public class Person
{
    #region References and Constructor

    string _name;
    public string Name
    {
        get => _name;
        private set => _name = value;
    }

    bool _isAlive;
    public bool IsAlive
    {
        get => _isAlive;
        private set => _isAlive = value;
    }

    public List<Person> children; //How to prevent public access to kids?

    public Person(string name)
    {
        this._name = name;
        this._isAlive = true;
        this.children = new List<Person>(); //Empty Children list to be added later
    }

    #endregion

    #region Public Methods
    public void Kill()
    {
        if (_isAlive == true)
        {
            _isAlive = false;
        }
        else
        {
            Debug.Log("Can't kill a ghost!");
        }
    }

    public void AddChild(string childName, Dictionary<string, Person> familyLedger)
    {
        if (this._isAlive == false)
        {
            Debug.Log("Can't give birth when you're dead!");
            return;
        }

        Person child = new Person(childName);
        this.children.Add(child);
        familyLedger.Add(childName, child);
    }
    #endregion
}
