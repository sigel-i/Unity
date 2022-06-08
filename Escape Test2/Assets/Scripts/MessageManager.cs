using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
  public GameObject Panel;
  public Text message;

  //どこでも使えるようにする
  public static MessageManager instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }
  private void Start()
  {
    ShowMessage("クリアを目指そう！");
  }
  public void ShowPanel()
  {
    Panel.SetActive(true);
  }
  public void HidePanel()
  {
    Panel.SetActive(false);
  }
  public void ShowMessage(string msg)
  {
    message.text = msg;
    ShowPanel();
  }
}
