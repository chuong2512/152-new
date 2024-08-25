using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCamon : MonoBehaviour {
	 public GamePlayeController gpc;
	void Awake(){
//			GlobalGameHandler.OneVsOne=true;
//			GlobalGameHandler.isOvO = true;
//		GlobalGameHandler.hundradPins=true;
		gpc = GameObject.FindGameObjectWithTag ("GamePlayController").gameObject.GetComponent<GamePlayeController>();



		if (GlobalGameHandler.OneVsOne) {
		
			gpc.Cam1.SetActive (false);
			gpc.Cam2.SetActive (false);
			gpc.AnimCam.SetActive (false);
			gpc.cam1OneVsOne.SetActive (false);
			gpc.cam2OneVsOne.SetActive (false);
			gpc.AnimCamOneVsOne.SetActive (true);
		} else if (!GlobalGameHandler.OneVsOne&&!GlobalGameHandler.hundradPins	) {
			gpc.Cam1.SetActive (false);
			gpc.Cam2.SetActive (false);
			gpc.AnimCam.SetActive (true);
			gpc.cam1OneVsOne.SetActive (false);
			gpc.cam2OneVsOne.SetActive (false);
			gpc.AnimCamOneVsOne.SetActive (false);

		}
		GlobalGameHandler.Animcam2 = true;



//		print ("onEnabe");


	}
	




}
