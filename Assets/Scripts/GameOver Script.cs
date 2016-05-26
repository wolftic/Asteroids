using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	private GameObject player;
	private PlayerHealth playerHealth;
	private float playerLifes = 3;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");

		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void Update(){
		if (player == null) {
			playerLifes -= 1;
			Debug.Log ("ds");
		} else
			Debug.Log ("alive");
	}
}
