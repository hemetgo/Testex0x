using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;
	public Image healthBar;

	private void Start()
	{
		currentHealth = maxHealth;
		healthBar.transform.parent.gameObject.SetActive(false);
	}

	public void TakeDamage(int damage)
	{
		healthBar.transform.parent.gameObject.SetActive(true);
		currentHealth -= damage;

		healthBar.fillAmount = (float)currentHealth / (float)maxHealth;

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	protected virtual void Die()
	{
		Destroy(gameObject);
	}
}
