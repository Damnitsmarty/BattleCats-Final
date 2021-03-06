using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CattributesScript : MonoBehaviour {


    public RoomCheckerScript RoomCheck;




	public GameObject Cat;                                 // The cat holding the script
	public string CatName;                                 // The cat's Name
	public int Strength;                                   // The cat's Strength value
	public int Agility;                                    // The cat's Agility value
	public int Perception;                                 // The cat's Perception value
	public int Energy =100;                                // The cat's Energy value
	public int Hunger =100;                                // The cat's Hunger value

	public BoxCollider RoomCollider;

	public float PositionX;                                // The cat's X position value
	public float PositionY;                                // The cat's Y position value


	public int CatMaxStats;                                // The Limit that the cat can train to
	 

	public int Loops;                                       // The number of loops the Training update has to do

	public int TrainingStartTime;   // The time the cats training started
	public int TimePlayerQuit;      // The Time the player quit the game
	public int TimeDifference;      // The Difference between two times
	public int TimeLeft;    // Time untill the next stat increase



	public int CurrentTime;     // Finds the systems time
	public int TrainingTime = 0;
	public string training;// Holds the type of training the cat is doing
	public string trainingType;                             // The Type of training the player is doing 
	public string HungerLevel;                              // The Cat's Hunger Value

	public Text CatNameText;                                // The Cat's name Text
	public Text CatStrength;                                // The Cat's strength Text
	public Text CatAgility;                                 // The Cat's Agiltiy Text
	public Text CatPerception;                              // The Cat's perception Text
	public Text CatEnergy;                                  // The Cat's Energy Text
	public Text CatHunger;                                  // The Cat's Hunger Text
	public Text CatHungerLevel;                             // The Cat's Hunger Level Text
	public Text CatTraining;                                // The Cat's training Text

	string CatNameSaveFile;                            // The Cat's Name Save File Name
	string CatStrengthSaveFile;                        // The Cat's Strength Save File Name
	string CatAgilitySaveFile;                         // The Cat's Agility  Save File Name
	string CatPerceptionSaveFile;                      // The Cat's Perception Save File Name
    string CatEnergySaveFile;                          // The Cat's Energy Save File Name
	string CatHungerSaveFile;                          // The Cat's Hunger Save File Name
	string CatHungerLevelSaveFile;                     // The Cat's Hunger Level Save File Name
	string CatTrainingSaveFile;                        // The Cat's Training Save File Name
	string CatXPositionSave;                           // The Cat's X Position Save File Name
    string CatyPositionSave;                           // The Cat's Y Position Save File Name

	void awake()
	{
		DontDestroyOnLoad (transform.gameObject);

	}

	// Use this for initialization
	void Start () {

		CurrentTime = (int)System.DateTime.Now.Minute;                            // Get the systems current Time
		CatName = Cat.name;                                                       // Sets the Cats Name 
		SetCatsName();    // Set's the details of the cats Save and Load Info
		Cat = this.gameObject;

		if (CatMaxStats == null) 
		{
			SetMaxStats ();
		}

		// This sections loads in all the cattributes and training info
	
		TrainingStartTime= PlayerPrefs.GetInt("TrainingStartTime");	                        // Loads in when the cat srtarted its training
		TimePlayerQuit  =PlayerPrefs.GetInt("TimePlayerQuit");	                            // Loads in the Cats strength Level
		Strength  =PlayerPrefs.GetInt(CatStrengthSaveFile);	                               // Loads in the Cats strength Level
		Agility  =PlayerPrefs.GetInt(CatAgilitySaveFile);	                               // Loads in the Cats strength Level
		Perception  =PlayerPrefs.GetInt(CatPerceptionSaveFile);	                           // Loads in the Cats strength Level
		Energy  =PlayerPrefs.GetInt(CatEnergySaveFile);	                                  // Loads in the Cats strength Level
		Hunger  =PlayerPrefs.GetInt(CatHungerSaveFile);	                                 // Loads in the Cats strength Level
		HungerLevel = PlayerPrefs.GetString(CatHungerLevelSaveFile);                     //Loads the Cats Hunger Level 
		//trainingType =PlayerPrefs.GetString(CatTrainingSaveFile);	                     // Loads the current training
		PositionX = PlayerPrefs.GetFloat(CatXPositionSave);                              // Loads the Cats X position
		PositionY = PlayerPrefs.GetFloat (CatyPositionSave);                             // Loads the Cats y Position
	
		TimeDifference = CurrentTime - TimePlayerQuit;    // When the game is started this calculates the time difference between when the game quit and the current time
		SetText();

		for (Loops = 0; TimeDifference > Loops; Loops++)   // For each minute that has passed the game loops
		{
			TrainingUpdate ();                                    // Updates the Cats current Training
			Debug.Log ("You trained for " + TimeDifference + trainingType + "Points");
		}

		TrainingTime = CurrentTime + 1;                  // Sets the time untill the next training session is complete



		Cat.transform.position = new Vector3                    (PositionX, PositionY,-0.5f);	 // Moves the Cat to its saved location
	


	}

	void TrainingUpdate()      // This method updates the cattributes over time
	{
		switch (trainingType) {                         // Methods are called depending on the current training type

		case "Strength":                                 // If the cat is training in Strength

			Debug.Log ("Cat is training is Strength");


			                             // If the Cat hasn't reached its max stats

				if (training == "GymLevel1")                         //================================================
				{
					Strength++;                                      // The cats stats will be updtated in relation to which room they are training in
				} else 
				{
					if (training == "GymLevel2") 
					{
						Strength = Strength + 3;
					} 
					else if (training == "GymLevel3") 
					{
						Strength = Strength + 5;
					}
						
				}
			
			Hunger--;
			Energy--;

			break;

		case "Agility":                                          // Trains in Agility
			Debug.Log ("You are training Agility");




				if (training == "TreadMillLevel1") 
				{
					Strength++;
				} 
				else if (training == "TreadMillLevel2")
				{
					Strength = Strength + 3;
				} 
				else if (training == "TreadMillLevel3") 
				{
					Strength = Strength + 5;
				}

			Hunger--;
			Energy--;
			break;

		case "Perception":
			Debug.Log ("You are training Perception");


				if (training == "ArcadeRoomLevel1") 
				{
					Perception = Perception++;
				} 
				else if (training == "ArcadeRoomLevel2")
				{
					Perception = Perception + 3;
				} 
				else if (training == "ArcadeRoomLevel3") 
				{
					Perception = Perception + 5;
				}


			else 
			{
				Debug.Log ("This Cat has trained as far as it can in Perception");
			}
			Hunger--;
			Energy--;
			break;

		case "Kitchen":
			Debug.Log ("You are Eating at the kitchen");
			if (Hunger < 100 && Energy <100) {

				if (training == "KitchenLevel1") 
				{
					Hunger = Hunger + 10;
					Energy = Energy + 8;
				}
				else if (training == "KitchenLevel2") 
				{
					Hunger = Hunger + 15;
					Energy = Energy + 9;
				}
				else if (training == "KitchenLevel3") 
				{
					Hunger = Hunger + 20;
					Energy = Energy + 10;
				}
			} else
			{
				Debug.Log ("The cat is full");
			}

			break;
		case "InActive":
			Debug.Log ("Inactive");
			Hunger--;
			break;

		}
	}
		
	// Update is called once per frame
	void Update () {
		Debug.Log ("Cunt");
		CurrentTime = (int)System.DateTime.Now.Minute;         // Gets the current time
		if (CurrentTime == 0 && TrainingTime == 60) {            // If the current time is at the start or end of the clock then it will be set to 1 ( Avoids bugs)
			TrainingTime = 1;
		}
		if (CurrentTime == TrainingTime) {     // If the cat has been training for a certain amount of time then call the training method
			TrainingUpdate ();                    // Calls the training update
			TrainingTime = CurrentTime + 1;       // Updates the Training completion time
			SetText ();                           // Updates the text on display

		}

		// =============== Cat Hunger System ================================

//		if (Hunger > 80) {
//			//Debug.Log ("The cat is well fed");
//			HungerLevel = "HungerLevel :Well Fed"; 
//		} else if (Hunger > 50 && Hunger < 79) {
//			//Debug.Log (" The Cat is fed");
//			HungerLevel = "Hunger Level : Fed";                            // If the cats Hunger gets too high then it will effect the cats training performance
//
//		} else if (Hunger > 35 && Hunger < 49) {
//			//Debug.Log ("The cat is hungry");
//			HungerLevel = "Hunger Level : Hungry";
//		} else if (Hunger < 34 && Hunger > 1) {
//			//Debug.Log ("Starving");
//			HungerLevel = "Hunger Level : Starving";
//		}
	}



	



	
		
	void SetText()                                                  // Updates the Text on screen
	{
		CatNameText.text = "Name : " + CatName ;                                            // Displays the Cats Name
		CatStrength.text = "Strength :" + Strength +" / "+CatMaxStats ;                    // Displays the Cats Strength
		CatAgility.text = "Agility :" + Agility + " / " + CatMaxStats;                    // Displays the Cats Agility
		CatPerception.text = "Perception :" + Perception+" / "+ CatMaxStats;              // Displays the Cats perception
		CatEnergy.text = "Energy :" + Energy +" / 100" ;                                  // Displays the Cats Energy
		CatHungerLevel.text = HungerLevel;                                               // Displays the Cats Hunger Level
		CatHunger.text = "Hunger :" + Hunger+" / 100" ;                                 // Displays the Cats Hunger
	}

	public void OnApplicationQuit()                  // When the game is quit, its saves the Cats attributes to file 
	{
		PositionX = transform.position.x;              // Saves the Cats X Position 
		PositionY = transform.position.y;              // Saves the Cats Y Position



		TimePlayerQuit = CurrentTime;
		PlayerPrefs.SetString (CatNameSaveFile,CatName );                       // Saves the Cat's Name
		PlayerPrefs.SetInt (CatStrengthSaveFile, Strength);                       // Saves the Cat's Strength
		PlayerPrefs.SetInt (CatAgilitySaveFile, Agility);                        // Saves the Cat's Agility
		PlayerPrefs.SetInt (CatPerceptionSaveFile, Perception);                  // Saves the Cat's Perception
		PlayerPrefs.SetInt (CatEnergySaveFile, Energy);                       // Saves the Cat's Energy
		PlayerPrefs.SetInt (CatHungerSaveFile, Hunger);                       // Saves the Cat's Hunger
		PlayerPrefs.SetString (CatHungerLevelSaveFile, HungerLevel);          // Saves the Cat's Hunger Level
		PlayerPrefs.SetInt ("TimePlayerQuit", TimePlayerQuit);               // Saves the time that the player Quit
		PlayerPrefs.SetString (CatTrainingSaveFile, trainingType);           // Saves the Training type
		PlayerPrefs.SetFloat (CatXPositionSave ,PositionX );                 // Saves the Cats X position
		PlayerPrefs.SetFloat (CatyPositionSave , PositionY);                // Saves the Cat's Y Position
		TimeDifference = 0;
		Loops = 0;
	}

	void OnApplicationPause()                           // When the game is close all the values are saved
	{
		PositionX = transform.position.x;
		PositionY = transform.position.y;



		TimePlayerQuit = CurrentTime;
		PlayerPrefs.SetString (CatNameSaveFile,CatName );
		PlayerPrefs.SetInt (CatStrengthSaveFile, Strength);
		PlayerPrefs.SetInt (CatAgilitySaveFile, Agility);
		PlayerPrefs.SetInt (CatPerceptionSaveFile, Perception);
		PlayerPrefs.SetInt (CatEnergySaveFile, Energy);
		PlayerPrefs.SetInt (CatHungerSaveFile, Hunger);
		PlayerPrefs.SetInt ("TimePlayerQuit", TimePlayerQuit);
		PlayerPrefs.SetString (CatTrainingSaveFile, trainingType);
		PlayerPrefs.SetFloat (CatXPositionSave ,PositionX );
		PlayerPrefs.SetFloat (CatyPositionSave , PositionY);
		TimeDifference = 0;
		Loops = 0;

	}


	public void SaveGame()
	{
	

	}
		
	public void GymLevel1()     // When the gym button is pressed this changes the type of training underway to strength
	{
		trainingType = "Strength";
		training = "GymLevel1";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime); // Saves the Training start time 
		TrainingTime = CurrentTime + 1;
		Debug.Log ("Training Strength");
      
	}

	public void GymLevel2()     // When the gym button is pressed this changes the type of training underway to strength
	{
		Debug.Log ("Shit");
		trainingType = "Strength";
		training = "GymLevel2";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime); // Saves the Training start time 
		TrainingTime = CurrentTime + 1;
		Debug.Log ("Training Strength");
		return;
    }

	public void GymLevel3()     // When the gym button is pressed this changes the type of training underway to strength
	{
		trainingType = "Strength";
		training = "GymLevel3";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime); // Saves the Training start time 
		TrainingTime = CurrentTime + 1;
		Debug.Log ("Training Strength");
	}

	public void TreadMillLevel1()        // When the gym button is pressed this changes the type of training underway to strength
	{
		trainingType = "Agility";
		training = "TreadMillLevel1";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
		TrainingTime = CurrentTime + 1;
	}

	public void TreadMillLevel2()        // When the gym button is pressed this changes the type of training underway to strength
	{
		trainingType = "Agility";
		training = "TreadMillLevel2";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
		TrainingTime = CurrentTime + 1;
	}

	public void TreadMillLevel3()        // When the gym button is pressed this changes the type of training underway to strength
	{
		trainingType = "Agility";
		training = "TreadMillLevel3";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
		TrainingTime = CurrentTime + 1;
	}


	public void ArcadeLevel1()    // Perception Training
	{
		trainingType = "Perception";
		training = "ArcadeLevel1";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
	}

	public void ArcadeLevel2()    // Perception Training
	{
		trainingType = "Perception";
		training = "ArcadeLevel2";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
	}

	public void ArcadeLevel3()    // Perception Training
	{
		trainingType = "Perception";
		training = "ArcadeLevel3";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
	}




	public void SetCatsName()
	{
		CatNameSaveFile = "Name :"+CatName;                          //==================================================
		CatStrengthSaveFile = CatName+"Strength";
		CatAgilitySaveFile = CatName+"Agility";
		CatPerceptionSaveFile = CatName+"Perception";
		CatEnergySaveFile = CatName+"Energy";                             // This sections Creates Unique save files for each cat 
		CatHungerSaveFile = CatName+"Hunger";                             // 
		CatHungerLevelSaveFile = CatName + "HungerLevel";
		CatTrainingSaveFile = CatName+"Training";  
		CatXPositionSave = CatName + "XPosition";
		CatyPositionSave = CatName + "YPosition";                   // ===============================================================



	}




		
	public void KitchenLevel1 ()
	{
		trainingType = "Kitchen";
		training = "KitchenLevel1";
	}

	public void KitchenLevel2 ()
	{
		trainingType = "Kitchen";
		training = "KitchenLevel2";
	}

	public void KitchenLevel3 ()
	{
		trainingType = "Kitchen";
		training = "KitchenLevel3";
	}



	public void InActive()
	{
		trainingType = "InActive";
	}


	public void ResetStats ()    // Resets the Cattributes
	{
		Strength = 0;
		Agility = 0;
		Perception = 0;
		Energy = 100;
		Hunger = 100;
		trainingType = "InActive";
		SetText ();
	}
		



	public void SetMaxStats()
	{

		if (gameObject.tag == "StrayCat")                 // Sets the Max stats for a stray Cat
		{
			CatMaxStats = 20;

		}

		if (gameObject.tag == "HouseCat")                // Sets the max stats for a house cat
		{
			CatMaxStats = 40;
		}

		if (gameObject.tag == "NinjaCat")                // Sets the max stats for a ninja cat
		{
			CatMaxStats = 60;
		}

	}


}


