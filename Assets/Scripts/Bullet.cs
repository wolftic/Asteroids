using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
	public float Speed, Damage;
	public Transform shooter;

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
		if (other.transform == shooter)
			return;
		
		if (other.transform.tag == "Player") {
			other.transform.GetComponent<PlayerHealth> ().doDamage (Damage);
			Debug.Log ("HIT");
			Destroy (gameObject);
		}

		if (other.transform.tag == "Enemy") {
			other.transform.GetComponent<EnemyHealth> ().doDamage (Damage);
			Debug.Log ("HIT");
			Destroy (gameObject);
		}
		if(other.transform.tag == "Comet")
		{
			Destroy (gameObject);
			other.gameObject.GetComponent <Comet> ().split();
		}
	}
}
