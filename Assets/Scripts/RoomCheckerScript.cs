using UnityEngine;
using System.Collections;

public class RoomCheckerScript : MonoBehaviour {



	public  CattributesScript cattributes;
     public MobileInputScript InputScript;

    
   
    bool CatPickedUp;
	public GameObject CatLock;
	bool CatInPlace;

	// Use this for initialization
	void Start () {

		cattributes = this.gameObject.GetComponent ("CattributesScript") as CattributesScript;
		InputScript = this.gameObject.GetComponent ("MobileInputScript") as MobileInputScript;

	}
	
	// Update is called once per frame
	void Update () {
        CatPickedUp = InputScript.CatPickedUp;

//		if (this.gameObject.transform.position != CatLock.transform.position) 
//		{
//			CatInPlace = false;
//		}
//

//		if (CatLock != null && InputScript.CatPickedUp == false && CatInPlace == false) 
//		{
//			
//			LockCat ();
//
//
//		}





	}


//	void OnTriggerStay (Collider other)
//	{
//		if (other.gameObject.tag == "CatLock" ) 
//		{
//			CatLock = other.gameObject;
//			if (InputScript.CatPickedUp == false) 
//			{
//				this.gameObject.transform.position = CatLock.transform.position;
//			}
//		}
//
//
//
//	}


	void LockCat()
	{
		this.gameObject.transform.position = CatLock.transform.position;
		CatInPlace = true;
	}


    void OnTriggerEnter(Collider other)
    {
		Debug.Log ("Entered Room");
		CatLock = other.gameObject.transform.Find ("CatLock").gameObject;
		LockCat ();
	

            if (other.gameObject.tag == "GymLevel1")
            {
                
                cattributes.GymLevel1();
                Debug.Log("Cat placed in Gym");
                

		}


            if (other.gameObject.tag == "GymLevel2")
            {
			

			Debug.Log ("Gym");
			cattributes.GymLevel2 ();
                Debug.Log("Cat placed in Gym");
                


            }



            if (other.gameObject.tag == "GymLevel3")
            {
                cattributes.GymLevel3();
                Debug.Log("Cat placed in Gym");
            }







            if (other.gameObject.tag == "TreadMillLevel1")
            {
                cattributes.TreadMillLevel1();
                Debug.Log("Cat placed on the TreadMill");
            }


            if (other.gameObject.tag == "TreadMillLevel2")
            {
                cattributes.TreadMillLevel2();
                Debug.Log("Cat placed on the TreadMill");
            }

            if (other.gameObject.tag == "TreadMillLevel3")
            {
                cattributes.TreadMillLevel3();
                Debug.Log("Cat placed on the TreadMill");
            }



            if (other.gameObject.tag == "LaserRoomLevel1")
            {
                cattributes.ArcadeLevel1();
                Debug.Log("Cat placed in LaserRoom");
            }

            if (other.gameObject.tag == "LaserRoomLevel2")
            {
                cattributes.ArcadeLevel2();
                Debug.Log("Cat placed in LaserRoom");
            }

            if (other.gameObject.tag == "LaserRoomLevel3")
            {
                cattributes.ArcadeLevel3();
                Debug.Log("Cat placed in LaserRoom");
            }





            if (other.gameObject.tag == "KitchenLevel1")
            {
                cattributes.KitchenLevel1();
                Debug.Log("Cat placed in Kitchen");
            }


            if (other.gameObject.tag == "KitchenLevel2")
            {
                cattributes.KitchenLevel2();
                Debug.Log("Cat placed in Kitchen");
            }


            if (other.gameObject.tag == "KitchenLevel3")
            {
                cattributes.KitchenLevel3();
                Debug.Log("Cat placed in Kitchen");
            }

        
    }

	void OnTriggerExit (Collider other)
	{
		cattributes.InActive ();
		Debug.Log ("The Cat is Inactive");
		CatLock = null;
		CatInPlace = false;
}
}
