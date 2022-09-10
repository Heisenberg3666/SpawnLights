using Exiled.API.Features;
using System;
using SpawnLights.Events;

namespace SpawnLights
{
    public class Plugin : Plugin<Config>
    {
        private ServerEvents _serverEvents;
        
        public override string Name { get; } = "SpawnLights";
        public override string Author { get; } = "Heisenberg3666";
        public override Version Version { get; } = new Version(1, 0, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 3, 0);

        public override void OnEnabled()
        {
            _serverEvents = new ServerEvents(Config);
            
            RegisterEvents();
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            _serverEvents = null;
            
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _serverEvents.RegisterEvents();
        }

        private void UnregisterEvents()
        {
            _serverEvents.UnregisterEvents();
        }
    }
}
