using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ComboModel", menuName = "Databases/ComboModel")]
public class ComboModel : ScriptableObject
{
  public List<ComboConfig> combos;
}