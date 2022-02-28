using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver_zm : MonoBehaviour
{
    public GameObject key_0;

    public void Save()
    {
        GameObject.Find("Controler").GetComponent<SL_list>().key_0 = key_0.activeInHierarchy;
        
    }
}
