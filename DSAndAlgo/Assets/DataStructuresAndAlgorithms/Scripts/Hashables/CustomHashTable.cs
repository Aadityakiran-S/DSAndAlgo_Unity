using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class CustomHashTable
{
    #region Custom Structs

    [System.Serializable]
    public struct HashColumn
    {
        public bool isHashValid;
        public int hash;
        public LinkedList<HashCell> hashCellList;
    }

    [System.Serializable]
    public struct HashCell
    {
        public string key;
        public float value;
    }

    #endregion

    [SerializeField] private readonly List<HashColumn> _hashTable;
    [SerializeField] private int _maxNumberOfShelves;

    public CustomHashTable(int size)
    {
        _hashTable = new List<HashColumn>(size);
        _maxNumberOfShelves = size;
    }

    #region Public Functions

    public void AddHashCell(string key, float value)
    {
        //If a duplicate key is entered, returning out
        if (_hashTable.Any(x => x.hashCellList.Any(y => y.key == key)))
        {
            Debug.LogWarning("The key: " + key + " you have entered is a duplicate \n Try entering a unique key");
            return;
        }

        int hash = CreateHash(key);
        HashColumn hashColumn;
        HashCell hashCell = new HashCell
        {
            key = key,
            value = value
        };

        //Collision occurs and we need to add to existing hashColumn
        if (_hashTable.Any(x => x.hash == hash))
        {
            hashColumn = _hashTable.FirstOrDefault(x => x.hash == hash);
            hashColumn.hashCellList.AddLast(hashCell);
            Debug.LogWarning("Hash Collission has occured");
        }
        //No collision, create new hashColumn
        else
        {
            LinkedList<HashCell> hashCellList = new LinkedList<HashCell>();
            hashCellList.AddLast(hashCell);
            hashColumn = InitializeHashColumn(hash, hashCellList);
            _hashTable.Add(hashColumn);
        }
    }

    public float GetValue_ForGivenKey(string key)
    {
        int hashFromGivenKey = CreateHash(key);
        HashColumn hashColumn = _hashTable.FirstOrDefault(x => x.hash == hashFromGivenKey);

        if (hashColumn.isHashValid == false)
        {
            Debug.LogError("Entered key does not correspond to a hash in the table");
            return default;
        }
        else
        {
            return hashColumn.hashCellList.FirstOrDefault(x => x.key == key).value;
        }
    }

    public HashColumn RemoveEntireColumn(string key)
    {
        int hashFromGivenKey = CreateHash(key);
        HashColumn hashColumn = _hashTable.FirstOrDefault(x => x.hash == hashFromGivenKey);

        if (hashColumn.isHashValid == false)
        {
            Debug.LogError("Entered key does not correspond to a hash in the table");
            return default;
        }
        else
        {
            _hashTable.Remove(hashColumn);
            return hashColumn;
        }
    }

    public HashCell RemoveHashCell(string key)
    {
        int hashFromGivenKey = CreateHash(key);
        HashColumn hashColumn = _hashTable.FirstOrDefault(x => x.hash == hashFromGivenKey);

        if (hashColumn.isHashValid == false)
        {
            Debug.LogError("Entered jey does not correspond to a hash in the table");
            return default;
        }
        else
        {
            if (hashColumn.hashCellList.Any(x => x.key == key))
            {
                HashCell cellToRemove = hashColumn.hashCellList.FirstOrDefault(x => x.key == key);
                hashColumn.hashCellList.Remove(cellToRemove);
                return cellToRemove;
            }
            else
            {
                Debug.LogError("Entered key does not exist in hash table");
                return default;
            }
        }
    }

    public List<string> GetAllKeys()
    {
        List<string> keyList = new List<string>();

        foreach (HashColumn column in _hashTable)
        {
            foreach (HashCell cell in column.hashCellList)
            {
                keyList.Add(cell.key);
            }
        }

        return keyList;
    }

    //GetAllKeys and values function

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
            hash = hash,
            hashCellList = hashCellList
        };

        return hashColumn;
    }

    #endregion
}
