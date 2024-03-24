using UnityEngine.InputSystem;

namespace _Game._Scripts.Player
{
    public class InputManager : PersistentSingleton<InputManager>
    {
        private PlayerInputActions playerInputActions;
        public InputAction move {get; private set;}
        public InputAction jump {get; private set;}
        public InputAction skill1 {get; private set;}
        public InputAction skill2 {get; private set;}
        public InputAction skill3 {get; private set;}
        public InputAction skill4 {get; private set;}
        public InputAction skill5 {get; private set;}
        public InputAction attack { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            playerInputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            move = playerInputActions.Player.Move;
            move.Enable();

            jump = playerInputActions.Player.Jump;
            jump.Enable();

            skill1 = playerInputActions.Player.Skill1;
            skill1.Enable();

            skill2 = playerInputActions.Player.Skill2;
            skill2.Enable();

            skill3 = playerInputActions.Player.Skill3;
            skill3.Enable();

            skill4 = playerInputActions.Player.Skill4;
            skill4.Enable();

            skill5 = playerInputActions.Player.Skill5;
            skill5.Enable();

            attack = playerInputActions.Player.Attack;
            attack.Enable();
        }

        private void OnDisable()
        {
            move.Disable();
            jump.Disable();
            skill1.Disable();
            skill2.Disable();
            skill3.Disable();
            skill4.Disable();
            skill5.Disable();
            attack.Disable();
        }
    }
}