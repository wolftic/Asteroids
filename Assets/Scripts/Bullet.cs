using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
	public float Speed, Damage;

	Rigidbody rigidbody;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		rigidbody.constraints = RigidbodyConstraints.FreezePositionY;

		Destroy (gameObject, 5f);
	}

	void Update () {
		transform.Translate (Vector3.forward * Speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Player") {
			other.transform.GetComponent<PlayerHealth> ().doDamage (Damage);
			Debug.Log ("HIT");
		}

		if (other.transform.tag == "Enemy") {
			other.transform.GetComponent<EnemyHealth> ().doDamage (Damage);
			Debug.Log ("HIT");
		}

		Destroy (gameObject);
	}
}
