using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChange : MonoBehaviour
{
  //矢印の表示・非表示
  //全ての矢印を取得
  //SetActive(true/false)
  public GameObject rightArrow;
  public GameObject leftArrow;
  public GameObject backArrow;
  //パネルを列挙する
  enum Panel
  {
    Panel0,
    Panel1,
    Panel2,
    Panel3,
    Panel4,
    Panel5,
    Panel6,
    Panel7,
    Panel8
  }
  //現在表示しているパネル
  Panel currentPanel;

  private void Start()
  {
    Init();
    // Show(Panel.Panel0);
    // currentPanel = Panel.Panel0;
    // HideArrows();
    // rightArrow.SetActive(true);
  }

  void HideArrows()
  {
    rightArrow.SetActive(false);
    leftArrow.SetActive(false);
    backArrow.SetActive(false);
  }

  //ボタンを押したら移動してパネルを変更する
  public void OnRightArrow()
  {
    switch (currentPanel)
    {
      case Panel.Panel0:
        Show(Panel.Panel1);
        break;
      case Panel.Panel1:
        Show(Panel.Panel2);
        break;
      case Panel.Panel6:
        Show(Panel.Panel7);
        break;
      case Panel.Panel7:
        Show(Panel.Panel8);
        break;
    }
  }
  public void OnLeftArrow()
  {
    switch (currentPanel)
    {
      case Panel.Panel1:
        Show(Panel.Panel0);
        break;
      case Panel.Panel2:
        Show(Panel.Panel1);
        break;
      case Panel.Panel7:
        Show(Panel.Panel6);
        break;
      case Panel.Panel8:
        Show(Panel.Panel7);
        break;
    }
  }
  public void OnBackArrow()
  {
    switch (currentPanel)
    {
      case Panel.Panel3:
        Show(Panel.Panel0);
        break;
      case Panel.Panel4:
        Show(Panel.Panel1);
        break;
      case Panel.Panel5:
        Show(Panel.Panel2);
        break;
    }
  }
  void Init()
  {
    MessageManager.instance.HidePanel();
    HideArrows();
    currentPanel = Panel.Panel0;
    rightArrow.SetActive(true);
    transform.localPosition = new Vector2(0, 0);
  }

  void Show(Panel panel)
  {
    AudioManager.instance.PlaySE(AudioManager.SE.OnButton);
    MessageManager.instance.HidePanel();
    HideArrows();
    currentPanel = panel;
    switch (panel)
    {
      case Panel.Panel0:
        rightArrow.SetActive(true);
        transform.localPosition = new Vector2(0, 0);
        break;
      case Panel.Panel1:
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        transform.localPosition = new Vector2(-1000, 0);
        break;
      case Panel.Panel2:
        leftArrow.SetActive(true);
        transform.localPosition = new Vector2(-2000, 0);
        break;
      case Panel.Panel3:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(0, 1500);
        break;
      case Panel.Panel4:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-1000, 1500);
        break;
      case Panel.Panel5:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-2000, 1500);
        break;
      case Panel.Panel6:
        rightArrow.SetActive(true);
        transform.localPosition = new Vector2(0, 3000);
        break;
      case Panel.Panel7:
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        transform.localPosition = new Vector2(-1000, 3000);
        break;
      case Panel.Panel8:
        leftArrow.SetActive(true);
        transform.localPosition = new Vector2(-2000, 3000);
        break;
    }
  }

  public void OnLocker0()
  {
    Show(Panel.Panel3);
  }
  public void OnPig()
  {
    Show(Panel.Panel4);
  }
  public void OnHoll2()
  {
    Show(Panel.Panel6);
  }
  public void OnHoll6()
  {
    Show(Panel.Panel2);
  }
  public void OnBucket()
  {
    Show(Panel.Panel5);
  }
}
