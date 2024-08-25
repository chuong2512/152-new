using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour {
//
//
		Vector2 startPos, endPos, direction;
		float touchTimeStart, touchTimeFinish, timeInterval;

//
	public LayerMask layermask;

	[SerializeField]

	float throughForceInXandY =1f;

	[SerializeField]
	float throughForceInZ;

	Rigidbody rib;
	float Distance=5f;
//		[Range (0.05f, 1f)]

//		public float throwForce = 0.3f;

	public bool isClick;

	Vector3 objectPos;



	float Timeer;


//	public GameObject Cam;

	GamePlayeController gpc;



	void Awake(){
	
		gpc = GameObject.FindGameObjectWithTag ("GamePlayController").gameObject.GetComponent<GamePlayeController>();



	}
	void Start(){
		float Timeer = 0;
		GlobalGameHandler.Istime = false;
//		isClick = true;
	
	
		rib = GetComponent<Rigidbody> ();
		rib.isKinematic = true;
		GlobalGameHandler.isemptyPins = false; 


	}


	void OnEnable(){
//		gpc.timetext.text = ("");
		StartCoroutine (makePinStill ());
	}

//	IEnumerator waitforCam(){
//		yield return new WaitForSeconds (0.1f);
//		gpc.Cam1.transform.position = gpc.Cam1StartPos.transform.position;
//		gpc.Cam1.transform.rotation = gpc.Cam1StartPos.transform.rotation;
//
//		print ("cam 1"+gpc.Cam1.transform.position);
//	}

	void OnMouseUp(){
	
//		Cam.GetComponent<SmoothFollow> ().enabled = true;
	}


	void OnMouseDown(){
//		Cam.GetComponent<SmoothFollow> ().enabled = false;
		objectPos.x = gameObject.transform.position.x;
		objectPos.y = gameObject.transform.position.y;
		objectPos.z = gameObject.transform.position.z;

//		print (objectPos.x+"   objectPos  x");
//		print(gameObject.transform.name+ "   Name");
	}
//	void OnMouseDrag()
//	{
//	 
////		if (transform.position.z >= 103.5 && transform.position.z <= 106.5) {
////			rib.isKinematic = false;
//	
//
////		if (objPosition < 2) {
//
////		print (objectPos.x + "   objectPos  x");
////		print (objectPos.y + "   objectPos  y");
//
//
//
//
//
//		//
//
//
//
//		Vector3 mousePosition = new Vector3 ( Input.mousePosition.x,Input.mousePosition.y,Distance);
//
//		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
//
////		if (objPosition.y <= 3f && objPosition.x <=39.45081 && objPosition.x>=36.58072&&objPosition.y >=2.115  &&isClick) 
//			            transform.position = objPosition;
//
////		}
////			print (objectPos.x + "   objectPos  x");
//
//		}


	public float scrollSpeed=5f;
		public float minSwipeDistY;

		public float minSwipeDistX;

//	public Text ShowhimItsSwiping;

//		private Vector2 startPos;


	public void translateBall(){



		transform.Translate (Vector3.forward*Time.deltaTime*50f);
		transform.Rotate(Vector3.right * Time.deltaTime);

		// ...also rotate around the World's Y axis
		transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
	}


		void FixedUpdate()
		{


//		rib.velocity = 50f * (rib.velocity.normalized);

		if (GlobalGameHandler.Istime) {



//			gpc.gutterMaterial.GetTextureOffset (10, 0);
			this.gameObject.transform.Rotate (Vector3.right*Time.deltaTime*700f,Space.World);
//			transform.RotateAround(Vector3.zero, Vector3.right, 20 * Time.deltaTime);

			Timeer = Timeer + Time.deltaTime;
//			gpc.timetext.text =Timeer.ToString ("00");
//			print ("timer");
			if (Timeer>=15) {

				GlobalGameHandler.Istime = false;
//				print ("timer");

				isClick = true;
//				gpc.timetext.text = ("");
				GetComponent<BallCollider> ().reset_ball ();
			}
		}
			//#if UNITY_ANDROID
		if (Input.touchCount > 0) {


				Touch touch = Input.touches [0];



				switch (touch.phase) {

				case TouchPhase.Began:

					startPos = touch.position;

					break;



				case TouchPhase.Ended:

					float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;

					if (swipeDistVertical > minSwipeDistY) {

						float swipeValue = Mathf.Sign (touch.position.y - startPos.y);

						if (swipeValue > 0 && isClick) {//up swipe
						
							this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, 2.19f, this.gameObject.transform.position.z);
					
							if (!GlobalGameHandler.OneVsOne && !GlobalGameHandler.hundradPins)
								gpc.Cam1.GetComponent<SmoothFollow> ().enabled = true;
							else if (GlobalGameHandler.OneVsOne)
								gpc.cam1OneVsOne.GetComponent<SmoothFollow> ().enabled = true;
						
							if (GlobalGameHandler.hundradPins)
								gpc.camera.GetComponent<SmoothFollow> ().enabled = true;
						


							GlobalGameHandler.Istime = true;
							rib.isKinematic = false;
//						translateBall ();
//						transform.Translate (Vector3.back*Time.deltaTime*50f);

//						rib.AddForce (Vector3.forward * 27000*Time.deltaTime);
//						rib.AddForce (Vector3.forward * 300f);
							Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);

							rib.AddForce (Vector3.forward.normalized * 1000 * (0.55f * 2));
							GetComponent<AudioSource> ().Play ();

							GetComponent<KeyRotate> ().istilt = true;
							rib.AddRelativeTorque (5f, 0, 10f);
//						rib.AddForce(movement * 300f * Time.deltaTime);

//						rib.velocity = 50f * (rib.velocity.normalized);

							this.GetComponent<ConstantForce> ().enabled = true;

//						this.gameObject.transform.GetChild (1).gameObject.SetActive (true);

							isClick = false;
							gpc.BallPs.SetActive (true);
							if (GlobalGameHandler.OneVsOne) {

								gpc.cam1OneVsOne.GetComponent<SmoothFollow> ().distance = 4f;
								gpc.cam1OneVsOne.transform.position = gpc.Cam1OneVsOneStartPos2.transform.position;
								gpc.cam1OneVsOne.gameObject.transform.parent = null;

								if (gpc.ballSizeUP) {
									gpc.cam1OneVsOne.transform.position = new Vector3 (gpc.Cam1OneVsOneStartPos2.transform.position.x, gpc.Cam1OneVsOneStartPos2.transform.position.y + 0.424f, gpc.Cam1OneVsOneStartPos2.transform.position.z);

								}
							} else if (!GlobalGameHandler.OneVsOne && !GlobalGameHandler.hundradPins) {
								gpc.Cam1.GetComponent<SmoothFollow> ().distance = 4f;
								gpc.Cam1.transform.position = gpc.cam1startpos2.transform.position;

								gpc.Cam1.gameObject.transform.parent = null;
							} else if (GlobalGameHandler.hundradPins) {
								gpc.camera.GetComponent<SmoothFollow> ().distance = 10f;
//							gpc.Cam1.transform.position = gpc.cam1startpos2.transform.position;

//							gpc.Cam1.gameObject.transform.parent = null;
							}


						if(PlayerPrefs.GetInt("tutorial")==0)
						{
							gpc.tiltAnim.SetActive(true);
							gpc.swipeAnim.SetActive(false);
						}

//						StartCoroutine(handCo());
//						print ("is click "+isClick);

						}
							//Jump ();

						else if (swipeValue < 0) {//down swipe
//						ShowhimItsSwiping.text = "Niche ko swipe ho raha he janab ";
						}
						//Shrink ();

					}

					float swipeDistHorizontal = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;

					if (swipeDistHorizontal > minSwipeDistX) {

						float swipeValue = Mathf.Sign (touch.position.x - startPos.x);

						if (swipeValue > 0.1f) {//right swipe

//						ShowhimItsSwiping.text = "Right ko swipe ho raha he janab ";
//						rib.isKinematic = false;
//						rib.AddForce (Vector3.left * 400);
							//MoveRight ();

//						print("right");
						} else if (swipeValue < 0) {

//						ShowhimItsSwiping.text = "Left ko swipe ho raha he janab ";
//						print("left");
						}//left swipe

				

					}
					break;
				}
			}
		}
		

	IEnumerator makePinStill(){

		GameObject[] pins = GameObject.FindGameObjectsWithTag ("Pin");

		foreach (GameObject obj in pins) {
			obj.GetComponent<Rigidbody> ().isKinematic = true;
			obj.gameObject.transform.rotation = gpc.pinStartPos[0].gameObject.transform.rotation;
		}
		yield return new WaitForSeconds (4f);
		foreach (GameObject obj in pins) {
			obj.GetComponent<Rigidbody> ().isKinematic = false;
		}
	}

}
