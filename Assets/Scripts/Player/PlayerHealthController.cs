using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : HealthController
{

	protected override void Die()
	{
		base.Die();

		FindObjectOfType<GuiManager>().GameOver();
	}

}
