using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour {
	bool isSinking = false;
	float time;

	void Start () {
		time = Time.time;
	}

	float percentage = 0;

	void Update () {
		transform.Translate (Vector3.forward * 10.0f * Time.deltaTime);
		if (!isSinking && time < Time.time) {
			time = Time.time + 5f;
			isSinking = true;
		}
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
			other.GetComponent<PlayerHealth> ().doDamage (25f);
		}
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealth> ().doDamage (25f);
		}
	}

	public void split() {

	}
}
