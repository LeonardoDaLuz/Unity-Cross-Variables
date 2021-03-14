using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EvaporateTextPopup : MonoBehaviour
{
    public float Duration;

    public static EvaporateTextPopup instance;

    public static IDictionary<string, GameObject> popupCache;

    public static void Create(string prefabName, Vector3 position, string text)
    {

        if (popupCache == null)
            popupCache = new Dictionary<string, GameObject>();

        if (!popupCache.ContainsKey(prefabName))
        {
            Object obj = Resources.Load(prefabName);
            if (obj != null)
            {
                popupCache.Add(prefabName, (GameObject)obj);
            }
            else
            {
                Debug.LogError("Não foi possivel achar o prefab correspondente ao TextPopup: " + prefabName);
            }
        }

        GameObject newPopup = UniversalObjectPooling.PooledInstantiate(popupCache[prefabName], position, Quaternion.identity);
        Text newText = newPopup.transform.GetChild(0).GetComponent<Text>();
        newText.text = text;

    }
    public static void Create(GameObject prefab, Vector3 position, string text)
    {
        GameObject newPopup = UniversalObjectPooling.PooledInstantiate(prefab, position, Quaternion.identity);
        newPopup.GetComponentInChildren<Text>().text = text;
    }


}
