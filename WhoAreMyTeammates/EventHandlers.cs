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
            Timing.CallDelayed(plugin.Config.OnRoundDelay, () =>
            {
                foreach (KeyValuePair< Team, WamtBroadcast> broadcastKV in plugin.Config.TeamBroadcasts)
                    RunBroadcast(broadcastKV);
            });
        }

        public void OnChangingRole(ChangingRoleEventArgs args)
        {
            Timing.CallDelayed(plugin.Config.OnChangeDelay, () =>
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
            
            if (players.Count > 1)
            {
                message = String.Join(", ", broadcastKV.Key == Team.SCPs ?
                                            players.Select(player => player.Nickname + " (" + player.Role.Name + ")") :
                                            players.Select(player => player.Nickname));
                message = broadcastKV.Value.Contents.Replace("%list%", message);
                message = message.Replace("%count%", players.Count.ToString());
            }
            else message = broadcastKV.Value.AloneContents;

            Timing.CallDelayed(broadcastKV.Value.Delay, () =>
            {
                foreach (Player player in players)
                    DisplayBroadcast(player, message, broadcastKV.Value.Time, broadcastKV.Value.Type);
            });
            
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
