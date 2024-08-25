using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pincount : MonoBehaviour {
	GamePlayeController gpc;

	public static	int a,total ,chanc1_total,chance2_tota;
	public int b;


	public static	int aOneVsOne,totalOneVsOne ,chanc1_totalOneVsOne,chance2_totaOneVsOne;
	public int bOneVsOne;

	int temp=0;
	void Awake(){

		gpc = GameObject.FindGameObjectWithTag ("GamePlayController").gameObject.GetComponent<GamePlayeController>();
	}


	void Start () {
		
	
	}
	void OnEnable(){

        b = 0;
		bOneVsOne = 0;
//		total = 0;
//		totalOneVsOne = 0;
//		print ("total ahmed  vc");

		//		print ("P count  "+GlobalGameHandler.pcount);
//		print ("a  "+a);
	}


	IEnumerator OnTriggerEnter(Collider col){
		

		if (col.gameObject.CompareTag ("pcount")&&gpc.ball.GetComponent<Swipe>().isClick==false) {
			
//			print ("one vs on" + GlobalGameHandler.OneVsOne);


			if (!GlobalGameHandler.OneVsOne && !GlobalGameHandler.hundradPins) {
				col.gameObject.GetComponent<BoxCollider> ().enabled = false;
				if (GlobalGameHandler.isgutter) {
					yield break;
				}
				//			GlobalGameHandler.pcount++;
				a++;
				b++;
				//			total++;
				//			yield return new WaitForSeconds (1f);

				if (GlobalGameHandler.twopins) {
					b = b + 1;
				}

				if (GlobalGameHandler.spike) {
//					b = b + 1;

//					print ("b   ");
					//				if (a == 10) {
					if (GlobalGameHandler.ChancePerFrame == 1 && a != 10) {
						yield return new WaitForSeconds (2f);

						//					GlobalGameHandler.spike = false;

//						print ("spike");

					}

				}

				GlobalGameHandler.pcount = GlobalGameHandler.pcount + b;
				total = total + b;
				chanc1_total = chanc1_total + b;
				chance2_tota = chance2_tota + b;


				b = 0;
				if (GlobalGameHandler.BallFrames == 0) {
					//				gpc.p_text1[GlobalGameHandler.ChancePerFrame].text = a;	
				} else if (GlobalGameHandler.ChancePerFrame == 1) {
					//				gpc.p_text1[GlobalGameHandler.ChancePerFrame].text = a;	
				}


				//			gpc.PinCountText.text = GlobalGameHandler.pcount.ToString();


				//			print ("P count  "+GlobalGameHandler.pcount);

				//			print ("a   "+b);
				//			print ("a   "+a);
//				print ("a +check frame" + GlobalGameHandler.ChancePerFrame + "   a " + a);

//				if (GlobalGameHandler.BallFrames == 3 && (GlobalGameHandler.ChancePerFrame == 2||GlobalGameHandler.ChancePerFrame == 3)) {
//					
//					temp = temp+chanc1_total;
//					print ("temp "+temp+"  islast spike"+GlobalGameHandler.isLastSpike);
//					if (!GlobalGameHandler.isLastSpike &&  temp!=10) {
//						print ("temp  "+temp);
//						GlobalGameHandler.isFrameUpDateInstently = true;
//
//					} else if (temp == 10) {
//						gpc.p_text4 [GlobalGameHandler.ChancePerFrame - 1].text = "/".ToString ();
//						GlobalGameHandler.chance1 = 0;
//						GlobalGameHandler.chance2 = 0;
//						GlobalGameHandler.slash = true;
//						GlobalGameHandler.slesh_leaderB++;
//
//					}
//
//
////						print ("a"+temp);
//
//
//				}
//				if (GlobalGameHandler.BallFrames == 3 &&( GlobalGameHandler.ChancePerFrame == 1||GlobalGameHandler.ChancePerFrame == 0)) {
//					temp = chanc1_total;
//
////					print ("a"+temp);
////					print ("chance 1"+chanc1_total);
////					print ("chance 2"+chance2_tota);
//
//				}


				if (GlobalGameHandler.BallFrames == 3 && GlobalGameHandler.ChancePerFrame == 2&&a >= 10 && !GlobalGameHandler.spike) {
					print ("last spike  "+GlobalGameHandler.isLastSpike+"  spike  "+GlobalGameHandler.spike); 
					if (GlobalGameHandler.isLastSpike && GlobalGameHandler.spike) {
						print ("ddd");
						GlobalGameHandler.isFrameUpDateInstently = true;
						print ("ddd" + GlobalGameHandler.isFrameUpDateInstently + "hfh " + GlobalGameHandler.isFrameUpDateInstently);
					}
				}


				if ((GlobalGameHandler.ChancePerFrame == 0 || GlobalGameHandler.ChancePerFrame == 1) && a >= 10 && !GlobalGameHandler.spike) {

					GlobalGameHandler.spike = true;

					GlobalGameHandler.isLastSpike = false;
					GlobalGameHandler.spike_leaderB++;
				}
				else if ((GlobalGameHandler.ChancePerFrame == 0 || GlobalGameHandler.ChancePerFrame == 1) && a < 10 && GlobalGameHandler.spike)
				{
					GlobalGameHandler.isLastSpike = true;


					GlobalGameHandler.spike = false;
				
//					print ("last spkie"+GlobalGameHandler.isLastSpike);
//					print ("spkie"+GlobalGameHandler.spike);
					}




//				print ("total  " + total);
				//			gpc.p_total [GlobalGameHandler.BallFrames].text = total.ToString();
				b = 0;
				yield return new WaitForSeconds (1f);
				if (col.gameObject.activeInHierarchy) {
					Destroy (col.gameObject.transform.parent.gameObject);
//					col.gameObject.transform.parent.gameObject.SetActive(false);
				} else if (col.gameObject.activeInHierarchy == false) {
					yield break;
				}
			} else if (GlobalGameHandler.OneVsOne) {
//				print ("in one vs one");
				col.gameObject.GetComponent<BoxCollider> ().enabled = false;
				if (GlobalGameHandler.isgutterOneVsOne) {
					yield break;
//					print ("Gutter");
				}
				//			GlobalGameHandler.pcount++;
				aOneVsOne++;
				bOneVsOne++;
				//			total++;
				//			yield return new WaitForSeconds (1f);
				if (GlobalGameHandler.spikeOneVsOne) {
//					bOneVsOne = bOneVsOne + 1;

//					print ("b   ");
					//				if (a == 10) {
					if (GlobalGameHandler.ChancePerFrameOneVsOne == 1 && aOneVsOne != 10) {
						yield return new WaitForSeconds (2f);

						//					GlobalGameHandler.spike = false;

//						print ("spike");

					}

				}
//				print ("spike" + bOneVsOne);
				GlobalGameHandler.pcountOneVsOne = GlobalGameHandler.pcountOneVsOne + bOneVsOne;
				totalOneVsOne = totalOneVsOne + bOneVsOne;
				chanc1_totalOneVsOne = chanc1_totalOneVsOne + bOneVsOne;
				chance2_totaOneVsOne = chance2_totaOneVsOne + bOneVsOne;


				bOneVsOne = 0;
				if (GlobalGameHandler.BallFramesOneVsOne == 0) {
					//				gpc.p_text1[GlobalGameHandler.ChancePerFrame].text = a;	
				} else if (GlobalGameHandler.ChancePerFrameOneVsOne == 1) {
					//				gpc.p_text1[GlobalGameHandler.ChancePerFrame].text = a;	
				}


				//			gpc.PinCountText.text = GlobalGameHandler.pcount.ToString();


				//			print ("P count  "+GlobalGameHandler.pcount);

				//			print ("a   "+b);
				//			print ("a   "+a);
//				print ("a +check frame" + GlobalGameHandler.ChancePerFrameOneVsOne + "   a " + aOneVsOne);

				if (GlobalGameHandler.BallFramesOneVsOne == 3 && GlobalGameHandler.ChancePerFrameOneVsOne == 2&&aOneVsOne >= 10 && !GlobalGameHandler.spikeOneVsOne) {
					print ("last spike  "+GlobalGameHandler.isLastSpike+"  spike  "+GlobalGameHandler.spike); 
					if (GlobalGameHandler.isLastSpikeOvO && GlobalGameHandler.spikeOneVsOne) {
						print ("ddd");
						GlobalGameHandler.isFrameUpDateInstentlyOvO = true;
						print ("ddd" + GlobalGameHandler.isFrameUpDateInstently + "hfh " + GlobalGameHandler.isFrameUpDateInstently);
					}
				}

				if ((GlobalGameHandler.ChancePerFrameOneVsOne == 0 || GlobalGameHandler.ChancePerFrameOneVsOne == 1) && aOneVsOne >= 10 && !GlobalGameHandler.spikeOneVsOne) {

					GlobalGameHandler.spikeOneVsOne = true;
					GlobalGameHandler.isLastSpikeOvO = false;


//					print ("spike in");

				}
				else if ((GlobalGameHandler.ChancePerFrameOneVsOne == 0 || GlobalGameHandler.ChancePerFrameOneVsOne == 1) && aOneVsOne < 10 && GlobalGameHandler.spikeOneVsOne) {

					GlobalGameHandler.spikeOneVsOne = false;
					GlobalGameHandler.isLastSpikeOvO = true;



//					print ("spike in");

				}
//				print ("total  " + totalOneVsOne);
				//			gpc.p_total [GlobalGameHandler.BallFrames].text = total.ToString();
				b = 0;
				yield return new WaitForSeconds (1f);
				if (col.gameObject.activeInHierarchy) {
					
					Destroy (col.gameObject.transform.parent.gameObject);
//					col.gameObject.transform.parent.gameObject.SetActive(false);
				} else if (col.gameObject.activeInHierarchy == false) {
					yield break;
				}
			} else if (GlobalGameHandler.hundradPins) {
			
				col.gameObject.GetComponent<BoxCollider> ().enabled = false;
				GlobalGameHandler.h_Pins++;

				gpc.hundradPindText.text = GlobalGameHandler.h_Pins.ToString();
			}

		}


	


	}

	void OnTriggerExit(Collider col){

		if (col.gameObject.CompareTag ("pcount")&&gpc.ball.GetComponent<Swipe>().isClick==true){
//			col.gameObject.transform.parent.gameObject.SetActive(false);
			Destroy (col.gameObject.transform.parent.gameObject);
		}
		if(col.gameObject.CompareTag("Pin")&&gpc.ball.GetComponent<Swipe>().isClick==true) {
//			col.gameObject.SetActive(false);
				Destroy (col.gameObject);
				}

	}
}


