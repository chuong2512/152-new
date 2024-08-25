using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinPick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

	IEnumerator OnTriggerEnter(Collider col){

		if(col.gameObject.transform.CompareTag("Pin")&&GlobalGameHandler.ispin ){
			yield return new WaitForSeconds (0.2f);
			col.gameObject.transform.GetComponent<Rigidbody> ().isKinematic = true;
			col.gameObject.transform.SetParent (this.gameObject.transform);

			GlobalGameHandler.ispin = false;
//			Quaternion target = Quaternion.Euler(0, 90,0 );
//
//			// Dampen towards the target rotation
//			col.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 10f);
		}

	}

}
