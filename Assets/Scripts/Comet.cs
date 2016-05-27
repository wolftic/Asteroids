using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour {
	float time;
	private CometSpawner cometSpawner;

	void Start () {
		cometSpawner = GameObject.Find ("CometSpawner").GetComponent <CometSpawner> ();
	}

	void OnEnable () {
		time = Time.time + 10;
		GameObject.FindGameObjectWithTag ("Camera").GetComponent<CompassScript> ().AddPoint ("Comet", gameObject, Color.green);
	}

	void Update () {
		transform.Translate (Vector3.forward * 10.0f * Time.deltaTime);
		transform.GetChild (0).LookAt (Camera.main.transform.position);
		if (time < Time.time) {
			split ();
		}
	}	

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.GetComponent<PlayerHealth> ().doDamage (25f);
			split ();
		}
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealth> ().doDamage (25f);
			split ();
		}
	}

	public void split() {
		for (int i = 0; i < 2; i++) {
			Vector3 scale = Vector3.one * (transform.localScale.x - 1);
			if (scale.x != 0) {
				//GameObject go = Instantiate (gameObject, transform.position, Quaternion.Euler(0, transform.rotation.y * Random.Range(-45, 45), 0)) as GameObject;
				//GameObject go = PoolingScript.current.GetPooledObject (cometSpawner.comet.gameObject, true);
				//go.transform.localScale = scale;

				Quaternion rot = transform.rotation;
				rot.y *= Random.Range (-45, 45);
				Debug.Log (cometSpawner);
				cometSpawner.SpawnComet (transform.position, rot, scale);
			}
		}
		PoolingScript.current.Destroy (gameObject);
	}
}
