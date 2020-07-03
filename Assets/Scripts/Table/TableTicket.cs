using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TableTicket", menuName = "ScriptableObject/TableTicket")]
public sealed class TableTicket : ScriptableObject
{
    [Serializable]
    public sealed class Data
    {
        public int Level;
        
        [Tooltip("해당 레벨이 만족되면 주어지는 티켓 수량")]
        public int Ticket;
    }

    public List<Data> Datas;
}