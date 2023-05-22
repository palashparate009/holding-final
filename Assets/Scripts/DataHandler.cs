using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Data;

public class DataHandler : MonoBehaviour
{
    //
    //Json DATA variables
    public Achieveclass AchievementData = new Achieveclass();
    public string JString;
    public JsonData JDatas;

    void Start()
    {
        //
        //Data
        JString = File.ReadAllText(Application.dataPath + "/Assets/Achievement.json");
        JsonToObject();
        //ObjectToJson();
    }

    //
    //deserialization
    public void JsonToObject()
    {
        AchievementData = JsonMapper.ToObject<Achieveclass>(JString);
        Debug.Log("===> " + AchievementData.achievements.Count.ToString());
    }

    //
    //serialization
    public void ObjectToJson()
    {
        JDatas = JsonMapper.ToJson(AchievementData);
        File.WriteAllText(Application.dataPath + "/Assets/Achievement.json", JDatas.ToString());
    }


    private void OnDisable()
    {
      
        ObjectToJson();
    }

}


public class Achieveclass
{
    public string Name;
    public List<SmileAchieves> achievements = new List<SmileAchieves>();
}

public class SmileAchieves
{
    public int HighScore;
    public int CollectionCount;
}
   
