using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showadsOnLevelcompleteOrPause : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	


	void OnEnable()
	{
		GlobalGameHandler.levelcomplete++;
		GlobalGameHandler.levelfail = 0;
		GlobalGameHandler.levelpause = 0;
			
		if (GlobalGameHandler.levelcomplete >= 2) {
			//addddd
//			AdsScript.ShowAdOnLevelCompleteOrPause ();
		}


	}


}
