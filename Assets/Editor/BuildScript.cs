using UnityEditor;
using System.Collections.Generic;
using System.Diagnostics;
using System;

class MyEditorScript {
        static string[] SCENES = FindEnabledEditorScenes();

        static string APP_NAME = "unity-test";
        static string TARGET_DIR = "target";

        [MenuItem ("MyTools/Basic Windows Build")]
        static void PerformWindowsBuild ()
        {
                 string target_dir = APP_NAME + ".exe";
                 GenericBuild(SCENES, TARGET_DIR + "/" + target_dir, BuildTarget.StandaloneWindows, BuildOptions.None);
        }

    private static string[] FindEnabledEditorScenes() {
        List<string> EditorScenes = new List<string>();
        foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
            if (!scene.enabled) continue;
            EditorScenes.Add(scene.path);
        }
        return EditorScenes.ToArray();
    }

        static void GenericBuild(string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
        {
                EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
                var res = BuildPipeline.BuildPlayer(scenes,target_dir,build_target,build_options);
                if (res.summary.totalErrors > 0) {
                        throw new Exception("BuildPlayer failure: " + res.name);
                }
        }
}