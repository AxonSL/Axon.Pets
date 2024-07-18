using System;
using System.Collections.Generic;
using System.IO;
using Exiled.API.Features;
using Exiled.Loader;
using UnityEngine;

namespace Axon.Pets.Configs;

public class ConfigLoader
{
    public static List<PetConfig> Configs = new List<PetConfig>();
    private static string _configFolder = Path.Combine(Paths.Configs, "Pets");
    public static void Load()
    {
        if (!Directory.Exists(_configFolder))
        {
            Directory.CreateDirectory(_configFolder);
        }
        CreateDefault();
        foreach (var file in Directory.GetFiles(_configFolder))
        {
            var text = File.ReadAllText(file);
            try
            {
                var config = Loader.Deserializer.Deserialize<PetConfig>(text);
                Configs.Add(config);
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
        }
    }
    private static void CreateDefault()
    {
        var exampleConfig = new PetConfig(){
            Name = "V1",
            AssetName = "Assets/v1.prefab",
            AssetBundleName = "v1",
            Scale = Vector3.one * 0.1f,
            Permission = "Pets.V1",
            MaxAmount = 1,
            IdleAnimationName = "None",
            WalkingAnimationName = "None",
            PositionOffset = new Vector3(0, -2, 0)
        };
        File.WriteAllText(Path.Combine(_configFolder, "Example.yml"), Loader.Serializer.Serialize(exampleConfig));
    }
}