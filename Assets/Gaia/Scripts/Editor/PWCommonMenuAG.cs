﻿// Copyright © 2018 Procedural Worlds Pty Limited.  All Rights Reserved.
using UnityEngine;
using UnityEditor;
using GaiaCommon1;

namespace GaiaCommon1.Internal
{
    public class CommonMenu : Editor
    {

        /// <summary>
        /// Show Discord
        /// </summary>
        [MenuItem("Window/" + PWConst.COMMON_MENU + "/Show Discord, Have a Chat...", false, 120)]
        public static void ShowDiscord()
        {
            Application.OpenURL(PWConst.DISCORD_LINK);
        }

        /// <summary>
        /// Show PW assets
        /// </summary>
        [MenuItem("Window/" + PWConst.COMMON_MENU + "/Show Procedural Worlds Assets...", false, 121)]
        public static void ShowAssetStore()
        {
            Application.OpenURL(PWConst.ASSETS_LINK);
        }

        /// <summary>
        /// Show review option
        /// </summary>
        [MenuItem("Window/" + PWConst.COMMON_MENU + "/Show Procedural Worlds(SECTR) Assets...", false, 122)]
        public static void ShowAssetStoreSectr()
        {
            Application.OpenURL(PWConst.SECTR_ASSETS_LINK);
        }
    }
}
