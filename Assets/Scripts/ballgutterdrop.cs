using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballgutterdrop : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Ball")) {
			if(this.gameObject.layer==9)
			col.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.left * 300f);
			else if(this.gameObject.gameObject.layer==10)
				col.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.right * 300f);
			print ("Ad forece");
		}

		}
}
