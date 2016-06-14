using UnityEngine;
using System.Collections;

public class BossEvents : MonoBehaviour {
	private Boss boss;
	[SerializeField]private Canvas blindCanvas;
	private GameObject ren;
	[SerializeField]
	private GameObject[] visible;
	[SerializeField]
	private Transform player;
	private float bossAlpha = 0.1f;
	private Movement movement;
	private PlayerHealth playerHealth;
	[SerializeField]
	private Bullet thunderBolt;
	[SerializeField]
	private Bullet iceBullet;
	[SerializeField]
	private Bullet needle;
	[SerializeField]
	private Canvas frozenCanvas;
	[SerializeField]
	private Canvas poisonCanvas;



	void Start(){
		movement = player.GetComponent <Movement> ();
		playerHealth = player.GetComponent <PlayerHealth> ();
		blindCanvas.enabled = false;
		frozenCanvas.enabled = false;
		poisonCanvas.enabled = false;
		boss = GetComponent <Boss> ();
	}

	/*
	- boss events
			default
				shoot, spawn minions, 
			Ice boss
				Big Ice Shot, player bevriezen,
			Dessert Boss
				Needle Rain, Invisible,
			Jungle Boss
				Poison, Reversed Controlls,
			dark boss
				thunder, blindness,
			Ultimate Boss
				Ultimate Rain,
	 */

	//default power ups
	public void Shoot()
	{
		GameObject bullet = PoolingScript.current.GetPooledObject (boss.bullet.gameObject, true);
		bullet.transform.rotation = boss.muzzle.rotation;
		bullet.transform.position = boss.muzzle.position;
	}

	//default power ups
	public void SpawnMinions()
	{
		Instantiate (boss.minion, transform.position, Quaternion.identity);
	}

	//Ice power ups
	public void IceShot()
	{
		GameObject obj = PoolingScript.current.GetPooledObject (iceBullet.gameObject);

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = boss.muzzle.rotation;
		obj.SetActive (true);
	}

	//Ice power ups
	public void Freeze()
	{
		movement.frozen = true;
		frozenCanvas.enabled = true;
		Invoke ("Unfreeze",2);
	}

	private void Unfreeze(){
		movement.frozen = false;
		frozenCanvas.enabled = false;
	}

	//Dessert power ups
	[ContextMenu ("NeedleRain")]
	public void NeedleRain()
	{
		for (int i = 0; i < 7; i++) {
			NeedleShot ();
		}

	}

	private void NeedleShot(){

		GameObject obj = PoolingScript.current.GetPooledObject (needle.gameObject);
		Vector3 spawnPosition = boss.muzzle.forward + boss.muzzle.right.normalized * Random.Range (-1, 1);

		if (obj == null)
			return;
		
		obj.transform.position = spawnPosition;
		obj.transform.rotation = boss.muzzle.rotation;
		obj.SetActive (true);

		//Instantiate (boss.specialBullet, spawnPosition, boss.muzzle.rotation);
	}

	//Dessert power ups
	public void Invisible()
	{
		for (int i = 0; i < visible.Length; i++) 
		{
			visible [i].GetComponent <SpriteRenderer> ().enabled = false;
			Invoke ("VisibleBoss", 2);
		}
	}

	private void VisibleBoss()
	{
		for (int i = 0; i < visible.Length; i++) {
			visible [i].GetComponent <SpriteRenderer> ().enabled = true;
		}
	}

	//Jungle power ups
	public void Poison()
	{
		if (playerHealth.poisoned == false) {
			playerHealth.poisoned = true;
		}
	}

	public void PoisonHeal(){
		playerHealth.poisoned = false;
	}

	//Jungle power ups
	public void Reversed()
	{
		movement.reversed = true;
		Invoke ("Unreversed", 3);
		Debug.Log ("reverse");
	}

	private void Unreversed(){
		movement.reversed = false;
	}

	//Dark power ups
	//klein donderschot die 70 damage op de player doet als het raakt.
	public void Thunder()
	{
		Instantiate (thunderBolt, transform.position, transform.rotation);
		thunderBolt.transform.rotation = boss.muzzle.rotation;
		thunderBolt.transform.position = boss.muzzle.position;
	}

	//Dark power ups
	public void Blindness()
	{
		blindCanvas.enabled = false;
		Invoke ("BlindFix", 2);
	}

	//Ultimate power ups
	public void UltimateRain()
	{

	}

	private void BlindFix(){
		blindCanvas.enabled = true;
	}


}