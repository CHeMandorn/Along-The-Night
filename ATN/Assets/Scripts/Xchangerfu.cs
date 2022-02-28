using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Xchangerfu : MonoBehaviour
{
    //次脚本和Xchanger在不同情况应对换图人物朝向问题
    public Animator animator;
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
        if (x == y)
        {
            human = GameObject.Find("leader_0");
            animator = human.GetComponent<Animator>();
            human.transform.position = new Vector3(x1, human.transform.position.y, human.transform.position.z);
            change();
            Destroy(this.gameObject);
            Maincamera = GameObject.Find("Main Camera");
            Maincamera.transform.position = new Vector3(x1, Maincamera.transform.position.y, Maincamera.transform.position.z);
        }
    }

    private void change()
    {
        animator.SetBool("Scale", true);

    }

}
