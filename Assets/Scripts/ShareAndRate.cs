﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;


public class ShareAndRate : MonoBehaviour {

	public GameObject NetCheckingPanel;

	string subject = "bowling world club";
	string body = "https://play.google.com/store/apps/details?id=com.mentor.gs.bowling.world.club.free";

	#if UNITY_IPHONE

	[DllImport("__Internal")]
	private static extern void sampleMethod (string iosPath, string message);

	[DllImport("__Internal")]
	private static extern void sampleTextMethod (string message);

	#endif

	public void OnAndroidTextSharingClick()
	{
		if (Application.internetReachability != NetworkReachability.NotReachable) {
			StartCoroutine (ShareAndroidText ());
		} else {
			NetCheckingPanel.SetActive (true);
			this.gameObject.GetComponent<MenuScript> ().MainMenuPanel.SetActive (false);

		}

	}

	IEnumerator ShareAndroidText()
	{
		yield return new WaitForEndOfFrame();
		//execute the below lines if being run on a Android device
		#if UNITY_ANDROID
		//Reference of AndroidJavaClass class for intent
		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		//Reference of AndroidJavaObject class for intent
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
		//call setAction method of the Intent object created
		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		//set the type of sharing that is happening
		intentObject.Call<AndroidJavaObject>("setType", "text/plain");
		//add data to be passed to the other activity i.e., the data to be sent
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
		//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TITLE"), "Text Sharing ");
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
		//get the current activity
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
		//start the activity by sending the intent data
		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");
		currentActivity.Call("startActivity", jChooser);
		#endif
	}


	public void OniOSTextSharingClick()
	{

		#if UNITY_IPHONE || UNITY_IPAD
		string shareMessage = "Wow I Just Share Text ";
		sampleTextMethod (shareMessage);

		#endif
	}

	public void RateUs()
	{
		#if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.mentor.gs.bowling.world.club.free");
		#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
		#endif
	}


	public void MoreGames()
	{
		#if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/developer?id=Mentor+Game+Studio");
		#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
		#endif
	}

//	public void onNoAds()
//	{
//		PlayerPrefs.SetInt ("RemoveAds",1);
//	}
}