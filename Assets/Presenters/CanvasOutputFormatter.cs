using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CanvasOutputFormatter : IOutputReceiver
{
  Dictionary<Vector2Int, Sprite> spriteMap;
  Action<List<Sprite>> displayComboToUI;
  Action<string> displayComboResult;

  public CanvasOutputFormatter(Dictionary<Vector2Int, Sprite> spriteMap, Action<List<Sprite>> displayToUI, Action<string> displayComboResult)
  {
    this.spriteMap = spriteMap;
    this.displayComboToUI = displayToUI;
    this.displayComboResult = displayComboResult;
  }

  public void DisplayCombo(List<Vector2Int> currentInputs)
  {
    displayComboToUI?.Invoke(
      currentInputs.Select(input =>
      {
        if (input == Vector2.up
        || input == Vector2.down
        || input == Vector2.left
        || input == Vector2.right) return spriteMap[input];
        else return null;
      }).ToList()
    );
  }

  public void DisplayFinish(bool success, string comboName = "")
  {
    displayComboResult(success ? comboName : "MISSED");
  }
}