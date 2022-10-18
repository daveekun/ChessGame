using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class testEditor : EditorWindow
{
    [MenuItem("Window/testing")]
    static void OpenWindow()
    {
        testEditor window = (testEditor)GetWindow(typeof(testEditor));
        window.minSize = new Vector2(600,600);
        window.Show();
    }
}
