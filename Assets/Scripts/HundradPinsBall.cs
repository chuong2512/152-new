using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HundradPinsBall : MonoBehaviour {

	public GamePlayeController gpc;


	void Awake(){

		gpc = GameObject.FindGameObjectWithTag ("GamePlayController").gameObject.GetComponent<GamePlayeController> ();
	}


	// Use this for initialization


	void Start () {

		GetComponent<Swipe> ().isClick = true;
		GlobalGameHandler.istilt = true;
		gpc.camera.GetComponent<SmoothFollow> ().distance = 10;


	}

	IEnumerator OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag ("speed")) 
		{
			print ("in speed");
			gpc.hundrdcam2.SetActive (true);
			gpc.camera.SetActive (false);
			yield return new WaitForSeconds (1f);
			col.gameObject.transform.GetChild (0).gameObject.SetActive (true);
			gpc.hundradPindText.gameObject.SetActive(true);
		}
		if (col.gameObject.CompareTag ("Plane")) {

			this.gameObject.GetComponent<BoxCollider> ().enabled = false;
//			gpc.scoreboraddrop ();
			yield return new WaitForSeconds (2f);
			print ("in speed");
			yield return new WaitForSeconds (1f);
			gpc.hundradPindText.gameObject.SetActive(false);
			gpc.stageClear ();

			int a = PlayerPrefs.GetInt ("hund");
			PlayerPrefs.SetInt ("hund",a+1);


		}

	}
	

}
