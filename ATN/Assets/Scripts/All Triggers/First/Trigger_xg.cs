using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Trigger_xg : MonoBehaviour
{
    public GameObject Wall_left;
    private int e = 0;//按键刷新控制
    private int x;//switch控制量
    SayCrl Mysaycrl;//交互对话获取
    private int x1;//场景选择控制参数
    public Animator Crossfade_end;
    public Fungus.Flowchart myflowchart;
    public GameObject Sprite;


    private void Update()
    {
        if (myflowchart.GetBooleanVariable("movecrl"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                e = 1;
                StartCoroutine(Waittime());
                
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
        if (collision.name == "Wall_left")//边界换图
        {
            SenseChange(1);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        Hide(Sprite);
    }


    //判断触发体
    void panduan(Collider2D collision)  //根据返回的碰撞id判断发生的事件，用x值进行switch控制
    {
        if (collision.name == "CoatRack") x = 1;
        if (collision.name == "Gate") x = 2;
        
    }




    //事件选择控制
    void Toswirch(int x)
    {
        switch (x)
        {
            case 1: CoatRack(); break;
            case 2: Gate(); break;
            
        }
    }

    //以下为具体事件控制
    private void SenseChange(int x)
    {

        switch (x)
        {
            case 1://客厅
                {
                    Crossfade_end.Play("Corssfade_end");
                    x1 = 4;
                    StartCoroutine(Waittime(x1));
                    break;
                }
        }
    }
                private void Gate()
    {
        SayCrl Mysaycrl = GameObject.Find("Gate").GetComponent<SayCrl>();
        Mysaycrl.Say();
        Hide(Sprite);
    }

    private void CoatRack()
    {
        SayCrl Mysaycrl = GameObject.Find("CoatRack").GetComponent<SayCrl>();
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

        yield return new WaitForSeconds(0.2f);
        e = 0;
    }

    IEnumerator Waittime(int x1)
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(x1);//level1为我们要切换到的场景
    }
}
