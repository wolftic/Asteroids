using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour {
	bool isSinking = false;

	void Start () {
		Invoke ("Sink", 10.0f);
	}

	float percentage = 0;

	void Update () {
		transform.Translate (Vector3.forward * 10.0f * Time.deltaTime);
		if (isSinking) {
			percentage += 0.1f * Time.deltaTime;
			transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, percentage);
			if (transform.localScale == Vector3.zero) {
				Destroy (gameObject);
			}
		}
	}	

	void Sink () {
		isSinking = true;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.GetComponent<PlayerHealth> ().doDamage (10f);
		}
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealth> ().doDamage (10f);
		}
	}
}
