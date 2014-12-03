#pragma strict

var Xpos : float;

function Start () 
{
	Xpos = transform.position.x;
}

function Update () 
{
	if (Input.GetKey("g"))
	{
		transform.position.x -= .075;
	}

}