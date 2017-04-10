using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IStateHolder))]
public class StateRenderer : MonoBehaviour {

	[Serializable]
	public class StateRender {
		public State      State = State.None;
		public GameObject Item  = null;
	}

	IStateHolder _holder = null;

	public List<StateRender> States = new List<StateRender>();

	void Start() {
		_holder = GetComponent<IStateHolder>();
	}

	void Update() {
		SetupState();
	}

	void SetupState() {
		for ( int i = 0; i < States.Count; i++ ) {
			var state = States[i];
			state.Item.SetActive(state.State == _holder.State);
		}
	}
}
