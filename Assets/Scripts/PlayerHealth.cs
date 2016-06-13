﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
	public float Health;
	[SerializeField]
	private Image healthBar;
	private float regenDelay = 1.0F;
	private float regenTime = 0.0F;
	public bool poisoned = false;
	private bool invokingPoison = false;

	public void doDamage(float damage) 
	{
		Health -= damage;
	}

	void Update()
	{
		if(Time.time > regenTime && Health < 100)
		{
			Regeneration ();
		}

		if(poisoned && invokingPoison == false){
			InvokeRepeating ("Poisoning", 1, 1);
			invokingPoison = true;
		}

		healthBar.fillAmount = Health / 100;

		if (gameObject) {
			if (Health <= 0) {
				Destroy (gameObject);
			}
		}
	}

	private void Poisoning(){
		Debug.Log (poisoned);
		if(poisoned == false){
			invokingPoison = false;
			CancelInvoke ();
		}
		Health -= 3;
	}

	private void Regeneration()
	{
		Health++;
		regenTime = Time.time + regenDelay;
	}
}
