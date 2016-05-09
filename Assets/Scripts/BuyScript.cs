using UnityEngine;
using System.Collections;
using ItemType = PlayerInventory.ItemType;

public class BuyScript : MonoBehaviour {

	private PlayerInventory playerInventory;

	void Awake()
	{
		playerInventory = GameObject.FindGameObjectWithTag ("Playerinventory").GetComponent <PlayerInventory>();
	}

	//buy functions

	//koop functie aanmaken
	public void BuySSEngalica()
	{
		//als item niet in inventory zit kan jij code uitvoeren
		if(playerInventory.InInventory (ItemType.SSEngalica) == false)
		{
			//als jij zoveel coins heeft kan jij code uitvoeren
			if(playerInventory.DeductCoins (20))
			{
				//Item in inventory toevoegen
				playerInventory.AddItem (ItemType.SSEngalica);
				//aangeven dat speler item gekocht heeft.
				Debug.Log ("Bought SSEngalica");
			}
			//als speler te weinig geld heeft
			else
			{
				//aangeven dat speler te weinig geld heeft.
				Debug.Log ("Get More moneyz");
			}
		}
		//als je item al hebt.
		else
			//aangeven dat speler het item al heeft.
			Debug.Log ("Already got it!");
	}

	public void BuySCStriker()
	{
		if (playerInventory.InInventory (ItemType.SCStriker) == false)
			if (playerInventory.DeductCoins (20)) {
				playerInventory.AddItem (ItemType.SCStriker);
			} else
				Debug.Log ("Get More Moneyz");
			else
				Debug.Log ("Already got it");
	}

	public void BuyGun1()
	{
		if(playerInventory.InInventory (ItemType.Gun1) == false)
		{
			if(playerInventory.DeductCoins (20))
			{
				playerInventory.AddItem (ItemType.Gun1);
				Debug.Log ("Bought Gun1");
			}
			else
			{
				Debug.Log ("Get More moneyz");
			}
		}
		else
			Debug.Log ("Already got it!");
	}

	public void BuyAmmoGun1()
	{
		if (playerInventory.DeductCoins (10)) {
			playerInventory.AddItem (ItemType.AmmoGun1);
			Debug.Log ("bought ammo");
		} else
			Debug.Log ("get more money");
	}

	public void BuyGun2()
	{
		if(playerInventory.InInventory (ItemType.Gun2) == false)
		{
			if(playerInventory.DeductCoins (20))
			{
				playerInventory.AddItem (ItemType.Gun2);
				Debug.Log ("Bought Gun2");
			}
			else
			{
				Debug.Log ("Get More moneyz");
			}
		}
		else
			Debug.Log ("Already got it!");
	}

	public void BuyAmmoGun2()
	{
		if (playerInventory.DeductCoins (10)) {
			playerInventory.AddItem (ItemType.AmmoGun2);
			Debug.Log ("bought ammo");
		} else
			Debug.Log ("get more money");
		}

	//koop upgrade functie aanmaken
	public void BuyUpgradeSpeed()
	{
		//als speler nog geen upgrade heeft gekocht voer code uit
		if(playerInventory.InInventory (ItemType.SpeedUpgrade) == false)
		{
			//test of de speler genoeg coins heb en haal het geld weg, voer daarna code uit
			if(playerInventory.DeductCoins (20))
			{
				//add upgrade aan inventory
				playerInventory.AddItem (ItemType.SpeedUpgrade);
				//aangeven dat de speler upgrade gekocht heeft
				Debug.Log ("Bought speed upgrade");
			}
			//als speler te weinig geld heeft voer code uit
			else
			{
				//aangeven dat speler te weinig geld heeft
				Debug.Log ("Get More moneyz");
			}
		}
		//als speler upgrade al heeft
		else
			//aangeven dat speler upgrade al heeft
			Debug.Log ("Already got it!");
	}

	public void BuyUpgradeHealth()
	{
		if(playerInventory.InInventory (ItemType.HealthUpgrade) == false)
		{
			if(playerInventory.DeductCoins (20))
			{
				playerInventory.AddItem (ItemType.HealthUpgrade);
				Debug.Log ("Bought health upgrade");
			}
			else
			{
				Debug.Log ("Get More moneyz");
			}
		}
		else
			Debug.Log ("Already got it!");
	}

	public void BuyUpgradeFirepower()
	{
		if(playerInventory.InInventory (ItemType.FirePowerUpgrade) == false)
		{
			if(playerInventory.DeductCoins (20))
			{
				playerInventory.AddItem (ItemType.FirePowerUpgrade);
				Debug.Log ("Bought firepower upgrade");
			}
			else
			{
				Debug.Log ("Get More moneyz");
			}
		}
		else
			Debug.Log ("Already got it!");
	}

	//sell functions

	//verkoop functie aanmaken
	public void SellAmmoGun1()
	{
		//test of item in inventory zit en haal item weg, voer daarna de code uit
		if (playerInventory.DeductItem (ItemType.AmmoGun1)) {
			//geef coins aan speler
			playerInventory.coins += 10;
			//aangeven dat item verkocht is
			Debug.Log ("sold ammo");
		} else
			//aangeven dat speler het item niet heeft
			Debug.Log ("Niks om te verkopen");
	}

	public void SellAmmoGun2()
	{
		if(playerInventory.DeductItem (ItemType.AmmoGun2))
		{
			playerInventory.coins += 10;
			Debug.Log ("sold ammo");
		}
	}

	public void SellEnemyScrap()
	{
		if(playerInventory.DeductItem (ItemType.EnemyScrap))
		{
			playerInventory.coins += 10;
			Debug.Log ("sold enemy scrap");
		}
	}

	public void SellCometScrap()
	{
		if(playerInventory.DeductItem (ItemType.CometScrap))
		{
			playerInventory.coins += 10;
			Debug.Log ("sold Comet scrap");
		}
	}

	public void SellStars()
	{
		if(playerInventory.DeductItem (ItemType.Stars))
		{
			playerInventory.coins += 10;
			Debug.Log ("sold stars");
		}
	}

	public void SellRustyPlates()
	{
		if(playerInventory.DeductItem (ItemType.RustySteelPlates))
		{
			playerInventory.coins += 10;
			Debug.Log ("sold Rusty Steel Plates");
		}
	}

	public void SellGlass()
	{
		if(playerInventory.DeductItem (ItemType.Glass))
		{
			playerInventory.coins += 10;
			Debug.Log ("sold Glass");
		}
	}

	public void SellMinerals()
	{
		if(playerInventory.DeductItem (ItemType.Minerals))
		{
			playerInventory.coins += 10;
			Debug.Log ("sold Minerals");
		}
	}

	public void SellBrokenGuns()
	{
		if(playerInventory.DeductItem (ItemType.BrokenGuns))
		{
			playerInventory.coins += 10;
			Debug.Log ("sold Broken Guns");
		}
	}

	public void SellBolts()
	{
		if(playerInventory.DeductItem (ItemType.Bolts))
		{
			playerInventory.coins += 10;
			Debug.Log ("sold Bolts");
		}
	}
}
