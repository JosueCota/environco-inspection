using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recycler : MonoBehaviour
{
    [SerializeField] bool isRecycler;
    public static ItemSpawner instance;

    void OnCollisionEnter2D(Collision2D col)
    {   // Recycle layer = 10
        if (col.collider.gameObject.layer == 10 && isRecycler )
        {
            Destroy(col.gameObject);
        }

        else if (col.collider.gameObject.layer == 11 && !isRecycler)
        {
            Destroy(col.gameObject);
        }
    }
}
