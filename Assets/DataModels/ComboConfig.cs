using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ComboConfig", menuName = "Databases/ComboConfig")]
public class ComboConfig : ScriptableObject
{
  public string skillName;
  public List<Vector2Int> inputs;
}