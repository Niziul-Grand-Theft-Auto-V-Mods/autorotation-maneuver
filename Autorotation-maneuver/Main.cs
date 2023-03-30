using GTA;


namespace Autorotation_maneuver
{
    internal sealed class Main : Script
    {
        private Ped _player;

        public Main()
        {
            var isInLoading
                = Game
                    .IsLoading;

            Tick += (o, e) =>
            {
                if (isInLoading)
                {
                    isInLoading
                    = Game
                        .IsLoading;

                    return;
                }
                else
                {
                    Start();
                }
            };
        }

        private void Start()
        {
            if (_player == null)
            {
                _player
                    = Game
                        .Player
                            .Character;
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
                                heliBladesSpeed < 1.05f)
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
                                    IncreaseRotationOfHelicopterBladesBasedOn(value: 0.00050f);
                                    return;
                                }
                                else
                                {
                                    switch (controlVehicleFlyThrottleDownIsPressed)
                                    {
                                        case true:
                                            {
                                                IncreaseRotationOfHelicopterBladesBasedOn(value: 0.00025f);
                                            }
                                            return;
                                    }

                                    switch (controlVehicleFlyThrottleUpIsPressed)
                                    {
                                        case true:
                                            {
                                                IncreaseRotationOfHelicopterBladesBasedOn(value: 0.00100f);
                                            }
                                            return;
                                    }

                                }
                            }
                        }
                    }
                    return;
            }
        }
    
        private void IncreaseRotationOfHelicopterBladesBasedOn(float value)
        {
            var playerCharacter 
                = Game
                    .Player
                        .Character;

            var vehiclePlayer 
                = playerCharacter
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
                .HeliBladesSpeed += value - (isTheHelicopterGainingAltitude ? verticalSpeed / (vehicleSpeed * 5000) : verticalSpeed / 5000f);
        }
    }
}