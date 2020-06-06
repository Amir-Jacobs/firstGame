using UnityEngine;


public class PlayerJump : MonoBehaviour {

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private PlayerGrounded playerGrounded;

	private bool isJumping = false;
	private float lastJump;

	public float jumpForce;

	private float lastPress;

	private void Update() {
		isJumping = Input.GetAxisRaw("Vertical") > 0;

		if (isJumping)
			lastPress = Time.time;
	}

	private void FixedUpdate() {
		Jump();
	}

	private void Jump() {
		if (!playerGrounded.isGrounded) return;

		else if ((lastJump + .2f) > Time.time) return;

		// player jumping too fast or player hasn't jumped in a while
		else if (isJumping && (lastJump + .2f) > Time.time || (lastPress + .2f) < Time.time) return;

		rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

		lastJump = Time.time;
	}
}
