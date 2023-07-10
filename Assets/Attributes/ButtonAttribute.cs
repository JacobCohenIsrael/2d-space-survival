using System;
using UnityEngine;

namespace Gamefather.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ButtonAttribute : PropertyAttribute
    {
        public string buttonName;

        public ButtonAttribute(string buttonName)
        {
            this.buttonName = buttonName;
        }
    }
}
