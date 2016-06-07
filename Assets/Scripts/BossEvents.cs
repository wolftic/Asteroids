using UnityEngine;
using System.Collections;

public class BossEvents : MonoBehaviour {
	private Boss boss;
	[SerializeField]private Canvas blindCanvas;
	private GameObject ren;
	[SerializeField]
	private GameObject[] visible;
	private float bossAlpha = 0.1f;

	void Start(){
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

	}

	//Dessert power ups
	public void NeedleRain()
	{

	}

	//Dessert power ups
	public void Invisible()
	{
		Debug.Log ("invis");
		for (int i = 0; i < visible.Length; i++) {
			//visible [i].GetComponent <SpriteRenderer> ().enabled = false;
			Color alphaChange = visible[i].GetComponent <SpriteRenderer>().color;
			alphaChange = new Color (alphaChange.r, alphaChange.g, alphaChange.b, 0.1f);
		}
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