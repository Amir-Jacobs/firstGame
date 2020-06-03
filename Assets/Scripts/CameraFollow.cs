using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	private Vector3 velocity = Vector3.zero;

	public void Start() {	
		transform.position = target.position + offset;
	}

	private void LateUpdate() {
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

		transform.position = smoothedPosition;
	}
}
