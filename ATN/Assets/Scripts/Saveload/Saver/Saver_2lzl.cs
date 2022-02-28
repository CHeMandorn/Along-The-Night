using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver_2lzl : MonoBehaviour
{

    public GameObject zl_1;
    public GameObject zl_2;

    


    public void Save()
    {
        GameObject.Find("Controler").GetComponent<SL_list>().zl_1 = zl_1.activeInHierarchy;
        GameObject.Find("Controler").GetComponent<SL_list>().zl_2 = zl_2.activeInHierarchy;
        
    }



}

