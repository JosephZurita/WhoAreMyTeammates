using Exiled.API.Interfaces;
using PlayerRoles;
using System.Collections.Generic;
using System.ComponentModel;
using WhoAreMyTeammates.Models;

namespace WhoAreMyTeammates
{
    

    /// <inheritdoc />
    public sealed class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the delay after the round starts before broadcasts will be displayed.
        /// </summary>
        [Description("The delay after the round starts before broadcasts will be displayed.")]
        public float OnRoundDelay { get; set; } = 15;

        [Description("The delay after a class change before broadcasts will be displayed.")]
        public float OnChangeDelay { get; set; } = 15;

        /// <summary>
        /// Gets or sets a collection of all the broadcasts to display.
        /// </summary>
        [Description("Sets broadcasts for each class. Use %list% for the player names/SCP names and %count% for number of teammates")]
        public Dictionary<Team, WamtBroadcast> TeamBroadcasts { get; set; } = new Dictionary<Team, WamtBroadcast>()
        {
            {
                Team.SCPs, new WamtBroadcast()
                {
                    Contents = "Welcome to the<color=red><b> SCP Team.</b></color><color=#00ffff>\nThe following SCPs are on this team:\n</color><color=red>%list%</color>",
                    AloneContents = "<color=red>Attention - You are the <b>only</b> SCP This game.\nGood Luck.</color>",
                    ChangeClassContents = "Welcome to the <color=red><b> SCP Team.</b></color><color=#00ffff>\nThe following SCPs are on this team:\n</color><color=red>%list%</color>",
                    Delay = 5,
                    MaxPlayers = -1,
                    Type = DisplayType.Hint,
                    Time = 10,
                    ClassChangeIsEnabled = true,
                    IsEnabled = true,
                }
            },
            {
                Team.FoundationForces, new WamtBroadcast()
                {
                    Contents = "Welcome to the <color=#808080><b> MTF Team.</b></color><color=#00ffff>\nThe following Guards are on this team:\n</color><color=#808080>%list%</color>",
                    AloneContents = "<color=#808080>Attention - You are the <b>only</b> Facility Guard this game.\nGood Luck.</color>",
                    ChangeClassContents = "Welcome to the<color=#808080><b> MTF Team.</b></color><color=#00ffff>\nThe following Guards are on this team:\n</color><color=#808080>%list%</color>",
                    Delay = 0,
                    MaxPlayers = -1,
                    Type = DisplayType.Hint,
                    Time = 10,
                    ClassChangeIsEnabled = true,
                    IsEnabled = true
                }
            },
            {
                Team.Scientists, new WamtBroadcast()
                {
                    Contents = "Welcome to the<color=yellow><b> Scientist Team.</b></color><color=#00ffff> \nhese are your partners in science:\n</color><color=yellow>%list%</color>",
                    AloneContents = "<color=yellow>Attention - You are the <b>only</b> Scientist this game.\nGood Luck.</color>",
                    ChangeClassContents = "Welcome to the<color=yellow><b> Scientist Team.</b></color><color=#00ffff>\nThese are your partners in science:\n</color><color=yellow>%list%</color>",
                    Delay = 0,
                    MaxPlayers = -1,
                    Type = DisplayType.Hint,
                    Time = 10,
                    ClassChangeIsEnabled = true,
                    IsEnabled = true,
                }
            },
            {
                Team.ClassD, new WamtBroadcast()
                {
                    Contents = "Welcome to the<color=orange><b> Class D Team.</b></color>\nThe following class Ds are on this team:\n<color=orange>%list%</color>",
                    AloneContents = "<color=orange>Attention - You are the <b>only</b> Class D Personnel this game.\nGood Luck.</color>",
                    ChangeClassContents = "Welcome to the<color=orange><b> Class D Team.</b></color>\nThe following class Ds are on this team:\n<color=orange>%list%</color>",
                    Delay = 0,
                    MaxPlayers = -1,
                    Type = DisplayType.Hint,
                    Time = 10,
                    ClassChangeIsEnabled = true,
                    IsEnabled = true,
                }
            },
            {
                Team.ChaosInsurgency, new WamtBroadcast
                {
                    Contents = "Welcome to the<color=green><b> Chaos Insurgency.</b></color>\nThe following players are your comrades:\n<color=green>%list%</color>",
                    AloneContents = "<color=green>Attention - You are the <b>only</b> Insurgent this game.\nGood Luck.</color>",
                    ChangeClassContents = "Welcome to the<color=green><b> Chaos Insurgency.</b></color>\nThe following players are your comrades:\n<color=green>%list%</color>",
                    Delay = 0,
                    MaxPlayers = -1,
                    Type = DisplayType.Hint,
                    Time = 10,
                    ClassChangeIsEnabled = true,
                    IsEnabled = true,
                }
            }
        };
        public bool Debug { get; set; }
    }
}