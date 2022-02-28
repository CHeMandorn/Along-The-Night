using UnityEngine;
using Fungus;

public class SayCrl : MonoBehaviour
{
    public string ChartName;
    

    public void Say()
    {
        Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();//获取文本控制器
        if (flowchart.HasBlock(ChartName))//判断是否有内容
        {
            flowchart.ExecuteBlock(ChartName);//进行对话
        }

    }
}
