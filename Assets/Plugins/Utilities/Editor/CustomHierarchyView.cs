#if UNITY_EDITOR
using UnityEngine;

using UnityEditor;
using GenericFunctionsPro;
using System.Text;

[InitializeOnLoad]
public class CustomHierarchyView  {

	private static StringBuilder sb = new StringBuilder ();

    public static Texture2D[] AllTextures;
    public static bool _allTexturesLoaded;

	static CustomHierarchyView() {
		EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
	}

    static void HierarchyWindowItemOnGUI (int instanceID, Rect selectionRect) {			
		GameObject gameObject = EditorUtility.InstanceIDToObject (instanceID) as GameObject;
        if (gameObject == null)
            return;
        GetComponentsAndPrintThem(gameObject, selectionRect);
    //    GUI.Label(selectionRect,"TESTE");
    }

    static void GetComponentsAndPrintThem(GameObject obj, Rect selectionRect)
    {
        HierarchyIcon HierarchyIcon = obj.GetComponent<HierarchyIcon>();
        if (HierarchyIcon != null)
        {
            if(HierarchyIcon.Icons == null)
                return;

            for (int ib = 0; ib < HierarchyIcon.Icons.Count && ib < 5; ib++)
            {
                if (HierarchyIcon.Icons[ib] == null)
                    continue;

                Rect r = new Rect(selectionRect);
                r.x = r.width - ((ib + 1) * 12);
                r.width = 18;
                GUI.Label(r, new GUIContent(HierarchyIcon.Icons[ib]));
            }
        }
        HierarchyIcon[] HierarchyIcons = obj.GetComponentsInChildren<HierarchyIcon>();
        for (int i = 0; i < HierarchyIcons.Length; i++)
        {
            for (int ic = 0; ic < HierarchyIcons[i].Icons.Count && ic<10; ic++)
            {
                if (HierarchyIcons[i].Icons[ic] == null)
                    continue;

                Rect r = new Rect(selectionRect);
                r.x = r.width - ((ic +1)* 8);
                r.width = 9;
                GUI.Label(r, new GUIContent(HierarchyIcons[i].Icons[ic]));
            }
        }
    }
}

struct ActivePassive {
	public int active;
	public int passive;
}
#endif