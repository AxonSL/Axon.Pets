using Axon.Pets.Configs;
using Exiled.API.Features;

namespace Axon.Pets;

public class AxonPetsPlugin : Plugin<Config>
{
    
    public AxonPetsPlugin Instance;
    public override void OnEnabled()
    {
        ConfigLoader.Load();
        Instance = this;
        base.OnEnabled();
    }
}