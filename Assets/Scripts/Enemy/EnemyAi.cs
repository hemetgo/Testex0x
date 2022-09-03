using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public float moveSpeed;
	public Vector2 shootIntervalRange;
	public Bullet bulletPrefab;

	public SpriteRenderer spriteRenderer;
	public Animator animator;

	private Transform player;
    private NavMeshAgent agent;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;

		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
		agent.speed = moveSpeed;

		StartCoroutine(Shoot());
	}

	private void FixedUpdate()
	{
		Movement();
	}

	private void Movement()
	{
		if (player)
		{
			agent.destination = player.transform.position;
		}
		else
		{
			agent.destination = transform.position;
		}
		
		if (agent.destination.x < transform.position.x) spriteRenderer.flipX = false;
		else if (agent.destination.x > transform.position.x) spriteRenderer.flipX = true;

		if (agent.velocity.magnitude > 0) animator.SetBool("IsMoving", true);
		else animator.SetBool("IsMoving", false);
	}

	private IEnumerator Shoot()
	{
		
		yield return new WaitForSeconds(Random.Range(shootIntervalRange.x, shootIntervalRange.y));
		
		if (player)
		{
			// Shoot
			Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
			bullet.target = Bullet.Target.Player;

			RotateAt(bullet.transform, player.position);
		
			StartCoroutine(Shoot());
		}
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
