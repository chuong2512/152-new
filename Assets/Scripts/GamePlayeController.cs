using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class GamePlayeController : MonoBehaviour {

	public GameObject[] Envlevels;
	public GameObject Cam1, Cam2 ,Cam1StartPos ,cam1startpos2,AnimCam;
	// Use this for initialization
	public GameObject[] pinStartPos ,Levels;
	public GameObject pin,ball,pincounter;
	public Material[] balmaterial;
	public Transform ballspawn;

	public GameObject StageClearPanel ,StagePausePanel ;

	public Text timetext ,PinCountText,totalscoreText,bestScore,bestonPause;

	public GameObject  pinClean ;


	public Text[] p_text1,p_text2,p_text3,p_text4,p_total ;

	public AudioSource pindrop,startsound ,stageClearsound;

	public GameObject[] Stars;

	public Image fillScoreImage;
//	public Text[] p_text1 ,p_text2,p_text4,p_text3, p_total_text;
	public int best;


	public GameObject[] character ;
	public AnimationClip anim;

	public GameObject OnevsOne,Gutter1,Gutter2,Line1,Line2;





//	public Material gutterMaterial;



	[SerializeField]

	public GameObject cam1OneVsOne, cam2OneVsOne, Cam1OneVsOneStartPos,Cam1OneVsOneStartPos2,AnimCamOneVsOne;
	public GameObject[] pinStartPosOnevsOn0;
	public GameObject pinOnevsOn,ballOnevsOn,pincounterOnevsOn,pinCleanOnevsOn;
	public Transform ballspawnOnevsOn;
	public Text[] p_text1OnevsOn,p_text2OnevsOn,p_text3OnevsOn,p_text4OnevsOn,p_totalOnevsOn ;
	public Text PinCountTextOneVsOne;
	public Image fillScoreImageOnevsOn;
	float scrollSpeed =-1f; 


	public Text Player1txt , Player2txt;



	public GameObject BallPs;


	public GameObject [] LevelsRearanePos;

	public GameObject player1PAnel, player2PAnel,scoreboardDrop,scoreboardup ,scoreboardPanel;
	public Button player1buton,player2buton ;



	[SerializeField]


	public bool ballSizeUP;
	public GameObject NoGutter ,ball_for_two_Balls ,statsPanel;

	public Button NOGutter,BalSizeUp,twoPins,ghoost_Ball,twoBalls;



	bool isstats=false;


	[SerializeField]


	public GameObject[] env;

	public GameObject[] club,hundradPinsPos;

	public GameObject HundrdPinBall,HundrdPinBallPos,HundradPin;

	public GameObject[] cameras;
	public GameObject camera,hundrdcam2;

	public Text hundradPindText,totalonFAil ,playerwintext;

	// Use this for initialization





	public GameObject pause, statsOpen,otherPanels,levelfailPanel,RateUspanel;

	public GameObject enviremnet;



	public GameObject swipeAnim,tiltAnim;

	public GameObject PlayerNameShow;
//	public GameObject[] PinsSingPlay ,PinsOneVsOnePlay;

	public Text RewardedText;

	public GameObject MirrorReflect1, MirrorReflect2;

	int reward;

//	public Text fpsText;
//	float fps;

//	public GameObject StartPos;

	void Awake(){

		Time.timeScale =1;
	


			
		enviremnet.SetActive (true);




//		GlobalGameHandler.ball_number = 4;

//		GlobalGameHandler.Level_number = 1;

//		GlobalGameHandler.NoGutter = 3;
//		GlobalGameHandler.ballsize_Double = 3;
//		GlobalGameHandler.two_pins = 3;
//		GlobalGameHandler.Ghoost_Ball = 3;
//		GlobalGameHandler.two_balls = 3;

		GlobalGameHandler.Animcam2 = true;
//		print ("animcam ");
		foreach (GameObject obj in Levels) {
		
			obj.SetActive (false);
		}

		foreach(GameObject obj in Envlevels){
			obj.SetActive (true);
		}

		foreach (GameObject obj in club) {
			obj.SetActive (false);

		}
		if (GlobalGameHandler.isOvO) {
			club [0].SetActive (true);

		
		} else if (!GlobalGameHandler.isOvO && !GlobalGameHandler.hundradPins) {
			int i = Random.Range (0, 3);
			club [i].SetActive (true);
		} else if (GlobalGameHandler.hundradPins) {
		
			club [1].SetActive (true);
		}
	

		ball.GetComponent<Renderer> ().material = balmaterial [GlobalGameHandler.ball_number];
		OnevsOne.SetActive(false);
//		Cam1StartPos = GameObject.Find ("Main Camera start pos");

//		Cam1 = GameObject.Find ("Main Camera");
//		Cam2= GameObject.Find ("Cam 2");
		ballspawn= GameObject.Find ("Ball SpawnPoint").transform;

//		pinpick= GameObject.Find ("pin Collector");
		pinClean= GameObject.Find ("pin clean");
//		pinDroper= GameObject.Find ("pinDroper");
//		ppclen=GameObject.Find ("pclean");
		PlayerNameShow.SetActive(false);

		GlobalGameHandler.isFrameUpDateInstently = false;

		ballReset ();
		OnevsOne.SetActive(false);
//		GameObject respawn_Cam1 = GameObject.Instantiate(Cam1, Cam1.transform.position = Cam1StartPos.transform.position, Cam1.transform.rotation = Cam1StartPos.transform.rotation) as GameObject;
//		Cam1.transform.position =Cam1StartPos.transform.position;
//	    Cam1.transform.rotation = Cam1StartPos.transform.rotation;

//		print(PlayerPrefs.GetInt ("tutorial"));
		if (GlobalGameHandler.isOvO||GlobalGameHandler.hundradPins) {
			tiltAnim.transform.parent.gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("tutorial") >= 1) {

			tiltAnim.SetActive (false);
			swipeAnim.SetActive (false);
		}



	}



	void Start () {




		if (!GlobalGameHandler.OneVsOne && !GlobalGameHandler.hundradPins) {
			player1buton.gameObject.SetActive (false);
			player2buton.gameObject.SetActive (false);
		}
		GlobalGameHandler.issmily = false;
		camera.SetActive (false);
		hundrdcam2.SetActive (false);
		if (GlobalGameHandler.hundradPins) {
			foreach (GameObject obj in cameras) {
				obj.SetActive (false);
			}
			camera.SetActive (true);

		}


	
	
		GlobalGameHandler.isrewardMenu = true;
		pause.SetActive (true);
		statsOpen.SetActive (true);
		hundradPindText.gameObject.SetActive (false);
//		GlobalGameHandler.OneVsOne = false;
		fillScoreImage.fillAmount = 0;
		fillScoreImageOnevsOn.fillAmount = 0;
//		print (GlobalGameHandler.Level_number + "    level nmbr");
		if (!GlobalGameHandler.isOvO) {
			Levels [GlobalGameHandler.Level_number].SetActive (true);
		}
		GlobalGameHandler.isFrameUpDateInstentlyOvO=false;
		RateUspanel.SetActive (false);
//		GlobalGameHandler.issound = true;
//		AnimCam.SetActive (true);
		StagePausePanel.SetActive (false);
		StageClearPanel.SetActive (false);
		GlobalGameHandler.stageClear = false;
		PinCountText.text = "0";
		PinCountTextOneVsOne.text = "0";
		Cam1.SetActive (false);
		pincount.total=0;
		pincount.totalOneVsOne = 0;
		Cam2.SetActive (false);
		levelfailPanel.SetActive (false);
		cam1OneVsOne.SetActive (false);
		cam2OneVsOne.SetActive (false);
		GlobalGameHandler.spike = false;
		GlobalGameHandler.spikeOneVsOne = false;
		GlobalGameHandler.ispin = false;
		GlobalGameHandler.isLastSpike = false;
		GlobalGameHandler.BallFrames = 0;
		GlobalGameHandler.ChancePerFrame = 0;
		GlobalGameHandler.pcount = 0;
		GlobalGameHandler.pcountOneVsOne = 0;
		GlobalGameHandler.BallFramesOneVsOne = 0;
		GlobalGameHandler.ChancePerFrameOneVsOne = 0;
		scoreboardup.SetActive (false);
		GlobalGameHandler.h_Pins = 0;
//		GlobalGameHandler.BallFrames = 2;
		playerwintext.gameObject.transform.parent.gameObject.SetActive(false);
		GlobalGameHandler.nextlevel = false;
		GlobalGameHandler.chance1 = 0;
		GlobalGameHandler.chance2 = 0;
		GlobalGameHandler.chance1OvO = 0;
		GlobalGameHandler.chance2OvO = 0;
		GlobalGameHandler.isLastSpikeOvO = false;


		GlobalGameHandler.slash = false;
		GlobalGameHandler.slashOvO = false;

		GlobalGameHandler.NoGutter = PlayerPrefs.GetInt ("NoGutter");
		GlobalGameHandler.ballsize_Double = PlayerPrefs.GetInt ("BallSizeUp");
		GlobalGameHandler.two_pins = PlayerPrefs.GetInt ("twoPins");
		GlobalGameHandler.Ghoost_Ball = PlayerPrefs.GetInt ("GhostBall");
		GlobalGameHandler.two_balls = PlayerPrefs.GetInt ("TwoBalls");


		GlobalGameHandler.spike_leaderB = 0;
		GlobalGameHandler.slesh_leaderB = 0;

		ResetPins ();
		StartCoroutine	(textShowCor());

		if (GlobalGameHandler.OneVsOne) {
			
			OnevsOne.SetActive (true);
			Gutter2.GetComponent<Animator> ().enabled = true;
			Gutter1.GetComponent<Animator> ().enabled = false;
			Line2.GetComponent<Animator> ().enabled = true;
			Line1.GetComponent<Animator> ().enabled = false;
		

			MirrorReflect2.GetComponent<MirrorReflection> ().enabled = true;
	

		} else if (!GlobalGameHandler.OneVsOne) {
			Gutter2.GetComponent<Animator> ().enabled = false;
			Gutter1.GetComponent<Animator> ().enabled = true;
			Line2.GetComponent<Animator> ().enabled = false;
			Line1.GetComponent<Animator> ().enabled = true;
			MirrorReflect2.GetComponent<MirrorReflection> ().enabled = false;
		}

		GetPlayername ();
		ScoreBoardShow ();

		best =PlayerPrefs.GetInt ("bestScore");
		bestScore.text = best.ToString ();
		OnAudioBtnClickl ();

//		Stars [1].SetActive (false);
//		AdsScript.ShowTopLeftBanner ();


	}


	public void OnAudioBtnClickl(){
		if (GlobalGameHandler.issound) {
			AudioListener.volume = 1;
//			print ("is Audio "+GlobalGameHandler.issound);
		} else if(!GlobalGameHandler.issound) {
			AudioListener.volume = 0;
//			print ("is Audio "+GlobalGameHandler.issound);
		}

	}

	public void ScoreBoardShow(){
		if (!GlobalGameHandler.OneVsOne) {
		
			player2PAnel.SetActive (false);
			player1buton.interactable = false;
			player2buton.gameObject.SetActive (false);
		}
		else if (GlobalGameHandler.OneVsOne) {
			player2PAnel.SetActive (true);
			player1buton.interactable = true;
			player2buton.gameObject.SetActive (true);

		}

	}
	public void GetPlayername(){
	
		string a=PlayerPrefs.GetString ("Player1");
		string b=PlayerPrefs.GetString ("Player2");

		Player1txt.text = a.ToString ();

		if(a==""){
//			print ("a  "+a);
			Player1txt.text="Player 1";
		}

	
		Player2txt.text = b.ToString ();




		if(b==""){
//			print ("a  "+b);
			Player2txt.text="Player 2";
		}




	}
	


	void Update () {
		
		if (GlobalGameHandler.BallFrames >= 4) {
		
			GlobalGameHandler.stageClear = true;

			stageClear ();

			GlobalGameHandler.BallFrames = 0;
		}

		if (Application.targetFrameRate < 60) {
			Application.targetFrameRate = 60;
//			print ("ada");
		}
//		fps = 1 / Time.deltaTime;
//		fpsText.text = fps.ToString ();

	}
		
	public void stageClear (){


		PlayerPrefs.SetInt ("slash",GlobalGameHandler.slesh_leaderB);
		PlayerPrefs.SetInt ("spike",GlobalGameHandler.spike_leaderB);

		pincounter.SetActive (false);
		pincounterOnevsOn.SetActive (false);


		if (GlobalGameHandler.pcount >= 40||GlobalGameHandler.isOvO||GlobalGameHandler.hundradPins) {
			
			StartCoroutine (stageclr ());

		} else if(GlobalGameHandler.pcount < 40&&!GlobalGameHandler.isOvO&&!GlobalGameHandler.hundradPins) {
			StartCoroutine(stageFAil ());
			return;
		}


		if (PlayerPrefs.GetInt ("bestScore") < GlobalGameHandler.pcount) {
			
			PlayerPrefs.SetInt ("bestScore", GlobalGameHandler.pcount);
		}
//		print ("level number "+GlobalGameHandler.Level_number);

		totalscoreText.text = GlobalGameHandler.pcount.ToString();

		 reward = GlobalGameHandler.pcount * 10;
		PlayerPrefs.SetInt ("Coins",PlayerPrefs.GetInt ("Coins")+reward);
		RewardedText.text = reward.ToString();

		if (GlobalGameHandler.hundradPins) {

			totalscoreText.text = GlobalGameHandler.h_Pins.ToString ();

			reward = GlobalGameHandler.h_Pins * 10;


			PlayerPrefs.SetInt ("Coins",PlayerPrefs.GetInt ("Coins")+reward);
			RewardedText.text = reward.ToString ();
		}


//		print ("level number "+GlobalGameHandler.Level_number);


		if (GlobalGameHandler.isOvO) {
			playerwintext.gameObject.transform.parent.gameObject.SetActive (true);
			string a = PlayerPrefs.GetString ("Player1");
			string b = PlayerPrefs.GetString ("Player2");

			if (a == "") {
				a = "Player 1";
			}
			if (b == "") {
				b = "Player 2";
			}

			if (GlobalGameHandler.pcount < GlobalGameHandler.pcountOneVsOne) {
				playerwintext.text = (b + "  wins ").ToString ();
				
			} else if ((GlobalGameHandler.pcount > GlobalGameHandler.pcountOneVsOne)) {
				playerwintext.text = (b + "  wins ").ToString ();
				


			}

		}

		int x = GlobalGameHandler.pcount;
		if (x >= 30 && x < 55) 
		{
			Stars [0].SetActive (true);
		} 
		else if (x >= 55 && x < 80) 
		{
			Stars [0].SetActive (true);
			Stars [1].SetActive (true);
		}
		else if (x >= 80)
		{
			Stars [0].SetActive (true);
			Stars [1].SetActive (true);
			Stars [2].SetActive (true);
		}	

//		print ("level number "+GlobalGameHandler.Level_number);
			

	


	}

	IEnumerator stageFAil()
	{
		levelfailPanel.SetActive (true);
		StageClearPanel.SetActive (false);
		StagePausePanel.SetActive (false);
		totalonFAil.text = GlobalGameHandler.pcount.ToString();
		otherPanels.SetActive (false);
		scoreboradup ();

		yield return new WaitForSeconds (2f);
		pinClean.SetActive (false);
		yield return new WaitForSeconds (1f);

		Analytics.CustomEvent("LevelFail", new Dictionary<string, object> { { "Level", GlobalGameHandler.Level_number },  { "TotalCoins", PlayerPrefs.GetInt("Coins") } });

		Time.timeScale = 0.00000f;
		yield break ;
	}
	IEnumerator stageclr()
	{


		yield return new WaitForSeconds (1f);
		if (!GlobalGameHandler.isOvO) {
//			GlobalGameHandler.Level_number++;
//			print ("level number "+GlobalGameHandler.Level_number);
			if (PlayerPrefs.GetInt ("Levels") <= GlobalGameHandler.Level_number) {

				PlayerPrefs.SetInt ("Levels", GlobalGameHandler.Level_number+1);
//				print ("level number "+GlobalGameHandler.Level_number);
//				GlobalGameHandler.Level_number--;

				Analytics.CustomEvent("LevelComplete", new Dictionary<string, object> { { "Level", GlobalGameHandler.Level_number }, { "CoinsAwarded",reward  }, { "TotalCoins", PlayerPrefs.GetInt("Coins") } });
			}
		}



		//		Debug.Log ("level number on levelSuccess   " + GlobalGameHandler.Level_number);

//		pause.SetActive (false);
//		statsOpen.SetActive (false);
		stageClearsound.Play ();
		otherPanels.SetActive (false);
		scoreboradup ();
		pinClean.SetActive (false);
		yield return new WaitForSeconds (1f);

		if (best < GlobalGameHandler.pcount) {
			bestScore.text = GlobalGameHandler.pcount.ToString();

		} else {
			bestScore.text = best.ToString ();
		}

		StageClearPanel.SetActive (true);
		StagePausePanel.SetActive (false);
//		print("level number on levelSuccess   " + GlobalGameHandler.Level_number);
		yield return new WaitForSeconds (0.2f);


		if (GlobalGameHandler.Level_number == 5&&PlayerPrefs.GetInt ("rateus")==0) {
			RateUspanel.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("rateus") == 0) {
		
			if (GlobalGameHandler.Level_number == 8 || GlobalGameHandler.Level_number == 15 || GlobalGameHandler.Level_number == 20) {
				RateUspanel.SetActive (true);

			}
		}

		yield return new WaitForSeconds (1f);
//		GlobalGameHandler.Level_number--;

		Time.timeScale = 0.00000f;
	
	}

	public void OnRestart(){
		SceneManager.LoadScene("Scene_1");

	}

	public void OnQuit(){
		Application.LoadLevel("menu");

	}

	public void OnNextLEvel(){
		GlobalGameHandler.nextlevel = true;
		Application.LoadLevel("menu");

	}


	public void OnlevelPause(){
		scoreboradup ();
		otherPanels.SetActive (false);
//		pinClean.SetActive (false);
		Time.timeScale = 0.00000f;
		StagePausePanel.SetActive (true);
		StageClearPanel.SetActive (false);
		pause.SetActive (false);
		statsOpen.SetActive (false);
	}

	public void OnlevelResume(){
		otherPanels.SetActive (true);
		Time.timeScale =1;
		pause.SetActive (true);
		statsOpen.SetActive (true);
		StagePausePanel.SetActive (false);
		StageClearPanel.SetActive (false);
	}


	void  ResetPins()
	{
	
//		yield return new WaitForSeconds (2.2f);


		for (int i = 0; i <= 9; i++) {

			if (!GlobalGameHandler.OneVsOne&&!GlobalGameHandler.hundradPins) {

//				PinsSingPlay [i].gameObject.SetActive (true);
//				PinsSingPlay [i].transform.position = pinStartPos [i].transform.position;
//				PinsSingPlay [i].transform.rotation = pinStartPos [i].transform.rotation;
//				PinsSingPlay [i].GetComponent<Rigidbody> ().mass = 1.1f;
//				PinsSingPlay [i].GetComponent<Rigidbody> ().drag = 0.2f;
//				PinsSingPlay [i].GetComponent<Rigidbody> ().angularDrag = 0.15f;
//				PinsSingPlay [i].GetComponent<BoxCollider> ().enabled = true;
//				PinsSingPlay [i].GetComponent<Rigidbody> ().velocity = new Vector3(0f,0f,0f);
//			
//				PinsSingPlay [i].GetComponent<Rigidbody> ().angularVelocity = new Vector3(0f,0f,0f);
//
//				PinsSingPlay [i].transform.GetChild(1).gameObject.GetComponent<BoxCollider> ().enabled = true;




//				objectpooler.SpawmFromPool ("Pin",pinStartPos[i].transform.position,pinStartPos[i].transform.rotation);
//			
				GameObject respawn_pins = GameObject.Instantiate (pin, transform.position = pinStartPos [i].transform.position, transform.rotation = pinStartPos [i].transform.rotation) as GameObject;
			} else if (GlobalGameHandler.OneVsOne) {
				//				print ("one vs one");


//				objectpooler.SpwamFromQuee ("Pin",pinStartPosOnevsOn0[i].transform.position,pinStartPosOnevsOn0[i].transform.rotation);
				GameObject respawn_pins = GameObject.Instantiate (pinOnevsOn, transform.position = pinStartPosOnevsOn0 [i].transform.position, transform.rotation = pinStartPosOnevsOn0 [i].transform.rotation) as GameObject;

			}



		}
		if (GlobalGameHandler.hundradPins) {
			for (int i = 0; i <= 99; i++) {

				GameObject respawn_pins = GameObject.Instantiate (HundradPin, transform.position = hundradPinsPos [i].transform.position, transform.rotation = hundradPinsPos [i].transform.rotation) as GameObject;

			}
		}



	
	}

	IEnumerator textShowCor(){
		if (GlobalGameHandler.isOvO) {

			yield return new WaitForSeconds (1f);
			string a = PlayerPrefs.GetString ("Player1");
			string b = PlayerPrefs.GetString ("Player2");

			if (a == "") {
				a = "Player 1";
			}
			if (b == "") {
				b = "Player 2";
			}

			PlayerNameShow.SetActive (true);
			if (GlobalGameHandler.OneVsOne) {
				PlayerNameShow.transform.GetChild (0).GetComponent<Text> ().text = a;
			} else if (!GlobalGameHandler.OneVsOne) {
				PlayerNameShow.transform.GetChild (0).GetComponent<Text> ().text = b;
			}
			yield return new WaitForSeconds (1f);
			PlayerNameShow.SetActive (false);
		}
	}
	public void camchildon()
	{
		 if (!GlobalGameHandler.OneVsOne) {
//			print ();
		AnimCam.transform.GetChild (0).gameObject.SetActive (true);
		}

		else if (GlobalGameHandler.OneVsOne) {
			//		if (GlobalGameHandler.spikeOneVsOne) {
			AnimCamOneVsOne.transform.GetChild (0).gameObject.SetActive (true);
		}
	}

	public void pinRest(){
		if (!GlobalGameHandler.OneVsOne && !GlobalGameHandler.hundradPins) {

			if (GlobalGameHandler.isFrameUpDateInstently) {

				return;
			}
		}


		GlobalGameHandler.issmily = true;

		if (GlobalGameHandler.isOvO) {
			if (GlobalGameHandler.isFrameUpDateInstentlyOvO) {


			}
			if (GlobalGameHandler.OneVsOne) {

				MirrorReflect1.GetComponent<MirrorReflection> ().enabled = false;
				MirrorReflect2.GetComponent<MirrorReflection> ().enabled = true;

			} else if (!GlobalGameHandler.OneVsOne) {

				MirrorReflect1.GetComponent<MirrorReflection> ().enabled = true;
				MirrorReflect2.GetComponent<MirrorReflection> ().enabled = false;
			}		
		} 
//		ResetPins ();
		Invoke ("ResetPins",0.5f);
	
		StartCoroutine(textShowCor ());

	

		if (GlobalGameHandler.spike) {
			
		} else if (GlobalGameHandler.slash) {
		
			
			}



//		ResetPins();
//		if (GlobalGameHandler.ispin) {

	}
	public void ballReset(){


		if (GlobalGameHandler.OneVsOne) {
			//			print ("one vs one");
			if (GlobalGameHandler.isFrameUpDateInstentlyOvO) {
				GlobalGameHandler.OneVsOne = false;
				GlobalGameHandler.BallFramesOneVsOne++;


			}
		}
			else if (!GlobalGameHandler.OneVsOne&&!GlobalGameHandler.hundradPins) {

					if (GlobalGameHandler.isFrameUpDateInstently) {

						GlobalGameHandler.BallFrames++;

						return;
					}

				
			}




		if (GlobalGameHandler.OneVsOne) {
			//			print ("one vs one");
		

			GameObject respawn_bowling_ball = GameObject.Instantiate (ballOnevsOn, ballOnevsOn.transform.position = ballspawnOnevsOn.position, ballOnevsOn.transform.rotation = ballspawnOnevsOn.rotation) as GameObject;
		}

			else  if (!GlobalGameHandler.OneVsOne&&!GlobalGameHandler.hundradPins) {
			
		

			GameObject respawn_bowling_ball = GameObject.Instantiate (ball, ball.transform.position = ballspawn.position, ball.transform.rotation = ballspawn.rotation) as GameObject;

		}  

		else if (GlobalGameHandler.hundradPins) {
//			print ("one vs one");
			GameObject respawn_bowling_ball = GameObject.Instantiate (HundrdPinBall, HundrdPinBall.transform.position = HundrdPinBallPos.transform.position, HundrdPinBall.transform.rotation = HundrdPinBallPos.transform.rotation) as GameObject;
		}
	}

	public void levlsReArrange() 
	{
	
		int i = Random.Range (0, 5);

		Levels [GlobalGameHandler.Level_number].transform.position = LevelsRearanePos [i].transform.position;

	}


	public void OnPlayer1CLick(){
	
		player1PAnel.SetActive (true);
		player2PAnel.SetActive (false);

		player2buton.gameObject.GetComponent<Image> ().color = Color.green;

		player1buton.gameObject.GetComponent<Image>().color= new Color (255f,255f,255f);

		player1buton.interactable = false;
		player2buton.interactable = true;

	}
	public void OnPlayer2CLick(){

		player1PAnel.SetActive (false);
		player2PAnel.SetActive (true);

		player1buton.gameObject.GetComponent<Image>().color =Color.green;
		player2buton.gameObject.GetComponent<Image>().color = new Color (255f,255f,255f);

		player1buton.interactable = true;
		player2buton.interactable = false;

	

	}

	public void scoreboraddrop(){
	
		scoreboardDrop.SetActive (false);
		scoreboardup.SetActive (true);
		scoreboardPanel.GetComponent<Animator> ().SetBool ("sdrop",true);
	}
	public void scoreboradup(){

		scoreboardDrop.SetActive (true);
		scoreboardup.SetActive (false);
		scoreboardPanel.GetComponent<Animator> ().SetBool ("sdrop",false);
	}



	public void onBallSizeClick()
	{

		GlobalGameHandler.ballsize_Double--;
		BalSizeUp.interactable = false;
	
//		if (GlobalGameHandler.ball_size_Double) {
			ballSizeUP = true;
			GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
			ball.transform.localScale = new Vector3 (1.1f,1.1f,1.1f);
			ball.transform.position = new Vector3 (ball.transform.position.x, ball.transform.position.y+0.424f, ball.transform.position.z);


			if (!ball.GetComponent<Swipe> ().isClick) {
				if(GlobalGameHandler.OneVsOne)
				cam1OneVsOne.transform.position = new Vector3(Cam1OneVsOneStartPos2.transform.position.x,Cam1OneVsOneStartPos2.transform.position.y+0.424f,Cam1OneVsOneStartPos2.transform.position.z);

				else if(!GlobalGameHandler.OneVsOne)
					
					Cam1.transform.position = new Vector3(cam1startpos2.transform.position.x,cam1startpos2.transform.position.y+0.424f,cam1startpos2.transform.position.z);

				}
		PlayerPrefs.SetInt ("BallSizeUp", GlobalGameHandler.ballsize_Double);
//		}

	}


	public void OnNoGutterClick()
	{

		GlobalGameHandler.NoGutter--;

		NOGutter.interactable = false;

			NoGutter.SetActive (true);
			Gutter1.GetComponent<Animator> ().enabled = false;

		PlayerPrefs.SetInt ("NoGutter", GlobalGameHandler.NoGutter);

	}
	public void On2PinsClick()
	{
		GlobalGameHandler.twopins = true;
		GlobalGameHandler.two_pins--;

		twoPins.interactable = false;

		PlayerPrefs.SetInt ("twoPins", GlobalGameHandler.two_balls);
	}


	public void On2BallClick()
	{
		if (GlobalGameHandler.twoballs) {

			GlobalGameHandler.two_balls--;
		

			twoBalls.interactable = false;

			Transform ball_spawn_point = GameObject.FindGameObjectWithTag ("Ball").transform;

			GameObject respawn_bowling_ball = GameObject.Instantiate (ball_for_two_Balls, ball_for_two_Balls.transform.position = ball_spawn_point.position, ball_for_two_Balls.transform.rotation = ball_spawn_point.rotation) as GameObject;

			respawn_bowling_ball.GetComponent<Rigidbody> ().AddForce (Vector3.forward.normalized * 1000 * (.93f * 2));


			PlayerPrefs.SetInt ("TwoBalls", GlobalGameHandler.two_balls);

		}
	}


	public void OnGhostBallClick()
	{
		
		GlobalGameHandler.Ghoost_Ball--;

	

		ghoost_Ball.interactable = false;

		GameObject[] sphare = GameObject.FindGameObjectsWithTag ("nosphare");
		foreach (GameObject obj in sphare) {
			obj.GetComponent<SphereCollider> ().enabled = false;
		}

		GameObject[] box = GameObject.FindGameObjectsWithTag ("nobox");
		foreach (GameObject obj in box) {
			obj.GetComponent<BoxCollider> ().enabled = false;
		}


		GameObject[] leftright = GameObject.FindGameObjectsWithTag ("noleftright");
		foreach (GameObject obj in leftright) {
			obj.GetComponent<BoxCollider> ().enabled = false;
		}

		GameObject[] mesh = GameObject.FindGameObjectsWithTag ("nomesh");
		foreach (GameObject obj in mesh) {
			obj.GetComponent<MeshCollider> ().enabled = false;
		}

		GameObject[] capsuel = GameObject.FindGameObjectsWithTag ("nocapsuel");
		foreach (GameObject obj in capsuel) {
			obj.GetComponent<CapsuleCollider> ().enabled = false;
		}



		PlayerPrefs.SetInt ("GhostBall", GlobalGameHandler.Ghoost_Ball);


	}

	public void OnShareClick()

	{
	
		StartCoroutine (TakeSSAndShare());
	}

	private IEnumerator TakeSSAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
		ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
		ss.Apply();


		string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
		File.WriteAllBytes( filePath, ss.EncodeToPNG() );

		// To avoid memory leaks
		Destroy( ss );

		// Share on WhatsApp only, if installed (Android only)
		//if( NativeShare.TargetExists( "com.whatsapp" ) )
		//	new NativeShare().AddFile( filePath ).SetText( "Hello world!" ).SetTarget( "com.whatsapp" ).Share();
	}



	public void onStatsOpen ()
	{
	

		if (!isstats) {
			statsPanel.GetComponent<Animator> ().SetBool ("isstats", true);
		} else if (isstats) {
			statsPanel.GetComponent<Animator> ().SetBool ("isstats", false);
		}

		isstats = !isstats;

	}

	public void RateUs()
	{
//		GlobalGameHandler.rateuslater = true;
		PlayerPrefs.SetInt ("rateus",1);
		RateUspanel.SetActive (false);

		#if UNITY_ANDROID
		Application.OpenURL("https://play.google.com/store/apps/details?id=");
		#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
		#endif


	}

	public void onRateUsNo()
	{
		RateUspanel.SetActive (false);
		PlayerPrefs.SetInt ("rateus",0);
	}


//	public void UpdateLeaderBoard() {
//
//		if (PlayGamesPlatform.Instance.localUser.authenticated)
//		{
//			// Note: make sure to add 'using GooglePlayGames'
//			PlayGamesPlatform.Instance.ReportScore(best,
//				GPGSIds.leaderboard_stage_ranking,
//				(bool success) =>
//				{
//					Debug.Log("(Lollygagger) Leaderboard update success: " + success);
//				});
//		}
//	}

//	public void OnAchiementUnlock()
//	{
//		if (Social.localUser.authenticated) {
//			PlayGamesPlatform.Instance.ReportProgress (
//				GPGSIds.achievement_1_vs_1_500_win,
//				100.0f, (bool success) => {
//					Debug.Log ("(Lollygagger) Welcome Unlock: " +
//						success);
//				});
//		}
//	}
}
