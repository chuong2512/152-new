using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pindrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}



	IEnumerator OnTriggerEnter(Collider col){

		if(col.gameObject.transform.CompareTag("Pin")){
			yield return new WaitForSeconds (0.2f);
			col.gameObject.transform.GetComponent<Rigidbody> ().isKinematic = false;
			col.gameObject.transform.SetParent (null);

//			Quaternion target = Quaternion.Euler(0, 90,0 );
//
//			// Dampen towards the target rotation
//			col.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 10f);

//			col.gameObject.transform.rotation = Quaternion.Slerp (0f,90f,0f);
		}

	}
}
