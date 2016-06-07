using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
	public float Health;
	[SerializeField]
	private Image healthBar;
	private float regenDelay = 1.0F;
	private float regenTime = 0.0F;

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

		healthBar.fillAmount = Health / 100;

		if (gameObject) {
			if (Health <= 0) {
				Destroy (gameObject);
			}
		}
	}


	private void Regeneration()
	{
		Health++;
		regenTime = Time.time + regenDelay;
	}
}
