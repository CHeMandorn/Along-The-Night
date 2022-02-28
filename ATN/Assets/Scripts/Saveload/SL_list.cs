using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class SL_list : MonoBehaviour
{   
    private  int x;//场景编号
    private int y=0;//场景切换控制器

    //woshi
    


    [Header("卧室")]
    public bool tv;
    public bool Curtain;
    public bool Light_0;
    public bool GlobalLight_0;
    public bool GlobalLight_1;
    public bool Guifu;
    public bool Wardrobe;
    public bool firstsay;

    [Header("二楼走廊")]
    public bool zl_1;
    public bool zl_2;
    public bool phone_2l;

    [Header("卫生间")]
    public bool qg;
    public bool lian_1;
    public bool lian_0;

    [Header("祖母房间")]
    public bool key_0;

    [Header("客厅")]
    public bool mum_say;
    public bool phone_kt;

    [Header("阁楼")]
    public bool zumu_say;

    [Header("后院")]
    public bool girl;

    //
    void Start() 
    { 
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    
    public void set(bool save,bool x)
    {
        save = x;
    }


    private void Update()
    {
        x = SceneManager.GetActiveScene().buildIndex;
        if(y!=x)
        {
            switch (x)
            {
                case 1: woshi(); break;
                case 2: xuanguan(); break;
                case 3: L2zl(); break;
                case 4: keting(); break;
                case 5: wsj(); break;
                case 6: Zumu(); break;
                 case 7: gelou(); break;
                case 8: houyuan(); break;
            }

            
            y = x;
        }
    }


     


      public void woshi ()
      {
        GameObject.Find("Triggers").transform.Find("tv").gameObject.SetActive(tv);
        GameObject.Find("Curtain").transform.Find("Curtain_0").gameObject.SetActive(Curtain);
        GameObject.Find("Curtain").transform.Find("Curtain_1").gameObject.SetActive(!Curtain);
        GameObject.Find("Light").transform.Find("Light_0").gameObject.SetActive(Light_0);

        

    }
      public void xuanguan()
      {

      }

      public void  L2zl ()
      {
        GameObject.Find("background").transform.Find("2l_zl_1").gameObject.SetActive(zl_1);
        GameObject.Find("background").transform.Find("2l_zl_2").gameObject.SetActive(zl_2);
        
    }

      public void keting()
      {
        GameObject.Find("Triggers").transform.Find("mum_say").gameObject.SetActive(mum_say);
      }

      public void wsj()
      {
        GameObject.Find("Triggers").transform.Find("Qiaogun_0").gameObject.SetActive(qg);
        GameObject.Find("CL").transform.Find("lian_0").gameObject.SetActive(lian_0);
        GameObject.Find("CL").transform.Find("lian_1").gameObject.SetActive(lian_1);
    }

      public void Zumu()
      {
        GameObject.Find("Triggers").transform.Find("key").gameObject.SetActive(key_0);
    }

    public void gelou()
    {
        GameObject.Find("Triggers").transform.Find("say_zm").gameObject.SetActive(zumu_say);
    }

      public void houyuan()
      {
        GameObject.Find("Triggers").transform.Find("Girl").gameObject.SetActive(girl);
    }
}
