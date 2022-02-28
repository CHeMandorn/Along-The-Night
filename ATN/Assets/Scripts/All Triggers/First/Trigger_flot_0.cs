
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger_flot_0 : MonoBehaviour
{
    public Fungus.Flowchart myflowchart;
    public GameObject tv_1;
    public GameObject tv_2;
    public Animator Crossfade_end;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (myflowchart.GetBooleanVariable("Change_0")) 
        {
            Show(tv_1);
        }
        if (!myflowchart.GetBooleanVariable("Change_0"))
        {
            Hide(tv_1);
        }
        if (myflowchart.GetBooleanVariable("Change_1"))
        {
            Hide(tv_1);
            Show(tv_2);
        }
        if(myflowchart.GetBooleanVariable("Change_2"))
        {
            Crossfade_end.Play("Corssfade_end");
            StartCoroutine(Waittime());
        }
    }

    IEnumerator Waittime()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("woshi");
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
