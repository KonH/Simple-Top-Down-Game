using UnityEngine;

public class PlayerDoor : MonoBehaviour, IStateHolder {

	public State State { get; private set; }

	void Awake() {
		Close();
	}

	void Start() {
	}

	bool IsPlayer(Collider2D collider) {
		var go = collider.gameObject;
		return go.CompareTag(GameManager.PlayerTag);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if ( IsPlayer(collision) ) {
			Open();
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		if ( IsPlayer(collision) ) {
			Close();
		}
	}

	void Open() {
		State = State.Open;
	}

	void Close() {
		State = State.Closed;
	}
}
