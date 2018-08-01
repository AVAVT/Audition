using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

class GameLogic : IPlayInputReceiver
{
  public List<ComboConfig> combos;
  public IOutputReceiver outputReceiver;

  private List<Vector2Int> currentInputs = new List<Vector2Int>();

  public void OnComboFinish()
  {
    List<ComboConfig> availableCombos = GetAvailableComboForInputs(combos, currentInputs);
    ComboConfig successCombo = availableCombos.FirstOrDefault(combo => combo.inputs.Count == currentInputs.Count);
    if (successCombo != null)
    {
      outputReceiver.DisplayFinish(true, successCombo.skillName);
    }
    else
    {
      outputReceiver.DisplayFinish(false);
    }
    currentInputs = new List<Vector2Int>();
    outputReceiver.DisplayCombo(currentInputs);
  }

  public void OnUserInput(Vector2Int direction)
  {
    if (direction == Vector2.up
      || direction == Vector2.down
      || direction == Vector2.left
      || direction == Vector2.right)
    {
      currentInputs.Add(direction);
      List<ComboConfig> availableCombos = GetAvailableComboForInputs(combos, currentInputs);

      if (availableCombos.Count == 0)
      {
        outputReceiver.DisplayFinish(false);
        currentInputs = new List<Vector2Int>();
      }
      outputReceiver.DisplayCombo(currentInputs);
    }
    else throw new System.Exception("Invalid Input: " + direction);
  }

  List<ComboConfig> GetAvailableComboForInputs(List<ComboConfig> combos, List<Vector2Int> inputs)
  {
    return combos.FindAll(combo =>
      {
        for (int i = 0; i < inputs.Count; i++)
        {
          if (combo.inputs.Count <= i) return false;
          if (combo.inputs[i] != inputs[i]) return false;
        }
        return true;
      }
    );
  }
}