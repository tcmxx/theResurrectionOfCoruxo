using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;


//[ExecuteInEditMode]
public class GameSaveManager : MonoBehaviour
{
    public bool loadOnAwake = false;
    public static GameSaveManager Instance { get; private set; }

    private SerializableGameData gameData;

    [System.Serializable]
    public class SerializableGameData
    {
        public SerializableGameData()
        {
            occurredEvents = new Dictionary<string, bool>();
        }

        public Dictionary<string,bool> occurredEvents;
    }

    
    //helper to use in editor to clear the record
    public bool clearRecord = false;

    void Awake()
    {
        if (!Application.isPlaying)
            return;
        Debug.Log(gameObject.transform.name);
        if (Instance == null)
        {
            Debug.Log("Save Manager doesn't exist yet");
            DontDestroyOnLoad(gameObject);
            Instance = this;
            gameData = new SerializableGameData();
            if (loadOnAwake)
                Load();
        }
        else if (Instance != this)
        {
            Debug.Log("There is more than one game control");
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start()
    {
    }


    private void Update()
    {
        if (clearRecord)
        {
            ClearRecord();
            clearRecord = false;
        }
    }



    public void SetEventOccurred(string eventName, bool occurred = true)
    {
        if (string.IsNullOrEmpty(eventName))
            return;
            
        gameData.occurredEvents[eventName] = occurred;
        Save();
    }


    public bool GetEventOccurred(string name)
    {
        if (gameData.occurredEvents.ContainsKey(name))
        {
            return gameData.occurredEvents[name];
        }
        else
        {
            return false;
        }
    }

    public List<string> OccurredEvents()
    {
        List<string> result = new List<string>();
        foreach(var r in gameData.occurredEvents)
        {
            if (r.Value)
            {
                result.Add(r.Key);
            }
        }
        return result;
    }

    public void Save()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        string filename = Path.Combine(Application.persistentDataPath, "save.dat");
        if (!File.Exists(filename))
        {
            file = File.Create(filename);
        }
        else
        {
            file = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Write);
        }


        bf.Serialize(file, gameData);
        file.Close();

        print("Save at:" + filename);
    }

    public void Load()
    {
        string filename = Path.Combine(Application.persistentDataPath, "save.dat");

        if (File.Exists(filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filename, FileMode.Open, FileAccess.Read);

            SerializableGameData tmpGameData = (SerializableGameData)bf.Deserialize(file);

            gameData = tmpGameData;

            file.Close();
            print("Load at:" + filename);
        }
        else
        {
            ClearRecord();
            print("Did you find saved data");
        }

        

    }



    public void ClearRecord()
    {
        print("Clear game data");
        gameData = new SerializableGameData();
        Save();
    }



}
