using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Search : MonoBehaviour
{
    private GameObject[] database;
    private string[] list;
    
    
    [SerializeField]
    private TMP_InputField input;
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private GameObject previousItem;
    [SerializeField]
    private Material foundMaterial;
    [SerializeField]
    private Material defaultMaterial;
    [SerializeField]
    private Camera itemCam;
   
    void Start()
    {
        
        database = GameObject.FindGameObjectsWithTag("Medicine");
        list = new string[database.Length];
        for (int i = 0;i < database.Length; i++)
        {
            

            list[i] = database[i].name;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void AutoFill()
    {

    }

    public void EndEdit()
    {
       
        if (list.Contains(input.text))
        {
            int v = Array.IndexOf(list, input.text);
            item = database[v];
            Locate(item);
        }
        else if (previousItem != null)
        {
            ClearLast(previousItem);
        }
       
    }

    private void Locate(GameObject goal)
    {
        if (previousItem != null)
        {
            ClearLast(previousItem);
        }
        previousItem = goal;
        goal.GetComponent<MeshRenderer>().material = foundMaterial;
        goal.layer = 6;
        itemCam.Render();
       
    }

    private void ClearLast(GameObject previous)
    {
        previous.GetComponent<MeshRenderer>().material = defaultMaterial;
        previous.layer = 0;

    }

   
}
