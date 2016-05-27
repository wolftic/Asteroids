using UnityEngine;
using System.Collections;

public class BossEvents : MonoBehaviour {
	private Boss boss;

	void Start(){

		boss = GetComponent <Boss> ();

	}

	/*
	- boss events
			default
				shoot, spawn minnions, 
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



	}

	//default power ups
	public void SpawnMinnions()
	{

	}

	//Ice power ups
	public void IceShot()
	{

	}

	//Ice power ups
	public void Freeze()
	{

	}

	//Dessert power ups
	public void NeedleRain()
	{

	}

	//Dessert power ups
	public void Invisible()
	{

	}

	//Jungle power ups
	public void Poison()
	{

	}

	//Jungle power ups
	public void Reversed()
	{

	}

	//Dark power ups
	public void Thunder()
	{

	}

	//Dark power ups
	public void Blindness()
	{

	}

	//Ultimate power ups
	public void UltimateRain()
	{

	}
}
