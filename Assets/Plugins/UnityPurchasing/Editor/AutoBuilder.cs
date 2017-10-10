using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
 
public static class AutoBuilder {
 
	static string GetProjectName()
	{
		string[] s = Application.dataPath.Split('/');
		return s[s.Length - 2];
	}
 
	static string[] GetScenePaths()
	{
		string[] scenes = new string[EditorBuildSettings.scenes.Length];
 
		for(int i = 0; i < scenes.Length; i++)
		{
			scenes[i] = EditorBuildSettings.scenes[i].path;
		}
 
		return scenes;
	}

    static void PerformWindowsUniversalBuild()
        {

        	EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WSA, BuildTarget.WSAPlayer);
        	EditorUserBuildSettings.SetWSADotNetNative(WSABuildType.Debug, true);
        	EditorUserBuildSettings.wsaBuildAndRunDeployTarget = WSABuildAndRunDeployTarget.LocalMachineAndWindowsPhone;
        	EditorUserBuildSettings.wsaSDK = WSASDK.UWP;
        	EditorUserBuildSettings.wsaSubtarget = WSASubtarget.AnyDevice;
        	EditorUserBuildSettings.wsaUWPBuildType = WSAUWPBuildType.XAML;
        	EditorUserBuildSettings.wsaUWPSDK = "10.0.10586.0";
        	BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/WindowsUniversal", BuildTarget.WSAPlayer, BuildOptions.None);
        }

	static void PerformWin64Build ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows);
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/Win64/" + GetProjectName() + ".exe",BuildTarget.StandaloneWindows64,BuildOptions.None);
	}
 
	static void PerformMacBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneOSXUniversal);
	    PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Standalone, "com.unity3d.unityiap.mac.demo");
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/OSX-Universal/" + GetProjectName() + "_mac.app",BuildTarget.StandaloneOSXUniversal,BuildOptions.None);
	}
 
	static void PerformFacebookWebglBuild ()
	{		
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Facebook, BuildTarget.WebGL);
		//EditorUserBuildSettings.facebookCreatePackageForSubmission = true;
		//EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Facebook, BuildTarget.StandaloneWindows);	

		PlayerSettings.Facebook.sdkVersion = "7.9.4";
		List<string> appIds = new List<string>();
		appIds.Add("339961179753667");
		Facebook.Unity.Settings.FacebookSettings.AppIds = appIds;
				
		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = GetScenePaths();
        buildPlayerOptions.locationPathName = "Builds/facebook";
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.targetGroup = BuildTargetGroup.Facebook;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
	}

	static void PerformiOSBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.iOS, BuildTarget.iOS);
	    PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, "com.unity3d.unityiap.demo");
	    PlayerSettings.iOS.appleDeveloperTeamID = "3XGDM87KDL";
	    PlayerSettings.iOS.appleEnableAutomaticSigning = true;
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/iOS",BuildTarget.iOS, BuildOptions.None);
	}

	static void PerformResetNonConsumableBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
		PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.eight.bit.avenue.amorcam");
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/reset_non_consumable.apk", BuildTarget.Android,BuildOptions.None);
	}

	static void PerformXiaomiBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
		PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.unity.channel.sdk.sample");
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/xiaomi.apk",BuildTarget.Android,BuildOptions.None);
	}

	static void PerformCloudMoolahBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
		PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.eight.bit.avenue.amorcam");
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/cloud_moolah.apk",BuildTarget.Android,BuildOptions.None);
	}
	
	static void PerformDoubleInitBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
		PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.eight.bit.avenue.amorcam");
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/double_init.apk",BuildTarget.Android,BuildOptions.None);
	}

	static void PerformUnknownProdBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
		PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.eight.bit.avenue.amorcam");
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/unknown_prod.apk",BuildTarget.Android,BuildOptions.None);
	}
	
	static void PerformGooglePlayIl2cppBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
		PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.eight.bit.avenue.amorcam");
		PlayerSettings.SetPropertyInt( "ScriptingBackend", (int)ScriptingImplementation.IL2CPP, BuildTargetGroup.Android);
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/google_play.apk",BuildTarget.Android,BuildOptions.None);
	}

	static void PerformGooglePlayBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
		PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.eight.bit.avenue.amorcam");
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/google_play.apk",BuildTarget.Android,BuildOptions.None);
	}
	
	static void PerformFrenchLocaleBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
		PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.eight.bit.avenue.amorcam");
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/fr_locale.apk",BuildTarget.Android,BuildOptions.None);
	}
	
	static void PerformGalaxyPassBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
		PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.unity.purchasing.samsungappsbasic");
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/galaxy_pass.apk",BuildTarget.Android, BuildOptions.None);
	}

	static void PerformGalaxyFailBuild ()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
		PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.unity.purchasing.samsungappsbasic");
		BuildPipeline.BuildPlayer(GetScenePaths(), "Builds/galaxy_fail.apk",BuildTarget.Android, BuildOptions.None);
	}
}
