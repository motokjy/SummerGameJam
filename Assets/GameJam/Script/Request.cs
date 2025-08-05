using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Request", menuName = "Quest/Request")]
public class Request : ScriptableObject
{
    public string requestText;
    public int requestReward;
    public string prefabName; // プレハブ名（Hierarchy上のオブジェクト名と一致させる）
}
