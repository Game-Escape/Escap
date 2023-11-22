using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl
{
    public Dictionary<string, SceneBase> scene_dict;

    private static SceneControl instance;
    public static SceneControl GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("No SceneControl instance exist!");
            return instance;
        }
        return instance;

    }

    public int scene_number = 1;
    public string[] string_scene;

    public SceneControl()
    {
        instance = this;
        
        scene_dict= new Dictionary<string, SceneBase>();
    }

    /// <summary>
    /// ����һ������
    /// </summary>
    /// <param name="scene_name">Ŀ�곡��������</param>
    /// <param name="sceneBase">Ŀ�곡��</param>
    public void LoadScene(string scene_name,SceneBase sceneBase)
    {
        if (scene_number >= 2)
        {
            foreach (string scenename in string_scene)
            {
                if (scenename == scene_name)
                {
                    Debug.Log($"Scene {scene_name} has been loaded!");
                    break;
                }
                scene_number++;
                string_scene[scene_number] = scene_name;
            }
        }

        if (!scene_dict.ContainsKey(scene_name))
        {
            scene_dict.Add(scene_name, sceneBase);
        }

        //�����³���ʱ���ϳ���ִ���˳�����
        if (scene_number >= 2)
        {
            scene_dict[SceneManager.GetActiveScene().name].ExitScene();
        }

        //�����³���ʱ���³���ִ�н��뷽��
        sceneBase.EnterScene();
        GameRoot.GetInstance().root_UIMananger.PopAll();
        SceneManager.LoadScene(scene_name);

        //if(!scene_dict.ContainsKey(scene_name))
        //{
        //    scene_dict.Add(scene_name, sceneBase);
        //}

        //if(scene_dict.ContainsKey(SceneManager.GetActiveScene().name))
        //{
        //    scene_dict[SceneManager.GetActiveScene().name].ExitScene();
        //}
        //else
        //{
        //    Debug.LogWarning($"No {SceneManager.GetActiveScene().name} in the dictonary!");
        //}

        //#region Pop()

        //#endregion

        //SceneManager.LoadScene(scene_name);
        //sceneBase.EnterScene();
    }
}
