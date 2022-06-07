using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
  public GameObject[] boxs;

  //どこでも使えるようにする
  public static ItemBox instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }

  private void Start()
  {
    //初期化：全てのboxを空にする
    for (int i = 0; i < boxs.Length; i++)
    {
      boxs[i].SetActive(false);
    }
    //セーブデータがあると表示する
  }

  public void SetItem(ItemManager.Item item)
  {
    int index = (int)item;
    boxs[index].SetActive(true);
    SaveManager.instance.SetGetItemFlag(item);
  }
  public bool CanUseItem(ItemManager.Item item)
  {
    {
      int index = (int)item;
      if (boxs[index].activeSelf == true)
      {
        return true;
      }
      return false;
    }
  }
  public void UseItem(ItemManager.Item item)
  {
    int index = (int)item;
    boxs[index].SetActive(false);
    SaveManager.instance.SetUseItemFlag(item);
  }
}
