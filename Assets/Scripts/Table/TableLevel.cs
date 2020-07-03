using System;
using System.Collections.Generic;
using UnityEngine;

public class TableLevel : ScriptableObject
{
    [Serializable]
    public sealed class Data
    {
        public int Level;
        public long MaxExp;
    }
    
    public List<Data> Datas;
}