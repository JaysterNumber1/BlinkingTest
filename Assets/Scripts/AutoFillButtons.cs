using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using Unity.VisualScripting;

public class AutoFillButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPref;
    private GameObject button;
    private List<GameObject> buttons;
    
    public Transform canvas;
  

    // Start is called before the first frame update
    void Start()
    {
     
      buttons= new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void AddList(List<string> sublist)
    {
        
        for (int i = 0; i < sublist.Count; i++)
        {

            button = Instantiate(buttonPref, canvas);
            button.transform.Translate(0, -i*1.05f*button.GetComponent<RectTransform>().rect.height+25, 0);
            button.transform.parent = canvas;
            button.name = sublist[i];
            button.GetComponentInChildren<TMP_Text>().text = button.name;
            buttons.Add(button);
        }
       

    }
    public void NukeEm()
    {
        Debug.Log("NUKE 'EM ");
        for (int i = buttons.Count-1; i >=0; i--)

          
         {
            
            Destroy(buttons[i]);
            
        }
        buttons.Clear();



    }
}
