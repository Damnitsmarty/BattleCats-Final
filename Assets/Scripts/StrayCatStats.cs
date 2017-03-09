using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StrayCatStats : MonoBehaviour {



	public GameObject Cat; 
	public string CatName;
	public static GameObject GymPosition;
	public int Strength;
	public int Agility;
	public int Perception;
	public int Energy =100;
	public int Hunger =100;

	public float PositionX;
	public float PositionY;



	public int Loops;

	public int TrainingStartTime;   // The time the cats training started
	public int TimePlayerQuit;
	public int TimeDifference;

	public int CurrentTime;     // Finds the systems time
	public int TrainingTime = 0;
	public string training;               // Holds the type of training the cat is doing

	public Text CatNameText;
	public Text CatStrength;
	public Text CatAgility;
	public Text CatPerception;
	public Text CatEnergy;
	public Text CatHunger;
	public Text CatTraining;

	public string CatNameSaveFile;
	public string CatStrengthSaveFile;
	public string CatAgilitySaveFile;
	public string CatPerceptionSaveFile;
	public string CatEnergySaveFile;
	public string CatHungerSaveFile;
	public string CatTrainingSaveFile;
	public string CatXPositionSave;
	public string CatyPositionSave;

	void awake()
	{
		DontDestroyOnLoad (transform.gameObject);

	}

	// Use this for initialization
	void Start () {

		CurrentTime = (int)System.DateTime.Now.Minute;
		CatName = Cat.name;
		CatNameSaveFile = "Name :"+CatName;
		CatStrengthSaveFile = CatName+"Strength";
		CatAgilitySaveFile = CatName+"Agility";
		CatPerceptionSaveFile = CatName+"Perception";
		CatEnergySaveFile = CatName+"Energy";
		CatHungerSaveFile = CatName+"Hunger";
		CatTrainingSaveFile = CatName+"Training";  
		CatXPositionSave = CatName + "XPosition";
		CatyPositionSave = CatName + "YPosition";




		// This sections loads in all the cattributes and training info

		TrainingStartTime= PlayerPrefs.GetInt("TrainingStartTime");	  // Loads in when the cat srtarted its training
		TimePlayerQuit  =PlayerPrefs.GetInt("TimePlayerQuit");	  // Loads in the Cats strength Level
		Strength  =PlayerPrefs.GetInt(CatStrengthSaveFile);	  // Loads in the Cats strength Level
		Agility  =PlayerPrefs.GetInt(CatAgilitySaveFile);	  // Loads in the Cats strength Level
		Perception  =PlayerPrefs.GetInt(CatPerceptionSaveFile);	  // Loads in the Cats strength Level
		Energy  =PlayerPrefs.GetInt(CatEnergySaveFile);	  // Loads in the Cats strength Level
		Hunger  =PlayerPrefs.GetInt(CatHungerSaveFile);	  // Loads in the Cats strength Level
		training =PlayerPrefs.GetString(CatTrainingSaveFile);	  // Loads the current training
		PositionX = PlayerPrefs.GetFloat(CatXPositionSave);
		PositionY = PlayerPrefs.GetFloat (CatyPositionSave);

		TimeDifference = CurrentTime - TimePlayerQuit;    // When the game is started this calculates the time difference between when the game quit and the current time
		SetText();

		for (Loops = 0; TimeDifference > Loops; Loops++)   // For each minute that has passed the game loops
		{
			TrainingUpdate ();
			Debug.Log ("You trained for " + TimeDifference + training + "Points");
		}

		TrainingTime = CurrentTime + 1;



		Cat.transform.position = new Vector3 (PositionX, PositionY,0);	


	}


	void TrainingUpdate()      // This method updates the cattributes over time
	{

		switch (training) {

		case "Strength":

			Debug.Log (TrainingStartTime);
			if (Strength < 20) {
				Strength++;

			} else {
				Debug.Log ("This Cat has trained as far as it can in strength");
			}
			Hunger--;
			Energy--;

			break;

		case "Agility":
			Debug.Log ("You are training Agility");
			if (Agility < 20) {
				Agility++;
			} else {
				Debug.Log ("This Cat has trained as far as it can in Agility");
			}
			Hunger--;
			Energy--;
			break;

		case "Perception":
			Debug.Log ("You are training Perception");
			if (Perception < 20) {
				Perception++;
			} else {
				Debug.Log ("This Cat has trained as far as it can in strength");
			}
			Hunger--;
			Energy--;
			break;

		case "Kitchen":
			Debug.Log ("You are Eating at the kitchen");
			if (Hunger < 100) {
				Hunger++;
				Energy++;
			} else {
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
		CatTraining.text = "Training : " + training;
		CurrentTime = (int)System.DateTime.Now.Minute;
		if (CurrentTime == 0 && TrainingTime == 60)
		{
			TrainingTime = 1;
		}
		if (CurrentTime == TrainingTime)     // If the cat has been training for a certain amount of time then call the training method
		{
			TrainingUpdate ();
			TrainingTime = CurrentTime + 1;
			SetText ();

		}
	}

	void SetText()
	{
		CatNameText.text = "Name : " + CatName ;
		CatStrength.text = "Strength :" + Strength + " /20" ;
		CatAgility.text = "Agility :" + Agility +" /20";
		CatPerception.text = "Perception :" + Perception + "/20" ;
		CatEnergy.text = "Energy :" + Energy +" /100" ;
		CatHunger.text = "Hunger :" + Hunger +" /100" ;
	}

	public void OnApplicationQuit()    // When the game is quit, its saves the Cats attributes to file 
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
		PlayerPrefs.SetString ("CurrentTraining", training);
		PlayerPrefs.SetFloat (CatXPositionSave ,PositionX );
		PlayerPrefs.SetFloat (CatyPositionSave , PositionY);
		TimeDifference = 0;
		Loops = 0;
	}

	void OnApplicationPause()
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
		PlayerPrefs.SetString ("CurrentTraining", training);
		PlayerPrefs.SetFloat (CatXPositionSave ,PositionX );
		PlayerPrefs.SetFloat (CatyPositionSave , PositionY);
		TimeDifference = 0;
		Loops = 0;

	}


	public void SaveGame()
	{


	}




	public void Gym()     // When the gym button is pressed this changes the type of training underway to strength
	{
		training = "Strength";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime); // Saves the Training start time 
		TrainingTime = CurrentTime + 1;
		Debug.Log ("Training Strength");
	}

	public void TreadMill()        // When the gym button is pressed this changes the type of training underway to strength
	{
		training = "Agility";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
		TrainingTime = CurrentTime + 1;
	}

	public void LaserPointer()    // Perception Training
	{
		training = "Perception";
		PlayerPrefs.SetInt ("TrainingStartTime", CurrentTime);
	}

	public void Kitchen ()
	{
		training = "Kitchen";
	}

	public void InActive()
	{
		training = "InActive";
	}


	public void ResetStats ()    // Resets the Cattributes
	{
		Strength = 0;
		Agility = 0;
		Perception = 0;
		Energy = 100;
		Hunger = 100;
		training = "InActive";
		SetText ();
	}






}
