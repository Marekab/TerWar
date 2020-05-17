using UnityEngine;
using System.Collections;

public class FireScript2D : MonoBehaviour
{

	public float speed = 10; // скорость пули
	public Rigidbody2D bullet; // префаб нашей пули
	public Transform gunPoint; // точка рождения
	public float fireRate = 1; // скорострельность
	public bool facingRight = true; // направление на старте сцены, вправо?

	public Transform zRotate; // объект для вращения по оси Z

	// ограничение вращения
	public float minAngle = -40;
	public float maxAngle = 40;

	private float curTimeout;
	private int invert;

	void Start()
	{
		if (!facingRight) invert = -1; else invert = 1;
	}

	void SetRotation()
	{
		Vector3 mousePosMain = Input.mousePosition;
		mousePosMain.z = Camera.main.transform.position.z;
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
		lookPos = lookPos - transform.position;
		float angle = Mathf.Atan2(lookPos.y, lookPos.x * invert) * Mathf.Rad2Deg;
		angle = Mathf.Clamp(angle, minAngle, maxAngle);
		zRotate.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void Update()
	{
		if (Input.GetButton("Fire"))
		{
			Fire();
		}
		else
		{
			curTimeout = 100;
		}

		if (zRotate) SetRotation();

		float h = Input.GetAxis("Horizontal");

		if (h > 0 && !facingRight) 
			Flip(); 
		else if (h < 0 && facingRight) 
			Flip();
	}

	void Flip() // отражение по горизонтали
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		invert *= -1;
		transform.localScale = theScale;
	}

	void Fire()
	{
		curTimeout += Time.deltaTime;
		if (curTimeout > fireRate)
		{
			curTimeout = 0;
			Vector3 direction = gunPoint.position - transform.position;
			Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
			clone.velocity = transform.TransformDirection(direction.normalized * speed);
			clone.transform.right = direction.normalized;
		}
	}
}