using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DblClick : MonoBehaviour
{
    public GameObject x;
    public void click_0()
    {
        if (x.active == false)
            x.active = true;
        else x.active = false;
    }
}
