using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Trigger_hy : MonoBehaviour
{
    public GameObject girl;
    private int e1 = 0;//按键刷新控制   

    private int x1;//switch控制量

    public Saver_hy saver;

    public Animator Crossfade_end;
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
        if(collision.name=="Girl")
        {
            Hide(Sprite);
            SayCrl Mysaycrl = GameObject.Find("Girl").GetComponent<SayCrl>();
            Mysaycrl.Say();
            Hide(girl);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        Hide(Sprite);
    }



    //判断触发体
    void panduan(Collider2D collision)  //根据返回的碰撞id判断发生的事件，用x值进行switch控制
    {
        if (collision.name == "door") x1 = 1;
        
    }




    //事件选择控制
    void Toswirch(int x)
    {
        switch (x)
        {
            case 1: SenseChange(); break;
            
        }
    }


    //以下为具体事件控制

    private void SenseChange()
    {
        Crossfade_end.Play("Corssfade_end");

        //场景信息存储
       saver = GameObject.Find("Saver").GetComponent<Saver_hy>();
        saver.Save();


        StartCoroutine(Waittime());
        Hide(Sprite);
    }
    private void football()
    {
        SayCrl Mysaycrl = GameObject.Find("football").GetComponent<SayCrl>();
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
        SceneManager.LoadScene(4);//level1为我们要切换到的场景
    }

    IEnumerator Waittime2()
    {

        yield return new WaitForSeconds(0.2f);
        e1 = 0;
    }
}
