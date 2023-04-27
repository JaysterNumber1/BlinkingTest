using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Search : MonoBehaviour
{
    private GameObject[] database;
    public string[] list;
    public List<string> sublist;
    
    private GameObject currentItem;

    [SerializeField]
    public NavMeshAgent agent;
    [SerializeField]
    public LineRenderer line;
    [SerializeField]
    public AutoFillButtons autoFill;
    
    
    [SerializeField]
    public TMP_InputField input;
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private GameObject previousItem;
    [SerializeField]
    private Material foundMaterial;
    [SerializeField]
    private Material defaultMaterial;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Camera itemCam;
   
    void Start()
    {


        agent = GetComponent<NavMeshAgent>(); //assign the NavMeshAgent attached to this GameObject
        line = GetComponent<LineRenderer>(); //assign the LineRenderer attatched to this GameObject
        autoFill = GetComponent<AutoFillButtons>(); // assign the AutoFill script attatched to this GameObject
        
        database = GameObject.FindGameObjectsWithTag("Medicine"); //find all objects with the tag "Medicine" in the scene
        
        list = new string[database.Length];  //create a string array with the names of the GameObject array of database
        for (int i = 0;i < database.Length; i++)
        {
            

            list[i] = database[i].name; //add each GameObject.name to the strnig array
            

        }
        //Array.Sort(list);
        
        //initialize the LineRederer values
        line.startWidth = .15f;
        line.endWidth = .15f;
        line.positionCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentItem != null )
        {
            cam.transform.LookAt(currentItem.transform); //if there is a current item, look at it
        }
        if(Vector3.Distance(agent.destination, transform.position) <= agent.stoppingDistance) //set the line to be invisible if it isn't that long (within stopping distance)
        {
            line.positionCount = 0;
            

        }
        else if (agent.hasPath)
        {
            DrawPath(); //Draw the line path
           
        }
    }
   
    //Creates the list to be used by AutoFillButtons
    public void AutoFill()
    {
        int cap = 0;
       
        for (int i = 0; i < list.Length; i++)
        {

            if (list[i].StartsWith(input.text) && !input.text.Equals("")&&cap<5)
            {
                sublist.Add(list[i]);
                cap++;
            }
            
        }
        autoFill.NukeEm(); //clear the autofill buttons
        autoFill.AddList(sublist); //create the autofill buttons 
        sublist.Clear(); //clears the sublist for the AutoFills
    }

    public void EndEdit()
    {
       //if the string list contains the inputed text, find the item's associated GameObject
        if (list.Contains(input.text))
        {
            int v = Array.IndexOf(list, input.text);
            item = database[v];
            Locate(item);
            autoFill.NukeEm();


        }
        else if (previousItem != null)
        {
            //if the value is not in list, clear the previous query
            ClearLast(previousItem);
           
        }
        
       

    }

    


    private void Locate(GameObject goal)
    {
        //Clear the last item, not particularly neccessary
        if (previousItem != null)
        {
            ClearLast(previousItem);
        }
        previousItem = goal;

        //Set the material of the GameObject to appear through walls, set the Agent's Destination to that GameObject

        goal.GetComponent<MeshRenderer>().material = foundMaterial;
        currentItem = goal;
        goal.layer = 6;
        itemCam.Render();
        agent.SetDestination(goal.transform.position);
        
       
    }

    //Clear the Material of the last destination
    private void ClearLast(GameObject previous)
    {
        previous.GetComponent<MeshRenderer>().material = defaultMaterial;
        previous.layer = 0;

    }

    //Draws the path the camera follows to reach item

    private void DrawPath()
    {
        line.positionCount = agent.path.corners.Length+1;
        line.SetPosition(0, transform.position);
        
        if (agent.path.corners.Length < 2)
        {
            return;
        }

        for(int i = 1; i < agent.path.corners.Length; i++)
        {
          
            
                Vector3 pointPosition = new Vector3(agent.path.corners[i].x, (currentItem.transform.position.y) * (i + 1) / agent.path.corners.Length, agent.path.corners[i].z);
                line.SetPosition(i, pointPosition);
            
           
        }
        line.SetPosition(agent.path.corners.Length, currentItem.transform.position);
        


    }


}
