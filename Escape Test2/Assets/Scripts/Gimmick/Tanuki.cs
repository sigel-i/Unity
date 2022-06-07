using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanuki : MonoBehaviour
{


  //   Animation anim;
  public bool moved = false;
  // bool moved = false;
  //   private void Awake()
  //   {
  //     anim = GetComponent<Animation>();
  //   }
  private void Start()
  {
    //すでにクリアしているならロッカーを開ける
    bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.MovedTanuki);
    if (clearGimmick == true)
    {
      Move();
    }
  }
  public void OnThis()
  {
    bool hasLeaf = ItemBox.instance.CanUseItem(ItemManager.Item.Leaf);
    if (hasLeaf == true)
    {
      Move();
      //   anim.Play();
      AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
      MessageManager.instance.ShowMessage("たぬきが消えてしまった");
      ItemBox.instance.UseItem(ItemManager.Item.Leaf);
    }
    else
    {
      MessageManager.instance.ShowMessage("たぬきは葉っぱで消えるらしい");
    }
  }
  void Move()
  {
    moved = true;
    SaveManager.instance.SetGimmickFlag(SaveManager.Flag.MovedTanuki);
    gameObject.SetActive(false);
  }
}
