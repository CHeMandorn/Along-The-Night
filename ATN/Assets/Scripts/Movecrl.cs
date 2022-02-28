using UnityEngine;

public class Movecrl : MonoBehaviour
{
    public Fungus.Flowchart myflowchart; //对话流程在Inspector窗里拖进去
    private Animator animator;
    
    
    private void Start()
    {
        animator = GameObject.Find("leader_0").GetComponent<Animator>();
        
    }
    private void Update()
    {
        if (!myflowchart.GetBooleanVariable("movecrl")) control_off();
        if (myflowchart.GetBooleanVariable("movecrl")) control_on();
    }
    public void control_on()
    {      
        GameObject.Find("leader_0").GetComponent<moving>().enabled = true ;
    }
    public void control_off()
    {
    //    Debug.Log("collisionName:" );
        GameObject.Find("leader_0").GetComponent<moving>().enabled = false;
        this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);//使人物不因为矢量力继续移动
        animator.SetFloat("Horizontal", 0);//设置动画控制参数为停止值
    }
}
