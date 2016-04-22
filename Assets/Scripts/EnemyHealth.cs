using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public float Health;

	void Start () {
	
	}

	void Update () {
	
	}

	public void doDamage(float damage) {
		Health -= damage;
	}
}
