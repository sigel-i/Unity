using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
  public GameObject OpenObj;

  private void Start()
  {
    //すでにクリアしているならロッカーを開ける
    bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpendLocker);
    if (clearGimmick == true)
    {
      Open();
    }
  }
  public void OnThis()
  {
    bool hasKey = ItemBox.instance.CanUseItem(ItemManager.Item.Key);
    if (hasKey == true)
    {
      AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
      SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpendLocker);
      Open();
      ItemBox.instance.UseItem(ItemManager.Item.Key);
    }
    else
    {
      Debug.Log("鍵がかかっている");
    }
  }
  void Open()
  {
    OpenObj.SetActive(true);
  }
}
