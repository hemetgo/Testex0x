using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
	public Transform bulletSpawnPoint;
    public SpriteRenderer bengal;
    public Bullet bulletPrefab;

	private void Update()
	{
		BengalAim();
		ShootController();
	}

	private void ShootController()
	{
        if (Input.GetButtonDown("Fire1"))
		{
			// Shoot
			Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
			RotateAt(bullet.transform, Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
	}

	private void BengalAim()
	{
		// Rotate at mouse position
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RotateAt(bengal.transform, mousePosition);

		// Flip bengal
		if (mousePosition.x < bengal.transform.position.x) bengal.flipY = true;
		else if (mousePosition.x > bengal.transform.position.x) bengal.flipY = false;
	}

	public void RotateAt(Transform obj, Vector3 target)
	{
		target.z = 0f;

		Vector3 objectPos = obj.position;
		target.x = target.x - objectPos.x;
		target.y = target.y - objectPos.y;

		float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

		obj.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}

}
