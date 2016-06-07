using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

	//lijst met items aanmaken
	public enum ItemType { SSEngalica, SCStriker, Gun1, AmmoGun1, Gun2, AmmoGun2, SpeedUpgrade, HealthUpgrade, FirePowerUpgrade, EnemyScrap, CometScrap, BrokenGuns, Bolts, 
		Minerals, Glass, RustySteelPlates, Stars};
	//dictionary voor inventory aanmaken
	public Dictionary<ItemType, int> inventory = new Dictionary<ItemType, int>();

	//de variabelen niet in de inspector laten zien
	[HideInInspector]
	//variabelen coins aanmaken
	public int coins = 0;

	//functie start aanmaken
	void Start()
	{
		//niet verwijderen als scene geladen wordt.
		DontDestroyOnLoad (gameObject);
		//functie na een seconde starten (debug command)
		Invoke ("CoinsDebug", 1f);
	}

	//functie voor debuggen aanmaken
	void CoinsDebug()
	{
		//coins toevoegen
		coins += 1;
		//functie herhalen
		Invoke ("CoinsDebug", 0.5f);
	}

	//boolean aanmaken met variabelen amount erin
	public bool DeductCoins(int amount) {
		//als jij meer coins dan amount hebt voer code uit
		if (this.coins >= amount) {
			//haal het amount van jouw coins af
			coins -= amount;
			//boolean op true zetten
			return true;
			//als jij te weinig coins hebt boolean op false zetten
		} else return false;
	}

	public bool DeductItem(ItemType name) {
		if (InInventory (name)) {
			RemoveItem (name);
			return true;
		} else return false;
	}

	//boolean aanmaken met itemType naam erin
	public bool InInventory(ItemType name)
	{
		//als er in de inventory een item met de gegeven naam zit voer dan de code uit
		if(inventory.ContainsKey (name) )
		{
			//als het item meer dan 1 keer in de inventory zit zet boolean op true.
			if (inventory[name] > 0)
				return true;
		}
		return false;
	}

	//functie AddItem aanmaken met ItemType name
	public void AddItem(ItemType name) {
		//private functie starten.
		AddItem (name, 1);
	}

	void AddItem(ItemType name, int quantity) {
		if(inventory.ContainsKey (name) ) {
			inventory [name] += quantity;
		} else {
			inventory.Add (name, quantity);
		}
	}

	public void RemoveItem(ItemType name) {
		RemoveItem (name, 1);
	}

	void RemoveItem(ItemType name, int quantity) {
		if(inventory.ContainsKey (name) ) {
			inventory [name] -= quantity;
			if (inventory[name] <= 0) {
				inventory.Remove (name);
			}
		} else {
			inventory.Remove (name);
		}
	}
}