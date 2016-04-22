using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour {
	bool isSinking = false;

	void Start () {
		Invoke ("Sink", 1.0f);
	}

	float percentage = 0;

	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime);
		if (isSinking) {
			percentage += 0.1f * Time.deltaTime;
			transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, percentage);
			if (percentage > 1) {
				Destroy (gameObject);
			}
		}
	}	

	void Sink () {
		isSinking = true;
	}
}
