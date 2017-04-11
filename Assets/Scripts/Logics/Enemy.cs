using UnityEngine;

[RequireComponent(typeof(Movable))]
public class Enemy : MonoBehaviour, IStateHolder {

	public float IdleTime       = 5.0f;
	public bool  TrackPlayer    = false;
	public float DetectDistance = 0;
	public float SleepTime      = 0;
	public float MinMoveDelta   = 0;
	public float MoveCheckTime  = 0;

	Movable        _movable       = null;
	float          _idleTimer     = 0;
	float          _moveTimer     = 0;
	RaycastHit2D[] _raycastResult = new RaycastHit2D[64];
	Vector3        _prevPosition  = Vector3.zero;

	public State State { get; private set; }

	void Awake() {
		State = State.Idle;
	}

	void Start() {
		_movable = GetComponent<Movable>();
		_idleTimer = IdleTime;
		_prevPosition = transform.position;
	}

	void Update() {
		TrackPlayer = UpdateAttack();
		if ( !TrackPlayer ) {
			UpdateIdle();
		}
		State = TrackPlayer ? State.Attack : State.Idle;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, DetectDistance);
	}

	Vector2 GetDirection(Transform target) {
		return (target.position - transform.position) / Vector2.Distance(target.position, transform.position);
	}

	bool UpdateAttack() {
		var target = EnemyTarget.Instance;
		if ( target ) {
			var direction = GetDirection(target.transform);
			var resultCount = Physics2D.RaycastNonAlloc(transform.position, direction, _raycastResult, DetectDistance);
			var tracked = false;
			for ( int i = 0; i < resultCount; i++ ) {
				var result = _raycastResult[i];
				if ( result.transform.CompareTag(GameManager.WallTag) ) {
					return false;
				}
				if ( result.transform == target.transform ) {
					tracked = true;
					break;
				}
			}
			if ( tracked ) {
				_movable.MoveVector = direction;
				return true;
			}
		}
		return false;
	}

	void UpdateIdle() {
		var isNotMoved = CheckNotMoved();
		if ( (_idleTimer > IdleTime) || isNotMoved ) {
			SetupRandomMove();
			_idleTimer = 0;
		} else {
			_idleTimer += Time.deltaTime;
		}
	}

	bool CheckNotMoved() {
		if ( _moveTimer > MoveCheckTime ) {
			var isNotMoved = IsNotMoved();
			_prevPosition = transform.position;
			_moveTimer = 0;
			return isNotMoved;
		} else {
			_moveTimer += Time.deltaTime;
		}
		return false;
	}

	bool IsNotMoved() {
		var distance = Mathf.Abs((_prevPosition - transform.position).sqrMagnitude);
		var isNotMoved = distance <= MinMoveDelta;
		return isNotMoved;
	}

	void SetupRandomMove() {
		var xy = Random.value > 0.5f;
		var value = Random.value > 0.5f ? 1 : -1;
		_movable.MoveVector = new Vector2(xy ? value : 0, !xy ? value : 0);
	}

	public void Sleep() {
		Invoke("Resume", SleepTime);
		_movable.MoveVector = Vector3.zero;
		State = State.Sleep;
		enabled = false;
	}

	void Resume() {
		State = State.Idle;
		enabled = true;
	}
}
