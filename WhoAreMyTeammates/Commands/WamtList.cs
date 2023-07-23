namespace WhoAreMyTeammates.Commands
{
    using CommandSystem;
    using Exiled.API.Features;
    using Exiled.API.Enums;
    using PlayerRoles;
    using RemoteAdmin;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class WamtList : ICommand
    {
        /// <inheritdoc/>
        public string Command { get; } = "WamtList";

        /// <inheritdoc/>
        public string[] Aliases { get; } = { "WL", "SCPList", "ListSCPs" };

        /// <inheritdoc/>
        public string Description { get; } = "Lists SCPs in the current round";

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender playerSender && !Player.Get(playerSender.ReferenceHub).IsScp)
            {
                response = "Player must be SCP to execute command";
                return false;
            }

            response = "The Following SCPs are ingame: " 
                     + String.Join(", ", Player.Get(Team.SCPs).Select(scp => scp.Role.Name)) 
                     + ".";
            Player.Get(sender).Broadcast(10, $"<color=red>{response}</color>");
            return true;
        }
    }
}