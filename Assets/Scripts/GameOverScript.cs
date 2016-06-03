using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	private GameObject player;
	private bool playerdying = false;
	private PlayerHealth playerHealth;
	[SerializeField]
	private Text gameOverText;
	[SerializeField]
	private Canvas gameOverCanvas;


	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");

		playerHealth = player.GetComponent <PlayerHealth> ();
		gameOverText.canvasRenderer.SetAlpha (0);
		gameOverCanvas.enabled = false;
	}

	void Update(){
		if (playerHealth.Health <= 0 && !playerdying) {
			player.SetActive (false);
			playerdying = true;
			GameOverFadeIn ();
		}
	}

	private void GameOverFadeIn(){
		gameOverText.CrossFadeAlpha(1f, 3f, false);
		Invoke ("ShowButtons", 3f);
	}

	private void ShowButtons(){
		gameOverCanvas.enabled = true;
	}
}
