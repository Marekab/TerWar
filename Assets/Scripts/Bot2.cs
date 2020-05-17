using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (collision.gameObject.name != "Layer2") SceneManager.LoadScene(4);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
