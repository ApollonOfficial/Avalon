using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "GameData", menuName = "Game/New GameData")]
public class GameData : ScriptableObject
{
    private bool _IsRightID => IsRightID();
    [SerializeField] private List<ItemData> _ItemsList = new List<ItemData>();

    [SerializeField][HideIf(nameof(_IsRightID))][ReadOnly] private string _warning = "WrongID";
    public List<ItemData> ItemsList => _ItemsList;

    private bool IsRightID()
    {
        for(int i = 0; i < _ItemsList.Count; i++)
        {
            if(_ItemsList[i] != null)
            {
                if(i != _ItemsList[i].Base.Id)
                {
                    _warning = "WrongID: " + i.ToString();
                    return false;
                }
            }
        }
        return true;
    }
}
