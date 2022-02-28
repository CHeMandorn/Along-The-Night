using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Trigger_ws : MonoBehaviour
{
    private int e1 = 0;//按键刷新控制   
    
    private int x1;//switch控制量

    public Saver_woshi woshi;
    public GameObject final;
    public GameObject Tv_0;
    public GameObject LightFortv;
    public GameObject Wardrobe_0;
    public GameObject Curtain_0;
    public GameObject Curtain_1;
    public GameObject Light_0;
    public GameObject Guifu;
    public GameObject SwitchLight;
    public GameObject GuifuLight;
    public Animator Crossfade_end;
    public Fungus.Flowchart myflowchart;
    SayCrl Mysaycrl;//交互对话获取
    public GameObject Sprite;
    public GameObject GlobalLight_0;
    public GameObject GlobalLight_1;
    public Animator Eye;


    private void Start()
    {
        myflowchart.SetBooleanVariable("firstsay", GameObject.Find("Controler").GetComponent<SL_list>().firstsay);

        if(!GameObject.Find("Controler").GetComponent<SL_list>().phone_kt)
        {
            Show(final);
        }
    }
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
        if (e1==1)
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
        if (collision.name == "tv") x1 = 1;
        if (collision.name == "Wardrobe") x1 = 2;
        if (collision.name == "Curtain") x1 = 3;
        if (collision.name == "Switch") x1 = 4;
        if (collision.name == "football") x1 = 5;
        if (collision.name == "SenseChange") x1 = 6;
        if (collision.name == "final") x1 = 7;
        if (collision.name == "Portrait") x1 = 8;
    }




    //事件选择控制
    void Toswirch(int x)
    {
        switch(x)
        {
            case 1:tv();break;
            case 2:Wardrobe();break;
            case 3:Curtain();break;
            case 4:Lightcon();break;
            case 5:football();break;
            case 6: SenseChange(); break;
            case 7: Final(); break;
            case 8: Portrait(); break;
        }
    }

 
    //以下为具体事件控制

    private void Portrait()
    {
        SayCrl Mysaycrl = GameObject.Find("Portrait").GetComponent<SayCrl>();
        Mysaycrl.Say();
        Hide(Sprite);
    }
    private void SenseChange() 
    {
        Crossfade_end.Play("Corssfade_end");

        //场景信息存储
        woshi = GameObject.Find("Saver").GetComponent<Saver_woshi>();
        woshi.Save();


        StartCoroutine(Waittime());
        Hide(Sprite);
    }
    private void football()
    {
        SayCrl Mysaycrl = GameObject.Find("football").GetComponent<SayCrl>();
        Mysaycrl.Say();
        Hide(Sprite);
    }

    private void Lightcon()
    {
        if (Light_0.activeInHierarchy)//关灯判断
        {
            Hide(Light_0);
            Hide(GlobalLight_0);
            Show(GlobalLight_1);
            if (Curtain_0.activeInHierarchy)//窗帘打开时的关灯事件
            {
                Show(Guifu);
                Show(GuifuLight);
            }
            Show(SwitchLight);//灯开关的光源

            if(Tv_0.activeInHierarchy)
            {
                Show(LightFortv);
            }

        }
        else if (!Light_0.activeInHierarchy)
        {
            Show(Light_0);
            Hide(GlobalLight_1);
            Show(GlobalLight_0);

            Hide(LightFortv);
            Hide(Guifu);
            Hide(GuifuLight);
            Hide(SwitchLight);
        }
        
    }


    private void Curtain()
    {
        if(Curtain_0.activeInHierarchy)
        {
            Hide(Curtain_0);
            Show(Curtain_1);
            Hide(Guifu);
            Hide(GuifuLight);
        }
        else if(!Curtain_0.activeInHierarchy)
        {
            Hide(Curtain_1);
            Show(Curtain_0);
            if (!Light_0.activeInHierarchy)
            {
                Show(Guifu);
                Show(GuifuLight);
            }
        }
        

    }


    private void Wardrobe()
    {
        if (Wardrobe_0.activeInHierarchy)
        {
            Hide(Wardrobe_0);

        }
        else if (!Wardrobe_0.activeInHierarchy)
        {
            Show(Wardrobe_0);

        }
    }


    private void tv()
    {
        if (Tv_0.activeInHierarchy)
        {
            Hide(Tv_0);
            Hide(LightFortv);
        }
        else if (!Tv_0.activeInHierarchy)
        {
            Show(Tv_0);
            if (!Light_0.activeInHierarchy) Show(LightFortv);
            SayCrl Mysaycrl = GameObject.Find("tv").GetComponent<SayCrl>();
            Mysaycrl.Say();
        }
        Hide(Sprite);
    }

    private void Final()
    {
        Crossfade_end.Play("Corssfade_end");
        StartCoroutine(Waittimef());
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

    IEnumerator Waittimef()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("flot_1");//level1为我们要切换到的场景
    }
}
