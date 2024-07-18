using System;
using Axon.Server.AssetBundle;
using Exiled.API.Features;
using UnityEngine;

namespace Axon.Pets;

public class PetController : MonoBehaviour
{
    public Player Owner { get; private set; }
    public PetConfiguration PetConfiguration { get; private set; }

    private bool _canUpdate = false;
    public static void Spawn(Player owner , PetConfiguration configuration)
    {
        var asset = AssetBundleSpawner.SpawnAsset(configuration.AssetBundleName, configuration.AssetName, configuration.Name, Vector3.zero, Quaternion.identity, configuration.Scale);
        var component = asset.gameObject.AddComponent<PetController>();
        component.Owner = owner;
        component.PetConfiguration = configuration;
        component._canUpdate = true;
    }
    public void Despawn()
    {
        
    }
    public Animation Animation;
    private void Start()
    {
        Animation = gameObject.GetComponent<Animation>();
    }
    private bool isWalking = false;
    public void Update()
    {
        if(!_canUpdate) return;

        if (isWalking && PetConfiguration.WalkingAnimationName != "None")
        {
            Animation.Play(PetConfiguration.WalkingAnimationName);
        }
        else if(PetConfiguration.IdleAnimationName != "None")
        {
            Animation.Play(PetConfiguration.IdleAnimationName);
        }
        
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
            isWalking = true;
            gameObject.transform.position += (gameObject.transform.forward * (distance * 0.3f * Time.deltaTime)) + PetConfiguration.PositionOffset;
        }
        else
        {
            isWalking = false;
        }
        

    }
}