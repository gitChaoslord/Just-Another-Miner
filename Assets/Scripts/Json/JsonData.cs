using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData : MonoBehaviour
{

    string filename = "Data.json";
    string path;

    GameData gameData = new GameData();

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/"+filename;
        Debug.Log(path);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            gameData.date = System.DateTime.Now.ToShortDateString();
            gameData.time = System.DateTime.Now.ToShortTimeString();
            SaveData();
        }
        if(Input.GetKeyDown(KeyCode.H)){
            ReadData();
        }
    }


    void SaveData(){
        JsonWrapper wrapper = new JsonWrapper(); 
        wrapper.gameData = gameData;
        string contents = JsonUtility.ToJson(wrapper,true);
        System.IO.File.WriteAllText(path,contents);
    }
    void ReadData(){
        //an de borei na kanei read, 
       try {
            //check if there is no file
            if (System.IO.File.Exists(path)){
                string contents = System.IO.File.ReadAllText(path);
                JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
                gameData = wrapper.gameData;
                Debug.Log(gameData.date + "  " + gameData.time);
                //Debug.Log(gameData);
               
            }
            else
            {
                Debug.Log("no save file");
                //might need to reset data
                gameData = new GameData();
            }
       }
        catch (System.Exception ex) {
            Debug.Log(ex.Message);
            //need to trap exceptions gia na kserw pou kai pws crasharei
        }
    }
}
