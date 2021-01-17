namespace Oxide.Plugins
{
    [Info("PowerlessNeon", "MNGO", "1.0.0")]
    [Description("Allows neon signs to function without power.")]

    class PowerlessNeon : RustPlugin
    {
        //Sets power on plugin load
        void OnServerInitialized()
        {
            ChangePower(100);
        }
        //Make panels require 0 power on placement
        void OnEntitySpawned(NeonSign Neon)
        {
            Neon.UpdateHasPower(100, 1);
            Neon.SendNetworkUpdateImmediate();
        }

        //Make existing panels require 0 power on load
        void ChangePower(int amt)
        {
            foreach(var Neon in UnityEngine.Object.FindObjectsOfType<NeonSign>())
            {
                Neon.UpdateHasPower(amt, 1);
                Neon.SendNetworkUpdateImmediate();
            }
        }
        //Reverts to normal on plugin unload
        void Unload()
        {
            ChangePower(0);
        }
    }
}
