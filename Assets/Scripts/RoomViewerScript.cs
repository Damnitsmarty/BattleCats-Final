using UnityEngine;
using System.Collections;

public class RoomViewerScript : MonoBehaviour
{



	public CameraScript CameraInfo;

	public GameObject RoomCamera;      //The Camera in Each room
	public GameObject MainCamera;      // The Main Camera of the scene
	public GameObject RoomStats;
	public GameObject RoomUI;         // UI for the room
	public GameObject GameUI;         // The games UI


	public float CountDown;           // Time Limit for the double tap system
	public int NumberOfTaps;          // Number of taps in the time Limit
	 

	public bool RoomBeingWatched;     // Checks if the room is being watched


	// Use this for initialization
	void Start ()
	{
		
		GameUI = GameObject.Find ("UI");
		MainCamera = GameObject.Find ("Main Camera");
		CameraInfo = MainCamera.gameObject.GetComponent ("CameraScript") as CameraScript;
	}

	public void CameraSelected ()       // Activates the Camera in the room
	{
		RoomCamera.SetActive (true);
		MainCamera.SetActive (false);
		RoomUI.SetActive (true);
		GameUI.SetActive (false);
		RoomStats.SetActive (true);
			
		//CameraManager.DeactivateMainCamera ();
		Debug.Log ("Main Camera should be disabled");
	}

	public void CameraDeselected ()           // Deactivates the Camera in the room and reselects the main camera
	{
		RoomCamera.SetActive (false);
		MainCamera.SetActive (true);
		RoomUI.SetActive (false);
		GameUI.SetActive (true);
		RoomStats.SetActive (false);
	}
		
	// Update is called once per frame
	void Update ()
	{
		
		CountDown -= Time.deltaTime;            // Counts down the time

		if (CountDown < 0)                      // If the time is up 
		{
			NumberOfTaps = 0;                   // Reset number of taps
		}

		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began )   // If the user starts touching the screen
			{
			
			Vector3 ScreenPosition = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);       // Gets the position of the users touch
			Vector2 touchPos = new Vector2 (ScreenPosition.x, ScreenPosition.y);                         // Find that position in the scene
			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {                      // If the users touch and the 2D object overlap then
				CountDown = 1.5f;                                                                        // It starts the countdown


			{ 
				if (CountDown > 0) {                                                                    //If the countdown is still over the limit
					if (Input.touchCount >= 0) {                                                        // and if its the first touch
						NumberOfTaps = NumberOfTaps + 1;                                                // Add to the number of taps
					}
					if (NumberOfTaps == 2) {                                                            // If the sprite is tapped 2 times
							NumberOfTaps = 0;                                                           //The taps is reset
							if (CameraInfo.CameraMoving == false)
							{
							CameraSelected ();                                                          // The rooms camera is selected

							CountDown = 1.5f;                                                           //The countdown is reset
							}
					}
				}
			
				
			}
		}
	}
	}
	}





	

