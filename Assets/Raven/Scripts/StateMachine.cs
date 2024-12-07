namespace TheProblem
{
    public class StateMachine
    {
        //TODO: Change to getter and setter after testing **
        public State currentState;
        public BossLogic boss;

        public void Initialize(BossLogic b, State initialState)
        {
            boss = b;
            ChangeState(initialState);
        }

        public void ChangeState(State newState)
        {
            currentState?.ExitState();
            currentState = newState;
            currentState.EnterState();
        }

        public void Update()
        {
            currentState?.UpdateState();
        }
    }

    public class State
    {
        protected StateMachine myStateMachine;
        public State(StateMachine m)
        {
            myStateMachine = m;
        }
        public virtual void UpdateState()
        {

        }
        public virtual void EnterState()
        {

        }

        public virtual void ExitState()
        {

        }

    }
}
