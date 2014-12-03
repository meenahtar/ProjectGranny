#pragma strict

function Start () 
{

}

function Update () 
{
	var texture: Texture = Resources.Load("GrannyAttack");
	
	if (Input.GetKey("f"))
	{
		renderer.material.mainTexture = texture;
	}
}