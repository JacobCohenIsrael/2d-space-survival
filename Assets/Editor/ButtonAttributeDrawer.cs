using Gamefather.Attributes;
using UnityEditor;
using UnityEngine;

namespace Gamefather.Editor
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class ButtonAttributeDrawer : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var methods = target.GetType().GetMethods();
            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(ButtonAttribute), true);
                if (attributes.Length > 0)
                {
                    var buttonAttribute = (ButtonAttribute)attributes[0];
                    if (GUILayout.Button(buttonAttribute.buttonName))
                    {
                        method.Invoke(target, null);
                    }
                }
            }
        }
    }
}