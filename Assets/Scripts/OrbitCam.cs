using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;

public class OrbitCam : MonoBehaviour
{
	public Transform target;
	public float distance = 10.0f;
	public float xSpeed = 250f;
	public float ySpeed = 120f;
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;
	private float x = 0f;
	private float y = 0f;
	public bool flag = true;

	void  Start ()
	{
			
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
			
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody> ())
			GetComponent<Rigidbody> ().freezeRotation = true;
			
	}

	void  Update ()
	{if(target==null){
			target= GameObject.FindWithTag ("Player").gameObject.transform;
		}
			
		if (target) {
//#if UNITY_ANDROID
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved && flag) {
				Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

				foreach (Touch touch in Input.touches) {
					int pointerID = touch.fingerId;
					if (!EventSystem.current.IsPointerOverGameObject (pointerID)) {
						x += touchDeltaPosition.x * xSpeed * 0.02f;
						y -= touchDeltaPosition.y * ySpeed * 0.02f; 

					}					 
				} 
				
			}
//			#elif UNITY_EDITOR
			
//			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
//			y -= Input.GetAxis("Mouse Y") * ySpeed *0.02f; 
//#endif
				
			y = ClampAngle (y, yMinLimit, yMaxLimit);

			Quaternion rotation = Quaternion.Euler (y, x, 0);
			Vector3 position = rotation * new Vector3 (0f, 0f, -distance) + target.position;
			transform.rotation = rotation;
			transform.position = position;

		}
			
	}


	public void SetCameraBoolTrue ()
	{
		flag = true;
	}

	public void SetCameraBoolFalse ()
	{
		flag = false;
	}

	static float ClampAngle (float angle, float min, float max)
	{
			
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
			
	}
		
}