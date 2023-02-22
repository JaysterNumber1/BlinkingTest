using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Search : MonoBehaviour
{
    private GameObject[] database;
    private string[] list;
    private InputField item;
    private string itemName;
   
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

    public void SearchList()
    {
        
        if(list.Contains<string>())
        {
            Debug.Log("ITEMFOUND");
        }
    }

}
