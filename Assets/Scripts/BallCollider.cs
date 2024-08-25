using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BallCollider : MonoBehaviour
{
    private bool wasExecuted = false;




	Rigidbody rib;
	GamePlayeController gpc;
//	public GameObject[] pins,pinStartPos;

	public  pincount pincount;

	bool ispindropplay ,ispindropplayOneVsOne;
	void Awake() {

		gpc = GameObject.FindGameObjectWithTag ("GamePlayController").gameObject.GetComponent<GamePlayeController>();
		gpc.BallPs.SetActive(false);
		gpc.pinClean.SetActive (false);
		gpc.pinCleanOnevsOn.SetActive (false);
		GlobalGameHandler.istilt = false;
		gpc.NoGutter.SetActive (false);
		gpc.scoreboradup ();
		gpc.ballSizeUP = false;
		gpc.cam1OneVsOne.transform.position = gpc.Cam1OneVsOneStartPos.transform.position;
		gpc.cam1OneVsOne.transform.rotation = gpc.Cam1OneVsOneStartPos.transform.rotation;
		gpc.Cam1.transform.position = gpc.Cam1StartPos.transform.position;
		gpc.Cam1.transform.rotation = gpc.Cam1StartPos.transform.rotation;
		gpc.AnimCam.transform.GetChild (0).gameObject.SetActive (false);
		gpc.AnimCamOneVsOne.transform.GetChild (0).gameObject.SetActive (false);
		gpc.cam2OneVsOne.SetActive (false);
		gpc.Cam2.SetActive (false);
		gpc.Cam1.SetActive (false);
		gpc.cam1OneVsOne.SetActive (false);
		gpc.AnimCam.SetActive (false);
		gpc.AnimCamOneVsOne.SetActive (false);

		if (GlobalGameHandler.OneVsOne) {
			gpc.AnimCamOneVsOne.SetActive (true);
		}
		else if (!GlobalGameHandler.OneVsOne) {
			gpc.AnimCam.SetActive (true);
		}




//		print ("no gutter" + GlobalGameHandler.NoGutter);
//		print ("ball soize double" + GlobalGameHandler.ballsize_Double+" one vs one  "+GlobalGameHandler.OneVsOne);


//		print ("cam 1   "+gpc.Cam1.activeSelf);
	}
	void Start(){

		rib = GetComponent<Rigidbody> ();
		gpc.cam1OneVsOne.transform.position = gpc.Cam1OneVsOneStartPos.transform.position;
		gpc.cam1OneVsOne.transform.rotation = gpc.Cam1OneVsOneStartPos.transform.rotation;
		gpc.Cam1.transform.position = gpc.Cam1StartPos.transform.position;
		gpc.Cam1.transform.rotation = gpc.Cam1StartPos.transform.rotation;

	}


	void OnEnable(){
		
		if (!GlobalGameHandler.OneVsOne) {
			StartCoroutine (AnimCamCorutine ());
		} else if (GlobalGameHandler.OneVsOne) {
			StartCoroutine (AnimCamCorutineOneVsOne());

		}

		IAP_Products ();
	}

	IEnumerator AnimCamCorutine(){
		yield return new WaitForSeconds (0.01f);

		if (GlobalGameHandler.Animcam2) {
//			print ("anim Cam2");
			gpc.AnimCam.GetComponent<Animator> ().SetTrigger ("cam2");
			yield return new WaitForSeconds (3f);
//			gpc.character [2].GetComponent<Animation> ().Play ();
//			gpc.character [2].GetComponent<Animation> ().Play("VictoryIdle02");
//			yield return new WaitForSeconds (1f);
//			gpc.character [2].GetComponent<Animation> ().Play("VictoryIdle02");
//			yield return new WaitForSeconds (1f);
			GlobalGameHandler.Animcam2 = false;



		}
		if (GlobalGameHandler.spike) {
			gpc.AnimCam.transform.GetChild (0).gameObject.SetActive (true);
//			GlobalGameHandler.issmily = false;
		}
		gpc.Gutter2.GetComponent<Animator> ().enabled = false;
		gpc.Gutter1.GetComponent<Animator> ().enabled = true;
//		print ("anim Cam1");
		gpc.AnimCam.SetActive (true);
		gpc.AnimCam.GetComponent<Animator> ().SetTrigger ("cam");
		gpc.Cam2.SetActive (false);
		gpc.Cam1.SetActive (false);

		yield return new WaitForSeconds (2.2f);

		GetComponent<Swipe> ().isClick = true;
		GlobalGameHandler.istilt = true;
		gpc.startsound.Play ();
		gpc.AnimCam.SetActive (false);
		gpc.Cam2.SetActive (false);
		gpc.Cam1.SetActive (true);
		rib = GetComponent<Rigidbody> ();
		rib.isKinematic = true;
		ispindropplay=true;
		gpc.AnimCam.transform.GetChild (0).gameObject.SetActive (false);
		pincount = gpc.pincounter.GetComponent<pincount> ();
		//		pincount = GameObject.Find ("pin counter").gameObject.GetComponent<pincount>();
//		gpc.pinDroper.SetActive (false);
		pincount.a = 0;
		StartCoroutine (wiat());

		//		gpc.ppclen.SetActive (false);

		gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", false);

		//		gpc.pinpick.GetComponent<Animator> ().SetBool ("ispick", false);
//		print ("cam pos1");
		GlobalGameHandler.isgutter = false;
		gpc.pinClean.SetActive(false);
		gpc.Cam1.GetComponent<SmoothFollow> ().distance = 4f;

		pincount.chanc1_total=0;
		pincount.chance2_tota=0;
	

		if (GlobalGameHandler.Animcam2 == false) {
			foreach (GameObject obj in gpc.character) {

				obj.SetActive (false);
			}
		}


		if(PlayerPrefs.GetInt("tutorial")==0)
		{
			gpc.swipeAnim.SetActive(true);
			gpc.tiltAnim.SetActive (false);
		}



	}
	IEnumerator AnimCamCorutineOneVsOne(){
		yield return new WaitForSeconds (0.01f);

		if (GlobalGameHandler.Animcam2) {
//			print ("anim Cam2");
			gpc.AnimCamOneVsOne.GetComponent<Animator> ().SetTrigger ("cam2");
			yield return new WaitForSeconds (3f);
			//			gpc.character [2].GetComponent<Animation> ().Play ();
			//			gpc.character [2].GetComponent<Animation> ().Play("VictoryIdle02");
			//			yield return new WaitForSeconds (1f);
			//			gpc.character [2].GetComponent<Animation> ().Play("VictoryIdle02");
			//			yield return new WaitForSeconds (1f);
			GlobalGameHandler.Animcam2 = false;



		}

		if (GlobalGameHandler.spikeOneVsOne) {
			gpc.AnimCamOneVsOne.transform.GetChild (0).gameObject.SetActive (true);
//			GlobalGameHandler.issmily = false;
		}
		gpc.Gutter2.GetComponent<Animator> ().enabled = true;
		gpc.Gutter1.GetComponent<Animator> ().enabled = false;
//		print ("anim Cam1");
		gpc.AnimCamOneVsOne.SetActive (true);
		gpc.AnimCamOneVsOne.GetComponent<Animator> ().SetTrigger ("cam");
		gpc.cam2OneVsOne.SetActive (false);
		gpc.cam1OneVsOne.SetActive (false);

		yield return new WaitForSeconds (2.2f);

		GetComponent<Swipe> ().isClick = true;
		GlobalGameHandler.istilt = true;
		gpc.startsound.Play ();
		gpc.AnimCamOneVsOne.SetActive (false);
		gpc.cam2OneVsOne.SetActive (false);
		gpc.cam1OneVsOne.SetActive (true);
		rib = GetComponent<Rigidbody> ();
		rib.isKinematic = true;
		ispindropplay=true;


		gpc.AnimCamOneVsOne.transform.GetChild (0).gameObject.SetActive (false);
		pincount = gpc.pincounter.GetComponent<pincount> ();
		//		pincount = GameObject.Find ("pin counter").gameObject.GetComponent<pincount>();
		//		gpc.pinDroper.SetActive (false);
		pincount.aOneVsOne = 0;
		StartCoroutine (wiat());

		//		gpc.ppclen.SetActive (false);

		gpc.pinCleanOnevsOn.GetComponent<Animator> ().SetBool ("isclean", false);

		//		gpc.pinpick.GetComponent<Animator> ().SetBool ("ispick", false);
//		print ("cam pos1");
		GlobalGameHandler.isgutterOneVsOne = false;
		gpc.pinCleanOnevsOn.SetActive(false);
		gpc.cam1OneVsOne.GetComponent<SmoothFollow> ().distance = 4f;

		pincount.chanc1_totalOneVsOne=0;
		pincount.chance2_totaOneVsOne=0;
//		print ("chance 1 total  "+pincount.chanc1_totalOneVsOne);
//		print ("chance 2 total  "+pincount.chance2_totaOneVsOne);

		if (GlobalGameHandler.Animcam2 == false) {
			foreach (GameObject obj in gpc.character) {

				obj.SetActive (false);
			}
		}

	}
  public   void reset_ball()
    {

        if (!wasExecuted)
		{
			gpc.ballReset();
            wasExecuted = true;

			if (GlobalGameHandler.ChancePerFrame == 0) {
			
				gpc.levlsReArrange ();
			}
		
        }

        Destroy(gameObject);

    }


	IEnumerator wiat(){
		yield return new WaitForSeconds (2.5f);

		if (!GlobalGameHandler.OneVsOne) {

			gpc.pincounter.SetActive (true);
			gpc.pincounterOnevsOn.SetActive (false);
		}
		else if (GlobalGameHandler.OneVsOne) {

			gpc.pincounterOnevsOn.SetActive (true);
			gpc.pincounter.SetActive (false);
		}
	

	}


	public	GameObject[] ahmed;

	IEnumerator OnTriggerEnter(Collider ballCollider)
    {

        if (ballCollider.gameObject.tag == "Plane")
		{	
			gpc.twoBalls.interactable = false;
			gpc.BallPs.SetActive (false);

			if (!GlobalGameHandler.OneVsOne) {


			//			gpc.ppclen.SetActive (true);
//			gpc.pinClean.SetActive(true);

			this.gameObject.transform.GetComponent<BoxCollider> ().enabled = false;

			GlobalGameHandler.ChancePerFrame++;


//			print ("ball  "+GlobalGameHandler.ChancePerFrame);

			yield return new WaitForSeconds (2f);
				gpc.scoreboraddrop ();
				if (GlobalGameHandler.isOvO) {
					gpc.OnPlayer1CLick ();
				}
//			print ("chance 1 "+ pincount.chanc1_total+"  chance 2  "+pincount.chance2_tota);
			if (GlobalGameHandler.BallFrames == 0) {
					if (GlobalGameHandler.ChancePerFrame == 1) {
						gpc.p_text1 [GlobalGameHandler.ChancePerFrame - 1].text =	pincount.chanc1_total.ToString ();

						GlobalGameHandler.chance1 = pincount.chanc1_total;
						if (pincount.chanc1_total == 10) {
							gpc.p_text1 [GlobalGameHandler.ChancePerFrame - 1].text = "X";

						}
					} else if (GlobalGameHandler.ChancePerFrame == 2) {
						gpc.p_text1 [GlobalGameHandler.ChancePerFrame - 1].text =	pincount.chance2_tota.ToString ();
						GlobalGameHandler.chance2 = pincount.chance2_tota;

						int a = GlobalGameHandler.chance1 + GlobalGameHandler.chance2;

						if (a == 10) {
							gpc.p_text1 [GlobalGameHandler.ChancePerFrame - 1].text = "/".ToString ();
							GlobalGameHandler.chance1 = 0;
							GlobalGameHandler.chance2 = 0;

							GlobalGameHandler.slash = true;

							GlobalGameHandler.slesh_leaderB++;
						}

					}
			}
			else if (GlobalGameHandler.BallFrames == 1) {
					
					if (GlobalGameHandler.ChancePerFrame == 1) {
						gpc.p_text2 [GlobalGameHandler.ChancePerFrame - 1].text =	pincount.chanc1_total.ToString ();
						GlobalGameHandler.chance1 = pincount.chanc1_total;
						if (pincount.chanc1_total == 10) {
							gpc.p_text2 [GlobalGameHandler.ChancePerFrame - 1].text = "X";
						}
						if (GlobalGameHandler.spike) {
								
							int a = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
							
							gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (a +	pincount.chanc1_total).ToString ();
							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;

						} else if (GlobalGameHandler.isLastSpike) { 	

//							print ("spkie" + GlobalGameHandler.isLastSpike);
							int a = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
							gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (a +	pincount.chanc1_total).ToString ();
							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;

//							GlobalGameHandler.isLastSpike = false;
						} else if (GlobalGameHandler.slash) {
						

//							print ("spkie" + GlobalGameHandler.isLastSpike);
							int a = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
							gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (a +	pincount.chanc1_total).ToString ();
							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;
							GlobalGameHandler.slash = false;
						}


					} else if (GlobalGameHandler.ChancePerFrame == 2) {
						gpc.p_text2 [GlobalGameHandler.ChancePerFrame - 1].text =	pincount.chance2_tota.ToString ();
						GlobalGameHandler.chance2 = pincount.chance2_tota;

						int a = GlobalGameHandler.chance1 + GlobalGameHandler.chance2;

						if (a == 10) {
							gpc.p_text2 [GlobalGameHandler.ChancePerFrame - 1].text  = "/".ToString ();
							GlobalGameHandler.chance1 = 0;
							GlobalGameHandler.chance2 = 0;
							GlobalGameHandler.slash = true;

							GlobalGameHandler.slesh_leaderB++;
						}

						if (GlobalGameHandler.isLastSpike) { 	

//							print ("spkie" + GlobalGameHandler.isLastSpike);
							int b = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
							gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (b +	pincount.chance2_tota).ToString ();
							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chance2_tota;

							GlobalGameHandler.isLastSpike = false;
						}


					}

			}
			else if (GlobalGameHandler.BallFrames == 2) {
					if (GlobalGameHandler.ChancePerFrame == 1) {
						gpc.p_text3 [GlobalGameHandler.ChancePerFrame - 1].text =	pincount.chanc1_total.ToString ();
						GlobalGameHandler.chance1 = pincount.chanc1_total;
						if (pincount.chanc1_total == 10) {
							gpc.p_text3 [GlobalGameHandler.ChancePerFrame - 1].text = "X";
						}

						if (GlobalGameHandler.spike) {
							int a = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
							gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (a +	pincount.chanc1_total).ToString ();
							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;

							int b = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 2].text);

							gpc.p_total [GlobalGameHandler.BallFrames - 2].text = (b +	pincount.chanc1_total).ToString ();
							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;

						}

						else if (GlobalGameHandler.isLastSpike) {
							int a = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
							gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (a +	pincount.chanc1_total).ToString ();
							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;
//							GlobalGameHandler.isLastSpike = false;
						}
						else if (GlobalGameHandler.slash) {


//							print ("spkie" + GlobalGameHandler.isLastSpike);
							int a = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
							gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (a +	pincount.chanc1_total).ToString ();
							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;
							GlobalGameHandler.slash = false;
						}
					} 
				
					else if(GlobalGameHandler.ChancePerFrame==2){
					gpc.p_text3 [GlobalGameHandler.ChancePerFrame-1].text =	pincount.chance2_tota.ToString();
						GlobalGameHandler.chance2 = pincount.chance2_tota;

						int a = GlobalGameHandler.chance1 + GlobalGameHandler.chance2;

						if (a == 10) {
							gpc.p_text3 [GlobalGameHandler.ChancePerFrame-1].text  = "/".ToString ();
							GlobalGameHandler.chance1 = 0;
							GlobalGameHandler.chance2 = 0;
							GlobalGameHandler.slash = true;
							GlobalGameHandler.slesh_leaderB++;
						}

						if (GlobalGameHandler.isLastSpike) { 	

							//							print ("spkie" + GlobalGameHandler.isLastSpike);
							int b = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
							gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (b +	pincount.chance2_tota).ToString ();
							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chance2_tota;

							GlobalGameHandler.isLastSpike = false;
						}
					}

			}
			else if (GlobalGameHandler.BallFrames == 3) {
				if (GlobalGameHandler.ChancePerFrame == 1) {
					gpc.p_text4 [GlobalGameHandler.ChancePerFrame - 1].text =	pincount.chanc1_total.ToString ();
					if (pincount.chanc1_total == 10) {
						gpc.p_text4 [GlobalGameHandler.ChancePerFrame - 1].text = "X";
					}
					if (GlobalGameHandler.spike) {
						int a = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
						gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (a +	pincount.chanc1_total).ToString ();
						GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;

						int b = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 2].text);
						
						gpc.p_total [GlobalGameHandler.BallFrames - 2].text = (b +	pincount.chanc1_total).ToString ();
						GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;

//							int c =System.Convert.ToInt32(gpc.p_total [GlobalGameHandler.BallFrames-3].text ) ;
//							gpc.p_total [GlobalGameHandler.BallFrames-3].text  = (c+	pincount.chanc1_total).ToString ();
//							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;
					} else if (GlobalGameHandler.isLastSpike) {
						int a = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
						gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (a +	pincount.chanc1_total).ToString ();
					
						GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;
				
//							GlobalGameHandler.isLastSpike = false;
						}
						else if (GlobalGameHandler.slash) {


//							print ("spkie" + GlobalGameHandler.isLastSpike);
							int a = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
							gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (a +	pincount.chanc1_total).ToString ();
							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chanc1_total;
							GlobalGameHandler.slash = false;
						}

				} else if (GlobalGameHandler.ChancePerFrame == 2) {
						
						                          
					gpc.p_text4 [GlobalGameHandler.ChancePerFrame - 1].text =	pincount.chance2_tota.ToString ();
				
						if (GlobalGameHandler.isLastSpike) { 	

							//							print ("spkie" + GlobalGameHandler.isLastSpike);
							int b = System.Convert.ToInt32 (gpc.p_total [GlobalGameHandler.BallFrames - 1].text);
							gpc.p_total [GlobalGameHandler.BallFrames - 1].text = (b +	pincount.chance2_tota).ToString ();
							GlobalGameHandler.pcount = GlobalGameHandler.pcount + pincount.chance2_tota;

							GlobalGameHandler.isLastSpike = false;

						}
						int a = GlobalGameHandler.chance1 + GlobalGameHandler.chance2;
						print (GlobalGameHandler.chance1 +"   " +GlobalGameHandler.chance2);
						if (a == 10) {
							
							gpc.p_text4 [GlobalGameHandler.ChancePerFrame-1].text  = "/".ToString ();
							GlobalGameHandler.chance1 = 0;
							GlobalGameHandler.chance2 = 0;
							GlobalGameHandler.slash = true;
							GlobalGameHandler.slesh_leaderB++;
 
							print ("ddd"+GlobalGameHandler.isFrameUpDateInstently+"hfh "+GlobalGameHandler.slash);


						
						}

						if (!GlobalGameHandler.isLastSpike && !GlobalGameHandler.slash) {
							GlobalGameHandler.isFrameUpDateInstently = true;
						
							print ("ddd" + GlobalGameHandler.isFrameUpDateInstently + "hfh " + GlobalGameHandler.isFrameUpDateInstently);
						}


//						

					}
				else if(GlobalGameHandler.ChancePerFrame==3)
					gpc.p_text4 [GlobalGameHandler.ChancePerFrame-1].text =	pincount.chance2_tota.ToString();




			}


