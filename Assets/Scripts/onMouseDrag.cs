using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseDrag : MonoBehaviour {

	Vector3 dist;
	Vector3 startPos;
    public float posX;
	public float posZ;
	public 	float posY;
	public GamePlayeController gpc;
	float TouchKiLastPosition;

	void Awake(){
		
		gpc = GameObject.FindGameObjectWithTag ("GamePlayController").gameObject.GetComponent<GamePlayeController> ();
	}
	void OnMouseDown()
	{
		TouchKiLastPosition = Input.mousePosition.x;
		if (GetComponent<Swipe> ().isClick) {
			startPos = transform.position;
			dist = Camera.main.WorldToScreenPoint (transform.position);
			posX = Input.mousePosition.x - dist.x;
			posY = Input.mousePosition.y - dist.y;
			posZ = Input.mousePosition.z - dist.z;
		}
	}

	void OnMouseUp()
	{
		TouchKiLastPosition = Input.mousePosition.x;

		GetComponent<Rigidbody>().isKinematic = false;
	}

	void OnMouseDrag()
	{
		TouchKiLastPosition = Input.mousePosition.x;

		if (GetComponent<Swipe> ().isClick) {
			
			if (!GlobalGameHandler.OneVsOne) {



				float disX = Input.mousePosition.x - posX;
				float disY = Input.mousePosition.y - posY;
				float disZ = Input.mousePosition.z - posZ;
				Vector3 lastPos = Camera.main.ScreenToWorldPoint (new Vector3 (disX, disY, disZ));

//			print ("lastps x  " + lastPos.x + "  lastps z" + lastPos.z);
//				if (lastPos.x < 37.97726f) {
//					
//					transform.Rotate (Vector3.forward * 200 * Time.deltaTime);
//
//				} else if (lastPos.x > 37.97726f) {
//					transform.Rotate (Vector3.back * 200 * Time.deltaTime);
//
//				}
//				if (lastPos.x <= 39.92796f && lastPos.x >= 36.14826f && GetComponent<Swipe> ().isClick) {

      if (lastPos.x <= 39.92796f && lastPos.x >= 36.14826f && lastPos.z >= 79.16802 && lastPos.z <= 80.10508 && GetComponent<Swipe> ().isClick)
				{

			

					transform.position = new Vector3 (lastPos.x, startPos.y, lastPos.z);
//					if (lastPos.x <= 39.92796f && lastPos.x >= 36.14826f)
//						gpc.Cam1.transform.position = new Vector3 (lastPos.x, 3.42f, 77.22002f);

//				gpc.Cam1.transform.position= new Vector3 (lastPos.x, gpc.Cam1.transform.position.y, gpc.Cam1.transform.position.z);
//				gpc.Cam1.transform.parent= this.gameObject.transform;


				}
			}

		else if (GlobalGameHandler.OneVsOne) {

				float disX = Input.mousePosition.x - posX;
				float disY = Input.mousePosition.y - posY;
				float disZ = Input.mousePosition.z - posZ;
				Vector3 lastPos = Camera.main.ScreenToWorldPoint (new Vector3 (disX, disY, disZ));

//				print ("lastps z  " + lastPos.z + "  lastps x" + lastPos.x);

//				if (lastPos.x < 29.24248f) {
//
//					transform.Rotate (Vector3.forward * 200 * Time.deltaTime);
//
//				} else if (lastPos.x > 29.24248f) {
//					transform.Rotate (Vector3.back * 200 * Time.deltaTime);
//
//				}


//				if (lastPos.x <= 31.13228f && lastPos.x >= 27.2113f && GetComponent<Swipe> ().isClick) {


			if (lastPos.x <= 31.13228f && lastPos.x >= 27.2113f && lastPos.z >= 78.91786 && lastPos.z <= 80.10508 && GetComponent<Swipe> ().isClick) {

//			print ("lastps z  " + lastPos.z + "  lastps x" + lastPos.x);
				transform.position = new Vector3 (lastPos.x, startPos.y, lastPos.z);

//					transform.position = new Vector3 (lastPos.x, startPos.y, transform.position.z);


//				if (lastPos.x <= 31.13228f && lastPos.x >= 27.2113f)
//					gpc.cam1OneVsOne.transform.position = new Vector3 (lastPos.x, 3.42f, 77.22002f);

//				gpc.cam1OneVsOne.transform.parent= this.gameObject.transform;

//				}
//			}
		}

	}
	}
	}

//	void Update()
//	{
//		
//
//
//
//		if (TouchKiLastPosition < Input.mousePosition.x) {
//			print ("Right Ko Ghomo");
//		}
//		if (TouchKiLastPosition > Input.mousePosition.x) {
//			print ("Left Ko Ghomo");
//		}		
//	}
}