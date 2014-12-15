﻿using UnityEngine;
using System.Collections;

public class shop : MonoBehaviour {

	public bool item1Box = false;
	public bool item2Box = false;
	public bool item3Box = false;
	public bool item4Box = false;
	public bool isContinueBTN = false;

	// Use this for initialization
	void Start () {

		//For testing, disable for release!!!
		PlayerPrefs.SetInt ("GrannyHasItem1", 0);
		PlayerPrefs.SetInt ("GrannyHasItem2", 0);
		PlayerPrefs.SetInt ("GrannyHasItem3", 0);
		PlayerPrefs.SetInt ("GrannyHasItem4", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("GrannyHasItem1") == 1){
			markOff();
		}
		if(PlayerPrefs.GetInt("GrannyHasItem2") == 1){
			markOff();
		}
		if(PlayerPrefs.GetInt("GrannyHasItem3") == 1){
			markOff();
		}
		if(PlayerPrefs.GetInt("GrannyHasItem4") == 1){
			print("WHY");
			markOff();
		}
		/*
		print ("Item 1 = " + PlayerPrefs.GetInt("GrannyHasItem1"));
		print ("Item 2 = " + PlayerPrefs.GetInt("GrannyHasItem2"));
		print ("Item 3 = " + PlayerPrefs.GetInt("GrannyHasItem3"));
		print ("Item 4 = " + PlayerPrefs.GetInt("GrannyHasItem4"));
		*/
	}

	void OnMouseEnter(){
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit(){
		renderer.material.color = Color.white;
	}

	void OnMouseUp(){
		if (item1Box == true) {
			PlayerPrefs.SetInt("GrannyHasItem1",1);
		}
		if (item2Box == true) {
			PlayerPrefs.SetInt("GrannyHasItem2",1);
		}
		if (item3Box == true) {
			PlayerPrefs.SetInt("GrannyHasItem3",1);
		}
		if (item4Box == true) {
			PlayerPrefs.SetInt("GrannyHasItem4",1);
		}
		if (isContinueBTN == true) {
			//print(PlayerPrefs.GetInt("lastLevel"));
			PlayerPrefs.SetInt("lastLevel", PlayerPrefs.GetInt("lastLevel") + 1);
			print(PlayerPrefs.GetInt("lastLevel"));
			Application.LoadLevel(PlayerPrefs.GetInt("lastLevel"));
			print(PlayerPrefs.GetInt("lastLevel"));
		}

		//print ("Has item 1 = " + hasItem1 + " Has item 2 = " + hasItem2 + " Has item 3 = " + hasItem3 + " Has item 4 = " + hasItem4);
	}

	void markOff(){
		//renderer.material.color = Color.green;
	}
}