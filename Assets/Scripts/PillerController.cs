using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillerController : MonoBehaviour
{
    [SerializeField] private Vector2 minMaxSizeRange;

    [ContextMenu(nameof(ChangeSize))]
    public void ChangeSize()
    {
        var newScale = transform.localScale;
        newScale.x = Random.Range(minMaxSizeRange.x, minMaxSizeRange.y);
        transform.localScale = newScale;
    }
   
   
}
