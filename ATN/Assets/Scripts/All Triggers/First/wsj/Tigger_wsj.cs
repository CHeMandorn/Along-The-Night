using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Tigger_wsj : MonoBehaviour
{
    public GameObject CL;
    public GameObject CL_0;
    public GameObject CL_1;
    public GameObject Wall_Right;
    public GameObject QiaoGun;

    public Saver_wsj saver;

    public items qiaogun;//设置一个可获得物体
    public Inventory mybag;
    public Fungus.Flowchart myflowchart;
    private int e = 0;//按键刷新控制
    private int x;//switch控制量
    SayCrl Mysaycrl;//交互对话获取
    public GameObject Sprite;//闪烁按钮
    private int x1;//场景选择控制参数
    public Animator Crossfade_end;
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
        if (collision.name == "Wall_Right")//边界换图
        {
            Hide(Sprite);
            SenseChange();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        Hide(Sprite);
    }

    //判断触发体
    void panduan(Collider2D collision)  //根据返回的碰撞id判断发生的事件，用x值进行switch控制
    {
        x = 0;
        if (collision.name == "CL") x = 1;
        if (collision.name == "Qiaogun_0") x = 2;
    }




    //事件选择控制
    void Toswirch(int x)
    {
        switch (x)
        {
            case 1: Cl() ; break;
            case 2: QG(); break;
        }
    }

    //以下为具体事件控制
    private void Cl ()
    {
        if(CL_0.activeInHierarchy)
        {
            Hide(CL_0);
            Show(CL_1);

        }
        else
        {
            Hide(CL_1);
            Show(CL_0);
        }
    }

    private void QG()
    {
        if (!mybag.itemList.Contains(qiaogun))
        {
            mybag.itemList.Add(qiaogun);
            BagManager.CreatNewItem(qiaogun);
            
           // BagManager.RefreshItem();          
            
            Hide(Sprite);
            

            SayCrl Mysaycrl = GameObject.Find("Qiaogun_0").GetComponent<SayCrl>();
            Mysaycrl.Say();
            Hide(QiaoGun);
        }
        
        x = 0;
    }


    private void SenseChange()
    {
        saver = GameObject.Find("Saver").GetComponent<Saver_wsj>();
        saver.Save();
        Crossfade_end.Play("Corssfade_end");
                    x1 = 3;
                    StartCoroutine(Waittime(x1));
                    
                
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
