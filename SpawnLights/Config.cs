using Exiled.API.Interfaces;
using System.ComponentModel;

namespace SpawnLights
{
    internal class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("How long do you want the lights to be enabled after a spawn wave?")]
        public float LightTime { get; set; } = 15f;
    }
}
