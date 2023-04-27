using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using static UnityEditor.Progress;
//using Unity.VisualScripting;

public class AutoFillButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPref;
    private GameObject button;
    private List<GameObject> buttons;
    
    public Transform canvas;
    public GameObject buttonOrigin;
  

    // Start is called before the first frame update
    void Start()
    {
      buttons= new List<GameObject>();
    }

    //Add each item that starts with the passed in inputs and create a button for them.
    public void AddList(List<string> sublist)
    {    
        for (int i = 0; i < sublist.Count; i++)
        {
            button = Instantiate(buttonPref, buttonOrigin.transform);
            
            //button.transform.Translate(0, -i*button.GetComponent<RectTransform>().rect.height, 0);
            
            button.transform.parent = buttonOrigin.transform;
            button.name = sublist[i];
            button.GetComponentInChildren<TMP_Text>().text = button.name;
            buttons.Add(button);
        } 
    }

    //Clear all buttons. Used whenever there is a change in the list.
    public void NukeEm()
    {  
        for (int i = buttons.Count-1; i >=0; i--)        
         {        
            Destroy(buttons[i]);         
        }
        buttons.Clear();
    }
}
