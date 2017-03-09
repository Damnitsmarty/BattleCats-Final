using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


	public MobileInputScript MobileInput;
	public MobileInputScript MobileInputs;

	public float FOVZoomOut = 60;                     // The field of view for the camera
	public float FOVZoomIn = 12;
	public float dragMultiplier = 0.1f;                           // The speed the player can move the camera at
    public float zoomMultiplier = 0.1f;

	public Vector2 FirstTouch;
	public Vector2 LastTouch;


	public bool CameraMoving;

	public float DragDistance;

	public float CameraLocked = 0;                          // If the camera is Locked it cannot move, Movement speed is set to 0
	public float CameraUnlocked = 1f;                       // If the camera is unlocked it can now move

	private float lastPinchDistance = -1;

	void Log(string text)
	{
		GameObject.Find("Logger").GetComponent<UnityEngine.UI.Text>().text += "\n" + text;
	}
	// Use this for initialization
	void Start () {
		DragDistance = Screen.height * 20 / 100;
	}

	// Update is called once per frame
	void Update () {
		Touch touch = Input.GetTouch (0);



			
			if(Input.touchCount == 0)                       // If the player touches the screen with 2 fingers
			{
                //Cast a ray, to see if it hits any draggable objects;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);            // A ray cast is sent from the point on the screen they touched
                RaycastHit hit;                
                if (Physics.Raycast(ray, out hit))             
                {
                    if (hit.collider.GetComponent<RoomCheckerScript>()) return;                
                }

				if (MobileInputs.CatPickedUp == true)                       // If the player is picking up a cat they cannot move the camera
				{
				dragMultiplier = 0f;
					Debug.Log ("Cat Picked Up");

				}


			if (touch.phase== TouchPhase.Began) 
			{
				FirstTouch = touch.position;
				LastTouch = touch.position;
			}

			if (touch.phase == TouchPhase.Moved) 
			{
				LastTouch = touch.position;
			}

			if (touch.phase == TouchPhase.Ended) 
			{
				LastTouch = touch.position;
			}


			if (Mathf.Abs (LastTouch.x - FirstTouch.x) > DragDistance || Mathf.Abs (LastTouch.y - FirstTouch.y) > DragDistance) 
			{
				CameraMoving = true;
			} 
			else
			{
				CameraMoving = false;
			}

			if (MobileInput.CatPickedUp == false)                          // When they drop the cat they can move again
			{
				dragMultiplier = 0.01f/2;
				Debug.Log ("Cat Dropped");
			}
				//Moving
				Vector2 dPos = Input.GetTouch(0).deltaPosition;                    // Changes the position of the camera Based on the players finger movemnts
				//slow the movement
				dPos *= dragMultiplier;

            if (dPos.y >= 0.5)
            {
                transform.position += new Vector3(0, -dPos.y, 0);                  // Updates the Camaras position, The Camera can only move up and down 
            }

		

			}
			
		}

}


