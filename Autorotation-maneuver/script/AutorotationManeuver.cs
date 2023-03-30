using GTA;

namespace Autorotation_maneuver.script
{
    [ScriptAttributes(NoDefaultInstance = true)]
    internal sealed class AutorotationManeuver : Script
    {
        public AutorotationManeuver()
        {
            var currentVehicle
                = GetCurrentVehicle();

            Tick    += (o, e) =>
            {
                var isEngineRunning
                    = GetIfEngineIsRunning();

                if (isEngineRunning)
                {
                    return;
                }
                {
                    var helicopterBladesSpeed
                        = GetHelicopterBladesSpeed();

                    var isTheHelicopterInFlight
                        = GetIfTheHelicopterIsInFlight();

                    if (isTheHelicopterInFlight
                        &
                        helicopterBladesSpeed < 1.00f)
                    {
                        var controlVehicleFlyThrottleUpIsPressed
                            = Game
                                .IsControlPressed(Control
                                                    .VehicleFlyThrottleUp);

                        var controlVehicleFlyThrottleDownIsPressed
                            = Game
                                .IsControlPressed(Control
                                                    .VehicleFlyThrottleDown);


                        if (!controlVehicleFlyThrottleUpIsPressed
                            &
                            !controlVehicleFlyThrottleDownIsPressed)
                        {
                            SetRotationOfHelicopterBladesBasedOnThis(5E-3F);

                            return;
                        }
                        {
                            switch (controlVehicleFlyThrottleDownIsPressed)
                            {
                                case true:
                                    {
                                        var throttleDownValue
                                            = Game
                                                .GetControlValueNormalized(Control.VehicleFlyThrottleDown);

                                        var rate
                                            = throttleDownValue / 1E+4F + 15E-3F;

                                        SetRotationOfHelicopterBladesBasedOnThis(rate);
                                    }
                                    return;
                            }

                            switch (controlVehicleFlyThrottleUpIsPressed)
                            {
                                case true:
                                    {
                                        var throttleUpValue
                                            = Game
                                                .GetControlValueNormalized(Control.VehicleFlyThrottleUp);

                                        var rate
                                            = throttleUpValue / 1E+3F;

                                        SetRotationOfHelicopterBladesBasedOnThis(rate);
                                    }
                                    return;
                            }
                        }
                    }
                }
            };

            void SetRotationOfHelicopterBladesBasedOnThis(float rate)
            {
                var vehicleSpeed
                    = GetVehicleSpeed();

                var verticalSpeed
                    = GetVerticalSpeedOfVehicle();

                var isTheHelicopterGainingAltitude
                    = GetIfTheHelicopterIsGainingAltitude();

                currentVehicle
                    .HeliBladesSpeed += rate - (isTheHelicopterGainingAltitude ? vehicleSpeed / (verticalSpeed * 1E+4F) : (verticalSpeed - (vehicleSpeed / 1E+4F)) / 1E+4F);

                float GetVehicleSpeed()
                {
                    return currentVehicle.Speed;
                }

                float GetVerticalSpeedOfVehicle()
                {
                    return currentVehicle.Velocity.Z;
                }

                bool GetIfTheHelicopterIsGainingAltitude()
                {
                    return verticalSpeed > 1.35f;
                }
            }

            Vehicle GetCurrentVehicle()
            {
                return Game.Player.Character.CurrentVehicle;
            }

            bool GetIfEngineIsRunning()
            {
                return currentVehicle.IsEngineRunning;
            }

            float GetHelicopterBladesSpeed()
            {
                return currentVehicle.HeliBladesSpeed;
            }

            bool GetIfTheHelicopterIsInFlight()
            {
                return currentVehicle.IsInAir;
            }
        }
    }
}
