using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FitColliderToSpriteSize : MonoBehaviour {
    public bool Autofit=true;
    public Vector2 margin;
    public Vector2 Offset;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    // Use this for initialization
    private void OnDrawGizmosSelected()
    {
        if (!Autofit)
            return;

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (boxCollider == null)
            boxCollider = GetComponent<BoxCollider2D>();

        boxCollider.size = spriteRenderer.size - (margin*2f);
        boxCollider.offset = Offset;

    }
}
