using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawUtility : MonoBehaviour {

	public static void DrawLines(Vector3[] points, Color color, float duration) {
		for (int i = 0; i < points.Length-1; i++) {
			Debug.DrawLine (points [i], points [i + 1], color, duration);
		}
	}
	public static void DrawLines(Vector3 offset, Vector3[] points, Color color, float duration) {
		for (int i = 0; i < points.Length-1; i++) {
			Debug.DrawLine (offset+points [i], offset+points [i + 1], color, duration);
		}
	}
}
