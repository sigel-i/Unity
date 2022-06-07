using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHydrant : MonoBehaviour
{
  public GameObject OpenObj;
  //連続入力の実装
  enum Direction
  {
    Left = 0,
    Right = 1,
  }
  //Playerの入力
  List<Direction> userInputs = new List<Direction>();
  //正解の連続入力：右、左、左、右、右
  Direction[] correctAnswer = {
      Direction.Right,
      Direction.Left,
      Direction.Left,
      Direction.Right,
      Direction.Right,
  };

  private void Start()
  {
    //すでにクリアしているならロッカーを開ける
    bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpendFireHydrant);
    if (clearGimmick == true)
    {
      OpenObj.SetActive(true);
    }
  }

  //入力
  public void OnButton(int type)
  {
    //ユーザーの入力を代入
    if (type == 0)
    {
      userInputs.Add(Direction.Left);
    }
    if (type == 1)
    {
      userInputs.Add(Direction.Right);
    }
    Debug.Log(type);
    //ユーザーの入力を代入
    //5回入力したらチェック
    if (userInputs.Count == 5)
    {
      if (IsAllClear() == true)
      {
        Clear();
      }
      else
      {
        //不一致の場合の実装
        ResetInput();
      }
    }
  }

  void ResetInput()
  {
    MessageManager.instance.ShowMessage("入力が間違っているようだ");
    userInputs.Clear();
  }
  //一致しているかチェック
  bool IsAllClear()
  {
    for (int i = 0; i < userInputs.Count; i++)
    {
      if (userInputs[i] != correctAnswer[i])
      {
        return false;
      }
    }
    return true;
  }
  void Clear()
  {
    AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
    Debug.Log("クリア");
    SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpendFireHydrant);
    OpenObj.SetActive(true);
  }

}
