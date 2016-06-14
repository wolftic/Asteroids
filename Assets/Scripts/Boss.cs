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
	public Bullet specialBullet;
	public GameObject minion;
	public Transform muzzle;
	public Transform muzzle2;
	public Transform muzzle3;
	[SerializeField]
	private SpriteRenderer icon;
		
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
		GameObject.FindGameObjectWithTag ("Camera").GetComponent<CompassScript> ().AddPoint ("Comet", gameObject, Color.white, icon);

		Alive = true;
		statusType = StatusEffect.StatusType.NONE;
		cooldown = Time.time + AbilityCooldown;
	}

	void Update () {
		if (!target)
			return;
		
		if (Vector3.Distance (transform.position, target.position) <= Range) {
			if (!inRange) {
				inRange = true;
				OnInRange.Invoke ();
			}
			transform.LookAt (target, transform.up);
			if (Vector3.Distance (transform.position, target.position) >= Range/3) {
				transform.Translate (Vector3.forward * speed * Time.deltaTime);
			}
		} else {
			if (inRange) {
				inRange = false;
				OnOutOfRange.Invoke ();
			}
		}

		if (Health <= 0) {
			if (Alive) {
				Alive = false;
				OnDeath.Invoke ();
			}
		} else {
			if (!Alive) {
				Alive = true;
				OnSpawn.Invoke ();
			}
		}

		if (inRange && cooldown <= Time.time) {
			cooldown = Time.time + AbilityCooldown;

			int performAttack = Mathf.RoundToInt (Random.Range (0, Attacks.Length));
			Attacks [performAttack].Invoke ();
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Bullet") {
			OnHit.Invoke ();
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