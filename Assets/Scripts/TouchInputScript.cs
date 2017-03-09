using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputScript : MonoBehaviour {



	public Vector3 ClickPos;
	public Vector3 ScreenPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				if(hit.collider.tag == "Cat")
				{
					GameObject obj=GameObject.FindGameObjectWithTag("Cat");
					obj.GetComponent<Animation>().Play("cube");
				}
			}
		
	}
}
}
