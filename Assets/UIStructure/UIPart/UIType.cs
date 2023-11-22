using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType
{
    private string path;
    private string name;

    public string Path { get => path; }
    public string Name { get => name; }
    /// <summary>
    /// ��ȡUI��Ϣ
    /// </summary>
    /// <param name="ui_Path">ui��·��</param>
    /// <param name="ui_Name">ui������</param>
    public UIType(string ui_Path,string ui_Name)
    {
        path= ui_Path;
        name= ui_Name;  
    }
}