//			print ("total  "+pincount.total);

			gpc.p_total [GlobalGameHandler.BallFrames].text = pincount.total.ToString();

			gpc.PinCountText.text = GlobalGameHandler.pcount.ToString();



			StartCoroutine(fillImageCo ());

				ahmed = GameObject.FindGameObjectsWithTag("pcount");

				if(ahmed.Length < 1)
				{
					GlobalGameHandler.isemptyPins = true;
				}

//				print (ahmed[0]);
			if (GlobalGameHandler.isgutter) {

//				print ("ball   chance"+GlobalGameHandler.ChancePerFrame);
//				print ("ball frams  "+GlobalGameHandler.BallFrames);

				gpc.pincounter.SetActive (false);
				if (GlobalGameHandler.ChancePerFrame==2){
					gpc.pincounter.SetActive (false);
					if (GlobalGameHandler.BallFrames != 3) {
						GlobalGameHandler.ChancePerFrame = 0;
						GlobalGameHandler.BallFrames++;
							if (GlobalGameHandler.isOvO) {
								GlobalGameHandler.OneVsOne = true;
							}
						pincount.total = 0;
//						print ("chanc ++ ");

					}
					//					GlobalGameHandler.ChancePerFrame = 0;
					//					GlobalGameHandler.BallFrames++;
//						if (!GlobalGameHandler.spike) {
					
						if (!GlobalGameHandler.isemptyPins) {
							gpc.pinClean.SetActive (true);
//						}
							gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", true);

							yield return new WaitForSeconds (3f);

//					gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", false);

							yield return new WaitForSeconds (1.5f);
						}
					gpc.pinRest ();

					GlobalGameHandler.spike = false;


				}

				if (GlobalGameHandler.ChancePerFrame == 3) {
//						if (!GlobalGameHandler.spike) {
					
						if (!GlobalGameHandler.isemptyPins) {
							gpc.pinClean.SetActive (true);
//						}
							gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", true);	
							yield return new WaitForSeconds (3f);
						}
					GlobalGameHandler.ChancePerFrame = 0;

					GlobalGameHandler.BallFrames++;

						if (GlobalGameHandler.isOvO) {
							GlobalGameHandler.OneVsOne = true;
						}
//					print ("ball fram"+GlobalGameHandler.BallFrames);
					pincount.total = 0;
					yield break;
				}

//				print ("in gutter");

				gpc.Cam1.GetComponent<SmoothFollow> ().distance =4f;
				//				gpc.Cam1.GetComponent<SmoothFollow> ().distance = Mathf.Lerp(gpc.Cam1.transform.position.x,6f,gpc.Cam1.transform.position.z);

				reset_ball ();
				yield break ;
			}
			if (GlobalGameHandler.ChancePerFrame == 3) {
//					if (!GlobalGameHandler.spike) {

					if (!GlobalGameHandler.isemptyPins) {
						gpc.pinClean.SetActive (true);
//					}
						gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", true);	
						yield return new WaitForSeconds (3f);
					}
				GlobalGameHandler.ChancePerFrame = 0;
				GlobalGameHandler.BallFrames++;

					if (GlobalGameHandler.isOvO) {
						GlobalGameHandler.OneVsOne = true;
					}

//				print ("ball fram"+GlobalGameHandler.BallFrames);
				pincount.total = 0;
				yield break;
			}
			if(GlobalGameHandler.ChancePerFrame==1&&GlobalGameHandler.spike&&pincount.a>=10)
			{

				gpc.pincounter.SetActive (false);
//					if (!GlobalGameHandler.spike) {
				
					if (!GlobalGameHandler.isemptyPins) {
						gpc.pinClean.SetActive (true);
//					}
				gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", true);
//				print ("spike in");
				yield return new WaitForSeconds (3f);
//				gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", false);
					}
				yield return new WaitForSeconds (2f);
				

				if (GlobalGameHandler.BallFrames != 3) {
					GlobalGameHandler.ChancePerFrame = 0;
					GlobalGameHandler.BallFrames++;

						if (GlobalGameHandler.isOvO) {
							GlobalGameHandler.OneVsOne = true;
						}

					pincount.total = 0;
//					print ("chanc ++ ");
				}
				//				GlobalGameHandler.ChancePerFrame = 0;
					gpc.pinRest ();
				//				GlobalGameHandler.BallFrames++;
				//				pincount.total = 0;
				reset_ball ();
				yield break;
			}


			else if (GlobalGameHandler.ChancePerFrame == 1) {
//				print ("ispick");
				GlobalGameHandler.ispin = true;

				//				gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", true);
				//				gpc.pinpick.GetComponent<Animator> ().SetBool ("ispick", true);




				yield return new WaitForSeconds (2f);
				//				gpc.pincounter.SetActive (false);
				if(GlobalGameHandler.spike&&pincount.a>=10)
				{
//					print ("spike in");
					yield return new WaitForSeconds (3f);

					
					if (GlobalGameHandler.BallFrames != 3) {
						GlobalGameHandler.ChancePerFrame = 0;
						GlobalGameHandler.BallFrames++;

							if (GlobalGameHandler.isOvO) {
								GlobalGameHandler.OneVsOne = true;
							}

//							print ("chanc ++ ");
						pincount.total = 0;
					}
					//					GlobalGameHandler.ChancePerFrame = 0;
					//					GlobalGameHandler.BallFrames++;
						gpc.pinRest ();
					reset_ball ();
					yield break;
				}

				//				gpc.pinpick.GetComponent<Animator> ().SetBool ("ispick", false);
				yield return new WaitForSeconds (1f);
				//				print ("ispick");
				//				gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", false);


				//				gpc.pinpick.GetComponent<Animator> ().SetBool ("ispick", true);

//				print ("ispick");
				//				gpc.pinDroper.SetActive (true);

//				print ("isclean");


				//				yield return new WaitForSeconds (2f);
				//				gpc.pinpick.GetComponent<Animator> ().SetBool ("ispick", false);





			}


			else if(GlobalGameHandler.ChancePerFrame == 2 ) {
//				print ("ispick in f 1");
				if (GlobalGameHandler.BallFrames != 3) {
					GlobalGameHandler.ChancePerFrame = 0;
					GlobalGameHandler.BallFrames++;

						if (GlobalGameHandler.isOvO) {
							GlobalGameHandler.OneVsOne = true;
						}

//					print ("chanc ++ ");
					pincount.total = 0;
				}
				
					//				GlobalGameHandler.ChancePerFrame = 0;
				//				GlobalGameHandler.BallFrames++;

						
					if (!GlobalGameHandler.isemptyPins) {
						gpc.pinClean.SetActive (true);
					}
				gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", true);
				gpc.pincounter.SetActive (false);
				yield return new WaitForSeconds (3f);
//				gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", false);
				yield return new WaitForSeconds (1.5f);
//				print ("reset pins");
				gpc.pinRest ();


			}


			this.gameObject.transform.GetComponent<ConstantForce> ().enabled = false;
			//			gpc.Cam1.GetComponent<SmoothFollow> ().distance = 6;

			GetComponent<Swipe> ().isClick=true;
