using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSwitcher : MonoBehaviour
{
    public void SwitchText(string text)
    {
        GetComponentInChildren<Text>().Safe(n => n.text = text);
    }
}
