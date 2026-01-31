using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelLayers", menuName = "Scriptable Objects/LevelLayers")]
public class LevelLayers : ScriptableObject
{
    public List<GameObject> layerPrefabs = new List<GameObject>();
} 