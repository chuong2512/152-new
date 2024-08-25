using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pindestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	



	IEnumerator OnTriggerExit(Collider col){

		if (col.gameObject.CompareTag ("Pin")) {
			
			col.gameObject.GetComponent<BoxCollider> ().enabled = false;

			col.gameObject.GetComponent<Rigidbody> ().mass = 10;

			col.gameObject.GetComponent<Rigidbody> ().drag = 2;

			col.gameObject.GetComponent<Rigidbody> ().angularDrag = 2;

			yield return new WaitForSeconds (2.1f);

//			if (col.gameObject.activeInHierarchy) {
//				
//				Destroy (col.gameObject);
//
//			} else if (col.gameObject.activeInHierarchy == false) {
//				
//				yield break;
//
//			}

		}
	}
}
