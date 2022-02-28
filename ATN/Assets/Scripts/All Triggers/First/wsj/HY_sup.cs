using System.Collections;
using UnityEngine;


public class HY_sup : MonoBehaviour
{
    public float X_left;//边界值设定
    public float X_right;
    private float x;//人物x坐标
    private int t=0;//停留时间
    private int s=1;//协程控制0为关1位开
    private int s2 = 1;//事件控制0为关1位开

    public GameObject HY;
    public GameObject HY_s;

    private void Update()
    {
        x= GameObject.Find("leader_0").transform.position.x;
        if ((x<=X_right&&x>=X_left)&&s==1)
        {
            Event();
            s = 0;
        }
        
        if(t!=0&&( x >= X_right || x <= X_left))//t的归零重置
        {
            t = 0;
        }

        if(t>=5&&s2==1)
        {
            Event2();
            s2 = 0;
        }
        
    }

   
    private void Event()
    {
        StartCoroutine(Waittime());
        
    }

    private void Event2()//控制黑影出现
    {
        Hide(HY);
        Show(HY_s);
        StartCoroutine(Waittime3());
    }

    IEnumerator Waittime()//时间停留函数
    {
        yield return new WaitForSeconds(2.0f);
        t++;
        s = 1;
    }

    IEnumerator Waittime3()
    {
        yield return new WaitForSeconds(5.0f);
        Hide(HY_s);
        Show(HY);
    }

    private void Show(GameObject x)
    {
        x.SetActive(true);
    }

    private void Hide(GameObject x)
    {
        x.SetActive(false);
    }
}
