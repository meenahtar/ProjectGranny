using UnityEngine;
using System.Collections;

public class GrannyMovement : MonoBehaviour {

	float Xscale;
	Texture texture;
	public bool isMoving;

	// Use this for initialization
	void Start () 
	{
		Xscale = transform.localScale.x;
		isMoving = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey("a"))
		{
			isMoving = true;
			transform.localScale = new Vector3(-Xscale, transform.localScale.y, transform.localScale.z);
		}
		else if (Input.GetKey("d"))
		{
			isMoving = true;
			transform.localScale = new Vector3(Xscale, transform.localScale.y, transform.localScale.z);
		}
		else
		{
			isMoving = false;
		}
	}


}
