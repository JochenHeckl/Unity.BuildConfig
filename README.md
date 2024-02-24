# Unity.BuildConfig

Some scripts to simplify setting up a Unity build.

### Create a new config

- Open your Unity Project
- Import this package: Windows -> PackageManager -> +▾ -> "Import package from git url..."
- Click Assets -> Create -> Build -> "Create BuildConfig"
  ![Name BuildConfiguration](/Documentation~/Images/NameConfig.png)
- Name the config appropriately
- create a new File "Editor/BuildMenu.cs"

```csharp
  using System;
  using System.Linq;
  using UnityEditor;
  using BuildConfig;

  namespace SampleNamespace
  {
      public static class BuildMenu
      {
          [MenuItem("Build/<Name your build here>")]
          public static void NameOfYourBuildMethod()
          {
              var buildConfigGuid =
                  AssetDatabase.FindAssets("<Put your buildconfig here (without the .asset extension)>").SingleOrDefault()
                  ?? throw new InvalidOperationException("BuildConfiguration not found");

              var buildConfigPath = AssetDatabase.GUIDToAssetPath(buildConfigGuid);
              var buildConfig = AssetDatabase.LoadAssetAtPath<BuildConfiguration>(buildConfigPath);

              Build.BuildWithConfig(buildConfig);
          }
      }
  }
```

- Configure you build in the inspector
  ![Configure the build](/Documentation~/Images/ConfigureBuild.png)
- Build!
