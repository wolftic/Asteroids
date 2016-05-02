using UnityEngine;
using System.Collections;

public class BuyScript : MonoBehaviour {

	private PlayerInventory playerInventory;

	void Awake()
	{
		playerInventory = GameObject.FindGameObjectWithTag ("Playerinventory").GetComponent <PlayerInventory>();
	}

	//buy functions

	public void BuySSEngalica()
	{
		if(true)
		{

		}
	}

	public void BuySCStriker()
	{
		if(true)
		{

		}
	}

	public void BuyGun1()
	{
		if(true)
		{

		}
	}

	public void BuyAmmoGun1()
	{
		if(true)
		{

		}
	}

	public void BuyGun2()
	{
		if(true)
		{

		}
	}

	public void BuyAmmoGun2()
	{
		if(true)
		{

		}
	}

	public void BuyUpgradeSpeed()
	{
		if(true)
		{

		}
	}

	public void BuyUpgradeHealth()
	{
		if(true)
		{

		}
	}

	public void BuyUpgradeFirepower()
	{
		if(true)
		{

		}
	}

	//sell functions

	public void SellAmmoGun1()
	{
		if(playerInventory.coins >= 10)
		{
			
		}
	}

	public void SellAmmoGun2()
	{
		if(true)
		{

		}
	}

	public void SellEnemyScrap()
	{
		if(true)
		{

		}
	}

	public void SellCometScrap()
	{
		if(true)
		{

		}
	}

}
