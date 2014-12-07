#pragma strict

var Xpos : float;
var patrolBool : int;
var Xscale : float;

function Start () {
	Xpos = transform.position.x;
	Xscale = transform.localScale.x;
	patrolBool = 1;

}

function Update () {
	if(patrolBool == 1)
	{
		transform.localScale.x = -Xscale;
		if(transform.position.x < 2.6)
		{
			transform.position.x += .055;
		}
		else
		{
		patrolBool = 0;
		}
	}
	else
	{
		transform.localScale.x = Xscale;
		if(transform.position.x > -1.75)
		{
			transform.position.x -= .055;
			if(transform.position.x < -1.75)
			{
				patrolBool = 1;
			}
		}
	}
	
}

function OnCollisionEnter () {
	transform.position.y += 1;
}