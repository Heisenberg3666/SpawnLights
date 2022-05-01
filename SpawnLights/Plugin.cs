using Exiled.API.Features;
using System;
using Server = Exiled.Events.Handlers.Server;

namespace SpawnLights
{
    internal class Plugin : Plugin<Config>
    {
        private EventHandlers _events;
        public static Plugin Instance;

        public override string Name => "SpawnLights";

        public override string Author => "Heisenberg3666";

        public override Version Version => new Version(1, 0, 0, 0);

        public override Version RequiredExiledVersion => new Version(5, 1, 3);

        public override void OnEnabled()
        {
            base.OnEnabled();
            Instance = this;
            _events = new EventHandlers();
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            _events = null;
            Instance = null;
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            Server.RespawningTeam += _events.OnTeamRespawn;
        }

        public void UnregisterEvents()
        {
            Server.RespawningTeam -= _events.OnTeamRespawn;
        }
    }
}
