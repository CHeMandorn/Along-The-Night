using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger_2lzl : MonoBehaviour
{
    public GameObject zl1;
    public GameObject zl2;
    
    public Saver_2lzl saver;

    public GameObject Door_ZM;
    public GameObject Door_ws;
    public GameObject Door_TL;
    public GameObject Updoor;
    public items key_0;
    public items qiaogun;//设置一个可获得物体
    public Inventory mybag;
    public Fungus.Flowchart myflowchart;
    private int e = 0;//按键刷新控制
    private int x;//switch控制量
    SayCrl Mysaycrl;//交互对话获取
    public GameObject Sprite;//闪烁按钮
    private int x1;//场景选择控制参数
    public Animator Crossfade_end;
    public Animator Eye;
    private void Start()
    {
        if(!GameObject.Find("Controler").GetComponent<SL_list>().girl && GameObject.Find("Controler").GetComponent<SL_list>().zumu_say&& GameObject.Find("Controler").GetComponent<SL_list>().phone_2l)
        {
            myflowchart.SetBooleanVariable("phone", GameObject.Find("Controler").GetComponent<SL_list>().phone_2l);
            GameObject.Find("Controler").GetComponent<SL_list>().phone_2l = false;
        }
    }


    private void Update()
    {
        if (myflowchart.GetBooleanVariable("movecrl"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                e = 1;
                StartCoroutine(Waittime2());
            }

        }
    }

    //交互按键e
    void OnTriggerStay2D(Collider2D collision)
    {
        if (e == 1)
        {
            // Debug.Log("collisionName:"+ collision);//测试用
            panduan(collision);
            Toswirch(x);
            e = 0;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Show(Sprite);
        Eye.SetBool("Trigger", true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        Hide(Sprite);
        Eye.SetBool("Trigger", false);
    }

    //判断触发体
    void panduan(Collider2D collision)  //根据返回的碰撞id判断发生的事件，用x值进行switch控制
    {
        if (collision.name == "Door_WS") x = 1;
        if (collision.name == "Door_TL") x = 2;
        if (collision.name == "Updoor") x = 3;
        if (collision.name == "Stairs") x = 4;
        if (collision.name == "Door_ZM") x = 5;
    }




    //事件选择控制
    void Toswirch(int x)
    {
        switch (x)
        {
            case 1: SenseChange(x); break;
            case 2: wsj(); break;
            case 3: updoor(); break;
            case 4: SenseChange(x); break;
            case 5: SenseChange(x); break;
        }
    }

    //以下为具体事件控制
    private void wsj()
    {
        if (!mybag.itemList.Contains(key_0))
        {
            SayCrl Mysaycrl = GameObject.Find("Door_TL").GetComponent<SayCrl>();
            Mysaycrl.Say();
            Hide(Sprite);
        }
        else
            SenseChange(2);
    }
     private void updoor()
    {
        if(zl2.activeInHierarchy)
        {
            SenseChange(6);
        }
        else if (!mybag.itemList.Contains(qiaogun))
        {
            myflowchart.SetBooleanVariable("HaveQG", false);
            SayCrl Mysaycrl = GameObject.Find("Updoor").GetComponent<SayCrl>();
            Mysaycrl.Say();
            Hide(Sprite);
        }
        else
        {
            myflowchart.SetBooleanVariable("HaveQG", true);
            SayCrl Mysaycrl = GameObject.Find("Updoor").GetComponent<SayCrl>();
            Mysaycrl.Say();
            
            Show(zl2);
            Hide(zl1);           
        }
    }

   /*i private void TL()
    {
        f(!mybag.itemList.Contains(thisItem))
        {
            mybag.itemList.Add(thisItem);
            // BagManager.CreatNewItem(thisItem);
            BagManager.RefreshItem();
            SayCrl Mysaycrl = GameObject.Find("Door_TL").GetComponent<SayCrl>();
            Mysaycrl.Say();
            Hide(Sprite);

        }
             
        x = 0;
       


    } */
    private void SenseChange(int x)
    {
        saver = GameObject.Find("Saver").GetComponent<Saver_2lzl>();
        saver.Save();
        switch (x)
        {
            case 1:
                {
                    Crossfade_end.Play("Corssfade_end");
                    x1 = 1;
                    StartCoroutine(Waittime(x1));
                    break;
                }
            case 2:
                {
                    Crossfade_end.Play("Corssfade_end");
                    x1 = 5;
                    StartCoroutine(Waittime(x1));
                    break;
                }
            case 4:
                {
                    Crossfade_end.Play("Corssfade_end");
                    x1 = 4;
                    StartCoroutine(Waittime(x1));
                    break;
                }
            case 5:
                {
                    Crossfade_end.Play("Corssfade_end");
                    x1 = 6;
                    StartCoroutine(Waittime(x1));
                    break;
                }
            case 6:
                {
                    Crossfade_end.Play("Corssfade_end");
                    x1 = 7;
                    StartCoroutine(Waittime(x1));
                    break;
                }
        }
       
       
                    
                
        
    }




    //以下为激活控制
    private void Show(GameObject x)
    {
        x.SetActive(true);
    }

    private void Hide(GameObject x)
    {
        x.SetActive(false);
    }

    //场景切换控制
    IEnumerator Waittime(int x1)
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(x1);//level1为我们要切换到的场景
    }

    //以下为e取消激活检测
    IEnumerator Waittime2()
    {

        yield return new WaitForSeconds(0.2f);
        e = 0;
    }
}