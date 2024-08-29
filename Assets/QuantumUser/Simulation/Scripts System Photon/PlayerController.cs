namespace Quantum
{
    using Photon.Deterministic;
    using UnityEngine.Scripting;

    [Preserve]
    public unsafe class PlayerController : SystemMainThreadFilter<PlayerController.Filter>
    {
        public struct Filter
        {
            public EntityRef Entity;
            public Transform2D* Transform;
            public PhysicsBody2D* Body;
        }
        public override void Update(Frame frame, ref Filter filter)
        {
            var input = frame.GetPlayerInput(0);
            UpdatePlayerMovement(frame, ref filter, input);
        }
        private void UpdatePlayerMovement(Frame f, ref Filter filter, Input* input)
        {
            filter.Body->Velocity = input->Direction;
        }

    }
}
