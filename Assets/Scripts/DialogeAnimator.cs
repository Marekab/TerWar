using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogeManger dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        startAnim.SetBool("startOpen", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        startAnim.SetBool("startOpen", false);
        dm.EndDialoge();
    }
}
