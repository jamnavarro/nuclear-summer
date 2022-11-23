using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private float horizontal;
	private bool isFacingRight = true;

	public float speed = 2f;
	public float jumpingPower = 8f;
	public Animator animator;

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;

	// Update is called once per frame
	void Update() {
		horizontal = Input.GetAxisRaw("Horizontal");

		if (Input.GetButtonDown("Jump") && isGrounded()) {
			rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
		}

		if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) {
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}

		Flip();
	}
	
	void FixedUpdate() {
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
		animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
	}

	private void Flip() {
		if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) {
			isFacingRight = !isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;
		}
	}

	bool isGrounded() {
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}
}
