using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingOutMonarchy : MonoBehaviour
{
    #region References

    [SerializeField] List<string> successionList;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        successionList = new List<string>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        Monarchy alanMonarchy = new Monarchy("Alan");

        alanMonarchy.Birth("Sarah", "Alan");
        alanMonarchy.Birth("Jacob", "Alan");
        alanMonarchy.Birth("Izekiel", "Alan");

        alanMonarchy.Birth("Josh", "Sarah");
        alanMonarchy.Birth("Mark", "Sarah");

        alanMonarchy.Birth("Zack", "Josh");
        alanMonarchy.Birth("Bartholemew", "Zack");

        successionList = alanMonarchy.GetOrderOfSuccession();
    }

    #endregion
}
