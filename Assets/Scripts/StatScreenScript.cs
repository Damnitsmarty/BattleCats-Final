using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatScreenScript : MonoBehaviour {

	public CattributesScript CatScript;
	public PlayerStatsScript Player;
	public MobileInputScript InputScript;


	public GameObject CurrentCat;

	public Text CatStrengthStat;
	public Text CatAgilityStat;
	public Text CatSightStat;
	public Text CatEnergyStat;
	public Text CatHungerStat;
	public Text CatTrainingStat;

	public int CatStrengh;
	public int CatAgility;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () 
	{
		CurrentCat = InputScript.SelectedCat;


		CatStrengthStat.text = CatScript.Strength.ToString ();
		CatAgilityStat.text = CatScript.Agility.ToString ();
		CatSightStat.text = CatScript.Perception.ToString ();
		CatEnergyStat.text = CatScript.Energy.ToString ();
		CatHungerStat.text = CatScript.Hunger.ToString ();
		CatTrainingStat.text = CatScript.trainingType.ToString ();
	

	}




}
