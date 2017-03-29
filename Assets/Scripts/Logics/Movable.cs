using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movable : MonoBehaviour {

	public Vector2 MoveVector = Vector2.zero;
	public float   MoveScale  = 1.0f;

	Rigidbody2D _rigidbody = null;

	void Start() {
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		_rigidbody.velocity = MoveVector * MoveScale;
	}
}
