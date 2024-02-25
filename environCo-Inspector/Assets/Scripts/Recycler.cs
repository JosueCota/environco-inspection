using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recycler : MonoBehaviour
{
    [SerializeField] bool isRecycler;
    public static ItemSpawner instance;
    private float recycle = 3;
    private float trash = 3;

    void OnCollisionEnter2D(Collision2D col)
    {   // Recycle layer = 10
        if (col.collider.gameObject.layer == 10 && isRecycler )
        {
            Destroy(col.gameObject);
            recycle -= 1;
        }

        else if (col.collider.gameObject.layer == 11 && !isRecycler)
        {
            Destroy(col.gameObject);
            trash -= 1;
        }
    }

    private void Update()
    {
        if(trash <= 0 && recycle <= 0)
        {
            SceneManager.LoadScene("MiniGame2");
        }
    }
}
