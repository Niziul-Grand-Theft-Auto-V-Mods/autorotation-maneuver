using GTA;


namespace Autorotation_maneuver
{
    internal sealed class Main : Script
    {
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
            var player 
                = Game
                    .Player
                        .Character;

            var playerIsInVehicleWithRotatingWings 
                = player
                    .IsInHeli;

            switch (playerIsInVehicleWithRotatingWings)
            {
                case true:
                    {
                        var vehiclePlayer 
                            = player
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
                                heliBladesSpeed < 1.35f)
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


                                switch (controlVehicleFlyThrottleUpIsPressed)
                                {
                                    case true:
                                        {
                                            IncreaseRotationOfHelicopterBladesBasedOn(value: 0.00100f);
                                        }
                                        return;
                                }
                                
                                switch (controlVehicleFlyThrottleDownIsPressed)
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