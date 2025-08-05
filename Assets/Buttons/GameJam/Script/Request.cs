using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Request", menuName = "Quest/Request")]
public class Request : ScriptableObject
{
    public string requestText;
    public int requestReward;
}
