using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Search search;
    
    // Establish the button and search scripts
    public void Start()
    {
        button= GetComponent<Button>();
        search = GameObject.Find("SearchManager").GetComponent<Search>();
        
    }

    
    //On Click, autofill the input field to the button name
    public void OnClick()
    {
        
        search.input.text = button.name;
        search.EndEdit();
    }
    
}
