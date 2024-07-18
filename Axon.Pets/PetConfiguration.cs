using System;
using UnityEngine;

namespace Axon.Pets;

[Serializable]
public class PetConfiguration
{
    public string AssetName { get; set; }
    public string AssetBundleName { get; set; }
    public string WalkingAnimationName { get; set; } = "None";
    public string IdleAnimationName { get; set; } = "None";

    public string Name { get; set; }
    public Vector3 Scale { get; set; }
    public Vector3 PositionOffset { get; set; }
    public int MaxAmount { get; set; }
    public string Permission { get; set; }
}