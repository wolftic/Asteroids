using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public Bullet projectile;
	public Transform muzzle;
	public float shootDelay;
	public float bulletSpeed;
	public float fireRate = 0.4F;
	public AudioClip shotSound1;
	public AudioClip shotSound2;

	private float nextFire = 0.0F;
	private float bullets = 20;
	private float reloadTime = 1.8F;
	private EnemyMovement enemyMovement;

	void Awake()
	{
		enemyMovement = GetComponent <EnemyMovement>();
	}

	void Update()
	{
		if(bullets > 0 && Time.time > nextFire && enemyMovement.inRange && enemyMovement.target )
		{
			Shoot();
		}
		else if(bullets <= 0)
		{
			Reload();
		}
	}

	private void Shoot ()
	{
		Bullet bullet = Instantiate (projectile, muzzle.position, muzzle.rotation) as Bullet;
		bullet.shooter = transform;
		bullets -= 1;
		nextFire = Time.time + fireRate;
	}

	private void Reload()
	{
		bullets = 20;
		nextFire = Time.time + reloadTime;
	}

}
