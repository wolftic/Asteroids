using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float Health;

	void Start () {
	
	}

	void Update () {
	
	}

	public void doDamage(float damage) {
		Health -= damage;
	}
}
