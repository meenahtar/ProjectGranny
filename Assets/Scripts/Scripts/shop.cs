using UnityEngine;
using System.Collections;

public class shop : MonoBehaviour {

	public bool hasItem1 = false;
	public bool hasItem2 = false;
	public bool hasItem3 = false;
	public bool hasItem4 = false;
	public bool item1Box = false;
	public bool item2Box = false;
	public bool item3Box = false;
	public bool item4Box = false;
	public bool isContinueBTN = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hasItem1 == true) {
			markOff();
		}
		if(hasItem2 == true){
			markOff();
		}
		if(hasItem3 == true){
			markOff();
		}
		if(hasItem4 == true){
			markOff();
		}
		//print ("Has item 1 = " + hasItem1 + " Has item 2 = " + hasItem2 + " Has item 3 = " + hasItem3 + " Has item 4 = " + hasItem4);
	}

	void OnMouseEnter(){
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit(){
		renderer.material.color = Color.white;
	}

	void OnMouseUp(){
		if (item1Box == true) {
			hasItem1 = true;
		}
		if (item2Box == true) {
			hasItem2 = true;
		}
		if (item3Box == true) {
			hasItem3 = true;
		}
		if (item4Box == true) {
			hasItem4 = true;
		}
		if (isContinueBTN == true) {
			Application.LoadLevel("mainMenu");
		}

		//print ("Has item 1 = " + hasItem1 + " Has item 2 = " + hasItem2 + " Has item 3 = " + hasItem3 + " Has item 4 = " + hasItem4);
	}

	void markOff(){
		renderer.material.color = Color.green;
	}
}
