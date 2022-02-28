using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBag : MonoBehaviour
{
    public GameObject Mybag;
    private bool isOpen=false;

    void Update()
    {
        OpenMyBag();
    }

    void OpenMyBag()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
            Mybag.SetActive(isOpen);
        }
    }
}
