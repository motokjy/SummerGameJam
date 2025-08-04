using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RequestDataBase", menuName = "Quest/RequestDataBase")]
public class RequestDataBase : ScriptableObject
{
    public List<Request> requests = new List<Request>();
}