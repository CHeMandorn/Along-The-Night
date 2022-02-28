using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/New Item")]
public class items :ScriptableObject
{
    public string itemName;
    public Sprite itemImage;

    [TextArea]
    public string itemInfo;

    public bool CanUse; 
}
