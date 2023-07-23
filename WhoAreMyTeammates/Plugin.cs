using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace WhoAreMyTeammates
{
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc />
        public override string Author => "JZ formerly XoMiya-WPC, TheUltiOne & Build";

        /// <inheritdoc />
        public override string Name => "WhoAreMyTeammates";

        /// <inheritdoc />
        public override string Prefix => Name;

        /// <inheritdoc />
        public override Version RequiredExiledVersion => new Version(7, 2, 0);

        /// <inheritdoc />
        public override Version Version => new Version(4, 3, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            Player.ChangingRole += eventHandlers.OnChangingRole;
            Server.RoundStarted += eventHandlers.OnRoundStarted;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            Player.ChangingRole -= eventHandlers.OnChangingRole;
            Server.RoundStarted -= eventHandlers.OnRoundStarted;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}