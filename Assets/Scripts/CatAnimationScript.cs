using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimationScript : MonoBehaviour {


	public CattributesScript CatScript;
	public MobileInputScript InputScript;

	private Animator Anim;

	SpriteRenderer SpriteRender;


	public Sprite CatPickedUp;
	public Sprite CatPutDown;
	public Sprite CatStrength;
	public Sprite CatInactive;
	public Sprite CatSelected;


	// Use this for initialization
	void Start () {
		CatScript = this.gameObject.GetComponent ("CattributesScript") as CattributesScript;
		InputScript = this.gameObject.GetComponent ("MobileInputScript") as MobileInputScript;
		SpriteRender = GetComponent<SpriteRenderer> ();

		Anim = GetComponent<Animator> ();
		Anim.Play ("CatStrengthAnimation");
		Invoke ("ChangeAnim", 5.0f);
	}


	void ChaneAnim()
	{
		Anim.Play ("CatStrengthAnimation");

	}


	// Update is called once per frame
	void Update () {

		if (CatScript.trainingType == ("Strength"))
			{
			SpriteRender.sprite	= CatStrength;
			}

		if (CatScript.trainingType == ("InActive")) 
		{
				SpriteRender.sprite = CatInactive;
		}

		if (InputScript.SelectedCat == this.gameObject) 
		{
			SpriteRender.sprite = CatSelected;
		}

//		if (CatPickedUp == true) {
//			SpriteRender.sprite = CatPickedUp;
//
//		}
	}
}
