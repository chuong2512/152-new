
using UnityEngine;
using System.Collections;

public class KeyRotate : MonoBehaviour {

//    public KeyCode leftKey = KeyCode.A;
//    public KeyCode rightKey = KeyCode.D;
    public float rotateSpeed = 2;

	private Rigidbody  rigedboy;
	public bool istilt;

	// Use this for initialization
	void Awake(){
		istilt = false;
//		print ("istilt");
	}
	void Start () {
		

		rigedboy=GetComponent<Rigidbody> ();


	}
	
	// Update is called once per frame
	void Update () {


		
//		if (istilt) {
//
//			Vector3 dir1 =new Vector3( Input.acceleration.normalized.x+0.19f,0,0);
//
//			transform.Translate (dir1 * 2.3f * Time.deltaTime);
//			print ("a"+dir1);
//
//			if (dir1.x >= 0.15) {
//				istilt = false;
//
//			}
//		}


		Vector3 tilt = Input.acceleration;



		if (!GetComponent<Swipe> ().isClick && GlobalGameHandler.istilt) {



			if(GlobalGameHandler.OneVsOne){

				if (transform.position.x >= 26.31 && transform.position.x <= 32.23){


					Vector3 dir =new Vector3( Input.acceleration.normalized.x,0,0);
//					print ("a"+dir);

					//				if (dir.sqrMagnitude > 1) dir.Normalize();
					transform.Translate (dir * 3f * Time.deltaTime);
					if (dir.x >= 0.1) {
						istilt = false;
						//					print ("a"+dir);
					}
					//				transform.Translate (Input.acceleration.x / 8, 0, 0);






				}}





			else if(!GlobalGameHandler.OneVsOne){


				if (transform.position.x >= 33.88 && transform.position.x <= 41.4 && transform.position.y<=2.815f){

				Vector3 dir =new Vector3( Input.acceleration.normalized.x,0,0);
//				print ("b"+dir);

//				if (dir.sqrMagnitude > 1) dir.Normalize();
					transform.Translate (-(dir * 3f * Time.deltaTime));
				if (dir.x >= 0.1) {
					istilt = false;
//					print ("a"+dir);
					}
//				transform.Translate (Input.acceleration.x / 8, 0, 0);
			





				}}
		}

		}

	}

	//void FixedUpdate()
	//{
//		float turn = Input.GetAxis("Horizontal");
//		rigedboy.AddTorque(transform.up * rotateSpeed * turn);
	//}



