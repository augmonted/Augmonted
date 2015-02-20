
/*==============================================================================
Copyright (c) 2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;
using UnityEditor;

namespace Vuforia.EditorClasses
{
    public class ExtensionImport : AssetPostprocessor
    {
        // This method is called by Unity whenever assets are updated (deleted,
        // moved or added)
        public static void OnPostprocessAllAssets(string[] importedAssets,
                                                  string[] deletedAssets,
                                                  string[] movedAssets,
                                                  string[] movedFromAssetPaths)
        {
            foreach (var importedAsset in importedAssets)
            {
                // if this script is imported, force the Android build settings to ARMv7 only, 
                // as Vuforia does not support native Android x86 and need to run in emulation mode on those devices.
                if (importedAsset.Equals("Assets/Editor/QCAR/Scripts/ExtensionImport.cs"))
                {
                    if (PlayerSettings.Android.targetDevice != AndroidTargetDevice.ARMv7)
                    {
                        Debug.Log("Setting Android target device to ARMv7");
                        PlayerSettings.Android.targetDevice = AndroidTargetDevice.ARMv7;
                    }

#if INCLUDE_IL2CPP
#if UNITY_5_0
                    BuildTargetGroup buildTarget = BuildTargetGroup.iOS;
#else
                    BuildTargetGroup buildTarget = BuildTargetGroup.iPhone;
#endif
                    int scriptingBackend = PlayerSettings.GetPropertyInt("ScriptingBackend", buildTarget);
                    if (scriptingBackend != (int) ScriptingImplementation.IL2CPP)
                    {
                        Debug.Log("Setting iOS scripting backend to IL2CPP to enable 64bit support.");
                        PlayerSettings.SetPropertyInt("ScriptingBackend", (int)ScriptingImplementation.IL2CPP, buildTarget);
                    }
#endif
                }
            }
        }
    }

}
