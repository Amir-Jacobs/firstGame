using UnityEngine;

public class PlayerFlip : MonoBehaviour {
	private float x;
	private bool facingRight = true;

	void Update() {
		x = Input.GetAxisRaw("Horizontal");
	}

	private void FixedUpdate() {
		if (x > 0 && !facingRight || x < 0 && facingRight)
			Flip();
	}

	private void Flip() {
		facingRight = !facingRight;

		Vector3 scaler = transform.localScale;
		scaler.x *= -1;
		transform.localScale = scaler;
	}
}
