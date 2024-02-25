using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recycler : MonoBehaviour
{
    [SerializeField] bool isRecycler;
    public static ItemSpawner instance;
    [SerializeField] public float spawned;

    void OnCollisionEnter2D(Collision2D col)
    {   // Recycle layer = 10
        if (col.collider.gameObject.layer == 10 && isRecycler )
        {
            Destroy(col.gameObject);
            spawned -= 1;
        }

        else if (col.collider.gameObject.layer == 11 && !isRecycler)
        {
            Destroy(col.gameObject);
            spawned -= 1;
        }
    }

    private void Update()
    {
        if (spawned == 0)
        {
            SceneManager.LoadScene("MiniGame2");
        }
    }
}
