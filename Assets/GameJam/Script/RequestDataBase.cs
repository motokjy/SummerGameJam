using System.Collections.Generic;
using UnityEngine;

namespace TechC
{
    [CreateAssetMenu(fileName = "CharPrefabDatabase", menuName = "Test")]
    public class CharPrefabDatabase : ScriptableObject
    {
        public List<string> requestText=new List<string>();
    }
}
