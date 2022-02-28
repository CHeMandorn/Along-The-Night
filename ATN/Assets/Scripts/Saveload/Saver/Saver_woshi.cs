using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver_woshi : MonoBehaviour
{
   
    public  GameObject tv;
    public GameObject Curtain;
    
    public GameObject Light_0;
    public GameObject GlobalLight_0;
    public GameObject GlobalLight_1;



    public GameObject Guifu;
    public GameObject Wardrobe;
    public Fungus.Flowchart myflowchart;

    public void Save()
    {
        GameObject.Find("Controler").GetComponent<SL_list>().tv = tv.activeInHierarchy;
        GameObject.Find("Controler").GetComponent<SL_list>().Curtain = Curtain.activeInHierarchy;
        GameObject.Find("Controler").GetComponent<SL_list>().Light_0 = Light_0.activeInHierarchy;
        GameObject.Find("Controler").GetComponent<SL_list>().GlobalLight_0 = GlobalLight_0.activeInHierarchy;
        GameObject.Find("Controler").GetComponent<SL_list>().GlobalLight_1 = GlobalLight_1.activeInHierarchy;
        GameObject.Find("Controler").GetComponent<SL_list>().Guifu = Guifu.activeInHierarchy;
        GameObject.Find("Controler").GetComponent<SL_list>().Wardrobe = Wardrobe.activeInHierarchy;
        GameObject.Find("Controler").GetComponent<SL_list>().firstsay = myflowchart.GetBooleanVariable("firstsay");
    }

  

}

