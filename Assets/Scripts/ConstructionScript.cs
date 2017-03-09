using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ConstructionScript : MonoBehaviour {


	public GameObject[] ConstructionsOptions;                        // Array holding the Rooms you can choose to build from
	public GameObject OpenConstructionButton;                        // The button to open the construciton Menu
	public GameObject CloseConstructionButton;                       // The button to close the construction Menu

	public bool ConstructionMode;                                    // Checks if the user is in Construction Mode

	public MobileInputScript CatPicked;


	InGameCanvas CanvasControls;

	 

	// Use this for initialization
	void Start () {
		ConstructionsOptions = GameObject.FindGameObjectsWithTag ("ConstructionOptions");         // Loads all the objects with the construction Options tag into the array
		ExitConstructionMode ();                                                                  // Exits Construction Mode
		ConstructionMode = false;                      
	}
	
	// Update is called once per frame
	void Update () 
	{

}
	public void EnterConstructionMode()                                    // Enters Construction Mode
	{
		

		foreach (GameObject go in ConstructionsOptions)                       // For each object in the Construction options array
		{
			go.SetActive (true);                                              // Activate each object
			OpenConstructionButton.SetActive (false);                         //Disable the Open button
			CloseConstructionButton.SetActive (true);                         //Activate the close button

		}
		ConstructionMode = true;

	}



	public void ExitConstructionMode()                                                          //Exits the construction Mode
	{
		
		ConstructionsOptions = GameObject.FindGameObjectsWithTag ("ConstructionOptions");               // Loads all the objects with the construction Options into the Array
		foreach (GameObject go in ConstructionsOptions)                                                 // For each object in the Array
		{ 
			if (go.tag == "ConstructionOptions")                                                       // If the object has the construction Option tag then disable it
			{
				go.SetActive (false);
				OpenConstructionButton.SetActive (true);
				CloseConstructionButton.SetActive (false);
			}

			if (go.tag != "ConstructionOptions")                                                        // If the object doesn't have the construction Option tag then it stays active
			{
				go.SetActive (true);
				OpenConstructionButton.SetActive (true);
				CloseConstructionButton.SetActive (false);
			}
		}
		ConstructionMode = false;
	

	}



}

