using System;

[Serializable]
public class StateMachine
{
    public delegate void StateAction(out Action action, out Action onExecute1, out Action onExit1);

    // To know which state is currently in
    public string name;

    private Action _onEnter, _onExecute, _onExit;

    public void Execute()
    {
        _onExecute?.Invoke();
    }

    public void ChangeState(StateAction stateAction)
    {
        _onExit?.Invoke();
        stateAction.Invoke(out _onEnter, out _onExecute, out _onExit);
        _onEnter?.Invoke();

#if UNITY_EDITOR
        // To know which state is currently in
        name = stateAction.Method.Name;
#endif
    }
}
