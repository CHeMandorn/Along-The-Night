using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleTigger : MonoBehaviour
{
    private int e1 = 0;
    public Fungus.Flowchart myflowchart;
    SayCrl Mysaycrl;//交互对话获取
    public GameObject Sprite;
    private void Update()
    {
        if (myflowchart.GetBooleanVariable("movecrl"))
        {          
             if (Input.GetKeyDown(KeyCode.Space))      
             {     
                 e1 = 1;
                StartCoroutine(Waittime2());
            }
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


    void OnTriggerStay2D(Collider2D collision)
    {
        if (e1 == 1)
        {
            SayCrl Mysaycrl = GameObject.Find("Portrait").GetComponent<SayCrl>();
            Mysaycrl.Say();
            Hide(Sprite);
            e1 = 0;
        }
    }

    private void Show(GameObject x)
    {
        x.SetActive(true);
    }

    private void Hide(GameObject x)
    {
        x.SetActive(false);
    }

    IEnumerator Waittime2()
    {
        yield return new WaitForSeconds(0.2f);
        e1 = 0;
    }
}
