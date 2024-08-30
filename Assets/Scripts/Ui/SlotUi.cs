using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SlotUi : MonoBehaviour
{
    RawImage _rawImage;
    TextMeshProUGUI _text;
    Button _button;
    public Button slotButton => _button;

    public ItemScriptable currentItem;
    public int quantity;
    private void Awake()
    {
        _rawImage = GetComponentInChildren<RawImage>();
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        SetTexture(null);
    }
    void SetTexture(Texture texture)
    {
        _rawImage.texture = texture;
    }
    public void InitItem(ItemScriptable item)
    {
        currentItem = item;
        quantity++;
        _text.text = quantity.ToString();
        SetTexture(item._texture);
    }
    public void DropItem()
    {
        var pos = UiManager.instance.playerInputs.transform.position;

        Instantiate(currentItem.prefab,pos,Quaternion.identity);

        Subtract();

        if (quantity == 0)
        {
            ClearSlot();
        }
    }

    public void UseItem()
    {
        Subtract();

        if (quantity == 0)
        {
            ClearSlot();
        }
    }
    void Subtract()
    {
        quantity--;
        _text.text = quantity.ToString();
    }
    void ClearSlot()
    {
        currentItem = null;
        SetTexture(null);
    }
}
