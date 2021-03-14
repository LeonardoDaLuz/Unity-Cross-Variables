//Obtem a largura de uma animação, UTILISSISSIMO pra não ter que ficar configurando a duração dos estados manualmente.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using UnityEditor.Animations;

[CustomPropertyDrawer(typeof(AnimatorGetStateLengthAttribute))]
public class AnimatorGetStateLengthDrawer : PropertyDrawerGFPro
{
    AnimatorGetStateLengthAttribute target { get { return ((AnimatorGetStateLengthAttribute)attribute); } }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        object parent = property.GetParent();
        //Get Animator
        Animator animator = null;
        if (target._animatorVariableName == "")
        {
            MonoBehaviour targetgameObject = (MonoBehaviour)property.serializedObject.targetObject;
            animator = targetgameObject.gameObject.GetComponentInChildren<Animator>();
        }
        else
        {
            if (parent == null)
            {
                EditorGUI.PropertyField(position, property, label, true);
                return;
            }
            //Get animator reference
            FieldInfo AnimatorField = parent.GetType().GetField(target._animatorVariableName);
            if (AnimatorField != null)
                animator = (Animator)AnimatorField.GetValue(parent);
        }

        if (animator != null && parent != null)
        {
            //Get string field
            FieldInfo stateNameField = parent.GetType().GetField(target.variableNameWithStateName);

            if (stateNameField == null)
            {
                Debug.Log(property.serializedObject.targetObject.name+".GetAnimationLengthAttribute -> variable name is incorrect.");
                EditorGUI.PropertyField(position, property, label, true);
                return;
            }
            //Get String value
            object value = stateNameField.GetValue(parent);

            if (value == null)
                return;

            string stateName = value.ToString();
            if (stateName == "")
            {
                EditorGUI.PropertyField(position, property, label, true);
                return;
            }
            AnimatorState animState = AnimatorUtility.GetState(animator, stateName, target.layer);
            if (animState == null)
            {
                EditorGUI.PropertyField(position, property, label, true);
                return;
            }
            Motion AnimMotion = animState.motion;
            AnimationClip clip = (AnimationClip)AnimMotion;
            float Length = clip.length;
            property.floatValue = Length;
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            


           // EditorGUI.PropertyField(position, property, label, true);
        }
        else
        {
            Debug.Log(property.serializedObject.targetObject.name+".Animator not Found: varname: " + target._animatorVariableName);
            EditorGUI.PropertyField(position, property, label, true);
        }
        GUI.enabled = true;

    }
}
