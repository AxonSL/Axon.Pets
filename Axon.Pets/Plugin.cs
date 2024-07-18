using Axon.Pets.Configs;
using Exiled.API.Features;

namespace Axon.Pets;

public class AxonPetsPlugin : Plugin<Config>
{
    public override string Name { get; } = "Axon.Pets";
    public override string Author { get; } = "Tiliboyy (a little dimenzio(not rly(ehh maybe(yea you could say he helped me(but not alot(nothing really))))))";
    public AxonPetsPlugin Instance;
    public override void OnEnabled()
    {
        ConfigLoader.Load();
        Instance = this;
        base.OnEnabled();
    }
}