using UnityEngine;
using System.Collections;

public class GrannyMovement : MonoBehaviour {

	float Xscale;
	Texture texture;
	public bool isMoving;
	public bool facingRight;

	// Use this for initialization
	void Start () 
	{
		Xscale = transform.localScale.x;
		isMoving = false;
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey("a"))
		{
			isMoving = true;
			transform.localScale = new Vector3(-Xscale, transform.localScale.y, transform.localScale.z);
			facingRight = false;
		}
		else if (Input.GetKey("d"))
		{
			isMoving = true;
			transform.localScale = new Vector3(Xscale, transform.localScale.y, transform.localScale.z);
			facingRight = true;
		}
		else
		{
			isMoving = false;
		}
	}


}
