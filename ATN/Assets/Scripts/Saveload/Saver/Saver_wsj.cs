using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver_wsj : MonoBehaviour
{
    public GameObject qg;
    public GameObject lian_1;
    public GameObject lian_0;
    


    public void Save()
    {
        GameObject.Find("Controler").GetComponent<SL_list>().qg = qg.activeInHierarchy;
        GameObject.Find("Controler").GetComponent<SL_list>().lian_0 = lian_0.activeInHierarchy;
        GameObject.Find("Controler").GetComponent<SL_list>().lian_1 = lian_1.activeInHierarchy;

    }
}
