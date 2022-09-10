using Exiled.API.Interfaces;
using System.ComponentModel;

namespace SpawnLights
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("The time (seconds) that the lights will stay a colour.")]
        public float TimeEnabled { get; set; } = 15f;
    }
}
