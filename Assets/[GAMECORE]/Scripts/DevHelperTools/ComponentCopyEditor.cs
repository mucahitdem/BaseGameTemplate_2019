﻿#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class ComponentCopyEditor : EditorWindow
{
    private readonly List<GameObject> selectedTargetObjects = new List<GameObject>();
    private GameObject newSourceObject;
    private bool[] selectedComponents;
    private Component[] sourceComponents;
    private GameObject sourceObject;

    [MenuItem("Tools/Sefir-i Mevt Games/Dev Tools/Multiple Component Copy Editor")]
    public static void ShowWindow()
    {
        GetWindow<ComponentCopyEditor>("Component Copy Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("SelectStateModify Source Object", EditorStyles.boldLabel);
        newSourceObject =
            EditorGUILayout.ObjectField("Source Object", newSourceObject, typeof(GameObject), true) as GameObject;
        if (sourceObject != newSourceObject)
        {
            sourceObject = newSourceObject;
            RefreshComponentList();
        }

        GUILayout.Space(10);

        GUILayout.Label("SelectStateModify Target Objects", EditorStyles.boldLabel);

        if (GUILayout.Button("Add Target Objects")) AddSelectedTargetObjects();

        if (selectedTargetObjects.Count > 0)
        {
            EditorGUILayout.LabelField("Selected Target Objects:");

            for (var i = 0; i < selectedTargetObjects.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                selectedTargetObjects[i] =
                    EditorGUILayout.ObjectField(selectedTargetObjects[i], typeof(GameObject), true) as GameObject;
                if (GUILayout.Button("Remove")) RemoveTargetObject(i);
                EditorGUILayout.EndHorizontal();
            }
        }

        GUILayout.Space(10);

        GUILayout.Label("SelectStateModify Components to Copy", EditorStyles.boldLabel);
        if (GUILayout.Button("Refresh Component List")) RefreshComponentList();

        if (sourceComponents != null && sourceComponents.Length > 0)
        {
            EditorGUILayout.LabelField("Selected Components:");

            for (var i = 0; i < sourceComponents.Length; i++)
                selectedComponents[i] =
                    EditorGUILayout.ToggleLeft(sourceComponents[i].GetType().Name, selectedComponents[i]);
        }

        GUILayout.Space(10);

        EditorGUI.BeginDisabledGroup(selectedComponents == null || selectedComponents.Length == 0 ||
                                     selectedTargetObjects.Count == 0);
        if (GUILayout.Button("Copy Components")) CopyComponentsToTargets();
        EditorGUI.EndDisabledGroup();


        EditorGUI.BeginDisabledGroup(selectedTargetObjects.Count == 0);
        if (GUILayout.Button("Remove All Target Objects")) RemoveAllTargetObjects();
        EditorGUI.EndDisabledGroup();
    }

    private void AddSelectedTargetObjects()
    {
        var selectedObjects = Selection.gameObjects;
        selectedTargetObjects.AddRange(selectedObjects);
    }

    private void RemoveTargetObject(int index)
    {
        selectedTargetObjects.RemoveAt(index);
    }

    private void RefreshComponentList()
    {
        if (newSourceObject == null)
        {
            Debug.LogError("Source Object not selected!");
            return;
        }

        sourceComponents = newSourceObject.GetComponents<Component>();
        selectedComponents = new bool[sourceComponents.Length];
    }

    private void CopyComponentsToTargets()
    {
        if (newSourceObject == null)
        {
            Debug.LogError("Source Object not selected!");
            return;
        }

        if (selectedTargetObjects == null || selectedTargetObjects.Count == 0)
        {
            Debug.LogError("Target Objects not selected!");
            return;
        }

        for (var i = 0; i < sourceComponents.Length; i++)
            if (selectedComponents[i])
            {
                ComponentUtility.CopyComponent(sourceComponents[i]);

                foreach (var targetObject in selectedTargetObjects) ComponentUtility.PasteComponentAsNew(targetObject);
            }

        Debug.Log("Components copied successfully!");
    }

    private void RemoveAllTargetObjects()
    {
        selectedTargetObjects.Clear();
    }
}

#endif