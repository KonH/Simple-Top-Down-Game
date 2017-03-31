using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UDBase.EditorTools {
	public static class SchemesMenuItems {
		[MenuItem("UDBase/Schemes/Default")]
		static void SwitchToScheme_Default() {
			SchemesTool.SwitchScheme("Default");
		}		[MenuItem("UDBase/Schemes/GameJamScheme")]
		static void SwitchToScheme_GameJamScheme() {
			SchemesTool.SwitchScheme("GameJamScheme");
		}
	}
}
