using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
    [SerializeField] Animator anim;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("FixedDrag"))
        {
            anim.SetBool("SwitchedOff", true);
        }
    }
}
