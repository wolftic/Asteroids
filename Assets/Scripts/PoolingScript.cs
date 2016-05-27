using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolingScript : MonoBehaviour {

	public static PoolingScript current;
	[SerializeField]
	private GameObject[] pooledObject;
	[SerializeField]
	private int pooledAmount = 30;
	[SerializeField]
	private bool willGrow = true;

	List<List<GameObject>> pooledObjects;

	void Awake(){
		current = this;
	}

	void Start(){

		pooledObjects = new List<List<GameObject>> ();
		for (int x = 0; x < pooledObject.Length; x++){
			
			pooledObjects.Add (new List<GameObject>());
			Debug.Log ("Made list of GameObject: " + pooledObject[x]);

			for (int i = 0; i < pooledAmount; i++) {
				GameObject obj = (GameObject)Instantiate (pooledObject[x]);
				obj.SetActive (false);
				pooledObjects[x].Add (obj);
			}
		}
	}

	public GameObject GetPooledObject(GameObject type, bool active = false){
		for (int x = 0; x < pooledObject.Length; x++) {
			if(pooledObject[x] != type) {
				continue;
			}

			for (int i = 0; i < pooledObjects.Count; i++) {
				if (!pooledObjects [x] [i].activeInHierarchy) {
					pooledObjects [x] [i].SetActive (active);
					return pooledObjects [x] [i];
				}
			}

			if(willGrow){
				GameObject obj = (GameObject)Instantiate ((pooledObject[x]));
				pooledObjects [x].Add (obj);
				return obj;
			}
		}

		Debug.Log (type);

		return null;
	}
	public void Destroy(GameObject obj){
		obj.SetActive (false);
	}
}
