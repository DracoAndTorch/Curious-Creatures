using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string[] sceneNames;
    public Scene currentScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentScene.name);
        }
    }

    public void LoadScene()
    {
        int thisScene = findThisScene();
        if (thisScene == -1)
        {
            SceneManager.LoadScene(sceneNames[0]);
        }
        else
        {
            SceneManager.LoadScene(sceneNames[thisScene + 1]);
        }
    }

    int findThisScene()
    {
        int thisScene = -1;
        for (int i = 0; i < sceneNames.Length; i++)
        {
            if (sceneNames[i] == currentScene.name)
            {
                thisScene = i;
            }
        }
        return thisScene;
    }
}
