using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeTrigger : MonoBehaviour
{
    public DialogeManger manger;
    public Dialoge dialoge; 
    public void TriggerDialoge()
    {
        manger.StartDialoge(dialoge);
    }
}