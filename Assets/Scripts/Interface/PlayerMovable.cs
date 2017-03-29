using UnityEngine;

[RequireComponent(typeof(Movable))]
public class PlayerMovable : MonoBehaviour {

	public string AxisX = "Horizontal";
	public string AxisY = "Vertical";

	Movable _movable = null;

	void Start() {
		_movable = GetComponent<Movable>();
	}

	void Update() {
		_movable.MoveVector.x = Input.GetAxis(AxisX);
		_movable.MoveVector.y = Input.GetAxis(AxisY);
	}
}
