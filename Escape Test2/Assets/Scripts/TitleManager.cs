using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleManager : MonoBehaviour
{

  public GameObject continueButton;
  private void Start()
  {
    AudioManager.instance.PlayBGM(AudioManager.BGM.Title);
    //セーブデータがなければ、続きからのボタンを表示しない
    bool hasSaveData = SaveManager.instance.HasSaveData();
    if (hasSaveData == true)
    {
      continueButton.SetActive(true);
    }
    else
    {
      continueButton.SetActive(false);
    }
  }
  public void OnStartButton()
  {
    AudioManager.instance.PlaySE(AudioManager.SE.OnButton);
    //データを消して新規作成
    SaveManager.instance.CreateNewData();
    SceneManager.LoadScene("Main");
  }
  public void OnContinueButton()
  {
    //データをロード
    SaveManager.instance.Load();
    SceneManager.LoadScene("Main");
  }
}
