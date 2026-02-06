using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string[] scenes;
    private int currentScene;

    private void Start()
    {
        currentScene = getScene();
        if (currentScene == -1)
        {
            Debug.Log("SCENE NOT LISTED");
        }
    }

    int getScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int thisScene = -1;
        for (int i = 0; i < scenes.Length - 1; i++)
        {
            if(scenes[i] == scene.name)
            {
                thisScene = i;
            }
        }
        return thisScene;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }

        Continue();
    }

    public void Continue()
    {
        if (currentScene > scenes.Length - 1)
        {
            SceneManager.LoadScene(scenes[0]);
        }
        else
        {
            SceneManager.LoadScene(scenes[currentScene + 1]);
        }
    }
}
