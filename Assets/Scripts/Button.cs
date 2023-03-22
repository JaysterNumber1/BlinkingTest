using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Search search;

    // Start is called before the first frame update
    public void Start()
    {
        button= GetComponent<Button>();
        search = GameObject.Find("SearchManager").GetComponent<Search>();
        
    }

    // Update is called once per frame

    public void OnClick()
    {
        
        search.input.text = button.name;
        search.EndEdit();
    }
    
}
