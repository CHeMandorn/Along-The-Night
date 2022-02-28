using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Tigger_zumu : MonoBehaviour
{
    private int e1 = 0;//按键刷新控制   

    private int x1;//switch控制量
    public GameObject door;
    public GameObject List ;
    public GameObject Book;
    public GameObject Key ;
    public Animator Crossfade_end;
    public Inventory mybag;
    public items Key_1;//设置一个可获得物体
    public Fungus.Flowchart myflowchart;
    SayCrl Mysaycrl;//交互对话获取
    public GameObject Sprite;
    


    private void Update()
    {
        if (myflowchart.GetBooleanVariable("movecrl"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                e1 = 1;
                StartCoroutine(Waittime2());
            }

        }
    }



    //交互按键e
    void OnTriggerStay2D(Collider2D collision)
    {
        if (e1 == 1)
        {
            // Debug.Log("collisionName:"+ collision);//测试用
            panduan(collision);
            Toswirch(x1);
            e1 = 0;
            return;
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Show(Sprite);
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        Hide(Sprite);
    }



    //判断触发体
    void panduan(Collider2D collision)  //根据返回的碰撞id判断发生的事件，用x值进行switch控制
    {
        if (collision.name == "list") x1 = 1;
        if (collision.name == "book") x1 = 2;
        if (collision.name == "key") x1 = 3;
        if (collision.name == "Door") x1 = 4;

    }




    //事件选择控制
    void Toswirch(int x)
    {
        switch (x)
        {
            case 1: list(); break;
            case 2: book(); break;
            case 3: key(); break;
            case 4: SenseChange();break;
        }
    }


    //以下为具体事件控制

    private void SenseChange()
    {
        Crossfade_end.Play("Corssfade_end");
        StartCoroutine(Waittime());
        Hide(Sprite);
    }
   private void  list()
    {
        SayCrl Mysaycrl = GameObject.Find("list").GetComponent<SayCrl>();
        Mysaycrl.Say();
        Hide(Sprite);
    }
    private void key()
    {
        if (!mybag.itemList.Contains(Key_1))
        {
            mybag.itemList.Add(Key_1);
            BagManager.CreatNewItem(Key_1);
           // BagManager.RefreshItem();

            Hide(Sprite);

            SayCrl Mysaycrl = GameObject.Find("key").GetComponent<SayCrl>();
            Mysaycrl.Say();
            Hide(Key);
            
        }
        
    }

    /*private void QG()
    {
        if (!mybag.itemList.Contains(thisItem))
        {
            mybag.itemList.Add(thisItem);
            // BagManager.CreatNewItem(thisItem);
            BagManager.RefreshItem();          
            
            Hide(Sprite);
            

            SayCrl Mysaycrl = GameObject.Find("Qiaogun_0").GetComponent<SayCrl>();
            Mysaycrl.Say();
            Hide(QiaoGun);
        }
        
        x = 0;
    }*/

    private void book()
    {
        SayCrl Mysaycrl = GameObject.Find("book").GetComponent<SayCrl>();
        Mysaycrl.Say();
        Hide(Sprite);
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

    IEnumerator Waittime()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("2l_zl");//level1为我们要切换到的场景
    }

    IEnumerator Waittime2()
    {

        yield return new WaitForSeconds(0.2f);
        e1 = 0;
    }




}
