using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Imageを使用する場合は必要
using UnityEngine.Events; //UnityEventを使用する場合は必要

public class DialLocker : MonoBehaviour
{
  //3つのボタンをそれぞれクリックして絵柄が全て一致すればクリア

  //ボタンの画像を取得
  public Image[] buttons;
  //表示するマークを列挙
  enum Mark
  {
    Maru,
    Sankaku,
    Hoshi,
    Daia
  }
  //現在のマーク
  Mark[] currentMarks = { Mark.Maru, Mark.Maru, Mark.Maru };
  Mark[] correctAnswerMarks = { Mark.Maru, Mark.Sankaku, Mark.Hoshi };
  //表示する画像の素材一覧
  public Sprite[] resourceSprites;

  public UnityEvent ClearEvent;


  public void OnMarkButton(int position)
  {
    //positionのマークを変更する
    ChangeMark(position);
    //positionの画像を表示する
    ShowMark(position);

    if (IsALLClearMark() == true)
    {
      Clear();
    }
  }
  void ChangeMark(int position)
  {
    currentMarks[position]++; //1つ次のマークにする
    if (currentMarks[position] > Mark.Daia)
    {
      currentMarks[position] = Mark.Maru;
    }
  }
  void ShowMark(int position)
  {
    int index = (int)currentMarks[position]; //int化
    buttons[position].sprite = resourceSprites[index]; //対応する画像の表示
  }

  bool IsALLClearMark()
  {
    for (int i = 0; i < currentMarks.Length; i++)
    {
      if (currentMarks[i] != correctAnswerMarks[i])
      {
        //1つでも違うものがあればクリアではない
        return false;
      }
    }
    //全て一致したのでクリア
    return true;
  }

  void Clear()
  {
    AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
    //ロッカーを開ける
    MessageManager.instance.ShowMessage("ロッカーが開いた");
    ClearEvent.Invoke();
  }
}
