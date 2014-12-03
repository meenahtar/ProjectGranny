#pragma strict

var Xscale : float;
var texture : Texture;

function Start () {
	Xscale = transform.localScale.x;
}

function Update () {
	if (Input.GetKey("a"))
	{
		transform.localScale.x = -Xscale;
	}
	if (Input.GetKey("d"))
	{
		transform.localScale.x = Xscale;
	}
	if (Input.GetKey("f"))
	{
		renderer.material.SetTexture("GrannyAttack", texture);
	}

}