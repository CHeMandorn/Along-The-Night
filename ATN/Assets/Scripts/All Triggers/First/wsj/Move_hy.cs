using System.Collections;
using UnityEngine;

public class Move_hy : MonoBehaviour
{
    public GameObject X_Yz;
    public GameObject X_Yz_sup;
    public GameObject X_Pic;
    private float X_human;
    private float t;//变化差值
    
    int waittime;
    private void Update()
    {
        X_human = GameObject.Find("leader_0").transform.position.x;
        move_hy();

        if(Input.GetAxis("Horizontal")>0)
        {
            if(X_Pic.transform.localScale.x==1)
            {
                X_Pic.transform.localScale = new Vector3(-1,1,1);
            }
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            if (X_Pic.transform.localScale.x == -1)
            {
                X_Pic.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }


    private void move_hy()
    {
        t = X_Yz.transform.position.x - X_human;

        X_Pic.transform.position=new Vector3(X_Pic.transform.position.x-t, 
            X_Pic.transform.position.y, 
            X_Pic.transform.position.z);

        X_Yz.transform.position= new Vector3(X_human,
            X_Yz.transform.position.y,
            X_Yz.transform.position.z);
        X_Yz_sup.transform.position = new Vector3(X_human,
            X_Yz_sup.transform.position.y,
            X_Yz_sup.transform.position.z);
    }




   
}


