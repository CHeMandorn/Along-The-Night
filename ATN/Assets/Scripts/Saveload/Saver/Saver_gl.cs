using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver_gl : MonoBehaviour
{
    public GameObject zumu_say;

    public void Save()
    {
        GameObject.Find("Controler").GetComponent<SL_list>().zumu_say = zumu_say.activeInHierarchy;

    }
}
