using System;
using System.Linq;
using BuildConfig;
using UnityEditor;

namespace SampleNamespace
{
    public static class BuildMenu
    {
        [MenuItem("Build/Build Server")]
        public static void BuildServer()
        {
            var buildConfigGuid =
                AssetDatabase.FindAssets("Server.Release").SingleOrDefault()
                ?? throw new InvalidOperationException("Server.Release.asset not found");

            var buildConfigPath = AssetDatabase.GUIDToAssetPath(buildConfigGuid);
            var buildConfig = AssetDatabase.LoadAssetAtPath<BuildConfiguration>(buildConfigPath);

            Build.BuildWithConfig(buildConfig);
        }
    }
}
