using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver_hy : MonoBehaviour
{
    
    public GameObject Girl;

    public void Save()
    {
        GameObject.Find("Controler").GetComponent<SL_list>().girl = Girl.activeInHierarchy;
        
    }

}
