using UnityEngine;
using System.Collections;

public class PinCollider : MonoBehaviour {

    private bool wasExecuted = false;

 

    public void reset_pin()
    {

        if (!wasExecuted)
        {

//            GameObject respawn_pins = GameObject.Instantiate(gameObject, transform.position = pinspawn.position, transform.rotation = pinspawn.rotation) as GameObject;
            wasExecuted = true;
        }

//        Destroy(gameObject);



    }

 
	IEnumerator OnTriggerEnter(Collider pinCollider){

         //Has pin fallen down? if yes increment score by one
//		if (pinCollider.gameObject.tag == "Rail" ||pinCollider.gameObject.tag == "Plane" ||pinCollider.gameObject.tag == "G"&& pinCollider.gameObject.transform.position.y >= -5)
		if (pinCollider.gameObject.tag == "Rail" ||pinCollider.gameObject.tag == "Plane" ||pinCollider.gameObject.tag == "G")
         {
//			print ("pincollider"+pinCollider);
			yield return new WaitForSeconds (1f);
//			this.gameObject.SetActive (false);
			Destroy(gameObject);
             //Increment scoreupdate by 1 for each pin that falls down only once
             if (!wasExecuted)
             {
				
//                 ScoreText.gameObject.SendMessage("scoreUpdate");
//                 new WaitForSeconds(10);
//				reset_pin ();
//				if (GlobalGameHandler.ChancePerFrame == 2) {
//					GetComponent<PinCollider>().reset_pin();
//					GlobalGameHandler.ChancePerFrame = 0;
//				}


                 wasExecuted = true;
             }


             
         }
         
     
     }

}
