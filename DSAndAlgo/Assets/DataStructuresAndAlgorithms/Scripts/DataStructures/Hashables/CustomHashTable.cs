using System;
using System.Linq;
using System.Collections.Generic;

[System.Serializable]
public class CustomHashTable
{
    #region Custom Structs

    [System.Serializable]
    public struct HashColumn
    {
        public bool isHashValid;
        public LinkedList<HashCell> hashCellList;
    }

    [System.Serializable]
    public struct HashCell
    {
        public string key;
        public float value;
    }

    #endregion

    private readonly HashColumn[] _hashTable;
    private int _maxNumberOfShelves;   //It's better if this is a prime number to prevent collisions

    public CustomHashTable(int size)
    {
        _hashTable = new HashColumn[size];
        _maxNumberOfShelves = size;
    }

    #region Public Functions

    public void AddHashCell(string key, float value)
    {
        int hash = CreateHash(key);
        if (_hashTable[hash].hashCellList is null)    //given key corresponds to unique hash
        {
            HashColumn hashColumn;
            HashCell hashCell = new HashCell
            {
                key = key,
                value = value
            };

            LinkedList<HashCell> hashCellList = new LinkedList<HashCell>();
            hashCellList.AddLast(hashCell);
            hashColumn = InitializeHashColumn(hash, hashCellList);
            _hashTable[hash] = hashColumn;

        }
        else    //Hash is not unique => collission has occured
        {
            if (_hashTable[hash].hashCellList.Any(x => x.key == key)) //Given key is a duplicate
            {
                UnityEngine.Debug.LogWarning("The key: " + key + " you have entered is a duplicate \n Try entering a unique key");
                return;
            }
            else    //Given key is unique even though colission has occured
            {
                HashCell hashCell = new HashCell
                {
                    key = key,
                    value = value
                };

                _hashTable[hash].hashCellList.AddLast(hashCell);

                UnityEngine.Debug.LogWarning("Hash collision has occured");
            }
        }
    }

    public float GetValue_ForGivenKey(string key)
    {
        int hashFromGivenKey = CreateHash(key);
        if(_hashTable[hashFromGivenKey].hashCellList == null)    //Key doesn't correspond to hash
        {
            UnityEngine.Debug.LogError("Entered key does not correspond to a hash in the table");
            return default;
        }
        else    //Either hashColumn has the key or cell list within it has it
        {
            //This will be O(n) in the worst case only
            return _hashTable[hashFromGivenKey].hashCellList.FirstOrDefault(x => x.key == key).value; 
        }
    }

    public HashColumn RemoveEntireColumn(string key)
    {
        int hashFromGivenKey = CreateHash(key);

        if (_hashTable[hashFromGivenKey].hashCellList == null)   //Nothing in that column, no sense in removing
        {
            UnityEngine.Debug.LogError("Entered key does not correspond to a hash in the table");
            return default;
        }
        else //Key corresponds to a column, so that can be deleted
        {
            HashColumn column = _hashTable[hashFromGivenKey];
            _hashTable[hashFromGivenKey] = new HashColumn();
            return column;
        }
    }

    //O(1) in case of no collisions
    public HashCell RemoveHashCell(string key)
    {
        int hashFromGivenKey = CreateHash(key);
        HashColumn hashColumn = _hashTable[hashFromGivenKey];

        if (hashColumn.hashCellList.Count == 0)   //Hash doesn't even exist
        {
            UnityEngine.Debug.LogError("Entered key does not correspond to a hash in the table");
            return default;
        }
        else    //Hash exists but need to find which cell has the key
        {
            if (hashColumn.hashCellList.Any(x => x.key == key)) //O(n) in case of any collisions other O(1)
            {
                HashCell cellToRemove = hashColumn.hashCellList.FirstOrDefault(x => x.key == key);
                hashColumn.hashCellList.Remove(cellToRemove);
                return cellToRemove;
            }
            else
            {
                UnityEngine.Debug.LogError("Entered key does not exist in hash table");
                return default;
            }
        }
    }

    public List<string> GetAllKeys()
    {
        List<string> keyList = new List<string>();

        foreach (HashColumn column in _hashTable)
        {
            if(column.hashCellList != null)
            {
                foreach (HashCell cell in column.hashCellList)
                {
                    keyList.Add(cell.key);
                }
            }
        }

        return keyList;
    }

    //TODO: write a function that returns all keys and values

    #endregion

    #region Helper Functions

    private string CreateMD5Hash(string inputKey)
    {
        // Byte array representation of source string
        var sourceBytes = System.Text.Encoding.UTF8.GetBytes(inputKey.ToString());

        // Generate hash value (Byte Array) for input data
        var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(sourceBytes);

        // Convert hash byte array to string
        string hash = System.BitConverter.ToString(hashBytes).Replace("-", string.Empty);

        return hash;
    }

    int CreateHash(string key)
    {
        var hash = 0;
        for (int i = 0; i < key.Length; i++)
        {
            hash = (hash + (int)(key[i]) * i) % _maxNumberOfShelves;
        }
        return hash;
    }

    HashColumn InitializeHashColumn(int hash, LinkedList<HashCell> hashCellList)
    {
        HashColumn hashColumn = new HashColumn
        {
            isHashValid = true,
            hashCellList = hashCellList
        };

        return hashColumn;
    }

    #endregion
}
