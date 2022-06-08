using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
  //どこからでも使えるようにする
  public static SaveManager instance;
  private void Awake()
  {
    instance = this;
    Load();
  }

  //ギミックのフラグの列挙
  public enum Flag
  {
    OpendLocker01,
    MovedTanuki,
    MovedTeaServer,
    OpendLocker,
    BrokenPig,
    OpendFireHydrant,
    OpendElevator,
    Max,
  }
  const string SAVE_KEY = "SaveData";
  public SaveData saveData;

  //saveDataをJson(文字列)化
  //PlayerPrefsで文字列を保存
  void Save()
  {
    string json = JsonUtility.ToJson(saveData);
    PlayerPrefs.SetString(SAVE_KEY, json);
  }
  //PlayerPrefsで文字列を保存
  //Json文字列をクラスに変換
  public void Load()
  {
    saveData = new SaveData();
    if (PlayerPrefs.HasKey(SAVE_KEY) == true)
    {
      string json = PlayerPrefs.GetString(SAVE_KEY);
      saveData = JsonUtility.FromJson<SaveData>(json);
    }
  }
  public void CreateNewData()
  {
    PlayerPrefs.DeleteKey(SAVE_KEY);
    saveData = new SaveData();
  }
  public bool HasSaveData()
  {
    return PlayerPrefs.HasKey(SAVE_KEY);
  }

  public void SetGetItemFlag(ItemManager.Item item)
  {
    int index = (int)item;
    saveData.getItems[index] = true;
    Save();
  }

  public bool GetUseItemFlag(ItemManager.Item item)
  {
    int index = (int)item;
    return saveData.useItems[index];
  }
  public void SetUseItemFlag(ItemManager.Item item)
  {
    int index = (int)item;
    saveData.useItems[index] = true;
    Save();
  }

  public bool GetGetItemFlag(ItemManager.Item item)
  {
    int index = (int)item;
    return saveData.getItems[index];
  }
  public void SetGimmickFlag(Flag flag)
  {
    int index = (int)flag;
    saveData.gimmick[index] = true;
    Save();
  }

  public bool GetGimmickFlag(Flag flag)
  {
    int index = (int)flag;
    return saveData.gimmick[index];
  }
}


[Serializable]
public class SaveData
{
  public bool[] getItems = new bool[(int)ItemManager.Item.Max]; //取得したアイテム
  public bool[] useItems = new bool[(int)ItemManager.Item.Max]; //使用したアイテム
  public bool[] gimmick = new bool[(int)SaveManager.Flag.Max];
}
