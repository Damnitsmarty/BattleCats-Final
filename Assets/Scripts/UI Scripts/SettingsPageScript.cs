using UnityEngine;
using System.Collections;

public class SettingsPageScript : MonoBehaviour {


	public GameObject settingspage;
	public GameObject CatStatsPage;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}


	public void CatStatsPageshow()
	{
		CatStatsPage.SetActive (true);

	}


	public void CatStatsPageHide()
	{
		CatStatsPage.SetActive (false);
	}



	public void SettingsPageShow()
	{
		settingspage.SetActive (true);
	
	}



	public void SettingsPageHide()
	{
		settingspage.SetActive (false);

	}

}
