using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Boss : MonoBehaviour {
	[Header("Boss information")]
	public float Health;
	[Range(1, 20)]
	public float Range;
	public float AbilityCooldown;
	public NavMeshAgent agent;

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
	private Animator anim;

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		agent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();

		Alive = true;
		statusType = StatusEffect.StatusType.NONE;
		cooldown = Time.time + AbilityCooldown;
	}

	void Update () {
		if (Vector3.Distance (transform.position, target.position) <= Range) {
			if (!inRange) {
				inRange = true;
				OnInRange.Invoke ();
				agent.SetDestination (transform.position);
				anim.SetBool ("Walking", false);
				Debug.Log ("In range");
			}
		} else {
			if (inRange) {
				inRange = false;
				OnOutOfRange.Invoke ();
				anim.SetBool ("Walking", true);
				Debug.Log ("Out of range");
			}
			agent.SetDestination (target.position);
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
