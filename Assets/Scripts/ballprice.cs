using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballprice : MonoBehaviour {

	public Animator[] price;

	public MenuScript menu;
	// Use this for initialization
	void Start () {

		GlobalGameHandler.ball_open = 0;


		menu = menu.GetComponent<MenuScript> ();
		foreach (Animator obj in price) {
		
			obj.gameObject.transform.GetChild (0).gameObject.SetActive (false);
		}
	}
	


	void OnTriggerEnter(Collider col)
	{
//	print ("ball");

		if (col.gameObject.CompareTag ("Ball")) {
//			print ("ball"+col.gameObject.name);

			int name = System.Convert.ToInt32(col.gameObject.name);

			price [name - 1].SetBool ("text",true);
			price [name - 1].gameObject.transform.GetChild (0).gameObject.SetActive (true);



			GlobalGameHandler.ball_open = name-1;

			if(menu.isball[GlobalGameHandler.ball_open]==1)
				{
				menu.Selectbtn.SetActive (true);
//				print ("name " +name);
				}
			else if(menu.isball[GlobalGameHandler.ball_open]==0)
			{
				menu.Selectbtn.SetActive (false);
//				print ("name " +name+GlobalGameHandler.ball_open);
			}

//			if (name > GlobalGameHandler.ball_number) {
//				menu.Selectbtn.SetActive (false);
//				print ("name " +name);
//			
//			}
//			else if (name <= GlobalGameHandler.ball_number) {
//				menu.Selectbtn.SetActive (true);
//				print ("name " +name);
//			}
//

		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.CompareTag ("Ball")) {

			int name = System.Convert.ToInt32(col.gameObject.name);

			price [name - 1].SetBool ("text",false);
			price [name - 1].gameObject.transform.GetChild (0).gameObject.SetActive (false);

			GlobalGameHandler.ball_open = name-1;
//			price[name].GetComponent<>()


//
//			if (name > GlobalGameHandler.ball_number) {
//				menu.Selectbtn.SetActive (false);
//				print ("name " +name);
//			}
//			else if (name <= GlobalGameHandler.ball_number) {
//				menu.Selectbtn.SetActive (true);
//				print ("name " +name);
//			}

		}
	}





}


//for(int i=0;i<puntaje.Length;i++){
//	PlayerPrefs.SetInt("Puntaje"+i,puntaje[i]);
//}
//for(int i=0;i<puntaje.Length;i++){
//	print(PlayerPrefs.GetInt("Puntaje"+i));
//}