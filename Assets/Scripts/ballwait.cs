using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballwait : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	


	IEnumerator OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag("Ball")) {

			col.gameObject.GetComponent<Rigidbody> ().mass = 20f;
			col.gameObject.GetComponent<Rigidbody> ().drag = 2f;
			col.gameObject.GetComponent<Rigidbody> ().angularDrag = 2f;
			yield return new WaitForSeconds (1f);
			col.gameObject.transform.GetComponent<SphereCollider> ().enabled = false;
//			col.gameObject.GetComponent<SphereCollider> ().enabled = false;
		}
	}
}
