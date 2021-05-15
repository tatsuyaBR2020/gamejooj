using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DB
{
    public string nome;
    public string descricao;
    public GameObject itemPrefab;
}

[CreateAssetMenu(fileName = "New DataBase",menuName ="DataBaseItems")]
public class Database : ScriptableObject
{
    public List<DB> itens = new List<DB>();
}
