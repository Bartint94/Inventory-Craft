using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
public class ItemScriptable : ScriptableObject
{
    [SerializeField] Texture _Texture;
    public Texture _texture => _Texture;
    public int id;
    public int slotCapacity;
}
