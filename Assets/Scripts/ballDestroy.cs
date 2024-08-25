using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	


	IEnumerator 	OnTriggerEnter(Collider col){
	if (col.gameObject.CompareTag ("Plane")) {


			yield return new WaitForSeconds (3f);
			Destroy (this.gameObject);


		}}
}
