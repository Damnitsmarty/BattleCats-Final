using UnityEngine;
using System.Collections;

/*
 *  Unity UI button-friendly functions to toggle UI states
 */

public class InGameCanvas : MonoBehaviour {
    private Animator anim;


	public GameObject SettingsPages;

    bool slideBar = false;
    bool storePage = false;
    bool backPanel = false;
	bool SettingsPage = false;
	bool ConstructionBar = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

	public void SetSlideBar(bool value)
	{
		slideBar = value;
		anim.SetBool("SlideBar", slideBar);
		UpdateBackPanel();
	}




	public void SetConstructionBar(bool value)
	{
		ConstructionBar = value;
		anim.SetBool("ConstructionBar", slideBar);
		UpdateBackPanel();
	}
		
    public void SetStorePage(bool value)
    {
        storePage = value;
        anim.SetBool("StorePage", storePage);
        UpdateBackPanel();
    }



	public void SetSettingPage (bool value)
	{
		storePage = value;
		anim.SetBool ("SettingsPage", SettingsPage);
		SettingsPages.SetActive (true);
		UpdateBackPanel ();
	}

	public void RemoveSettings()
	{
		SettingsPages.SetActive (false);


	}

	public void UpdateBackPanel()
    {
        backPanel = slideBar || storePage;
        anim.SetBool("BackPanel", backPanel);

    }
}
