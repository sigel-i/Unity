using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker0 : MonoBehaviour
{
  //ダイアルをクリアしたら、ロッカーをOpenする
  public GameObject OpenObj;

  private void Start()
  {
    //すでにクリアしているならロッカーを開ける
    bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpendLocker01);
    if (clearGimmick == true)
    {
      Open();
    }
  }
  public void Open()
  {
    OpenObj.SetActive(true);
    SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpendLocker01);
  }
}
