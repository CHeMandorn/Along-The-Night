using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver_kt : MonoBehaviour
{
    public GameObject mum_say;

    public void Save()
    {
        GameObject.Find("Controler").GetComponent<SL_list>().mum_say = mum_say.activeInHierarchy;

    }
}
