using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateItem : MonoBehaviour
{
    public GameObject shape;
    public GameObject createdShape;
    public GameObject itemList;
    public Item newItem;
    public TMP_InputField input;
    public bool inputReady;
    public TMP_Text prompt;
    public GameObject finished;
    public bool done;
    public Vector3 posHit;
    public float width;
    public float height;
    public float depth;
    public FreeFlyCamera ffc;
    // Start is called before the first frame update
    void Start()
    {

        done = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(NewItem());
    }

    private IEnumerator NewItem()
    {
        ffc._active = false;
        createdShape = Instantiate(shape, posHit, Quaternion.Euler(0, 0, 0), itemList.transform);
        newItem = createdShape.GetComponent<Item>();
        newItem.names = "";
        width = height = depth = 0f;

        done = false;

        //createdShape.transform.localScale = new Vector3(width, height, depth);


        
    
        while (!done)
        {



            if (height == 0)
            {
                if (depth == 0)
                {
                    if (width == 0)
                    {
                        if (newItem.names.Equals(""))
                        {
                            

                            prompt.text = "What is the name?";
                         
                            yield return new WaitUntil(() => inputReady);


                            newItem.names = input.text.ToString();
                            createdShape.name = newItem.names;
                            input.text = "";

                            inputReady = false;


                        }

                       

                        prompt.text = "What is the width?";

                        yield return new WaitUntil(() => inputReady && isFloat()==true);


                        width = float.Parse(input.text.ToString());
                        input.text = "";

                        inputReady = false;

                    }
                    

                    prompt.text = "What is the depth?";

                    yield return new WaitUntil(() => inputReady && isFloat() == true);


                    depth = float.Parse(input.text.ToString());
                    input.text = "";
                    inputReady = false;

                }
              

                prompt.text = "What is the height?";

                yield return new WaitUntil(() => inputReady && isFloat() == true);


                height = float.Parse(input.text.ToString());
                input.text = "";

                inputReady = false;

            }
            createdShape.transform.localScale = new Vector3(width, height, depth);

            yield return null;
            done = true;
           
        }

        

        createdShape.transform.position = new Vector3(createdShape.transform.position.x + width/2, createdShape.transform.position.y + height/2, createdShape.transform.position.z + depth/2);

        OnFinished();
        ffc._active = true;

    }

    public void EndEdit()
    {
        inputReady = true;

    }
    private bool isFloat()
    {
      
        if (float.TryParse(input.text.ToString(), out float result))
        {
            return true;
        }
        else
        {
            inputReady = false;
            return false;
        }
    }
    public void OnFinished()
    {
        prompt.text = "";
        EventSystem.current.SetSelectedGameObject(null);
        newItem = null;
        createdShape = null;

    }

}
