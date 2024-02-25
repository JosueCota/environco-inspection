using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : MonoBehaviour
{
    [SerializeField] bool isRecycler;

    void OnCollisionEnter2D(Collision2D col)
    {   // Recycle layer = 10
        if (col.collider.gameObject.layer == 10 && isRecycler )
        {
            Debug.Log("Hitting recycle");
            Destroy(col.gameObject);
        } else if (col.collider.gameObject.layer == 11 && !isRecycler)
        {
            Destroy(col.gameObject);
        }
    }
}
