using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SlotUi : MonoBehaviour
{
    public RawImage _rawImage;
    public ItemScriptable currentItem;
    public int quantity;
    private void Awake()
    {
        _rawImage = GetComponentInChildren<RawImage>();
        SetTexture(null);
    }
    void SetTexture(Texture texture)
    {
        _rawImage.texture = texture;
    }
    public void InitItem(ItemScriptable item)
    {
     
         SetTexture(item._texture);
    }
}
