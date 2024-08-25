using UnityEngine;
using System.Collections;

public class LevlSelRot : MonoBehaviour {



	public float rotSpeed = 70;

	void OnMouseDrag()
	{
		float rotX = Input.GetAxis("Mouse X")*rotSpeed*Mathf.Deg2Rad*Time.deltaTime;


		transform.RotateAround(Vector3.up, -rotX);

	}




}
