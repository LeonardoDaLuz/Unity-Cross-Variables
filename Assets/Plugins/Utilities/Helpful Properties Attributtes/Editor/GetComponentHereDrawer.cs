//Get component automatico na inspector

using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;


[CustomPropertyDrawer (typeof(GetComponentHereAttribute))]
public class GetComponentHereDrawer : PropertyDrawer
{

	GetComponentHereAttribute target { get { return ((GetComponentHereAttribute)attribute); } }

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		if (property.objectReferenceValue == null) {
			string tipo = property.type;
			tipo = tipo.Replace ("PPtr<$", "");
			tipo = tipo.Replace (">", "");

			MonoBehaviour inspectedObject = (MonoBehaviour)property.serializedObject.targetObject;
			property.objectReferenceValue = GetComponentInChildren (inspectedObject, tipo);



		}

		if (target.hide)
			return;

		if (target.force)
			GUI.enabled = false;
        

		EditorGUI.PropertyField (position, property, label, true);

	}

	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return target.hide ? -2f : EditorGUI.GetPropertyHeight (property, label);

	}


	Component GetComponentInChildren (MonoBehaviour monoBehaviour, string typeName)
	{
		var Component = monoBehaviour.GetComponent (typeName);

		if (Component != null)
			return Component;

		Component = GetComponentInChildren (monoBehaviour.transform, typeName);

		if(Component==null)
			Debug.Log (monoBehaviour.GetType ().ToShortString () + "-> Component of type " + typeName + " not found.");

		return null;
	}

	Component GetComponentInChildren (Transform transform, string typeName)
	{
		for (int i = 0; i < transform.childCount; i++) {
			var Component = transform.GetChild (i).GetComponent (typeName);
			if (Component == null) {
				Component = GetComponentInChildren (transform.GetChild (i), typeName);
			}
			if (Component != null) {
				Debug.Log ("Component Obtained: " + typeName);
				return Component;
			}
		}
		return null;
	}

}