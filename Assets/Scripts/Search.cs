using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Search : MonoBehaviour
{
    private GameObject[] database;
    private string[] list;
    private GameObject currentItem;

    public NavMeshAgent agent;
    public LineRenderer line;
    
    
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
    private Camera cam;
    [SerializeField]
    private Camera itemCam;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();
        
        database = GameObject.FindGameObjectsWithTag("Medicine");
        list = new string[database.Length];
        for (int i = 0;i < database.Length; i++)
        {
            

            list[i] = database[i].name;
            

        }

        line.startWidth = .15f;
        line.endWidth = .15f;
        line.positionCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentItem != null)
        {
            cam.transform.LookAt(currentItem.transform);
        }
        if(Vector3.Distance(agent.destination, transform.position) <= agent.stoppingDistance)
        {
            line.positionCount = 0;
        }
        else if (agent.hasPath)
        {
            DrawPath();
        }
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
        currentItem = goal;
        goal.layer = 6;
        itemCam.Render();
        agent.SetDestination(goal.transform.position);
        
       
    }

    private void ClearLast(GameObject previous)
    {
        previous.GetComponent<MeshRenderer>().material = defaultMaterial;
        previous.layer = 0;

    }

    //Draws the path the camera follows to reach item

    private void DrawPath()
    {
        line.positionCount = agent.path.corners.Length;
        line.SetPosition(0, transform.position);

        if (agent.path.corners.Length < 2)
        {
            return;
        }

        for(int i = 1; i < agent.path.corners.Length; i++)
        {
            Vector3 pointPosition = new Vector3(agent.path.corners[i].x, (currentItem.transform.position.y)*(i+1)/agent.path.corners.Length, agent.path.corners[i].z);
            line.SetPosition(i, pointPosition);
        }
    }

   
}
