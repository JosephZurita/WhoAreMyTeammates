using CommandSystem;
using Exiled.API.Features;
using PlayerRoles;
using RemoteAdmin;
using System;
using System.Linq;

namespace WhoAreMyTeammates.Commands
{
    

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class WamtList : ICommand
    {
        /// <inheritdoc/>
        public string Command { get; } = "WamtList";

        /// <inheritdoc/>
        public string[] Aliases { get; } = { "WL" };

        /// <inheritdoc/>
        public string Description { get; } = "Lists SCPs in the current round";

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender playerSender) || !Player.Get(playerSender.ReferenceHub).IsScp)
            {
                response = "Player must be SCP to execute command";
                return false;
            }

            response = "The Following SCPs are ingame: " 
                     + String.Join(", ", Player.Get(Team.SCPs).Select(scp =>  scp.Nickname + " (" + scp.Role.Name + ")")) 
                     + ".";
            Player.Get(sender).Broadcast(10, $"<color=red>{response}</color>");
            return true;
        }
    }
}