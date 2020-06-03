using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] private Rigidbody2D rb;

	[SerializeField] private PhysicsMaterial2D highFriction;
	[SerializeField] private PhysicsMaterial2D noFriction;

	private float x;

	public float speed;
	public float calculatedMovement;

	void Update() {
        x = Input.GetAxisRaw("Horizontal");
	}

	private void FixedUpdate() {
		Move();
	}

	private void Move() {
		calculatedMovement = x * speed;

		if (x == 0)
			rb.sharedMaterial = highFriction;

		else
			rb.sharedMaterial = noFriction;

		Vector2 direction = new Vector2(calculatedMovement, rb.velocity.y);
		rb.velocity = direction;
	}
}
