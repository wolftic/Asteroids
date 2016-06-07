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
		Vector3 scale = Vector3.one * (transform.localScale.x - 1);
		if (scale.x != 0) {
			for (int i = 0; i < 2; i++) {
				Quaternion rot = transform.rotation;
				rot.y *= Random.Range(-45, 45);
				cometSpawner.SpawnComet(transform.position, rot, scale);
			}
		}
		PoolingScript.current.Destroy (gameObject);
	}
}

