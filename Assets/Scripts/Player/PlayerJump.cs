using UnityEngine;

public class PlayerJump : MonoBehaviour {

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float jumpForce;

	private bool isJumping = false;
	private bool doubleJump = false;
	private float lastJump;

	public LayerMask whatIsGround;
	public Transform groundCheck;

	public float groundRadius = 0.1f;
	public bool isGrounded = false;

	private void Update() {
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		isJumping = Input.GetAxisRaw("Vertical") > 0;
	}

	private void FixedUpdate() {
		if (!isGrounded && isJumping && !doubleJump && lastJump + .4f < Time.time) {
			doubleJump = true;
			Jump();
		}

		if (isGrounded && isJumping && lastJump + .2f < Time.time)
			Jump();

		if (isGrounded && doubleJump) doubleJump = false;
	}

	private void Jump() {

		if (doubleJump)
			rb.AddForce(new Vector2(0, jumpForce * 1.2f), ForceMode2D.Impulse);
		else
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

		lastJump = Time.time;
	}
}
