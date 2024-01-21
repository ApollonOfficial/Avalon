using System.Collections.Generic;
using UnityEngine;

public abstract class Buffeble : MonoBehaviour
{
    public abstract void AddBuff(Buff buff, BuffUI buffUI);
    public abstract void RemoveBuff(Buff buff, out BuffUI buffUI);
    public abstract void Countdown(Buff buff);

    public Buff GetBuff(int number) => ActiveBuffs[number];

    public void SetBuffUI(Buff buff, BuffUI buffUI)
    {
        buffUI.SetIcon(buff.GetIcon());
        buffUI.transform.SetParent(BuffTable);
        buffUI.transform.localScale = Vector3.one;
    }

    public virtual Transform BuffTable{get;}
    public virtual List<Buff> ActiveBuffs {get;set;}
}