//			print ("yied brea ");
//			GlobalGameHandler.spike = false;
			reset_ball();

			}
			else if (GlobalGameHandler.OneVsOne) {


//				print ("ball frams  "+GlobalGameHandler.BallFramesOneVsOne);

			
//				gpc.pinCleanOnevsOn.SetActive(true);

				this.gameObject.transform.GetComponent<BoxCollider> ().enabled = false;

				GlobalGameHandler.ChancePerFrameOneVsOne++;


//				print ("ball  "+GlobalGameHandler.ChancePerFrameOneVsOne);

				yield return new WaitForSeconds (2f);

				gpc.scoreboraddrop ();
				gpc.OnPlayer2CLick ();
//				print ("chance 1 "+ pincount.chanc1_totalOneVsOne+"  chance 2  "+pincount.chance2_totaOneVsOne);
				if (GlobalGameHandler.BallFramesOneVsOne == 0) {
					if (GlobalGameHandler.ChancePerFrameOneVsOne == 1) {
						
						gpc.p_text1OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne - 1].text =	pincount.chanc1_totalOneVsOne.ToString ();
						GlobalGameHandler.chance1OvO = pincount.chanc1_totalOneVsOne;
						if (pincount.chanc1_totalOneVsOne == 10) {
							gpc.p_text1OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne - 1].text = "X";
						}
					} else if (GlobalGameHandler.ChancePerFrameOneVsOne == 2) {
						
						gpc.p_text1OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne - 1].text =	pincount.chance2_totaOneVsOne.ToString ();

						GlobalGameHandler.chance2OvO = pincount.chance2_totaOneVsOne;

						int a = GlobalGameHandler.chance1OvO + GlobalGameHandler.chance2OvO;

						if (a == 10) {
							gpc.p_text1OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne - 1].text = "/".ToString ();
							GlobalGameHandler.chance1OvO = 0;
							GlobalGameHandler.chance2OvO = 0;
							GlobalGameHandler.slashOvO = true;
						}
					}

				}
				else if (GlobalGameHandler.BallFramesOneVsOne == 1) {
					if (GlobalGameHandler.ChancePerFrameOneVsOne == 1) {
						gpc.p_text2OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne - 1].text =	pincount.chanc1_totalOneVsOne.ToString ();
						GlobalGameHandler.chance1OvO = pincount.chanc1_totalOneVsOne;
						if (pincount.chanc1_totalOneVsOne == 10) {
							gpc.p_text2OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne - 1].text = "X";
						}

						if (GlobalGameHandler.spikeOneVsOne) {
							int a =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (a+	pincount.chanc1_totalOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;

						}
						else if (GlobalGameHandler.isLastSpikeOvO) {
//							print ("{ghju");
							int a =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (a+	pincount.chanc1_totalOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;

//							GlobalGameHandler.isLastSpikeOvO = false;
						}
						else if (GlobalGameHandler.slashOvO) {
							int a =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (a+	pincount.chanc1_totalOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;
							GlobalGameHandler.slashOvO = false;
						}

					}
					else if(GlobalGameHandler.ChancePerFrameOneVsOne==2){
						gpc.p_text2OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne-1].text =	pincount.chance2_totaOneVsOne.ToString();
						GlobalGameHandler.chance2OvO = pincount.chance2_totaOneVsOne;

						int a = GlobalGameHandler.chance1OvO + GlobalGameHandler.chance2OvO;

						if (a == 10) {
							gpc.p_text2OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne-1].text = "/".ToString ();
							GlobalGameHandler.chance1OvO = 0;
							GlobalGameHandler.chance2OvO = 0;
							GlobalGameHandler.slashOvO=true;
						}

						 if (GlobalGameHandler.isLastSpikeOvO) {
//							print ("{ghju");
							int b =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (b+	pincount.chance2_totaOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chance2_totaOneVsOne;

							GlobalGameHandler.isLastSpikeOvO = false;
						}
					}

				}
				else if (GlobalGameHandler.BallFramesOneVsOne == 2) {
					if(GlobalGameHandler.ChancePerFrameOneVsOne==1){
						
						gpc.p_text3OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne-1].text =	pincount.chanc1_totalOneVsOne.ToString();
						GlobalGameHandler.chance1OvO = pincount.chanc1_totalOneVsOne;
						if (pincount.chanc1_totalOneVsOne == 10) {
							gpc.p_text3OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne - 1].text = "X";
						}

						if (GlobalGameHandler.spikeOneVsOne) {
							int a =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (a+	pincount.chanc1_totalOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;

						
							int b =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-2].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-2].text  = (b+	pincount.chanc1_totalOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;

						}
						else if (GlobalGameHandler.isLastSpikeOvO) {

							int a =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (a+	pincount.chanc1_totalOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;

//							GlobalGameHandler.isLastSpikeOvO = false;
						}
						else if (GlobalGameHandler.slashOvO) {
							int a =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (a+	pincount.chanc1_totalOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;
							GlobalGameHandler.slashOvO = false;
						}
					}
					else if(GlobalGameHandler.ChancePerFrameOneVsOne==2){
						gpc.p_text3OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne-1].text =	pincount.chance2_totaOneVsOne.ToString();
						GlobalGameHandler.chance2OvO = pincount.chance2_totaOneVsOne;

						int a = GlobalGameHandler.chance1OvO + GlobalGameHandler.chance2OvO;

						if (a == 10) {
							gpc.p_text3OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne-1].text = "/".ToString ();
							GlobalGameHandler.chance1OvO = 0;
							GlobalGameHandler.chance2OvO = 0;
							GlobalGameHandler.slashOvO = true;
						}
						 if (GlobalGameHandler.isLastSpikeOvO) {

							int b =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (b+	pincount.chance2_totaOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chance2_totaOneVsOne;

							GlobalGameHandler.isLastSpikeOvO = false;
						}
					}

				}
				else if (GlobalGameHandler.BallFramesOneVsOne == 3) {
					if (GlobalGameHandler.ChancePerFrameOneVsOne == 1) {
						gpc.p_text4OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne - 1].text =	pincount.chanc1_totalOneVsOne.ToString ();
						if (pincount.chanc1_totalOneVsOne == 10) {
							gpc.p_text4OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne - 1].text = "X";
						}


						if (GlobalGameHandler.spikeOneVsOne) {
							int a =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (a+	pincount.chanc1_totalOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;

						
						
							int b =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-2].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-2].text  = (b+	pincount.chanc1_totalOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;

						
//						if (GlobalGameHandler.spikeOneVsOne) {
//							int c =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-3].text ) ;
//							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-3].text  = (c+	pincount.chanc1_totalOneVsOne).ToString ();
//							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;
//
						}else if (GlobalGameHandler.isLastSpikeOvO) {

							int a =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (a+	pincount.chanc1_totalOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;

//							GlobalGameHandler.isLastSpikeOvO = false;
						}
						else if (GlobalGameHandler.slashOvO) {
							int a =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (a+	pincount.chanc1_totalOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chanc1_totalOneVsOne;
							GlobalGameHandler.slashOvO = false;
						}

					} else if (GlobalGameHandler.ChancePerFrameOneVsOne == 2) {
						gpc.p_text4OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne - 1].text =	pincount.chance2_totaOneVsOne.ToString ();

						 if (GlobalGameHandler.isLastSpikeOvO) {

							int b =System.Convert.ToInt32( gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text ) ;
							gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne-1].text  = (b+	pincount.chance2_totaOneVsOne).ToString ();
							GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + pincount.chance2_totaOneVsOne;

							GlobalGameHandler.isLastSpikeOvO = false;
						}
						int a = GlobalGameHandler.chance1OvO + GlobalGameHandler.chance2OvO;

						if (a == 10) {
							gpc.p_text3OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne-1].text = "/".ToString ();
							GlobalGameHandler.chance1OvO = 0;
							GlobalGameHandler.chance2OvO = 0;
							GlobalGameHandler.slashOvO = true;
						}

						if (!GlobalGameHandler.isLastSpikeOvO && !GlobalGameHandler.slashOvO) {
							GlobalGameHandler.isFrameUpDateInstentlyOvO = true;

							print ("ddd" + GlobalGameHandler.isFrameUpDateInstently + "hfh " + GlobalGameHandler.isFrameUpDateInstently);
						}

					}
					else if(GlobalGameHandler.ChancePerFrameOneVsOne==3)
						gpc.p_text4OnevsOn [GlobalGameHandler.ChancePerFrameOneVsOne-1].text =	pincount.chance2_totaOneVsOne.ToString();
				}


