using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }

    [SerializeField] float timeRemaining = 30f;
    [SerializeField] TextMeshProUGUI timer;

    bool isFinished = false;


    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }


    void Update()
    {


        if (!isFinished)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                isFinished = true;
            }
            else
            {
                int seconds = Mathf.FloorToInt(timeRemaining % 60);
                timer.text = seconds.ToString();
            }
        }
        else
        {
            SceneManager.LoadScene("MiniGame2");
        }

    }

    private string DisplayTime(float time)
    {
        float seconds = Mathf.FloorToInt(time % 60);

        return string.Format("{0}", seconds);
    }

    private void changeScene()
    {

    }

}
