using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCollision : MonoBehaviour
{
    private float sticks;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sticks += 1;
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
    }
    private void Update()
    {
        if (sticks == 3)
        {
            Delay();
            SceneManager.LoadScene("StartScreen");
        }
    }
}
