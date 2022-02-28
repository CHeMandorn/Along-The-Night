using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awake_Setup : MonoBehaviour
{
    public Animator t;
    public GameObject x;
    private void Update()
    {
        awakeAni();
    }
    public void awakeAni()
    {
        if(t.enabled)
        {
            if(x.active==false)
            {
                t.SetBool("Back", true);
            }
            if (x.active == true)
            {
                t.SetBool("Back", false);
            }
        }
    }
}
