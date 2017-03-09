using UnityEngine;
using System.Collections;

public class MainCameraManager : MonoBehaviour {

	public GameObject MainCamera;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void ActivateMainCamera()                         // Activates the main camera
	{
		MainCamera.SetActive (true);
	}

	public void DeactivateMainCamera()                      //Deactivates the main Camera
	{
		MainCamera.SetActive (false);

	}
}
