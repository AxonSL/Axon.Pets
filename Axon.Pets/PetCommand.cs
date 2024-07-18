using System;
using System.Linq;
using Axon.Pets.Configs;
using CommandSystem;
using Exiled.API.Features;

namespace Axon.Pets;

[CommandHandler(typeof(ClientCommandHandler))]
public class PetCommand : ICommand
{

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        var ply = Player.Get(sender);
        PetController.Spawn(ply, ConfigLoader.Configs.First());
        response = "Spawned";
        return true;
    }
    public string Command { get; } = "spawnpet";
    public string[] Aliases { get; } =[];
    public string Description { get; } = "spawns pet";
}