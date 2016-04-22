using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public float Health;

	private float regenDelay = 1.0F;
	private float regenTime = 0.0F;

	public void doDamage(float damage) 
	{
		Health -= damage;
	}

	void Update()
	{
		if(Time.time > regenTime)
		{
			Regeneration ();
		}

		if(Health <= 0)
		{
			Destroy (gameObject);

		}
	}

	private void Regeneration()
	{
		Health++;
		regenTime = Time.time + regenDelay;
	}
}
