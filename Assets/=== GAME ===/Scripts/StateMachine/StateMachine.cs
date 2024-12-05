using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] List<StateBase> allStates = new List<StateBase>();
    [SerializeField] StateBase currentState;
    public StateBase GetState(State state) => allStates.FirstOrDefault(x => x.State == state);

    public bool debug;
    [ShowIf(nameof(debug))]
    public State targetState;

    [ContextMenu("Change State")]
    public void ChangeState()
    {
        ChangeState(targetState);
    }


    public void InitStateMachine(AnimationControl animControl, State defaultState = State.Idle)
    {
        allStates.ForEach(x => x.OnInit(this, animControl));
        currentState = GetState(defaultState);
        currentState.OnEnter();
    }

    public void ChangeState(State state)
    {
        if (state == currentState.State) return;
        currentState.OnExit();
        currentState = GetState(state);
        currentState.OnEnter();
    }
    private void Update()
    {
        currentState.OnUpdate();
    }
    private void FixedUpdate()
    {
        currentState.OnPhysicUpdate();
    }
}

public abstract class StateBase : MonoBehaviour
{
    protected StateMachine stateMachine;
    protected AnimationControl animationControl;
    public abstract State State { get; }
    public void OnInit(StateMachine stateMachine, AnimationControl animControl)
    {
        this.stateMachine = stateMachine;
        animationControl = animControl;
    }
    public abstract void OnUpdate();

    public abstract void OnPhysicUpdate();

    public abstract void OnEnter();

    public abstract void OnExit();

    public virtual T GetOwner<T>() where T : CharacterBase
    {
        var t = stateMachine.GetComponent<CharacterBase>();
        if (t is T owner)
            return owner;
        throw new InvalidCastException($"Cannot get {typeof(T).Name} from {t.GetType().Name} ");
    }
}

public enum State
{
    Idle,
    Attack,
    Die
}