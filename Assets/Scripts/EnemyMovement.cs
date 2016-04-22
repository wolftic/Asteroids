using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	float xSpeed;
	Vector3 movement;

	public ParticleSystem[] thrusters;
	public Transform target;
	public float maxSpeed;
	public float RANGE;

	public bool inRange;

	void Start () {
		maxSpeed = 30.0f;
		inRange = false;
	}

	Quaternion newRot;
	Quaternion oldRot;

	void Update () {
		if (target) {
			if (Vector3.Distance (transform.position, target.position) < RANGE) {
				inRange = true;
			} else {
				inRange = false;
			}

			if (!inRange) {
				for (int i = 0; i < thrusters.Length; i++) {
					if (!thrusters [i].isPlaying) {
						thrusters [i].Play ();
					}
				}
				xSpeed += .5f;
				xSpeed = Mathf.Clamp (xSpeed, 0f, 10f);
			} else {
				for (int i = 0; i < thrusters.Length; i++) {
					if (thrusters [i].isPlaying) {
						thrusters [i].Stop ();
					}
				}
				xSpeed *= 0.98f;
			}
		
			oldRot = newRot;
			newRot = Quaternion.LookRotation(transform.position - target.position);

			transform.LookAt(target);

			float diff = oldRot.y - newRot.y;
			diff *= 2000;

			diff = Mathf.Clamp (diff, -1, 1);

			transform.Translate (Vector3.forward * Time.deltaTime * xSpeed);

			transform.GetChild (0).localRotation = Quaternion.Lerp (transform.GetChild (0).localRotation, Quaternion.Euler (diff * 30.0f * Vector3.forward), 5.0f * Time.deltaTime);
		}
	}
}