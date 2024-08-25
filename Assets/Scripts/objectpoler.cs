using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectpoler : MonoBehaviour {
	[System.Serializable]

	public class pool
	{
		public string tag;
		public GameObject prefab;

	    public int size;

	}

	#region Singleton

	public static objectpoler Instacnce;

	private void Awake()
	{
		Instacnce = this;
	}

	#endregion

	public List <pool> pools;


	public Dictionary <string ,Queue <GameObject >> poolDictionary;

	void Start()
	{
		
		poolDictionary = new Dictionary<string, Queue<GameObject>> ();

	
		foreach (pool pool in pools) {
		
			Queue <GameObject> objectPool = new Queue<GameObject> ();
			if (GlobalGameHandler.OneVsOne) {
				pool.size = 120;
			}
			else if(!GlobalGameHandler.OneVsOne)
			{
				pool.size=60;
			}
			for (int i = 0; i < pool.size; i++) {
			
				GameObject obj=Instantiate (pool.prefab);

				obj.SetActive (false);
				objectPool.Enqueue (obj);


			}

			poolDictionary.Add (pool.tag, objectPool);
//			print (pool.tag);
			print ("sgrdsfs"+poolDictionary [pool.tag]);
		}


	}


	public GameObject SpawmFromPool(string tag,Vector3 position ,Quaternion rotation)
	{
		
//		if (!poolDictionary.ContainsKey (tag)) {
//		
//			Debug.LogError ("pool with tag  " + tag + "   doesn`t exist");
//		
//			return null;
//		}


		GameObject objectSpawm = poolDictionary [tag].Dequeue ();

		objectSpawm.SetActive (true);
		objectSpawm.transform.position = position;
		objectSpawm.transform.rotation = rotation;

		poolDictionary [tag].Enqueue (objectSpawm);

		return objectSpawm;


	}


//	public GameObject SpwamFromQuee(string tag, Vector3 position, Quaternion rotation)
//	{
//		print ("ssss");
////		print (poolDictionary.ContainsKey() );
//
//		if (!poolDictionary.ContainsKey (tag)) 
//		{
//		
//			Debug.LogWarning ("Pool  with tag  " + tag + "  doesn`t excist");
//		
//			return null;
//		}
//
//		GameObject objecttoSpawm = poolDictionary [tag].Dequeue ();
//
//		objecttoSpawm.SetActive (true);
//		objecttoSpawm.transform.position = position;
//		objecttoSpawm.transform.rotation = rotation;
//
//
//		poolDictionary [tag].Enqueue (objecttoSpawm);
//
//		return objecttoSpawm;
//	}


}
