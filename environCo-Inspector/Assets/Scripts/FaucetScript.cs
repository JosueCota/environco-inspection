using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidBody2D;
    private float rotation;
    public bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.rotation.z);
        if (Mathf.Abs(transform.rotation.z) >= .9999 && canMove){
            Debug.Log("FREEZE");
            canMove = false;
        }
    }
}
