using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine.Events;

public class EditorWindowExample : EditorWindow,IHasCustomMenu
{
    #region AboutEditorStyle
    [SerializeField] private int SpaceLength = 40;  //间隔长度
    [SerializeField] private Vector2 scrollView;
    #endregion
    private bool toogle1;

    private int intNum;
    private bool toogle2;

    private AnimFloat animFloat = new AnimFloat(0.0001f);
    private Texture tex;
    private Sprite sprite;
    private GameObject obj;
    private Material mat;
    private AudioClip audioClip;

    private float knob_Angle;


    //static EditorWindowExample exampleWindow;

    [MenuItem("CustomEditor/Windows/Example")]
    private static void Open()
    {
        /*
         *  GetWindow<TYPE>();执行的操作为：
         *    如果已经存在则获取EditorWindow
         *    如果不存在则生成
         *    最后执行Show函数
         */
        //var window=GetWindow<EditorWindowExample>(typeof(SceneView));  //添加到Scene Dock Area
        GetWindow<EditorWindowExample>();

        /*
         *  这是舍近求远的做法，
         *  只为了展示寻找窗口对象的看法
         */
        var windows = Resources.FindObjectsOfTypeAll<EditorWindowExample>();
        if(windows.Length>0)
        {
            var window = windows[0];
            window.maxSize = new Vector2(600, 800);

            var icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Editor/Gizmos/unity.png");
            window.titleContent = new GUIContent("Example Windows", icon);
        }
        
        //same code:
        /*
        if (exampleWindow == null)
            exampleWindow = CreateInstance<EditorWindowExample>();
        exampleWindow.Show();
        */
    }

    private void OnGUI()
    {
        scrollView=GUILayout.BeginScrollView(scrollView, GUILayout.Width(position.width), GUILayout.Height(position.height));
        EditorGUILayout.LabelField("示例1：BeginChangeCheck()和EndChangeCheck()的使用");

        /*
         *   知识点一：
         *   ToggleLeft
         */
        EditorGUI.BeginChangeCheck();
        toogle1 = EditorGUILayout.ToggleLeft("ToggleLeft：改变则会在控制台上Debug出语句（Toggle Left）", toogle1);
        toogle2 = EditorGUILayout.Toggle("Toggle：改变则会在控制台上Debug出语句(Toggle)", toogle2);
        if (EditorGUI.EndChangeCheck())
            Debug.Log("Toggle状态发生了改变");



        EditorGUILayout.Space(SpaceLength);
        EditorGUILayout.LabelField("示例2：BeginDisabledGroup()和EndDisabledGroup()的使用");
        Display();
        EditorGUILayout.Space();
        EditorGUI.BeginDisabledGroup(true);
        Display();
        EditorGUI.EndDisabledGroup();


        EditorGUILayout.Space(SpaceLength);
        EditorGUILayout.LabelField("示例3：GUI的FadeGroup动画");
        bool on = animFloat.value == 1;
        if(GUILayout.Button(on?"Close":"Open",GUILayout.Width(64)))
        {
            animFloat.target = on ? 0.0001f : 1;
            animFloat.speed = 5f;

            var env = new UnityEvent();
            env.AddListener(() => Repaint());
            animFloat.valueChanged = env;
        }
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginFadeGroup(animFloat.value);
        DisplayForExampleThree();
        EditorGUILayout.EndFadeGroup();
        DisplayForExampleThree();
        EditorGUILayout.EndHorizontal();



        EditorGUILayout.Space(SpaceLength);
        EditorGUILayout.LabelField("示例4：ObjectField的使用");
        DisplayForExampleFour();



        EditorGUILayout.Space(SpaceLength);
        EditorGUILayout.LabelField("示例5：EditorGUI.MultiFloatField的使用：绘制多个浮点值编辑字段");
        //DisplayForFive();



        EditorGUILayout.Space(SpaceLength);
        EditorGUILayout.LabelField("示例6：EditorGUI.indentLevel的使用：缩进管理");
        DisplayForSix();


        EditorGUILayout.Space(SpaceLength);
        EditorGUILayout.LabelField("示例7：EditorGUI.Knob的使用：圆形Slider");
        DisplayForSeven();



        EditorGUILayout.Space(SpaceLength);
        EditorGUILayout.LabelField("示例8：自定义Scope的使用");
        DisplayForEight();



        EditorGUILayout.Space(SpaceLength);
        EditorGUILayout.LabelField("示例9：切换按钮样式");
        DisplayForNight();


        GUILayout.EndScrollView();
    }

