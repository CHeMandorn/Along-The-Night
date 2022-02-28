using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BagManager : MonoBehaviour
{
    static BagManager instance;
    public Inventory myBag;
    public GameObject slotGrid;
    public slot slotPrefeb;
  //  public Text itemInfo;
    public void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;

    }

    private void OnEnable()
    {
        RefreshItem();
    }

    public  static void CreatNewItem(items Item)
    {
        slot newItem = Instantiate(instance.slotPrefeb, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = Item;
        newItem.slotImage.sprite = Item.itemImage;
        Color x = new Color();
        x.a = 255;
        x.g = 204;
        x.b = 204;
        x.r = 204;
        newItem.slotImage.color = x;
           
    }

    public static void RefreshItem()
    {
        
        for (int i=0;i<instance.myBag.itemList.Count;i++)
        {
            CreatNewItem(instance.myBag.itemList[i]);
        }
    }
}
