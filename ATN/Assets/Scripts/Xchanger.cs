using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Xchanger : MonoBehaviour
{
    private int x;//x当前场景编号
    public GameObject Maincamera;
    public int y;//y为目标场景编号
    public float x1;//新人物位置
    private GameObject human;
    private void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        x = SceneManager.GetActiveScene().buildIndex;
        if(x==y)
        {
            human = GameObject.Find("leader_0");
            human.transform.position=new Vector3(x1, human.transform.position.y, human.transform.position.z);
            Destroy(this.gameObject);
            Maincamera = GameObject.Find("Main Camera");
            Maincamera.transform.position = new Vector3(x1, Maincamera.transform.position.y, Maincamera.transform.position.z);
        }
    }



}
