using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu]
public class ActionMap : ScriptableObject
{
	public string Title;
	public InputAction[] actions;

	private static List<T> FindAssetsByType<T>() where T : UnityEngine.Object
    {
    List<T> assets = new List<T>();
    string[] guids = AssetDatabase.FindAssets(string.Format("t:{0}", typeof (T).ToString().Replace("UnityEngine.", "")));
        for( int i = 0; i < guids.Length; i++ )
    {
        string assetPath = AssetDatabase.GUIDToAssetPath( guids[i] );
        T asset = AssetDatabase.LoadAssetAtPath<T>( assetPath );
        if( asset != null )
        {
            assets.Add(asset);
        }
    }
    return assets;
    }

    public static List<ActionMap> GetAllActionMaps()
    {
        return FindAssetsByType<ActionMap>();
    }
}
