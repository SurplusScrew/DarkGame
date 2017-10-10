using UnityEngine;

public class UtilMaths
{
    public static Vector2 V3toV2_XZ(Vector3 v)
    {
        return new Vector2(v.x, v.z);
    }
    public static Vector2 V3toV2_XY(Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }
    public static Vector2 V3toV2_YZ(Vector3 v)
    {
        return new Vector2(v.y, v.z);
    }
    public static Vector3 V2toV3_XZ(Vector2 v, float y = 0)
    {
        return new Vector3(v.x, y, v.y);
    }
    public static Vector3 V2toV3_XY(Vector3 v, float z = 0)
    {
        return new Vector3(v.x, v.y, z);
    }
    public static Vector3 V2toV3_YZ(Vector3 v, float x = 0)
    {
        return new Vector3(x, v.x, v.y);
    }
}
