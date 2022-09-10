using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using Respawning;
using UnityEngine;

namespace SpawnLights.Events
{
    public class ServerEvents
    {
        private readonly Config _config;

        public ServerEvents(Config config)
        {
            _config = config;
        }

        public void RegisterEvents()
        {
            Exiled.Events.Handlers.Server.RespawningTeam += OnRespawningTeam;
        }

        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RespawningTeam -= OnRespawningTeam;
        }
        
        private void OnRespawningTeam(RespawningTeamEventArgs e)
        {
            if (e.Players.Count < 1)
                return;

            Room surfaceRoom = Room.Get(RoomType.Surface);
            surfaceRoom.TurnOffLights(0.25f);

            if (e.NextKnownTeam == SpawnableTeamType.NineTailedFox)
                surfaceRoom.Color = Color.blue;
            else if (e.NextKnownTeam == SpawnableTeamType.ChaosInsurgency)
                surfaceRoom.Color = Color.green;
            
            Timing.CallDelayed(_config.TimeEnabled, () =>
            {
                surfaceRoom.TurnOffLights(0.25f);
                surfaceRoom.ResetColor();
            });
        }
    }
}