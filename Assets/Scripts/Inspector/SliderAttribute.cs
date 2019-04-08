using System;
using UnityEngine;
using UnityEditor;



/// <summary>
/// Displays a field as a Slider in the inspector.
/// </summary>
public class SliderAttribute : PropertyAttribute
{
    public float min;
    public float max;

    public SliderAttribute(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}

[CustomPropertyDrawer(typeof(SliderAttribute))]
public class SliderDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SliderAttribute slider = attribute as SliderAttribute;

        switch (property.propertyType)
        {
            case SerializedPropertyType.Integer:
                EditorGUI.IntSlider(position, property, Convert.ToInt32(slider.min), Convert.ToInt32(slider.max), label);
                break;

            case SerializedPropertyType.Float:
                EditorGUI.Slider(position, property, slider.min, slider.max, label);
                break;

            default:
                EditorGUI.LabelField(position, label.text, "Slider only works with float or int.");
                break;
        }
    }
}
