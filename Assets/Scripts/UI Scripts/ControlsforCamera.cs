using UnityEngine;
using System.Collections;

public class ControlsforCamera : MonoBehaviour {


	public float speed = 0.01f;

	public GameObject CatPosition;




	// Use this for initialization
	void Start ()
	{


	}

	// Update is called once per frame
	void Update ()
	{



		if (Input.touchCount == 1) {
			Vector3 ScreenPosition = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (ScreenPosition.x, ScreenPosition.y);
			

				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {

					// Gets the change of position of the finger since the last frame
					Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

					// Move the cat across the Screen
					transform.position = new Vector3 (touchPos.x, touchPos.y, 0);

				}
			}
		}
	}
