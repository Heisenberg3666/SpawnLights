using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using Respawning;
using System.Linq;
using UnityEngine;

namespace SpawnLights
{
    internal class EventHandlers
    {
        public void OnTeamRespawn(RespawningTeamEventArgs ev)
        {
            if (ev.Players.Count == 0)
                return;

            Room surfaceRoom = Room.List.FirstOrDefault(x => x.Type == RoomType.Surface);

            if (surfaceRoom == null)
                return;

            surfaceRoom.TurnOffLights(0.25f);

            if (ev.NextKnownTeam == SpawnableTeamType.NineTailedFox)
            {
                surfaceRoom.Color = Color.blue;
                Log.Debug("mtf");
            }
            if (ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency)
            {
                surfaceRoom.Color = Color.green;
                Log.Debug("chi");
            }

            Timing.CallDelayed(Plugin.Instance.Config.LightTime, () =>
            {
                surfaceRoom.TurnOffLights(0.25f);
                surfaceRoom.ResetColor();
            });
        }
    }
}
