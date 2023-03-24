using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TimeBasedKeyValueStore : MonoBehaviour
{
    #region Question

    //https://leetcode.com/problems/time-based-key-value-store/

    #endregion

    #region References



    #endregion

    #region UnityLifecycle

    //Use this to initialize
    private void Awake()
	{
	
	}	
	
	//Use this to run
	private void Start()
    {
        
    }

    #endregion

    public class TimeMap
    {

        #region References and Constructor
        private Dictionary<string, List<ValueTime>> _dict;

        public TimeMap()
        {
            _dict = new Dictionary<string, List<ValueTime>>();
        }
        #endregion

        #region Public Methods

        public void Set(string key, string value, int timestamp)
        {
            ValueTime entry = new ValueTime(timestamp, value);
            if (_dict.ContainsKey(key))
            {
                _dict[key].Add(entry);
            }
            else
            {
                _dict.Add(key, new List<ValueTime>() { entry });
            }
        }

        public string Get(string key, int timestamp)
        {
            if (!_dict.ContainsKey(key))
            {
                return "";
            }

            List<ValueTime> entry = _dict[key]; ValueTime minTimeItem = new ValueTime(0, "");

            //Do Binary search here since entry is guarenteed to be sorted
            //Since timestamp values are ever increasing
            string output = Return_LastTimeStampValue(entry);

            #region Linear time solution
            //foreach (var item in entry)
            //{
            //    if (item.Time <= timestamp)
            //    {
            //        if (minTimeItem.Time <= item.Time)
            //        {
            //            minTimeItem = item;
            //        }
            //    }
            //}

            //return minTimeItem.Value;
            #endregion
            
            return output;
        }

        #endregion

        #region Helper Methods and Classes

        public class ValueTime
        {
            private int _time;
            private string _value;

            public int Time
            {
                get { return _time; }
                set { _time = value; }
            }

            public string Value
            {
                get { return _value; }
                set { _value = value; }
            }

            public ValueTime(int time, string value)
            {
                _time = time; _value = value;
            }
        }

        private string Return_LastTimeStampValue(List<ValueTime> list)
        {
            return "";
        }

        #endregion
    }
}