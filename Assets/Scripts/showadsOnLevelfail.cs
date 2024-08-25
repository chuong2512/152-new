using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showadsOnLevelfail : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnEnable()
	{
		GlobalGameHandler.levelcomplete=0;
		GlobalGameHandler.levelfail ++;
		GlobalGameHandler.levelpause=0;

		if (GlobalGameHandler.levelfail >= 2) {
			//addddd
//			AdsScript.ShowAdOnLevelFail ();
		}


	
	}
}
