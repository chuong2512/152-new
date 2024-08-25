using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForTwoBalls : MonoBehaviour {

	public GamePlayeController gpc;


	void Awake(){

		gpc = GameObject.FindGameObjectWithTag ("GamePlayController").gameObject.GetComponent<GamePlayeController> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag ("Ball")) {
		
		

			if (GlobalGameHandler.two_balls != 0 && !GlobalGameHandler.OneVsOne) {

				print ("in trigger of two balls");

				GlobalGameHandler.twoballs = true;
				gpc.twoBalls.gameObject.SetActive (true);

				gpc.twoBalls.interactable = true;
			}



//			this.gameObject.GetComponent<BoxCollider> ().enabled = false;

		}
	}
}
