using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bot : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.gameObject.name != "Layer2") SceneManager.LoadScene(2);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
