using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
  public enum Item
  {
    Leaf,
    Key,
    Card,
    Hammer,
    Paper,
    Max,
  }
  public Item item;

  private void Start()
  {
    bool hasItem = SaveManager.instance.GetGetItemFlag(item);
    bool usedItem = SaveManager.instance.GetUseItemFlag(item);
    if (usedItem == true)
    {
      gameObject.SetActive(false);
    }
    else if (hasItem == true)
    {
      SetToItemBox();
    }
  }

  //クリックされた時に、
  public void OnThis()
  {
    AudioManager.instance.PlaySE(AudioManager.SE.GetItem);
    SetToItemBox();
    MessageManager.instance.ShowMessage(GetItemName(item) + "を手に入れた");
  }

  string GetItemName(Item item)
  {
    switch (item)
    {
      case Item.Leaf:
        return "葉っぱ";
      case Item.Key:
        return "金庫の鍵";
      case Item.Hammer:
        return "ハンマー";
      case Item.Card:
        return "エレベータキー";
      case Item.Paper:
        return "焦げた紙";
    }
    return "";
  }

  void SetToItemBox()
  {
    //消す
    gameObject.SetActive(false);
    //ItemBoxに追加する
    ItemBox.instance.SetItem(item);
  }
}
