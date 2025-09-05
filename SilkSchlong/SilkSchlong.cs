using System;
using System.Threading;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;

using Buttplug.Client;
using GlobalEnums;
using HarmonyLib;
using UnityEngine;

namespace SilkSchlong
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class SilkSchlongMod : BaseUnityPlugin
    {
        private const string modGUID = "com.nonpolynomial.silkschlong";
        private const string modName = "SilkSchlong";
        private const string modVersion = "0.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);
        internal static ManualLogSource ModLogger;
        internal static ButtplugClient Client = new ButtplugClient("SilkSchlong");

        public static SilkSchlongMod Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            harmony.PatchAll();
            ModLogger = BepInEx.Logging.Logger.CreateLogSource(modName);
            ModLogger.LogInfo($"Plugin {modName} is loaded!");
            Task.Run(async () => await Client.ConnectAsync(new ButtplugWebsocketConnector(new Uri("ws://localhost:12345"))));
        }

        private static async Task RunVibration(int vibeTime)
        {
            if (Client.Connected)
            {
                foreach (var device in Client.Devices)
                {
                    if (device.VibrateAttributes.Count == 0)
                    {
                        continue;
                    }

                    await device.VibrateAsync(1.0);
                    await Task.Delay(vibeTime);
                    await device.VibrateAsync(0.0);
                }
            }
        }
        
        [HarmonyPatch(typeof(HeroController), "AddSilk", new Type[] {typeof(int), typeof(bool), typeof(SilkSpool.SilkAddSource), typeof(bool)})]
        class HeroController_AddSilk_Patch
        {
            [HarmonyPrefix]
            public static void Prefix(int amount, bool heroEffect, SilkSpool.SilkAddSource source, bool forceCanBindEffect)
            {
                ModLogger.LogInfo($"Adding silk: {amount}");
                Task.Run(async () => await RunVibration(250));
            }
        }

        [HarmonyPatch(typeof(HeroController), "BindCompleted")]
        class HeroController_BindCompleted_Patch
        {
            [HarmonyPrefix]
            public static void Prefix()
            {
                ModLogger.LogInfo($"Bind Completed");
                Task.Run(async () => await RunVibration(1000));
            }
        }
    }
}