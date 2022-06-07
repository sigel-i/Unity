using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePig : MonoBehaviour
{
  public GameObject PigObj;
  public GameObject brokenPigObj;

  private void Start()
  {
    //すでにクリアしているならロッカーを開ける
    bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.BrokenPig);
    if (clearGimmick == true)
    {
      Break();
    }
  }
  public void OnThis()
  {
    bool hasHammer = ItemBox.instance.CanUseItem(ItemManager.Item.Hammer);
    if (hasHammer == true)
    {
      AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
      SaveManager.instance.SetGimmickFlag(SaveManager.Flag.BrokenPig);
      Break();
      ItemBox.instance.UseItem(ItemManager.Item.Hammer);
    }
    else
    {
      MessageManager.instance.ShowMessage("壊せそうだ");
    }
  }
  void Break()
  {
    //普通のブタを非表示
    PigObj.SetActive(false);
    //壊れたブタを表示
    brokenPigObj.SetActive(true);
  }
}
