// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="XoMiya-WPC and TheUltiOne">
// Copyright (c) XoMiya-WPC and TheUltiOne. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using WhoAreMyTeammates.Models;

namespace WhoAreMyTeammates
{
    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the plugin class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnRoundStarted()
        {
            Timing.CallDelayed(plugin.Config.DelayTime, () =>
            {
                foreach (KeyValuePair< Team, WamtBroadcast> broadcastKV in plugin.Config.TeamBroadcasts)
                    RunBroadcast(broadcastKV);
            });
        }

        public void OnChangingRole(ChangingRoleEventArgs args)
        {
            Timing.CallDelayed(1f, () =>
            {
                WamtBroadcast broadcast;
                Team rcTeam = args.Player.RoleManager.Hub.GetTeam();

                if (   !Enum.IsDefined(typeof(Team), rcTeam) 
                    || !plugin.Config.TeamBroadcasts.TryGetValue(rcTeam, out broadcast)
                    || !broadcast.ClassChangeIsEnabled)
                    return;

                RunBroadcast(new KeyValuePair<Team, WamtBroadcast>(rcTeam, broadcast));
                
            });
        }
        private void RunBroadcast(KeyValuePair<Team, WamtBroadcast> broadcastKV)
        {
            if (!broadcastKV.Value.IsEnabled)
                return;

            List<Player> players = Player.Get(broadcastKV.Key).ToList();
            string message;

            if (broadcastKV.Value.MaxPlayers > -1 && players.Count >= broadcastKV.Value.MaxPlayers)
                return;

            /*
            if (players.Count > 1)
                message = String.Join(", ", broadcastKV.Key == Team.SCPs ?
                                            players.Select(player => player.Nickname + " (" + player.Role.Name + ")"):
                                            players.Select(player => player.Nickname));
            else message = broadcastKV.Value.AloneContents;
            */

            message = broadcastKV.Value.Contents.Replace("%list%", String.Join(", ", players.Select(player => player.Nickname + " (" + player.Role.Name + ")")));
            message = message.Replace("%count%", players.Count.ToString());

            foreach (Player player in players)
                Timing.CallDelayed(broadcastKV.Value.Delay, () => DisplayBroadcast(player, message, broadcastKV.Value.Time, broadcastKV.Value.Type));
        }

        private void DisplayBroadcast(Player player, string content, ushort duration, DisplayType displayType)
        {
            switch (displayType)
            {
                case DisplayType.Broadcast:
                    player.Broadcast(duration, content);
                    return;
                case DisplayType.Hint:
                    player.ShowHint(content, duration);
                    return;
                case DisplayType.ConsoleMessage:
                    player.SendConsoleMessage(content, "cyan");
                    return;
            }
        }
    }
}
