using Axon.Server.AssetBundle;
using Exiled.API.Features;
using UnityEngine;

namespace Axon.Pets;

public class PetController : MonoBehaviour
{
    public Player Owner { get; private set; }
    public PetConfig PetConfig { get; private set; }

    private bool _canUpdate = false;
    public static void Spawn(Player owner , PetConfig config)
    {
        var asset = AssetBundleSpawner.SpawnAsset(config.AssetBundleName, config.AssetName, config.Name, Vector3.zero, Quaternion.identity, config.Scale);
        var component = asset.gameObject.AddComponent<PetController>();
        component.Owner = owner;
        component.PetConfig = config;
        component._canUpdate = true;
    }
    public void Despawn()
    {
        
    }
    public void Update()
    {
        if(!_canUpdate) return;
        if (Owner == null)
        {
            Destroy(gameObject);
            return;
        }
        gameObject.transform.LookAt(Owner.Position);
        var distance = Vector3.Distance(gameObject.transform.position, Owner.Position);

        if (distance > 100f)
        {
            gameObject.transform.position = Owner.Transform.position;
        }
        if (distance > 1f)
        {
            gameObject.transform.position += (gameObject.transform.forward * (distance * 0.3f * Time.deltaTime)) + PetConfig.PositionOffset;
        }
        

    }
}