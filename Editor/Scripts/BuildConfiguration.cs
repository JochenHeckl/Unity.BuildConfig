using System;
using UnityEditor;
using UnityEngine;

namespace BuildConfig
{
    [Serializable]
    [CreateAssetMenu(fileName = "New BuildConfig.asset", menuName = "Build/Create BuildConfig")]
    public class BuildConfiguration : ScriptableObject
    {
        public SceneAsset[] scenes = { };
        public string assetBundleManifestPath = "";
        public string[] extraScriptingDefines;
        public string outputDirectory = "Build/MyProject.exe";
        public BuildOptions buildOptions;
        public BuildTarget target;
        public StandaloneBuildSubtarget subtarget;
        public BuildTargetGroup targetGroup;

        [Header("BuildTarget Config")]
        public BuildTargetGroup namedBuildTarget;
        public ScriptingImplementation scriptingImplementation;
        public ApiCompatibilityLevel apiCompatibilityLevel;
        public Il2CppCompilerConfiguration il2CppCompilerConfiguration;
    }
}
