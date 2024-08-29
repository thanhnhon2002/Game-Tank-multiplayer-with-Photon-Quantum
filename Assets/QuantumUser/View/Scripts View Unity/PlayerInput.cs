namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine;

    public class PlayerInput : MonoBehaviour
    {
        private void OnEnable()
        {
            QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
        }

        public void PollInput(CallbackPollInput callback)
        {
            Quantum.Input input = new Quantum.Input();
            input.Direction.X = UnityEngine.Input.GetKey(KeyCode.LeftArrow)?-1: UnityEngine.Input.GetKey(KeyCode.RightArrow)?1:0;
            input.Direction.Y = UnityEngine.Input.GetKey(KeyCode.DownArrow)?-1: UnityEngine.Input.GetKey(KeyCode.UpArrow)?1:0;
            input.Attack = UnityEngine.Input.GetKey(KeyCode.Space);
            callback.SetInput(input, DeterministicInputFlags.Repeatable);

        }
    }
}
