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


	void Start(){
		movement = player.GetComponent <Movement> ();
		blindCanvas.enabled = false;
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
		
	}

	//Ice power ups
	public void Freeze()
	{
		movement.frozen = true;
		Invoke ("Unfreeze",2);
	}

	private void Unfreeze(){
		movement.frozen = false;
	}

	//Dessert power ups
	public void NeedleRain()
	{

	}

	//Dessert power ups
	public void Invisible()
	{
		Debug.Log ("invis");
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
	public void Thunder()
	{

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