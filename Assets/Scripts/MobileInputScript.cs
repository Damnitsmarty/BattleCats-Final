using UnityEngine;
using System.Collections;

public class MobileInputScript : MonoBehaviour
{
	public CattributesScript CatInfo;
	public PlayerStatsScript PlayerInfo;
	public StatScreenScript CatStats;
	public RoomCheckerScript RoomScript;



	public float speed = 100;
	public GameObject Cat;
	public bool CatPickedUp;
	public Vector3 TouchMovement;
	public GameObject SelectedCat;
	public GameObject StatScreen;

	public ConstructionScript ConstructionMenu;

	SpriteRenderer SpriteRender;

	public Sprite CatPickedUpSprite;
	public Sprite CatDownSprite;


	// Use this for initialization
	void Start ()
	{
		Cat = this.gameObject;

		SpriteRender = GetComponent<SpriteRenderer> ();
		CatPickedUp = false;

		CatInfo = this.gameObject.GetComponent ("CattributesScript") as CattributesScript;
		CatStats = StatScreen.gameObject.GetComponent ("StatScreenScript") as StatScreenScript;

	}


	// Update is called once per frame
	void Update ()
	{



		CatPickedUp = false;

		if (Input.touchCount == 1) {
			CatPickedUp = true;
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit hit;
			Vector3 TouchPos = new Vector3 (ray.origin.x, ray.origin.y, -6f);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "Cat") {  // Will need to change this to fix the All cats moving things;
					



					CatPickedUp = true;
					if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
						SelectedCat = hit.collider.gameObject;
						CatStats.CatStrengthStat.text = CatInfo.Strength.ToString ();
						CatStats.CatAgilityStat.text = CatInfo.Agility.ToString ();
						CatStats.CatSightStat.text = CatInfo.Perception.ToString ();
						CatStats.CatHungerStat.text = CatInfo.Hunger.ToString ();
						CatStats.CatEnergyStat.text = CatInfo.Energy.ToString ();
						CatStats.CatTrainingStat.text = CatInfo.training.ToString ();

					}
						
					Debug.Log ("Cat touch");
					if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
						Debug.Log ("Move attempt");
						//TouchMovement = Input.GetTouch (0).deltaPosition;
						//this.gameObject.transform.position = new Vector3 (TouchPos.x, TouchPos.y, -6f);
						if (SelectedCat == this.gameObject) 
						{
							SelectedCat.gameObject.transform.position = new Vector3 (TouchPos.x, TouchPos.y, -6f);
						}
						
						//(-TouchMovement.x * 0.1f, -TouchMovement.y * 0.1f, -TouchMovement.z * 0f);
				
						Debug.Log ("Cat Moved");
					


				



//			Vector3 ScreenPosition = Camera.main.ScreenToWorldPoint (Input.GetMouseButtonDown.position);
//			Vector2 touchPos = new Vector2 (ScreenPosition.x, ScreenPosition.y);
//				if (GetComponent<Collider> () == Physics.OverlapBox (touchPos))
//			{
//
//			
//				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
//					
//					// Gets the change of position of the finger since the last frame
//					Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
//
//					// Move the cat across the Screen
//					transform.position = new Vector3 (touchPos.x, touchPos.y, -0.5f);
//
//
//				}
//
//
//			}
//		}





					}
				}
			}


		}
	}
}

