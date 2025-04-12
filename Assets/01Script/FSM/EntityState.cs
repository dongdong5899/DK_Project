using DKProject.FSM;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.Entities.Components
{
    public class EntityState : MonoBehaviour, IEntityComponent
    {
        public string CurrentState { get; private set; }

        [SerializeField] private EntityStateListSO _startStateList;
        [SerializeField] private StateSO _startState;

        private Dictionary<string, StateBase> _stateDictionary;

        public void Initialize(Entity entity)
        {
            CurrentState = _startState.StateName;

            foreach (StateSO stateSO in _startStateList.states)
            {
                try
                {
                    Type type = Type.GetType($"{entity.GetType().FullName}{stateSO.StateName}State");
                    StateBase stateBase = Activator.CreateInstance(type) as StateBase;

                    _stateDictionary.Add(stateSO.StateName, stateBase);
                }
                catch
                {
                    Debug.LogWarning($"{stateSO.name}");
                }
            }
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
