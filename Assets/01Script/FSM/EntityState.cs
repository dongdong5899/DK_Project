using DKProject.FSM;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Entities.Components
{
    public class EntityState : MonoBehaviour, IEntityComponent, IAfterInitable
    {
        public string CurrentState { get; private set; }

        [SerializeField] private EntityStateListSO _startStateList;
        [SerializeField] private StateSO _startState;

        private Dictionary<string, StateBase> _stateDictionary;

        private Entity _entity;

        public void Initialize(Entity entity)
        {
            _entity = entity;
        }

        public void AfterInit()
        {
            _stateDictionary = new Dictionary<string, StateBase>();
            foreach (StateSO stateSO in _startStateList.states)
            {
                string className = $"DKProject.FSM.{stateSO.StateTarget}{stateSO.StateName}State";
                try
                {
                    Type type = Type.GetType(className);
                    StateBase stateBase = Activator.CreateInstance(type, _entity, stateSO.animParamSO) as StateBase;

                    _stateDictionary.Add(stateSO.StateName, stateBase);
                }
                catch (Exception ex)
                {
                    Debug.LogWarning($"{className}\nError : {ex.ToString()}");
                }
            }
            CurrentState = _startState.StateName;

            _stateDictionary[CurrentState].Enter();
        }

        public void ChangeState(StateSO stateSO)
        {
            _stateDictionary[CurrentState].Exit();
            CurrentState = stateSO.StateName;
            _stateDictionary[CurrentState].Enter();
        }
        public void ChangeState(string stateName)
        {
            _stateDictionary[CurrentState].Exit();
            CurrentState = stateName;
            _stateDictionary[CurrentState].Enter();
        }

        public void Update()
        {
            _stateDictionary[CurrentState].Update();
        }
    }
}
