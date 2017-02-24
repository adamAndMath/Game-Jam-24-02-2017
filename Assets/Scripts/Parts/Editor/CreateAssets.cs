using UnityEditor;
using UnityEngine;

public class CreateAssets
{
    [MenuItem("Assets/Create/Move Part")]
    public static void CreatePartMove()
    {
        ProjectWindowUtil.CreateAsset(ScriptableObject.CreateInstance<PartMove>(), "partMove.asset");
    }
}
