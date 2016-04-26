using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour {
	bool isSinking = false;
	float time;

	void Start () {
		time = Time.time + 10;
	}

	float percentage = 0;

	void Update () {
		transform.Translate (Vector3.forward * 10.0f * Time.deltaTime);
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
				GameObject go = Instantiate (gameObject, transform.position, Quaternion.Euler(0, transform.rotation.y * Random.Range(-45, 45), 0)) as GameObject;
				go.transform.localScale = scale;
			}
		}
		Destroy (gameObject);
	}
}
