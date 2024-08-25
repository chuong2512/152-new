using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showadsOnLevelpause : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

	void OnEnable()
	{
		GlobalGameHandler.levelcomplete=0;
		GlobalGameHandler.levelfail = 0;
		GlobalGameHandler.levelpause++;

		if (GlobalGameHandler.levelpause >= 2) {
			//addddd
//			AdsScript.ShowAdmob ();
		}
	}

}
