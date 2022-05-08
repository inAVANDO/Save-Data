using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySaveSystem : MonoBehaviour
{
    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            selectedWeapon = data.savedSelectedWeapon;
        }
    }

    public void LoadScene() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.savedSelectedWeapon = selectedWeapon;
        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]
class SaveData {
    public int savedSelectedWeapon;
}
