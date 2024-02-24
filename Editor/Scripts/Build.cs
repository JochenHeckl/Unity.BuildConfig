using System.IO;
using System.Linq;
using Unity.Logging;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace BuildConfig
{
    public static class Build
    {
        private static DirectoryInfo ProjectPath => Directory.GetParent(Application.dataPath);

        public static void BuildWithConfig(BuildConfiguration buildConfig)
        {
            ApplyPlayerSettings(buildConfig);

            var buildOptions = new BuildPlayerOptions
            {
                assetBundleManifestPath = Path.Combine(
                    ProjectPath.FullName,
                    buildConfig.assetBundleManifestPath
                ),
                extraScriptingDefines = buildConfig.extraScriptingDefines,
                locationPathName = Path.Combine(ProjectPath.FullName, buildConfig.outputDirectory),
                options = buildConfig.buildOptions,
                scenes = buildConfig.scenes.Select(AssetDatabase.GetAssetPath).ToArray(),
                subtarget = (int)buildConfig.subtarget,
                target = buildConfig.target,
                targetGroup = buildConfig.targetGroup
            };

            var buildReport = BuildPipeline.BuildPlayer(buildOptions);
            Log.Info("BuildResult: {BuildResult}", buildReport.summary.result);

            if (buildReport.summary.result == BuildResult.Succeeded)
            {
                Log.Info("Artifacts written to: {OutPutPath}", buildReport.summary.outputPath);
            }
        }

        private static void ApplyPlayerSettings(BuildConfiguration buildConfig)
        {
            PlayerSettings.SetScriptingBackend(
                NamedBuildTarget.FromBuildTargetGroup(buildConfig.namedBuildTarget),
                buildConfig.scriptingImplementation
            );

            PlayerSettings.SetIl2CppCompilerConfiguration(
                NamedBuildTarget.FromBuildTargetGroup(buildConfig.namedBuildTarget),
                buildConfig.il2CppCompilerConfiguration
            );

            PlayerSettings.SetApiCompatibilityLevel(
                NamedBuildTarget.FromBuildTargetGroup(buildConfig.namedBuildTarget),
                buildConfig.apiCompatibilityLevel
            );

            PlayerSettings.SetApiCompatibilityLevel(
                NamedBuildTarget.FromBuildTargetGroup(buildConfig.namedBuildTarget),
                buildConfig.apiCompatibilityLevel
            );
        }
    }
}
