using UnityEngine;

public interface IPlayInputReceiver
{
  void OnUserInput(Vector2Int direction);
  void OnComboFinish();
}