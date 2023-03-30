using GTA;

namespace Autorotation_maneuver
{
    internal sealed class Main : Script
    {
        private Ped _player;

        public Main()
        {
            Tick += (o, e) =>
            {
                if (Game.IsLoading)
                {
                    return;
                }

                if (_player == null)
                {
                    _player
                        = Game.Player.Character;
                }

                var playerIsInVehicleWithRotatingWings
                    = _player
                        .IsInHeli;

                switch (playerIsInVehicleWithRotatingWings)
                {
                    case false:
                        {
                            return;
                        }
                    case true:
                        {
                            var vehiclePlayer
                                = _player
                                    .CurrentVehicle;

                            var isEngineRunning
                                = vehiclePlayer
                                    .IsEngineRunning;

                            if (isEngineRunning)
                            {
                                return;
                            }
                            else
                            {
                                var heliBladesSpeed
                                    = vehiclePlayer
                                        .HeliBladesSpeed;

                                var isTheHelicopterInFlight
                                    = vehiclePlayer
                                        .IsInAir;


                                if (isTheHelicopterInFlight
                                        &&
                                    heliBladesSpeed < 1.00f)
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
                                            &&
                                        !controlVehicleFlyThrottleDownIsPressed)
                                    {
                                        SetRotationOfHelicopterBladesBasedOnThis(0.00050f);
                                        return;
                                    }
                                    else
                                    {
                                        switch (controlVehicleFlyThrottleDownIsPressed)
                                        {
                                            case true:
                                                {
                                                    var throttleDownValue
                                                        = Game
                                                            .GetControlValueNormalized(Control.VehicleFlyThrottleDown);

                                                    var rate
                                                        = (throttleDownValue / 10000f) + 0.00015f;

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
                                                        = throttleUpValue / 1000f;
    
                                                    SetRotationOfHelicopterBladesBasedOnThis(rate);
                                                }
                                                return;
                                        }

                                    }
                                }
                            }
                        }
                        return;
                }
            };
        }

        private void SetRotationOfHelicopterBladesBasedOnThis(float rate)
        {
            var vehiclePlayer 
                = _player
                    .CurrentVehicle;

            var vehicleSpeed 
                = vehiclePlayer
                    .Speed;

            var verticalSpeed 
                = vehiclePlayer
                    .Velocity
                        .Z;

            var isTheHelicopterGainingAltitude 
                = verticalSpeed > 1.35f;

            vehiclePlayer
                .HeliBladesSpeed += rate - (isTheHelicopterGainingAltitude ? vehicleSpeed / (verticalSpeed * 10000f) : (verticalSpeed - (vehicleSpeed / 10000f)) / 10000f);
        }
    }
}