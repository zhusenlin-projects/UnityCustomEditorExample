using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExamplMenuItem
{
    /*
     *   MenuIten第二个参数为isValidateFunction，用于检查菜单显示时是否可以执行
     *   如果设置为true,则方法将成为Validate方法
     *   Validate方法是一个返回值是bool的方法，如果返回true作为返回值，则可以执行，否则就不可以执行
     *   默认值为false
     *   
     *   
     *   优先级参数为priority，如果前后两者相差11,则会在菜单中间形成一条分割线
     */

    /*
     *   菜单响应快捷方式字符串写在路径后，用空格隔开
     *   %       ->     Ctrl(Windows) 或Command(MacOSX)
     *   #       ->     Shift键
     *   &       ->     Alt
     *   -       ->     无修饰符
     *   F1..F12 ->     功能键
     *   HOME    ->     HOME键
     *   END     ->     END键
     *   PGUP
     *   PGDN
     *   KP0..KP9->     数字0...9
     *   KP。    ->     。
     *   KP+
     *   KP-
     *   KP*
     *   KP/
     *   KP=
     *   
     *   a...z   ->     26个字母
     */
    [MenuItem("CustomEditor/MenuItemExample/Layer1 %#g", priority = 1)]
    private static bool MenuItemExample1() 
    {
        Debug.Log("快捷键响应此菜单");
        return true; 
    }


    [MenuItem("CustomEditor/MenuItemExample/Layer2", priority = 12)]
    private static void MenuItemExample2() 
    {
        /*
         *   类似于toggle的选项
         */
        var menuPath = "CustomEditor/MenuItemExample/Layer2";
        var @checked = Menu.GetChecked(menuPath);
        Menu.SetChecked(menuPath, !@checked);
    }


    [MenuItem("CustomEditor/MenuItemExample/Layer3", priority = 22)]
    private static void MenuItemExample3() { }


    [MenuItem("CustomEditor/MenuItemExample/Layer4", priority = 999)]
    private static void MenuItemExample4() { }


    /// <summary>
    /// 上下文菜单
    /// CONTEXT/  表示此菜单是上下文  后面接组件类型
    /// </summary>
    /// <param name="menuCommand"></param>

    [MenuItem("CONTEXT/Transform/LOG_Pos")]
    private static void LOG_Pos(MenuCommand menuCommand)
    {
        Debug.Log(((Transform)menuCommand.context).position);
    }

}