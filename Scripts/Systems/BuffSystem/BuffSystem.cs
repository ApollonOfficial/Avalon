using System.Collections.Generic;
using UnityEngine;

public class BuffSystem : MonoBehaviour
{
    public static BuffSystem buffSystem;

    [SerializeField] private Transform _PoolUI;
    [SerializeField] private BuffUI _PrefabBuffUI;

    private List<Buffeble> _entities = new List<Buffeble>();
    private Queue<BuffUI> _buffsUI = new Queue<BuffUI>();

    private void Awake()
    {
        buffSystem = this;
        for(int n_buffsUI = 0; n_buffsUI < 15; n_buffsUI++)
        {
            _buffsUI.Enqueue(Instantiate(_PrefabBuffUI, _PoolUI));
        }
    }

    public void AddBuffOnEntity(Buffeble entity, Buff buff)
    {
        if(!IsBuffOnEntityAlreadyExists(entity, buff, out Buff activeBuff))
        {
            if(_buffsUI.TryDequeue(out BuffUI buffUI))
            {
                entity.AddBuff(buff, buffUI);
                if(!IsEntityAlreadyExists(entity))
                {
                    _entities.Add(entity);
                }
            }
        }
        else
        {
            activeBuff.AddTime(buff.LastTime);
        }
    }

    public void AddBuffOnEntity(Buffeble[] entities, Buff buff)
    {
        for(int n_entity = 0; n_entity < entities.Length; n_entity++)
        {
            AddBuffOnEntity(entities[n_entity], buff);
        }
    }

    private void Update()
    {
        if(GameTime.IsPause)
            return;

        for(int n_entity = 0; n_entity < _entities.Count; n_entity++)
        {
            for(int n_buff = 0; n_buff < _entities[n_entity].ActiveBuffs.Count; n_buff++)
            {
                if(_entities[n_entity].ActiveBuffs[n_buff].LastTime > 0)
                {
                    _entities[n_entity].Countdown(_entities[n_entity].GetBuff(n_buff));
                }
                else
                {
                    _entities[n_entity].RemoveBuff(_entities[n_entity].GetBuff(n_buff), out BuffUI _buffUI);
                    _buffUI.transform.SetParent(_PoolUI);
                    _buffsUI.Enqueue(_buffUI);
                }
            }
        }
    }

    private bool IsEntityAlreadyExists(Buffeble entity)
    {
        foreach(Buffeble _entity in _entities)
        {
            if(_entity == entity)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsBuffOnEntityAlreadyExists(Buffeble entity, Buff buff, out Buff activeBuff)
    {
        activeBuff = null;
        foreach(Buff _buff in entity.ActiveBuffs)
        {
            if(_buff.BuffType == buff.BuffType)
            {
                activeBuff = _buff;
                return true;
            }
        }
        return false;
    }

    private BuffSystem()
    {}
}
