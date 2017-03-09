using UnityEngine;
using System.Collections;
using System;

public class TimeTest : MonoBehaviour {

	
	public float TheTime;
	public float Limit;

	int d = (int)System.DateTime.Now.DayOfWeek;
	int Month = (int)System.DateTime.Now.Month;
	int y = (int)System.DateTime.Now.Year;
	int m = (int)System.DateTime.Now.Minute;
	int h = (int)System.DateTime.Now.Hour;

	public int CompletionTime;


	public bool Training ; 
	// Use this for initialization
	void Start () {
	
		Limit = 10.0F;
		Debug.Log ("The Date is " + d + "/" + Month + "/" + y );
		Debug.Log ("The Minute is " + m);
		Debug.Log ("The Hour is " + h);
		Training = false;
		CompletionTime = 59;
	}
	
	// Update is called once per frame
	void Update () 
	{

	




			if ( m > CompletionTime) 
			{
				Debug.Log ( "The training is Complete");
				
			}








		

		if (Input.GetKeyDown (KeyCode.F2)) {
			Debug.Log ("Is it "+ m);
			
		}

			if (Input.GetKeyDown (KeyCode.F1)) {
				StartTraining ();

			}




//		TheTime = Time.time;
//		//Debug.Log ("The Time is"+ TheTime);
//		Debug.Log ("The Date is " + d);
//		if (TheTime > Limit) 
//		{
//			Debug.Log ( "Ten seconds have passed");
//
//		}


	}

	void StartTraining ()
	{
		CompletionTime = m + 1;
		Debug.Log ("Training will be complete at " + CompletionTime);
		Training = true;
	}
}
