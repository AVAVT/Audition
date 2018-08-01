using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasViewController : MonoBehaviour
{
  [SerializeField] private Text comboName;
  [SerializeField] private RectTransform comboArrowContainer;
  [SerializeField] private Gradient textGradient;

  List<Image> arrows = new List<Image>();
  Coroutine comboResultCoroutine;

  public void DisplayComboToUI(List<Sprite> sprites)
  {
    if (arrows.Count < sprites.Count)
    {
      int numberToCreate = sprites.Count - arrows.Count;
      for (int i = 0; i < numberToCreate; i++)
      {
        GameObject newArrow = new GameObject("Arrow");
        newArrow.transform.SetParent(comboArrowContainer);
        arrows.Add(newArrow.AddComponent<Image>());
      }
    }

    for (int i = 0; i < arrows.Count; i++)
    {
      if (i < sprites.Count)
      {
        arrows[i].sprite = sprites[i];
      }

      arrows[i].gameObject.SetActive(i < sprites.Count);
    }
  }

  public void DisplayComboResult(string text)
  {
    if (comboResultCoroutine != null) StopCoroutine(comboResultCoroutine);
    comboResultCoroutine = StartCoroutine(AnimateComboResult(text));
  }

  IEnumerator AnimateComboResult(string text)
  {
    comboName.text = text;
    float time = 0;
    while (time < 0.5f)
    {
      comboName.color = textGradient.Evaluate(time * 2f);
      time += Time.deltaTime;
      yield return null;
    }

    comboName.color = Color.clear;
    comboResultCoroutine = null;
  }
}