//				print ("total  "+pincount.total);

				gpc.p_totalOnevsOn [GlobalGameHandler.BallFramesOneVsOne].text = pincount.totalOneVsOne.ToString();

				gpc.PinCountTextOneVsOne.text = GlobalGameHandler.pcountOneVsOne.ToString();
//				print ("ball frams  "+GlobalGameHandler.BallFramesOneVsOne);


				StartCoroutine(fillImageCo ());
				ahmed = GameObject.FindGameObjectsWithTag("pcount");

				if(ahmed.Length < 1)
				{
					GlobalGameHandler.isemptyPins = true;
				}

				if (GlobalGameHandler.isgutterOneVsOne) {

//					print ("ball   chance"+GlobalGameHandler.ChancePerFrameOneVsOne);
//					print ("ball frams  "+GlobalGameHandler.BallFramesOneVsOne);

					gpc.pincounterOnevsOn.SetActive (false);
					if (GlobalGameHandler.ChancePerFrameOneVsOne==2){
						gpc.pincounterOnevsOn.SetActive (false);
						if (GlobalGameHandler.BallFramesOneVsOne != 3) {
							GlobalGameHandler.ChancePerFrameOneVsOne = 0;
							GlobalGameHandler.BallFramesOneVsOne++;

							if (GlobalGameHandler.isOvO) {
								GlobalGameHandler.OneVsOne = false;
							}

							pincount.totalOneVsOne = 0;
//							print ("chanc ++ ");

						}
						//					GlobalGameHandler.ChancePerFrame = 0;
						//					GlobalGameHandler.BallFrames++;
					
						if (!GlobalGameHandler.isemptyPins) {
							gpc.pinCleanOnevsOn.SetActive (true);

							gpc.pinCleanOnevsOn.GetComponent<Animator> ().SetBool ("isclean", true);

							yield return new WaitForSeconds (3f);
						}
//						gpc.pinCleanOnevsOn.GetComponent<Animator> ().SetBool ("isclean", false);

						yield return new WaitForSeconds (2f);
						gpc.pinRest ();

						GlobalGameHandler.spikeOneVsOne = false;


					}

					if (GlobalGameHandler.ChancePerFrameOneVsOne == 3) {
						if (!GlobalGameHandler.isemptyPins) {
							gpc.pinCleanOnevsOn.SetActive (true);
							gpc.pinCleanOnevsOn.GetComponent<Animator> ().SetBool ("isclean", true);	
							yield return new WaitForSeconds (3f);
						}

						GlobalGameHandler.ChancePerFrameOneVsOne = 0;
						GlobalGameHandler.BallFramesOneVsOne++;

						if (GlobalGameHandler.isOvO) {
							GlobalGameHandler.OneVsOne = false;
						}


//						print ("ball fram"+GlobalGameHandler.BallFramesOneVsOne);
						pincount.totalOneVsOne = 0;

						gpc.pinRest ();
						reset_ball ();
//						gpc.ballReset ();
						yield break;
					}

//					print ("in gutter");

					gpc.cam1OneVsOne.GetComponent<SmoothFollow> ().distance =4f;
					//				gpc.Cam1.GetComponent<SmoothFollow> ().distance = Mathf.Lerp(gpc.Cam1.transform.position.x,6f,gpc.Cam1.transform.position.z);

					reset_ball ();
					yield break ;
				}
				if (GlobalGameHandler.ChancePerFrameOneVsOne == 3) {
					if (!GlobalGameHandler.isemptyPins) {
						gpc.pinCleanOnevsOn.SetActive (true);
						gpc.pinCleanOnevsOn.GetComponent<Animator> ().SetBool ("isclean", true);	
						yield return new WaitForSeconds (3f);
					}
					GlobalGameHandler.ChancePerFrameOneVsOne = 0;
					GlobalGameHandler.BallFramesOneVsOne++;

					if (GlobalGameHandler.isOvO) {
						GlobalGameHandler.OneVsOne = false;
					}


//					print ("ball fram"+GlobalGameHandler.BallFramesOneVsOne);
					pincount.totalOneVsOne = 0;
					gpc.pinRest ();
					reset_ball ();
//					gpc.ballReset ();
					yield break;
				}
				if(GlobalGameHandler.ChancePerFrameOneVsOne==1&&GlobalGameHandler.spikeOneVsOne&&pincount.aOneVsOne>=10)
				{

					gpc.pincounterOnevsOn.SetActive (false);
					if (!GlobalGameHandler.isemptyPins) {
						gpc.pinCleanOnevsOn.SetActive (true);
						gpc.pinCleanOnevsOn.GetComponent<Animator> ().SetBool ("isclean", true);
//						print ("spike in");
						yield return new WaitForSeconds (3f);
					}
//					gpc.pinCleanOnevsOn.GetComponent<Animator> ().SetBool ("isclean", false);
					yield return new WaitForSeconds (2f);


					if (GlobalGameHandler.BallFramesOneVsOne != 3) {
						GlobalGameHandler.ChancePerFrameOneVsOne = 0;
						GlobalGameHandler.BallFramesOneVsOne++;

						if (GlobalGameHandler.isOvO) {
							GlobalGameHandler.OneVsOne = false;
						}


						pincount.totalOneVsOne = 0;
//						print ("chanc ++ ");
					}
					//				GlobalGameHandler.ChancePerFrame = 0;
					gpc.pinRest ();
					//				GlobalGameHandler.BallFrames++;
					//				pincount.total = 0;
					reset_ball ();
					yield break;
				}


				else if (GlobalGameHandler.ChancePerFrameOneVsOne == 1) {
//					print ("ispick");
					GlobalGameHandler.ispinOneVsOne = true;

					//				gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", true);
					//				gpc.pinpick.GetComponent<Animator> ().SetBool ("ispick", true);




					yield return new WaitForSeconds (2f);
					//				gpc.pincounter.SetActive (false);
					if(GlobalGameHandler.spikeOneVsOne&&pincount.aOneVsOne>=10)
					{
//						print ("spike in");
						yield return new WaitForSeconds (3f);

					
						if (GlobalGameHandler.BallFramesOneVsOne != 3) {
							GlobalGameHandler.ChancePerFrameOneVsOne = 0;
							GlobalGameHandler.BallFramesOneVsOne++;

							if (GlobalGameHandler.isOvO) {
								GlobalGameHandler.OneVsOne = false;
							}


//							print ("chanc ++ ");
							pincount.totalOneVsOne = 0;
						}
						yield return new WaitForSeconds (1f);
						//					GlobalGameHandler.ChancePerFrame = 0;
						//					GlobalGameHandler.BallFrames++;
						gpc.pinRest ();
						reset_ball ();
						yield break;
					}

					//				gpc.pinpick.GetComponent<Animator> ().SetBool ("ispick", false);

					//				print ("ispick");
					//				gpc.pinClean.GetComponent<Animator> ().SetBool ("isclean", false);


					//				gpc.pinpick.GetComponent<Animator> ().SetBool ("ispick", true);

//					print ("ispick");
					//				gpc.pinDroper.SetActive (true);

//					print ("isclean");


					//				yield return new WaitForSeconds (2f);
					//				gpc.pinpick.GetComponent<Animator> ().SetBool ("ispick", false);





				}


				else if(GlobalGameHandler.ChancePerFrameOneVsOne == 2 ) {
//					print ("ispick in f 1");
					if (GlobalGameHandler.BallFramesOneVsOne != 3) {
						GlobalGameHandler.ChancePerFrameOneVsOne = 0;
						GlobalGameHandler.BallFramesOneVsOne++;

						if (GlobalGameHandler.isOvO) {
							GlobalGameHandler.OneVsOne = false;
						}


//						print ("chanc ++ ");
						pincount.totalOneVsOne = 0;
					}
					//				GlobalGameHandler.ChancePerFrame = 0;
					//				GlobalGameHandler.BallFrames++;

					if (!GlobalGameHandler.isemptyPins) {
						gpc.pinCleanOnevsOn.SetActive (true);
						gpc.pinCleanOnevsOn.GetComponent<Animator> ().SetBool ("isclean", true);
						gpc.pincounterOnevsOn.SetActive (false);
						yield return new WaitForSeconds (3f);
					}
//					gpc.pinCleanOnevsOn.GetComponent<Animator> ().SetBool ("isclean", false);
					yield return new WaitForSeconds (2f);
//					print ("reset pins");
					gpc.pinRest ();


				}

				this.gameObject.transform.GetComponent<ConstantForce> ().enabled = false;
				//			gpc.Cam1.GetComponent<SmoothFollow> ().distance = 6;

				GetComponent<Swipe> ().isClick=true;
