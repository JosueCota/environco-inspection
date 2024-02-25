using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
    [SerializeField] Animator anim;
    
    void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.collider.CompareTags("FixedDrag"))
        {
            anim.SetBool("SwitchedOff", true);
        }
    }
}
