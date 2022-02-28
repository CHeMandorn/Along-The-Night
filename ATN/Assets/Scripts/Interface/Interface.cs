using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Interface : MonoBehaviour
{
    public Animator Crossfade_end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void Exit_0()
    {
        Application.Quit();
    }    
    public void ChangeSense()
    {
        Crossfade_end.Play("Corssfade_end");
        StartCoroutine(Waittime());
    }

    IEnumerator Waittime()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("flot_0");
    }
}
