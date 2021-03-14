//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using System.Reflection;
//using UnityEditor.Animations;

//[CustomPropertyDrawer(typeof(AnimatorGetStateLengthAttribute))]
//public class AnimatorGetStateLengthDrawer : PropertyDrawerGFPro
//{


//    AnimatorGetStateLengthAttribute target { get { return ((AnimatorGetStateLengthAttribute)attribute); } }

//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//       // Debug.Log(0);
//        object SerializedClass = property.GetParent();
//        if (!target.force && property.floatValue != 0f)
//        {
//           // Debug.Log("1a");
//            EditorGUI.PropertyField(position, property, label, true);
//        }
//        else
//        {
//            //Debug.Log("1b");
//            //Get Animator
//            Animator animator = null;
//            if (target._animatorVariableName == "")
//            {
//               // Debug.Log("1a");
//                MonoBehaviour targetgameObject = (MonoBehaviour)property.serializedObject.targetObject;
//                animator = targetgameObject.gameObject.GetComponentInChildren<Animator>();
//            }
//            else
//            {
//              //  Debug.Log("2b");
               
//                if(SerializedClass==null)
//                {
//                    EditorGUI.PropertyField(position, property, label, true);
//                    return;
//                }
//                FieldInfo AnimatorField = SerializedClass.GetType().GetField(target._animatorVariableName);
//                if (AnimatorField != null)
//                    animator = (Animator)AnimatorField.GetValue(SerializedClass);

//            }

//            if (animator != null)
//            {
//              //  Debug.Log("3a");
//                // Debug.Log("1d");
//                FieldInfo stateNameField = SerializedClass.GetType().GetField(target.variableNameWithStateName);
//                if (stateNameField == null)
//                {
//                    EditorGUI.PropertyField(position, property, label, true);
//                    return;
//                }
//                string stateName = stateNameField.GetValue(SerializedClass).ToString();
//                if (stateName == "")
//                {
//                    EditorGUI.PropertyField(position, property, label, true);
//                    return;
//                }
//              //  return;
//             //   Debug.Log(animator.name);
//             //   Debug.Log(stateName);
//              //  Debug.Log(target.layer);
//                AnimatorState animState= AnimatorUtility.GetState(animator, stateName, target.layer);
//                if (animState == null)
//                {
//                    EditorGUI.PropertyField(position, property, label, true);
//                    return;
//                }
//                Motion AnimMotion = animState.motion;
//                AnimationClip clip = (AnimationClip)AnimMotion;
//                float Length = clip.length;
//                property.floatValue = Length;
//                EditorGUI.PropertyField(position, property, label, true);
//            }
//            else
//            {
//                Debug.Log("3b");
//                Debug.Log("Animator not Found: varname: " + target._animatorVariableName);
//                EditorGUI.PropertyField(position, property, label, true);
//            }
//            //  Debug.Log("1c");

//        }

//    }
//}
