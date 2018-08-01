using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConsoleOutputFormatter : IOutputReceiver
{
  public Action<string> DisplayToConsole;
  public void DisplayCombo(List<Vector2Int> currentInputs)
  {
    DisplayToConsole(
      string.Join(",", currentInputs.Select(input =>
      {
        if (input == Vector2.up) return "Up";
        else if (input == Vector2.down) return "Down";
        else if (input == Vector2.left) return "Left";
        else if (input == Vector2.right) return "Right";
        else return "";
      }))
    );
  }

  public void DisplayFinish(bool success, string comboName = "")
  {
    DisplayToConsole(success ? comboName : "MISSED");
  }
}