    private void Display()
    {
        toogle2=EditorGUILayout.ToggleLeft("Toggle2", toogle2);
        intNum = EditorGUILayout.IntSlider(intNum, 0, 10);
        GUILayout.Button("Button");
    }

    private void DisplayForExampleThree()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.ToggleLeft("Toogle", false);
        var options = new[] { GUILayout.Width(128), GUILayout.Height(128) };
        tex = EditorGUILayout.ObjectField(tex, typeof(Texture), false, options) as Texture;
        GUILayout.Button("Button");
        EditorGUILayout.EndVertical();
    }

    private void DisplayForExampleFour()
    {
        obj = EditorGUILayout.ObjectField(obj, typeof(GameObject), true) as GameObject;
        mat = EditorGUILayout.ObjectField(mat, typeof(Material), false) as Material;
        audioClip = EditorGUILayout.ObjectField(audioClip, typeof(AudioClip), false) as AudioClip;

        var options = new[] { GUILayout.Width(64), GUILayout.Height(64) };
        tex = EditorGUILayout.ObjectField(tex, typeof(Texture), false, options) as Texture;
        sprite=EditorGUILayout.ObjectField(sprite, typeof(Sprite), false, options) as Sprite;
    }

    private void DisplayForFive()
    {
        float[] numbers = new float[] { 0, 1, 2 };
        GUIContent[] contents = new GUIContent[]
        {
            new GUIContent("X轴"),
            new GUIContent("Y轴"),
            new GUIContent("Z轴")
        };

        EditorGUI.MultiFloatField(new Rect(30, 30, 200, EditorGUIUtility.singleLineHeight),
                                  new GUIContent("Multi Float"),
                                  contents,
                                  numbers);
    }

    private void DisplayForSix()
    {
        EditorGUILayout.LabelField("Parent");
        EditorGUI.indentLevel++;
        EditorGUILayout.LabelField("Child");
        EditorGUILayout.LabelField("child");
        EditorGUI.indentLevel--;
        EditorGUILayout.LabelField("Parent");
        EditorGUI.indentLevel++;
        EditorGUILayout.LabelField("child");
        EditorGUI.indentLevel--;
    }

    private void DisplayForSeven()
    {
        knob_Angle = EditorGUILayout.Knob(Vector2.one * 64, knob_Angle, 0, 360, "度", Color.gray, Color.red, true);
    }

    private void DisplayForEight()
    {
        using(new BackgroundColorScope(Color.red))
        {
            GUILayout.Button("RED");
            using(new BackgroundColorScope(Color.green))
            {
                GUILayout.Button("GREEN");
            }
        }
    }

    private bool toggle_On;
    private int selected;

    private void DisplayForNight()
    {
        EditorGUI.indentLevel++;
        EditorGUILayout.LabelField("->单个按钮的切换");
        toggle_On = GUILayout.Toggle(toggle_On, toggle_On ? "ON" : "OFF", "button");
       
        EditorGUILayout.LabelField("->多个按钮的切换(toolbar样式)");
        selected = GUILayout.Toolbar(selected, new string[] { "ONE", "TWO", "THREE" },EditorStyles.toolbarButton);

        EditorGUILayout.LabelField("->多个按钮的切换(SelectionGird样式)");
        selected = GUILayout.SelectionGrid(selected, new string[] { "ONE", "TWO", "THREE" }, 1, "PreferencesKeysElemenet");
        EditorGUI.indentLevel--;
    }


    /// <summary>
    /// 添加Menu Item
    /// </summary>
    /// <param name="menu"></param>
    public void AddItemsToMenu(GenericMenu menu)
    {
        menu.AddItem(new GUIContent("EXAMPLE ITEM1"), false, () => { });
        menu.AddItem(new GUIContent("EXAMPLE ITEM2"), true, () => { });
    }

    /*
    [MenuItem("CustomEditor/Windows/Assets/Save EditorWindow")]
    private static void SaveEditorWindow()
    {
        var windows = Resources.FindObjectsOfTypeAll<EditorWindowExample>();
        if (windows.Length > 0)
        {
            var window = windows[0];
            AssetDatabase.CreateAsset(window, "Assets/CustomAsset/EditorWindowExample1.asset");
            AssetDatabase.Refresh();
        }
        
    }
    */


}
