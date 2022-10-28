using System.Collections.Generic;
using Singleton;
using UnityEngine;

namespace Player
{
    public class StackList : Singleton<StackList>
    {
        public List<GameObject> stack = new List<GameObject>();
    }
}
