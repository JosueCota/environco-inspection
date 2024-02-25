using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckHeirarchy : MonoBehaviour
{
    bool gameObjectFound = false;

    void Update()
    {
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject recyclable in allGameObjects)
        {
            if (recyclable.name == "Recyclable(Clone)")
            {
                gameObjectFound = true;
                Debug.Log("found recyclable");
            }
        }

        GameObject[] otherGameObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject trash in allGameObjects)
        {
            if (trash.name == "Trash(Clone)")
            {
                gameObjectFound = true;
                Debug.Log("found trash");
            }
        }

        if(gameObjectFound == false)
        {
            SceneManager.LoadScene("MiniGame2");
        }

        gameObjectFound = false;
    }
}