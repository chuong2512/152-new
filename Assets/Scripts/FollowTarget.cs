using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);



		void Start(){
			target=GameObject.FindGameObjectWithTag("Ball").transform;
		}

        private void LateUpdate()
        {
			if (!target) {
				target=GameObject.FindGameObjectWithTag("Ball").transform;

			}
            transform.position = target.position + offset;
        }
    }
}
