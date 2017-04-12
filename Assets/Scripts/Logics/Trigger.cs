using UnityEngine;

public class Trigger : MonoBehaviour, IStateHolder {

	public PlayerDoor Door     = null;
	public float      OffDelay = 0.0f;

	public State State { get; private set; }

	void Awake() {
		State = State.Off;
	}

	bool IsPlayer(Collider2D collider) {
		var go = collider.gameObject;
		return go.CompareTag(GameManager.PlayerTag);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if ( IsPlayer(collision) ) {
			StartOn();
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		if ( IsPlayer(collision) ) {
			StartOff();
		}
	}

	void StartOn() {
		CancelOff();
		State = State.On;
		Door.Open();
	}

	void StartOff() {
		State = State.Off;
		Invoke("Off", OffDelay);
	}

	void CancelOff() {
		CancelInvoke("Off");
	}

	void Off() {
		Door.Close();
	}
}
