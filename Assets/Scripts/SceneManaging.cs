using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    [SerializeField]
    private string menu;
    [SerializeField]
    private string build;
    [SerializeField]
    private string find;


    //Establish the scene names in scripts
     void Start()
    {
        menu = "MainMenu";
        build = "BuildScene";
        find = "FindScene";
    }

    //Close the Application
    public void onQuit()
    {
        Application.Quit();
    }

    //Load the "FindScene"
    public void onFind()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(find);
        OnSceneLoad();

    }

    //Load the "BuildScene"
    public void onBuild()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(build);
        OnSceneLoad();

    }

    //Load the "MainMenu"
    public void onMenu()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(menu);
        OnSceneLoad();

    }

    //If a duplicate SceneManager is made, destroy
    public void OnSceneLoad()
    {
        if (GameObject.FindGameObjectsWithTag("SceneManager").Length>1)
        {
            Destroy(this);
        }
    }


}
