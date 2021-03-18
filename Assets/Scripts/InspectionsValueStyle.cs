using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[DisallowMultipleComponent]                                         //修饰后禁止在同一个物体上附加多个此组件
[ExecuteInEditMode]                                                 //在编辑器模式下也可以运行（即使不是play状态），加载新场景则调用Awake()\Start();更新数据则调用Update();OnGUI()时刻被调用
[AddComponentMenu("EditorScripts/Inspections ValueStyle Scripts")]  //在Unity的Component菜单中添加选项
public class InspectionsValueStyle : MonoBehaviour
{
    [Header("范围限制"),Range(1, 10)] public int Num;

    //建议使用TextArea,因为Multiline不适配滚动条
    [Space(16)]
    [Header("多行文本框")]
    [Multiline(5)] public string MultilineStyleStr= "这是一个多行文本框\n(MultilineStyle)";
    [TextArea(3,5)] public string TextAreaStyleStr = "这是一个多行文本框\n(TextAreaStyle)";

    /// <summary>
    /// 给变量添加上下文菜单
    /// </summary>
    [Header("上下文菜单")]
    [ContextMenuItem("Random", "RandomNum")]
    [ContextMenuItem("Reset", "ResetNum")]
    public int IntNum = 5;
    private void RandomNum() { IntNum = Random.Range(0, 100); }
    private void ResetNum() { IntNum = 5; }

    /// <summary>
    /// 颜色面板的属性
    /// </summary>
    [Header("颜色面板")]
    public Color NonColorUsage;
    [ColorUsage(false)] public Color NonAlphaColorUsage;
    [ColorUsage(true, true)] public Color FullColorUsage;

    /// <summary>
    /// 这是一个间隔
    /// </summary>
    [Space(48)]
    [Tooltip("这是一个用[Space(48)]间隔后的变量")]
    public string str = "";


    [HideInInspector] public string HideInInspectorValue = "即使是public也不显示在Inspector面板上";

    /// <summary>
    /// 当你需要修改变量名但想要把旧值拷贝到新的变量而不初始化，就使用[FormerlySerializedAs("SerializeStr_1")]。
    /// 但要注意，每修改一次变量名就要更新它的参数保证旧数据能copy
    /// </summary>
    [SerializeField]
    [FormerlySerializedAs("SerializeStr_1")] public string SerializeStr = "这是一个在编辑器中已序列化的值";

    /// <summary>
    /// 给组件添加上下文菜单项
    /// </summary>
    [ContextMenu("CheckValueMsg")]
    private void CheckValueMsg()
    {
        Debug.Log($"组件全称：{typeof(InspectionsValueStyle).FullName}");
    }
}
