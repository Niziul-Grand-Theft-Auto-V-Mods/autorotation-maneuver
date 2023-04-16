using GTA;

namespace Autorotation_maneuver.main_resources.classes
{
    internal class AutorotationMetrics
    {
        internal float GetThrottleUp()
        {
            return _
                   = Game.GetControlValueNormalized(Control.VehicleFlyThrottleUp);
        }

        internal float GetThrottleDown()
        {
            return _
                   = Game.GetControlValueNormalized(Control.VehicleFlyThrottleDown);
        }

        internal float GetVehicleSpeed()
        {
            var currentVehicle
                = Game.Player.Character.CurrentVehicle;

            return _
                   = currentVehicle.Speed;
        }

        internal float GetVehicleVerticalVelocity()
        {
            var currentVehicle
                = Game.Player.Character.CurrentVehicle;

            return _
                   = -currentVehicle.Velocity.Z;
        }
    }
}
