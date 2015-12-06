using UnityEngine;
using System.Collections;

[System.Serializable]

public class Boundary
{
	public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class movarino : MonoBehaviour
{
	public float speed = 10.0f;
	public float XUpdate = 0.0f;
	public float YUpdate = 0.0f;
	public float ZUpdate = 0.0f;
	public Boundary boundary;
	
	void FixedUpdate ()
	{

		boundary.yMax = 10;
		boundary.yMin = -10;
		boundary.zMax = 10;
		boundary.zMin = -10;

		speed = 10.0f;

		ZUpdate = Input.GetAxis ("Horizontal");
		YUpdate = Input.GetAxis ("Vertical");
		//Debug.Log(moveHorizontal);
		Vector3 movement = new Vector3(0.0f, YUpdate, ZUpdate);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3 
			(	20.0f,
			 Mathf.Clamp (GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax), 
			 Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
				);
	}
}