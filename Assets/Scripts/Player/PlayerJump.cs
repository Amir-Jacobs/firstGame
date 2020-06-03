using UnityEngine;


public class PlayerJump : MonoBehaviour {

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private PlayerGrounded playerGrounded;

	private bool isJumping = false;
	private float lastJump;

	public float jumpForce;

	private void Update() {
		isJumping = Input.GetAxisRaw("Vertical") > 0;
	}

	private void FixedUpdate() {
		if (isJumping &&
			playerGrounded.isGrounded &&
			(lastJump + .2f) < Time.time)
			Jump();
	}

	private void Jump() {
		rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

		lastJump = Time.time;
	}
}
