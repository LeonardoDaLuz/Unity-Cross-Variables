using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchyIcon : MonoBehaviour {
    public List<Texture2D> Icons;
    public void Add(Texture2D tex)
    {
        if (Icons == null)
            Icons=new List<Texture2D>();

        Icons.Add(tex);
    }
    
}
