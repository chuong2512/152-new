using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour {

	public Animator cam;
	public GameObject door;

	// Use this for initialization
	void Start () {
//		PlayerPrefs.DeleteAll ();
		//addddd
//		PlayerPrefs.SetInt ("Coins",300000);
	
//		AdsScript.RemoveSmartBanner();
//		AdsScript.RemoveTopLeftBanner ();
//		AdsScript.RemoveTopRightBanner ();
		//addddd
		StartCoroutine (LoadingAnim ());
//		PlayerPrefs.SetInt ("Coins",1000000);



	}
	


	IEnumerator LoadingAnim()
	{
//		yield return new WaitForSeconds (2f);

//		door.GetComponent<Animator>().enabled = true;
		yield return new WaitForSeconds (1f);
//		cam.SetBool ("isgo",true);
//		yield return new WaitForSeconds (2f);

		GlobalGameHandler.isrewardMenu = false;
		GlobalGameHandler.nextlevel = false;
//		AdsScript.ShowAdmob ();
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("menu");

	}

}

