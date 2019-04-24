using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update
    public static int flag = 0;
    PlayerStats stats;
    void Start()
    {
        if (flag == 0)
        {
            DataLoad();
            flag = 1;
        }
        else if(flag == 1)
        {
            DataSave();
        }
        else if(flag == 2)
        {
            DataDelete();
            flag = 0;
        }
    }

    void DataLoad()
    {
        if(File.Exists(Application.dataPath + "/save.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/save.json");
            stats = JsonUtility.FromJson<PlayerStats>(json);
        }
        
        else
        {
            stats.SetCon(1f);
            stats.SetDex(1f);
            stats.SetInt(1f);
            stats.SetStr(1f);
            stats.SetName("EZClap");
            //Name init

            DataSave();
        }

    }

    void DataSave()
    {
        string json = JsonUtility.ToJson(stats);
        File.WriteAllText(Application.dataPath + "/save.json", json);
    }

    void DataDelete()
    {
        File.Delete(Application.dataPath + "/save.json");
    }
}
