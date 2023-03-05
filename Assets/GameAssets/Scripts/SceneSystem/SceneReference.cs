using System;
using System.IO;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace GameAssets.Scripts.SceneSystem
{
    [Serializable]
    public class SceneReference : ISerializationCallbackReceiver
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset m_SceneAsset;

#pragma warning disable 0414
        [SerializeField] private bool m_IsDirty;
#pragma warning restore 0414
#endif

        [SerializeField] private string m_ScenePath = string.Empty;


        public string ScenePath
        {
            get
            {
#if UNITY_EDITOR
                AutoUpdateReference();
#endif
                return m_ScenePath;
            }

            set
            {
                m_ScenePath = value;

#if UNITY_EDITOR
                m_SceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(m_ScenePath);
                if (m_SceneAsset == null)
                {
                    Debug.LogError($"Setting {nameof(SceneReference)} to {value}, but no scene could be located there.");
                }
#endif
            }
        }

        public string SceneName => Path.GetFileNameWithoutExtension(ScenePath);

        public SceneReference() { }

        public SceneReference(string scenePath)
        {
            ScenePath = scenePath;
        }

        public SceneReference(SceneReference other)
        {
            m_ScenePath = other.m_ScenePath;

#if UNITY_EDITOR
            m_SceneAsset = other.m_SceneAsset;
            m_IsDirty = other.m_IsDirty;

            AutoUpdateReference();
#endif
        }

        public SceneReference Clone() => new SceneReference(this);

        public override string ToString()
        {
            return m_ScenePath;
        }

        [Obsolete("Needed for the editor, don't use it in runtime code!", true)]
        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            AutoUpdateReference();
#endif
        }

        [Obsolete("Needed for the editor, don't use it in runtime code!", true)]
        public void OnAfterDeserialize()
        {
#if UNITY_EDITOR
            EditorApplication.update += OnAfterDeserializeHandler;
#endif
        }

#if UNITY_EDITOR
        private void OnAfterDeserializeHandler()
        {
            EditorApplication.update -= OnAfterDeserializeHandler;
            AutoUpdateReference();
        }

        private void AutoUpdateReference()
        {
            if (m_SceneAsset == null)
            {
                if (string.IsNullOrEmpty(m_ScenePath))
                    return;

                SceneAsset foundAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(m_ScenePath);
                if (foundAsset)
                {
                    m_SceneAsset = foundAsset;
                    m_IsDirty = true;

                    if (!Application.isPlaying)
                    {
                        EditorSceneManager.MarkAllScenesDirty();
                    }
                }
            }
            else
            {
                string foundPath = AssetDatabase.GetAssetPath(m_SceneAsset);
                if (string.IsNullOrEmpty(foundPath))
                    return;

                if (foundPath != m_ScenePath)
                {
                    m_ScenePath = foundPath;
                    m_IsDirty = true;

                    if (!Application.isPlaying)
                    {
                        EditorSceneManager.MarkAllScenesDirty();
                    }
                }
            }
        }
#endif
    }


#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SceneReference))]
    [CanEditMultipleObjects]
    internal class SceneReferencePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty isDirtyProperty = property.FindPropertyRelative("m_IsDirty");
            if (isDirtyProperty.boolValue)
            {
                isDirtyProperty.boolValue = false;
            }

            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            const float buildSettingsWidth = 20f;
            const float padding = 2f;

            Rect assetPos = position;
            assetPos.width -= buildSettingsWidth + padding;

            Rect buildSettingsPos = position;
            buildSettingsPos.x += position.width - buildSettingsWidth + padding;
            buildSettingsPos.width = buildSettingsWidth;

            SerializedProperty sceneAssetProperty = property.FindPropertyRelative("m_SceneAsset");

            EditorGUI.PropertyField(assetPos, sceneAssetProperty, new GUIContent());

            string guid = string.Empty;
            int indexInSettings = -1;

            if (sceneAssetProperty.objectReferenceValue)
            {
                long localId;
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(sceneAssetProperty.objectReferenceValue, out guid, out localId))
                {
                    indexInSettings = Array.FindIndex(EditorBuildSettings.scenes, s => s.guid.ToString() == guid);
                }
            }

            GUIContent settingsContent = indexInSettings != -1
                ? new GUIContent("-", "Scene is already in the Editor Build Settings. Click here to remove it.")
                : new GUIContent("+", "Scene is missing in the Editor Build Settings. Click here to add it.")
            ;

            Color prevBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = indexInSettings != -1 ? Color.red : Color.green;

            if (GUI.Button(buildSettingsPos, settingsContent, EditorStyles.miniButtonRight) && sceneAssetProperty.objectReferenceValue)
            {
                if (indexInSettings != -1)
                {
                    List<EditorBuildSettingsScene> sceneList = EditorBuildSettings.scenes.ToList();
                    sceneList.RemoveAt(indexInSettings);

                    EditorBuildSettings.scenes = sceneList.ToArray();
                }
                else
                {
                    EditorBuildSettingsScene[] newSceneArray = new EditorBuildSettingsScene[]
                    {
                        new EditorBuildSettingsScene(AssetDatabase.GetAssetPath(sceneAssetProperty.objectReferenceValue), true)
                    };

                    EditorBuildSettings.scenes = EditorBuildSettings.scenes.Concat(newSceneArray).ToArray();
                }
            }

            GUI.backgroundColor = prevBackgroundColor;

            EditorGUI.EndProperty();
        }
    }
#endif
}