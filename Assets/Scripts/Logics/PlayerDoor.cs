using UnityEngine;

public class PlayerDoor : MonoBehaviour, IStateHolder {

	public GameObject LockedMarker = null;
	public string     ItemFilter   = null;
	public bool       Automatic    = true;

	public State State { get; private set; }

	bool IsLocked {
		get { return !string.IsNullOrEmpty(ItemFilter); }
	}

	bool CanOpen {
		get {
			if ( IsLocked ) {
				var collector = Collector.Instance;
				if ( collector ) {
					return collector.Has(ItemFilter);
				}
				return false;
			}
			return true;
		}
	}

	void Awake() {
		Close();
		LockedMarker.SetActive(IsLocked);
	}

	bool IsPlayer(Collider2D collider) {
		var go = collider.gameObject;
		return go.CompareTag(GameManager.PlayerTag);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if ( Automatic && IsPlayer(collision) ) {
			Open();
		}
	}

	void OnTriggerExit2D(Collider2D collision) {
		if ( Automatic && IsPlayer(collision) ) {
			Close();
		}
	}

	public void Open() {
		if ( CanOpen ) {
			State = State.Open;
		}
	}

	public void Close() {
		State = State.Closed;
	}
}
