using UnityEngine;
using System;
using System.Collections;


/**
 * Attribute to expose a public property in the Unity inspector.
 * Keep in mind that changes to actual variables are only saved if
 * they are serialized by Unity. A variable is serialized if it is
 * either public, or using the [SerializeField] attribute.
 * Using the [SerializeField] attribute causes Unity to display it 
 * in the inspector. You can counteract this by also using the 
 * [HideInInspector] attribute.
 *
 * Example usage:
 *
 * [HideInInspector] [SerializeField]
 * protected bool _visible = true;
 * 
 * [ExposeProperty]
 * public virtual bool visible
 * {
 *     get { return _visible; }
 *     set { _visible = value; OnVisibilityChanged(_visible); }
 * }
 */
[AttributeUsage( AttributeTargets.Property )]
public class ExposePropertyAttribute : PropertyAttribute
{
 
}
