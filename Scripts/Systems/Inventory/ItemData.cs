using UnityEngine;
using NaughtyAttributes;
using System;

public enum ItemTypes : byte
{
    Key,
    Material,
    Artefact
}

[System.Serializable] public struct Key
{
    public int test;
}
[System.Serializable] public struct Material
{

}
[System.Serializable] public struct Artefact
{
    public enum ArtifactRange : byte
    {
        Mythical,
        Legendary,
        Epic,
        Rare,
        Normal
    }
    public Stats StatsModificated;
    public ArtifactRange Range;
    public bool CanModificated;
    public ItemData MaterialToUpgrade;
}
[System.Serializable] public struct Base
{
    public Sprite Icon;
    public int MaxCount;
    public int Id;
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/New Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] private ItemTypes _type;
    [SerializeField] private Base _base;

    public Base Base => _base;
    public ItemTypes Type => _type;

    private bool _isKey => _type == ItemTypes.Key;
    private bool _isMaterial => _type == ItemTypes.Material;
    private bool _isArtefact => _type == ItemTypes.Artefact;

    [EnableIf(nameof(_isKey))][ShowIf(nameof(_isKey))] public Key Key;
    [EnableIf(nameof(_isMaterial))][ShowIf(nameof(_isMaterial))] public Material Material;
    [EnableIf(nameof(_isArtefact))][ShowIf(nameof(_isArtefact))] public Artefact Artefact;
    private bool isMaterialToUpdateInArtefact => IsMaterialToUpdateInArtefact();
    private bool IsMaterialToUpdateInArtefact()
    {
        if(Artefact.MaterialToUpgrade)
        {
            if(Artefact.MaterialToUpgrade.Type == ItemTypes.Material)
                return true;
        }
        return false;
    }

    [SerializeField][HideIf(nameof(isMaterialToUpdateInArtefact))]
    [ShowIf(nameof(_isArtefact))][ReadOnly] 
    private string _warning = "It isn't material";
}
