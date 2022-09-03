using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5;

	public SpriteRenderer spriteRenderer;
	public Animator animator;
	
	private Rigidbody2D rig;

	private void Start()
	{
		rig = GetComponent<Rigidbody2D>();	
	}

	private void Update()
	{
		Movement();
	}

	private void Movement()
	{
		// Movement
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		rig.velocity = new Vector2(horizontal, vertical).normalized * moveSpeed;

		// Graphics
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (mousePosition.x < transform.position.x) spriteRenderer.flipX = true;
		else if (mousePosition.x > transform.position.x) spriteRenderer.flipX = false;
		 
		animator.SetBool("IsMoving", rig.velocity.magnitude != 0);
	}
}
