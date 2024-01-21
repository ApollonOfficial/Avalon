using UnityEngine;

public interface IEntity
{
    public abstract Movement Movement{get;}
    public abstract Stats Stats{get;}
    public abstract Animator Animator{get;}
    public abstract float Horizontal{get;}
}