//				print ("yied brea ");
//				GlobalGameHandler.spikeOneVsOne = false;
				reset_ball();
			}

        }
		else if (ballCollider.gameObject.tag == "G")
			
		{	
			gpc.BallPs.SetActive (false);

			if(PlayerPrefs.GetInt("tutorial")==0)
			{
				gpc.tiltAnim.SetActive(false);
				gpc.swipeAnim.SetActive(false);
			}

			if (!GlobalGameHandler.OneVsOne) {
				GlobalGameHandler.spike = false;

				gpc.Cam1.GetComponent<SmoothFollow> ().enabled = false;

				//			gpc.Cam1.GetComponent<SmoothFollow> ().distance = 15;
				//			gpc.Cam1.GetComponent<SmoothFollow> ().distance = Mathf.Lerp(gpc.Cam1.transform.position.x,15f,gpc.Cam1.transform.position.z);

				yield return new WaitForSeconds (0.3f);

				rib.AddForce (Vector3.forward * 500);

				GlobalGameHandler.isgutter = true;

				yield return new WaitForSeconds (1f);
				//			gpc.Cam1.GetComponent<SmoothFollow> ().distance = 6;

			} else if (GlobalGameHandler.OneVsOne) {
			

				gpc.cam1OneVsOne.GetComponent<SmoothFollow> ().enabled = false;

				//			gpc.Cam1.GetComponent<SmoothFollow> ().distance = 15;
				//			gpc.Cam1.GetComponent<SmoothFollow> ().distance = Mathf.Lerp(gpc.Cam1.transform.position.x,15f,gpc.Cam1.transform.position.z);
				GlobalGameHandler.spikeOneVsOne = false;
				yield return new WaitForSeconds (0.3f);

				rib.AddForce (Vector3.forward *500);

				GlobalGameHandler.isgutterOneVsOne = true;

				yield return new WaitForSeconds (1f);
				//			gpc.Cam1.GetComponent<SmoothFollow> ().distance = 6;

			}




		}




		if (ballCollider.gameObject.CompareTag ("tstop")) {
		
			if (gpc.ballSizeUP) {
				rib.mass = rib.mass * rib.mass;
				rib.drag = rib.drag * rib.drag;
				rib.angularDrag = rib.angularDrag * rib.angularDrag;
//				rib.velocity = rib.velocity + rib.velocity;
			}

			if(PlayerPrefs.GetInt("tutorial")==0)
			{
				gpc.tiltAnim.SetActive(false);
				gpc.swipeAnim.SetActive(false);
			}

			if (!GlobalGameHandler.OneVsOne) {


				GlobalGameHandler.istilt = false;
				gpc.Cam1.SetActive (false);
				gpc.Cam1.GetComponent<SmoothFollow> ().enabled = false;
				gpc.Cam2.SetActive (true);

			} else if (GlobalGameHandler.OneVsOne) {
			

				GlobalGameHandler.istilt = false;
				gpc.cam1OneVsOne.SetActive (false);
				gpc.cam1OneVsOne.GetComponent<SmoothFollow> ().enabled = false;
				gpc.cam2OneVsOne.SetActive (true);

			}
			}

		if (ballCollider.gameObject.CompareTag ("Pin")) {
			if (GlobalGameHandler.OneVsOne) {
				if(ispindropplay&&(GlobalGameHandler.ChancePerFrame!=2||GlobalGameHandler.BallFrames==3))
					gpc.pindrop.Play ();

				//			print("pin  "+ballCollider.gameObject.name);
				ispindropplay = false;

			}
			else if (!GlobalGameHandler.OneVsOne) {
				if(ispindropplay&&(GlobalGameHandler.ChancePerFrameOneVsOne!=2||GlobalGameHandler.BallFramesOneVsOne==3))
					gpc.pindrop.Play ();

				//			print("pin  "+ballCollider.gameObject.name);
				ispindropplay = false;

			}


		}

    }

	IEnumerator fillImageCo(){
	
	
		if (!GlobalGameHandler.OneVsOne) {
			for (int i = 0; i <= GlobalGameHandler.pcount; i++) {
			

				gpc.fillScoreImage.fillAmount = i * 0.015f;
//			print (i*1.02f);
		
				yield return new WaitForSeconds (0.02f);

			} 
		}
			else if (GlobalGameHandler.OneVsOne) {
			for (int i = 0; i <= GlobalGameHandler.pcountOneVsOne; i++) {

				gpc.fillScoreImageOnevsOn.fillAmount = i * 0.015f;
				//			print (i*1.02f);

				yield return new WaitForSeconds (0.02f);


			}
			}

//		gpc.fillScoreImage.fillAmount = GlobalGameHandler.pcount*0.02f;
	}

	public void IAP_Products()
	{
		GlobalGameHandler.twoballs = false;
		GlobalGameHandler.twopins = false;
		gpc.twoBalls.interactable = false;

		if (GlobalGameHandler.NoGutter != 0) {
			gpc.NOGutter.interactable = true;
		}  if (GlobalGameHandler.NoGutter == 0||GlobalGameHandler.OneVsOne) {
//			print ("in no gutter");
			gpc.NOGutter.interactable=false;
//			gpc.NOGutter.gameObject.SetActive (false);
		}
		if (GlobalGameHandler.ballsize_Double != 0) {
			gpc.BalSizeUp.interactable = true;
		}  if (GlobalGameHandler.ballsize_Double == 0|| GlobalGameHandler.OneVsOne) {

			//			print ("ball soize double" + GlobalGameHandler.ballsize_Double+" one vs one  "+GlobalGameHandler.OneVsOne);
//			gpc.BalSizeUp.gameObject.SetActive (false);
			gpc.BalSizeUp.interactable = false;
		}


		if (GlobalGameHandler.two_pins != 0) {
			gpc.twoPins.interactable = true;
		}  

		if (GlobalGameHandler.two_pins == 0|| GlobalGameHandler.OneVsOne) {

//			gpc.twoPins.gameObject.SetActive (false);
			gpc.twoPins.interactable = false;
		}


		if (GlobalGameHandler.Ghoost_Ball != 0) {
			gpc.ghoost_Ball.interactable = true;
		}  

		if (GlobalGameHandler.Ghoost_Ball == 0|| GlobalGameHandler.OneVsOne) {
			gpc.ghoost_Ball.interactable = false;
//			gpc.ghoost_Ball.gameObject.SetActive (false);
		}




		if (GlobalGameHandler.two_balls == 0|| GlobalGameHandler.OneVsOne) {

//			gpc.twoBalls.gameObject.SetActive (false);
			gpc.twoBalls.interactable = false;
		}


		//		print("one vs one"+GlobalGameHandler.OneVsOne);
		if (GlobalGameHandler.ballsize_Double != 0 && !GlobalGameHandler.OneVsOne) {
			//			print("one vs one"+GlobalGameHandler.OneVsOne);
//			gpc.BalSizeUp.gameObject.SetActive (true);
			gpc.BalSizeUp.interactable = true;

//			print ("in no gutter");
		}
		if (GlobalGameHandler.NoGutter != 0 && !GlobalGameHandler.OneVsOne) {
//			gpc.NOGutter.gameObject.SetActive (true);
			gpc.NOGutter.interactable=true;
		}
		if (GlobalGameHandler.two_pins != 0 && !GlobalGameHandler.OneVsOne) {
//			gpc.twoPins.gameObject.SetActive (true);
			gpc.twoPins.interactable = true;
		}
		if (GlobalGameHandler.Ghoost_Ball != 0 && !GlobalGameHandler.OneVsOne) {
//			gpc.ghoost_Ball.gameObject.SetActive (true);
			gpc.ghoost_Ball.interactable = true;
		}








		CollidersOn ();
	}

	public void CollidersOn()
	{

	

		GameObject[] sphare = GameObject.FindGameObjectsWithTag ("nosphare");
		foreach (GameObject obj in sphare) {
			obj.GetComponent<SphereCollider> ().enabled = true;
		}

		GameObject[] box = GameObject.FindGameObjectsWithTag ("nobox");
		foreach (GameObject obj in box) {
			obj.GetComponent<BoxCollider> ().enabled = true;
		}


		GameObject[] leftright = GameObject.FindGameObjectsWithTag ("noleftright");
		foreach (GameObject obj in leftright) {
			obj.GetComponent<BoxCollider> ().enabled = true;
		}

		GameObject[] mesh = GameObject.FindGameObjectsWithTag ("nomesh");
		foreach (GameObject obj in mesh) {
			obj.GetComponent<MeshCollider> ().enabled = true;
		}

		GameObject[] capsuel = GameObject.FindGameObjectsWithTag ("nocapsuel");
		foreach (GameObject obj in capsuel) {
			obj.GetComponent<CapsuleCollider> ().enabled = true;
		}

	}
}
