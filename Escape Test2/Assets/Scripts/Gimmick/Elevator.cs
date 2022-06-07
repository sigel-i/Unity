using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
  public GameObject leftObj;
  public GameObject rightObj;

  Animation anim;
  bool moved = false;
  private void Awake()
  {
    anim = GetComponent<Animation>();
  }
  private void Start()
  {
    //すでにクリアしているならロッカーを開ける
    bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpendElevator);
    if (clearGimmick == true)
    {
      Opened();
    }
  }
  public void OnThis()
  {
    if (moved == true)
    {
      return;
    }
    bool hasKey = ItemBox.instance.CanUseItem(ItemManager.Item.Card);
    if (hasKey == true)
    {
      AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
      Open();
      SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpendElevator);
      ItemBox.instance.CanUseItem(ItemManager.Item.Card);
    }
    else
    {
      MessageManager.instance.ShowMessage("エレベーターキーが必要だ");

    }
  }
  void Opened()
  {
    moved = true;
    // moved = true;
    // anim.Play();
    //左右の扉を開く
    leftObj.SetActive(false);
    rightObj.SetActive(false);
  }
  void Open()
  {
    moved = true;
    anim.Play();
    //左右の扉を開く
    // leftObj.SetActive(false);
    // rightObj.SetActive(false);
  }
}
