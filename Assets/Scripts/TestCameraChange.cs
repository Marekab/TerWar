using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraChange : MonoBehaviour
{
    public Transform Target;
    public float animationtime = 5;
    private UnityStandardAssets._2D.CameraFollow2D CameraFollow2D;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TestCameraSwap(collision.gameObject.transform));
        }
    }

   
    void Start ()
    {
        CameraFollow2D = Camera.main.GetComponent<UnityStandardAssets._2D.CameraFollow2D>();
	}
	
	// Update is called once per frame
	void Update ()
   {

		
	}
    private IEnumerator TestCameraSwap(Transform prefTarget)
    {
        CameraFollow2D.target = Target; 
        yield return new WaitForSecondsRealtime(animationtime);
        CameraFollow2D.target = prefTarget;
    }
}

