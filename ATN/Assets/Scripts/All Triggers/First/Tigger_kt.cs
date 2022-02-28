using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Tigger_kt : MonoBehaviour
{
    public GameObject phone;
    public GameObject Light_tvForhum;
    public GameObject ChuGui;
    public GameObject Lon_down;
    public GameObject Lon_open;
    public GameObject Loff_open;
    public GameObject Loff_down;
    public GameObject mum_say;
    public GameObject Light_1;    
    public GameObject Door_hy;
    public GameObject Wall_right;
    public GameObject Lightopen;
    public GameObject Lightclose;
    public GameObject tv;
    public GameObject tv_on;

    public Saver_kt saver;


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
    private void Start()
    {
        myflowchart.SetBooleanVariable("mum_say", GameObject.Find("Controler").GetComponent<SL_list>().mum_say);

        if(!GameObject.Find("Controler").GetComponent<SL_list>().phone_2l&& GameObject.Find("Controler").GetComponent<SL_list>().phone_kt)
        {
            Show(phone);
            GameObject.Find("Controler").GetComponent<SL_list>().phone_kt = false;
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
            x = 0;
        }
    }

    //闪烁按键显示控制
    void OnTriggerEnter2D(Collider2D collision)
    {
        Show(Sprite);
        if(collision.name == "Wall_right")//边界换图
        {
            SenseChange(2);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        Hide(Sprite);
    }

    //判断触发体
    void panduan(Collider2D collision)  //根据返回的碰撞id判断发生的事件，用x值进行switch控制
    {
        if (collision.name == "ChuGui") x = 1;
        if (collision.name == "Light_1") x = 2;
        if (collision.name == "Door_hy") x = 3;
        if (collision.name == "Wall_right") x = 4;
        if (collision.name == "Tv") x = 5;
        if (collision.name == "Stairs") x = 6;
        if (collision.name == "phone") x = 7;
    }




    //事件选择控制
    void Toswirch(int x)
    {
        switch (x)
        {
            case 1: Chugui(); break;
            case 2: light1(); break;
            case 3:SenseChange(3);break;
            case 4: break;
            case 5:tvCtl(); break; 
            case 6: SenseChange(1); break;
            case 7:Phone();break;
        }
    }

    //以下为具体事件控制
    
    private void tvCtl()
    {
        if(!tv_on.activeInHierarchy)
        {
            Show(tv_on);
            Show(Light_tvForhum);
        }
        else
        {
            Hide(tv_on);
            Hide(Light_tvForhum);
        }
    }

    private void light1()
    {
        if (Light_1.activeInHierarchy)
        {

            Hide(Light_1);
            Show(Lightclose);
            Hide(Lightopen);            
            if(Lon_down.activeInHierarchy)
            {
                Hide(Lon_down);
                Show(Loff_down);
            }
            if (Lon_open.activeInHierarchy)
            {
                Hide(Lon_open);
                Show(Loff_open);
            }
        }
        else 
        {
           
            Show(Light_1);
            Show(Lightopen);
            Hide(Lightclose);
            if (Loff_down.activeInHierarchy)
            {
                Hide(Loff_down);
                Show(Lon_down);
            }
            if (Loff_open.activeInHierarchy)
            {
                Hide(Loff_open);
                Show(Lon_open);
            }
        }
    }
    private void Chugui()
    {
        if(Light_1.activeInHierarchy)
        {            
           if(Lon_down.activeInHierarchy)
            {
                Hide(Lon_down);
                Show(Lon_open);
            }
            else
            {
                Hide(Lon_open);
                Show(Lon_down);
            }
        }
        else
        {
            if (Loff_down.activeInHierarchy)
            {
                Hide(Loff_down);
                Show(Loff_open);
            }
            else
            {
                Hide(Loff_open);
                Show(Loff_down);
            }
        }
    }

    private void Phone()
    {
        Hide(Sprite);
        SayCrl Mysaycrl = GameObject.Find("phone").GetComponent<SayCrl>();
        Mysaycrl.Say();
        Hide(phone);

    }



    private void SenseChange(int x)
    {
        Hide(mum_say);
        saver = GameObject.Find("Saver").GetComponent<Saver_kt>();
        saver.Save();
        switch (x)
        {
            case 1://二楼走廊
                {
                    Crossfade_end.Play("Corssfade_end");
                    x1 = 3;
                    StartCoroutine(Waittime(x1));
                    break;
                }
            case 2://玄关
                {
                    Crossfade_end.Play("Corssfade_end");
                    x1 = 2;
                    StartCoroutine(Waittime(x1));
                    break;
                }
            case 3://后院
                {
                    Crossfade_end.Play("Corssfade_end");
                    x1 = 8;
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
