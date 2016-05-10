using UnityEngine;
using System.Collections;
using ItemType = PlayerInventory.ItemType;

public class BuyScript : MonoBehaviour {

	private PlayerInventory playerInventory;

	void Awake()
	{
		playerInventory = GameObject.FindGameObjectWithTag ("Playerinventory").GetComponent <PlayerInventory>();
	}

	//shop functie aanmaken
	public void ShopInteraction(GameObject knop)
	{
		switch (knop.tag) {

		case "Buyknop5":
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

			break;

		case "Buyknop6":
			if (playerInventory.InInventory (ItemType.SCStriker) == false)
			if (playerInventory.DeductCoins (20)) {
				playerInventory.AddItem (ItemType.SCStriker);
			} else
				Debug.Log ("Get More Moneyz");
			else
				Debug.Log ("Already got it");

			break;

		case "Buyknop3":
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

			break;


		case "Buyknop1":
			if (playerInventory.DeductCoins (10)) {
				playerInventory.AddItem (ItemType.AmmoGun1);
				Debug.Log ("bought ammo");
			} else
				Debug.Log ("get more money");

			break;

		case "Buyknop4":
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

			break;

		case "Buyknop2":
			if (playerInventory.DeductCoins (10)) {
				playerInventory.AddItem (ItemType.AmmoGun2);
				Debug.Log ("bought ammo");
			} else
				Debug.Log ("get more money");

			break;

		case "Buyknop7":
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

			break;

		case "Buyknop8":
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

			break;

		case "Buyknop9":
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

			break;

		case "Sellknop1":
			if (playerInventory.DeductItem (ItemType.AmmoGun1)) {
				//geef coins aan speler
				playerInventory.coins += 10;
				//aangeven dat item verkocht is
				Debug.Log ("sold ammo");
			} else
				//aangeven dat speler het item niet heeft
				Debug.Log ("Niks om te verkopen");
				
			break;

		case "Sellknop2":
			if (playerInventory.DeductItem (ItemType.AmmoGun2)) {
				playerInventory.coins += 10;
				Debug.Log ("sold ammo");
			} else
				Debug.Log ("Niks om te verkopen");

			break;

		case "Sellknop3":
			if(playerInventory.DeductItem (ItemType.EnemyScrap))
			{
				playerInventory.coins += 10;
				Debug.Log ("sold enemy scrap");
			}else
				Debug.Log ("Niks om te verkopen");

			break;

		case "Sellknop4":
			if(playerInventory.DeductItem (ItemType.CometScrap))
			{
				playerInventory.coins += 10;
				Debug.Log ("sold Comet scrap");
			}else
				Debug.Log ("Niks om te verkopen");

			break;

		case "Sellknop5":
			if(playerInventory.DeductItem (ItemType.Stars))
			{
				playerInventory.coins += 10;
				Debug.Log ("sold stars");
			}else
				Debug.Log ("Niks om te verkopen");

			break;

		case "Sellknop6":
			if(playerInventory.DeductItem (ItemType.RustySteelPlates))
			{
				playerInventory.coins += 10;
				Debug.Log ("sold Rusty Steel Plates");
			}else
				Debug.Log ("Niks om te verkopen");

			break;

		case "Sellknop7":
			if(playerInventory.DeductItem (ItemType.Glass))
			{
				playerInventory.coins += 10;
				Debug.Log ("sold Glass");
			}else
				Debug.Log ("Niks om te verkopen");

			break;

		case "Sellknop8":
			if(playerInventory.DeductItem (ItemType.Minerals))
			{
				playerInventory.coins += 10;
				Debug.Log ("sold Minerals");
			}else
				Debug.Log ("Niks om te verkopen");

			break;

		case "Sellknop9":
			if(playerInventory.DeductItem (ItemType.BrokenGuns))
			{
				playerInventory.coins += 10;
				Debug.Log ("sold Broken Guns");
			}else
				Debug.Log ("Niks om te verkopen");

			break;

		case "Sellknop10":
			if(playerInventory.DeductItem (ItemType.Bolts))
			{
				playerInventory.coins += 10;
				Debug.Log ("sold Bolts");
			}else
				Debug.Log ("Niks om te verkopen");

			break;
		}
	}
}
