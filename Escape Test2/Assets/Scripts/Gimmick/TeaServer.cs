using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaServer : MonoBehaviour
{

  public Tanuki tanuki;
  Animation anim;
  bool moved = false;
  private void Awake()
  {
    anim = GetComponent<Animation>();
  }

  private void Start()
  {
    //すでにクリアしているならロッカーを開ける
    bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.MovedTeaServer);
    if (clearGimmick == true)
    {
      Moved();
    }
  }
  void Moved()
  {
    moved = true;
    transform.localPosition = new Vector3(10, -86, 0);
  }
  void Move()
  {
    moved = true;
    anim.Play();
    // gameObject.SetActive(false);
  }
  public void OnThis()
  {
    if (moved == true)
    {
      return;
    }
    bool MovedTanuki = tanuki.moved;
    if (MovedTanuki == true)
    {
      AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
      Move();
      SaveManager.instance.SetGimmickFlag(SaveManager.Flag.MovedTeaServer);
    }
    else
    {
      MessageManager.instance.ShowMessage("たぬきがいて動かせない");
    }
  }
}
