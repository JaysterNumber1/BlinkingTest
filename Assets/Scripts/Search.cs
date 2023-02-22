using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Search : MonoBehaviour
{
    private GameObject[] database;
    private string[] list;
   
    void Start()
    {
        database = GameObject.FindGameObjectsWithTag("Medicine");
        list = new string[database.Length];
        for (int i = 0;i < database.Length; i++)
        {
            

            list[i] = database[i].ToString();
            Debug.Log(list[i]);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void AutoFill()
    {

    }

}
