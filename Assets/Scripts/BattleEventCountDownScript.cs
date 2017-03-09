using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleEventCountDownScript : MonoBehaviour {

	public int CurrentTime;
	public int TimeOfEvent;
	public int EventCountDown;
	public bool EventActive;



	public Text CountDown;






	// Use this for initialization
	void Start () {
		EventActive = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		CurrentTime = (int)System.DateTime.Now.Minute;
		EventCountDown = TimeOfEvent - CurrentTime;
		SetCountDownClock();
		if (EventActive == true) 
		{
			TimeOfEvent = CurrentTime + 8;
			EventActive = false;
		}
	}


	Debug.Logger("Yas");

	void SetCountDownClock()
	{
		CountDown.text = "Event In: " + EventCountDown +""+ " Minutes";

	}

	void SetTimeOfEvent()
	{
		CurrentTime = (int)System.DateTime.Now.Minute;

		CountDown.text = "Event In: " + EventCountDown + "Minutes";

	}
}
