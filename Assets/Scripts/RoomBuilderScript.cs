using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RoomBuilderScript : MonoBehaviour {


	RoomBuilderScript BuildScript;
	CameraScript CameraInfo;

	public GameObject MainCamera;
	public GameObject GymRoom;                        // The Gym Prefab
	public GameObject ArcadeRoom;                     // The Arcade Room
	public GameObject KitchenRoom;                        // Kitchen
	public GameObject TreadmillRoom;                  // TreadMill Room ( Currently Not In)
	public GameObject ConstructionRoom;               // The Empty Constructionroom
	public GameObject ConstructionBar;                // The Construction UI
	public Sprite BuildSprite;                        // The Buid Option Sprite
	public Sprite ConstructionSprite;                 // The under construction Sprite
	public GameObject Sprite;                     
	public GameObject Parent;                         // The Parent Object ( Used to change the Rooms Name and Tag After building)
	public BoxCollider2D BuggyCollider;               // A Collider that causes issues if left active

	public GameObject GymHolder;

	public Button GymButton;
	public Button ArcadeButtons;
	public Button KitchenButton;


	public bool BuildingGym;                          // Checks if a Gym is being Built
	public bool BuildingArcade;                       // Checks if a Arcade is being Built
	public bool BuildingKitchen;                      // Checks if a Kithcen is being Built

	public bool CatNip;



	public int CurrentTime;                            // The Systems current Time
	public int BuildStartTime;                         // The time the construction was started
	public int BuildFinishTime;                        // The time the Construction will finish
	public int BuildTimeLeft;                          // How long is left before construction is finished

	ConstructionScript BuildControls;                   

	SpriteRenderer spriteRender;
	PlayerStatsScript PlayerInfo;


	// Use this for initialization
	void Start () {

		MainCamera = GameObject.Find ("MainCamera");

		GymRoom = this.gameObject.transform.FindChild ("GymRoomPrefab").gameObject;
		ArcadeRoom = this.gameObject.transform.FindChild ("ArcadePrefab").gameObject;
		KitchenRoom = this.gameObject.transform.FindChild ("KitchenPrefab").gameObject;
		ConstructionRoom = this.gameObject.transform.FindChild ("ConstructionRoomPrefab").gameObject;
		ConstructionBar = this.gameObject.transform.FindChild ("ConstructionBar").gameObject;
		CameraInfo = MainCamera.gameObject.GetComponent ("CameraScript") as CameraScript;
	
	

	
	





		//BuildSpritePosition = BuildSprite.transform.position;
		spriteRender = GetComponent<SpriteRenderer>();
		PlayerInfo = GameObject.Find("PlayerStats Manager").GetComponent<PlayerStatsScript>();
		BuildControls = GameObject.Find ("Construction Manager").GetComponent<ConstructionScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		CatNip = PlayerInfo.CatNipMode;
		CurrentTime= (int)System.DateTime.Now.Minute;                  // Gets the current time

		BuildTimeLeft = BuildFinishTime - CurrentTime;
		if (Input.touchCount == 2) 
		{
			ConstructionBar.SetActive (false);                         // Disables the Construction UI if the player moves the camera
		}




		if (Input.touchCount == 1 && CameraInfo.CameraMoving != true)                                    // If the player touches the screen with one hand 
		{

			Vector3 ScreenPosition = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (ScreenPosition.x, ScreenPosition.y);                             // and the touch is on one of the Construction Sprite
			if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {
				if (GetComponent<Collider2D>().tag == "ConstructionOptions") {                               // And the sprite has the Construction Option Tag
					ShowConstructionBar ();                                                                  // It will show that Rooms Construction UI

				}
			}
		}


		if (CatNip == true) {
			if (Input.touchCount == 1) {
				Vector3 ScreenPosition = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchPos = new Vector2 (ScreenPosition.x, ScreenPosition.y);                             // and the touch is on one of the Construction Sprite
				if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {
					if (GetComponent<Collider2D> ().tag == "UnderConstruction") {
						BuildTimeLeft = 0;
						Debug.Log ("Cat Nip mother fucker");
						PlayerInfo.CatNipUsed ();
						PlayerInfo.CatNipModeDeactivated ();
					}

				}
			}
		}


		if (BuildTimeLeft <= 0)                                                                               // If the construction is finished
		{
			if (BuildingGym == true)                    // If a Gym is being built
			{
				FinishBuildingGym ();                 // Spawn a gym
			}
			 
			if (BuildingArcade == true)              // If a Arcade is being built 
			{
				FinishArcade ();                      // Spawn a Arcade

			}


			if (BuildingKitchen == true)               // If a Kitchen is being built 
			{
				FinishKitchen ();                     // Spawn a kitchen
			}
		}
	}

	public void ShowConstructionBar()             // This method displays the construction UI
	{
		ConstructionBar.SetActive (false);
		ConstructionBar.SetActive (true);
	}

	public void HideConstructionBar()             // This method Hides the construction UI
	{
		ConstructionBar.SetActive (false);
		BuildControls.ExitConstructionMode ();
	}


	void FinishBuildingGym ()                     // Spawns the gym
	{
		BuildingGym = false;
		Parent.tag = "GymLevel1";                // Changes the Parent Objects Tag
		Parent.name = "Gym";                     //Changes the parent objects Name
		BuggyCollider.enabled = false;           // Disables a collider
		GymRoom.SetActive (true);                // Activates the Gym Room
		ConstructionRoom.SetActive (false);      // Deactivates the Construction Room
		HideConstructionBar ();                  // Hides the Construction UI
	}

	public void BuildGym ()                       // Starts the construction of the Gym
	{
		Debug.Log ("Bitch");
		gameObject.GetComponentInChildren<SpriteRenderer> (Sprite).sprite = ConstructionSprite;              // Changes the sprite on the room
		BuildFinishTime = CurrentTime + 2;                                                                   // Sets the finsih time for the build
		BuildingGym = true;                                
		Parent.tag = "UnderConstruction";                                                                    // Changes the Tag to under construction
		HideConstructionBar ();                                                                // Hides the Construction UI 
		PlayerInfo.GymBuilt ();                               // Should remove Battlecat Coins ( Not working at the moment)
		ConstructionBar.SetActive (false);
        PlayerInfo.BattleCatCoins = PlayerInfo.BattleCatCoins - 250;
	}

	public void BuildArcade()                                                                                 //Starts the construction of the Arcade
	{
		
		Parent.tag = "UnderConstruction";                                                                     // Changes the rooms Tag
		gameObject.GetComponentInChildren<SpriteRenderer> (Sprite).sprite = ConstructionSprite;               // Changes the sprite of the Room
		BuildFinishTime = CurrentTime + 2;                                                                    // Sets the finish time for the Build
		BuildingArcade = true;                          
		HideConstructionBar ();                                                                               // Hides the Construction Ui
		PlayerInfo.ArcadeBuilt();
		ConstructionBar.SetActive (false);
        PlayerInfo.BattleCatCoins = PlayerInfo.BattleCatCoins - 200;
    }

	public void FinishArcade ()                        // Spawns the Arcade
	{ 
		Parent.tag = "ArcadeLevel1";                   // Changes the Rooms tag
		Parent.name = "Arcade";                        // Changes the Rooms name
		BuggyCollider.enabled = false;                 // Disables the collider
		ArcadeRoom.SetActive (true);                   // Activates the Arcade room
		ConstructionRoom.SetActive (false);            // Hides the Empty Construction Room
		HideConstructionBar ();                        // Hides the construction UI

	}



	public void FinishKitchen()                        // Spawns the Kitchen
	{
		Parent.tag = "KitchenLevel1";                  // Changes the Rooms Tag
		Parent.name = "Kitchen";                       // Changes the rooms name
		BuggyCollider.enabled = false;                 // Disables the Buggy Collider
		KitchenRoom.SetActive (true);                      //Activates the Kitchen Room
		ConstructionRoom.SetActive (false);            //Hides the Empty Construction Room
		HideConstructionBar ();                        // Hides the construction UI
	}



	public void BuildKitchen ()                                                                             // Starts the Construction of a Kitchen
	{
		Parent.tag = "UnderConstruction";                                                                   // Changes the Rooms tag
		gameObject.GetComponentInChildren<SpriteRenderer> (Sprite).sprite = ConstructionSprite;             // Changes the Rooms Sprite
		BuildFinishTime = CurrentTime + 2;                                                                  // Sets the Finsih time for the construction
		BuildingKitchen = true;                                                                              
		HideConstructionBar ();                                                                             // Hides the construciton UI
		PlayerInfo.KitchenBuilt ();                                                                          // Deducts funds from the player
		ConstructionBar.SetActive (false);
        PlayerInfo.BattleCatCoins = PlayerInfo.BattleCatCoins - 100;
    }
}
