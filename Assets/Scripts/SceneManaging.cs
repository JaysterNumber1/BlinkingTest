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

     void Start()
    {
        menu = "MainMenu";
        build = "BuildScene";
        find = "FindScene";
    }
    public void onQuit()
    {
        Application.Quit();
    }
    public void onFind()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(find);
        OnSceneLoad();

    }

    public void onBuild()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(build);
        OnSceneLoad();

    }

    public void onMenu()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(menu);
        OnSceneLoad();

    }
    public void OnSceneLoad()
    {
        if (GameObject.FindGameObjectsWithTag("SceneManager").Length>1)
        {
            Destroy(this);
        }
    }


}
