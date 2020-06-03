using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyController : MonoBehaviour
{
	public string GhostWallsTag;
	public float Speed = 1;

	private Rigidbody2D _rigidbody;

	public int Dirrection { get; private set; } 

	// Use this for initialization
	void Start()
	{
		Dirrection = 1;
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		_rigidbody.velocity = new Vector2(Dirrection, 0).normalized * Speed;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("Collision " + other.gameObject.name);
		if (other.gameObject.CompareTag(GhostWallsTag)) 
		{
			Dirrection = -Dirrection;
		}
	}
}
