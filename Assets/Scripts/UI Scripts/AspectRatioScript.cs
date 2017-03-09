using UnityEngine;
using System.Collections;

public class AspectRatioScript : MonoBehaviour {

	public float targetaspect;

	public float windowaspect;

	public float scaleheight;
	public float scalewidth;

	// Use this for initialization
	void Start () {

		targetaspect = 16.0f / 9.0f;

		// Finds the games current aspect ratio
		windowaspect = Screen.width / Screen.height;


		// The current Viewport height should be scaled by this amount
		scaleheight = windowaspect / targetaspect;

		Camera camera = GetComponent<Camera> ();

		// If scaled height is less than current height add Letterbox

		if (scaleheight < 1.0f) {
			Rect rect = camera.rect;

			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;

			camera.rect = rect;
		} else { // Adds the Pillar Box
			scalewidth = 1.0f / scaleheight;

			Rect rect = camera.rect;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

			camera.rect = rect;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
