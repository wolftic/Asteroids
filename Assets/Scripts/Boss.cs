using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Boss : MonoBehaviour {
	[Header("Boss information")]
	public float Health;
	[Range(1, 50)]
	public float Range;
	public float AbilityCooldown;
	public float speed;
	public Bullet bullet;
	public GameObject minion;
	public Transform muzzle;

	[Header("Attacks")]
	public UnityEvent[] Attacks = new UnityEvent[1];

	[Header("Events")]
	public UnityEvent OnInRange;
	public UnityEvent OnOutOfRange;
	public UnityEvent OnHit;
	public UnityEvent OnSpawn;
	public UnityEvent OnDeath;

	private bool inRange = true;
	private bool Alive;
	private Transform target;
	private StatusEffect.StatusType statusType;
	private float cooldown;

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;

		Alive = true;
		statusType = StatusEffect.StatusType.NONE;
		cooldown = Time.time + AbilityCooldown;
	}

	void Update () {
		if (Vector3.Distance (transform.position, target.position) <= Range) {
			if (!inRange) {
				inRange = true;
				OnInRange.Invoke ();
				Debug.Log ("In range");
			}
			transform.LookAt (target, transform.up);
			transform.Translate (Vector3.forward*speed*Time.deltaTime);
		} else {
			if (inRange) {
				inRange = false;
				OnOutOfRange.Invoke ();
				Debug.Log ("Out of range");
			}
		}

		if (Health <= 0) {
			if (Alive) {
				Alive = false;
				OnDeath.Invoke ();
				Debug.Log ("On death");
			}
		} else {
			if (!Alive) {
				Alive = true;
				OnSpawn.Invoke ();
				Debug.Log ("On spawn");
			}
		}

		if (inRange && cooldown <= Time.time) {
			cooldown = Time.time + AbilityCooldown;

			Debug.Log ("Performed attack");

			int performAttack = Mathf.RoundToInt (Random.Range (0, Attacks.Length));
			Attacks [performAttack].Invoke ();
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Bullet") {
			OnHit.Invoke ();
			Debug.Log ("On hit");
		}

		if (other.tag == "StatusEffect") {
			StatusEffect effect = other.GetComponent<StatusEffect> ();
			statusType = effect.statusType;
			Invoke ("ResetStatusEffect", effect.Duration);
		}
	}
	
	void ResetStatusEffect() {
		statusType = StatusEffect.StatusType.NONE;
	}
}
