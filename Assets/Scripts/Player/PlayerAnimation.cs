using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Animator animator;
	[SerializeField] private PlayerJump playerJump;
	[SerializeField] private PlayerMovement playerMovement;

	private float previousVelocity;

	private void Awake() {
		previousVelocity = rb.position.y;
	}

	private void Update() {
		// jumping or falling
		if (!playerJump.isGrounded) {
			JumpAnimation();

			FallAnimation();
		}

		// running or idle
		else {
			RunAnimation();

			ResetAnimations();
		}

		previousVelocity = rb.transform.position.y;
	}

	private void ResetAnimations() {
		// reset falling
		if (animator.GetBool("isFalling") && playerJump.isGrounded)
			animator.SetBool("isFalling", false);

		// reset jumping
		if (animator.GetBool("isJumping") && playerJump.isGrounded)
			animator.SetBool("isJumping", false);

		// reset running
		if (animator.GetBool("isRunning") && playerMovement.calculatedMovement == 0)
			animator.SetBool("isRunning", false);
	}

	private void JumpAnimation() {
		if (previousVelocity >= rb.transform.position.y) return;

		animator.SetBool("isJumping", true);
	}

	private void FallAnimation() {
		if (previousVelocity <= rb.transform.position.y) return;

		animator.SetBool("isJumping", false);
		animator.SetBool("isFalling", true);
	}

	private void RunAnimation() {
		if (playerMovement.calculatedMovement == 0) return;

		animator.SetBool("isRunning", true);
	}
}
