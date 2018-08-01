using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : MonoBehaviour
{
  public IPlayInputReceiver inputReceiver;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.UpArrow)) inputReceiver?.OnUserInput(Vector2Int.up);
    else if (Input.GetKeyDown(KeyCode.DownArrow)) inputReceiver?.OnUserInput(Vector2Int.down);
    else if (Input.GetKeyDown(KeyCode.LeftArrow)) inputReceiver?.OnUserInput(Vector2Int.left);
    else if (Input.GetKeyDown(KeyCode.RightArrow)) inputReceiver?.OnUserInput(Vector2Int.right);
    else if (Input.GetKeyDown(KeyCode.Space)) inputReceiver?.OnComboFinish();
  }
}