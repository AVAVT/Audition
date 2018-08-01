using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
  public ComboModel comboModel;
  public CanvasViewController canvasViewController;
  public List<Sprite> arrowSprites;

  private GameLogic gameLogic;

  private void Awake()
  {
    gameLogic = InitGameLogic();
    BindInput(gameLogic);
    BindOutput(gameLogic);
  }

  GameLogic InitGameLogic()
  {
    var gameLogic = new GameLogic();
    gameLogic.combos = comboModel.combos;

    return gameLogic;
  }

  void BindInput(GameLogic gameLogic)
  {
    KeyboardInputController keyboardInput = gameObject.AddComponent<KeyboardInputController>();
    keyboardInput.inputReceiver = gameLogic;
  }

  void BindOutput(GameLogic gameLogic)
  {
    Dictionary<Vector2Int, Sprite> spriteMap = new Dictionary<Vector2Int, Sprite>()
    {
      {Vector2Int.up, arrowSprites[0]},
      {Vector2Int.down, arrowSprites[1]},
      {Vector2Int.left, arrowSprites[2]},
      {Vector2Int.right, arrowSprites[3]}
    };

    CanvasOutputFormatter outputFormatter = new CanvasOutputFormatter(
      spriteMap,
      canvasViewController.DisplayComboToUI,
      canvasViewController.DisplayComboResult
    );
    gameLogic.outputReceiver = outputFormatter;
  }
}