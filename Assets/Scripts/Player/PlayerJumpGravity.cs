using UnityEngine;

public class PlayerJumpGravity : MonoBehaviour {

	[SerializeField] private Rigidbody2D rb;

	public float fallMultiplier = 2.5f;
	public float lowFallMultiplier = 1f;

    private void FixedUpdate() {

		// Jumping
		if (rb.velocity.y < 0)
			rb.gravityScale = fallMultiplier;

		// Falling
		else if (rb.velocity.y < 0)
			rb.gravityScale = lowFallMultiplier;

		// Standing
		else
			rb.gravityScale = 1f;
	}
}
