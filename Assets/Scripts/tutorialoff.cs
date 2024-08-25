using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialoff : MonoBehaviour {
	GamePlayeController gpc;
	void Awake(){

		gpc = GameObject.FindGameObjectWithTag ("GamePlayController").gameObject.GetComponent<GamePlayeController>();



	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag ("Ball")) {
		
			PlayerPrefs.SetInt ("tutorial",1);
			gpc.tiltAnim.SetActive (false);

			this.gameObject.SetActive (false);
		}

	}
}
