using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float maxSpeed = 30.0f;
	float xSpeed;

	Vector3 movement;
	public ParticleSystem[] thrusters;
	public Transform target;

	void Start () {
	}

	Quaternion newRot;

	void Update () {
		if(Input.GetAxisRaw("Vertical") != 0) {
			for (int i = 0; i < thrusters.Length; i++) {
				if (!thrusters [i].isPlaying && Input.GetAxisRaw("Vertical") > 0) {
					thrusters [i].Play ();
				}
			}
			xSpeed += Input.GetAxis ("Vertical");
			xSpeed = Mathf.Clamp (xSpeed, 0f, maxSpeed);
		} else {
			for (int i = 0; i < thrusters.Length; i++) {
				if (thrusters [i].isPlaying) {
					thrusters [i].Stop ();
				}
			}
			xSpeed *= 0.99f;
		}

		float horizontal = Input.GetAxis ("Horizontal");
		newRot = Quaternion.Euler(-horizontal * 30.0f * Vector3.forward);;

		transform.Translate (Vector3.forward * Time.deltaTime * xSpeed);
 		transform.Rotate (horizontal * 1.0f * Vector3.up);
		transform.GetChild (0).localRotation = Quaternion.Lerp (transform.GetChild (0).localRotation, newRot, 5.0f * Time.deltaTime);
	}
}