using System.Collections.Generic;
using UnityEngine;

public interface IOutputReceiver
{
  void DisplayCombo(List<Vector2Int> currentInputs);
  void DisplayFinish(bool success, string comboName = "");
}