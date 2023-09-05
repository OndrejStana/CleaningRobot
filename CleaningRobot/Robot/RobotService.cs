using CleaningRobot.Serializer;
using CleaningRobot.Enums;

namespace CleaningRobot.Robot
{
    /// <summary>
    /// Service responsible for running robot commands.
    /// </summary>
    internal class RobotService : IRobotService
    {
        private const string ERROR_INVALID_START_CELL = "Robot is initialized at invalid location.";
        private const string ERROR_NEGATIVE_BATTERY_LEVEL = "Robot is initialized with negative battery level.";

        private readonly IRobotState robotState;


        /// <summary>
        /// Initializes a new instance of the <see cref="RobotService"/> class.
        /// </summary>
        public RobotService(IRobotState robotState)
        {
            this.robotState = robotState;
        }


        /// <inheritdoc />
        public void Initialize(Source source)
        {
            robotState.Map = (SpaceType[][])source.Map.Clone();
            robotState.X = source.Start.X;
            robotState.Y = source.Start.Y;
            robotState.Facing = source.Start.Facing;
            robotState.Battery = source.Battery;
            Validate();

            Visit();
        }


        /// <inheritdoc />
        public CommandState TryDrainBattery(int batteryCost)
        {
            if (!CanDrainBattery(batteryCost))
            {
                return CommandState.OutOfBattery;
            }
            
            robotState.Battery -= batteryCost;
            return CommandState.Success;
        }


        /// <inheritdoc />
        public void TurnLeft()
        {
            robotState.Facing = robotState.Facing switch
            {
                Direction.North => Direction.West,
                Direction.East => Direction.North,
                Direction.South => Direction.East,
                Direction.West => Direction.South,
                _ => robotState.Facing
            };
        }


        /// <inheritdoc />
        public void TurnRight()
        {
            robotState.Facing = robotState.Facing switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => robotState.Facing
            };
        }


        /// <inheritdoc />
        public CommandState TryAdvance()
        {
            if (!CanAdvance())
            {
                return CommandState.CannotExecute;
            }

            switch (robotState.Facing)
            {
                case Direction.North:
                    robotState.Y -= 1;
                    break;
                case Direction.East:
                    robotState.X += 1;
                    break;
                case Direction.South:
                    robotState.Y += 1;
                    break;
                case Direction.West:
                    robotState.X -= 1;
                    break;
            }

            Visit();
            return CommandState.Success;
        }


        /// <inheritdoc />
        public CommandState TryGoBack()
        {
            if (!CanGoBack())
            {
                return CommandState.CannotExecute;
            }

            switch (robotState.Facing)
            {
                case Direction.North:
                    robotState.Y += 1;
                    break;
                case Direction.East:
                    robotState.X -= 1;
                    break;
                case Direction.South:
                    robotState.Y -= 1;
                    break;
                case Direction.West:
                    robotState.X += 1;
                    break;
            }

            Visit();
            return CommandState.Success;
        }


        /// <inheritdoc />
        public void Clean()
        {
            if (CellExists(robotState.X, robotState.Y) && !robotState.Cleaned.Any(c => c.X == robotState.X && c.Y == robotState.Y))
            {
                robotState.Cleaned.Add(new Location { X = robotState.X, Y = robotState.Y });
            }
        }


        /// <inheritdoc />
        public Destination GetCurrentPosition()
        {
            return new Destination
            {
                Cleaned = robotState.Cleaned.ToList(),
                Visited = robotState.Visited.ToList(),
                Final = new RobotPosition
                {
                    X = robotState.X,
                    Y = robotState.Y,
                    Facing = robotState.Facing
                },
                Battery = robotState.Battery
            };
        }


        private bool CanDrainBattery(int batteryCost)
        {
            return robotState.Battery >= batteryCost;
        }


        private bool CanAdvance()
        {
            return IsCellCleanable(robotState.Facing);
        }


        private bool CanGoBack()
        {
            return robotState.Facing switch
            {
                Direction.North => IsCellCleanable(Direction.South),
                Direction.East => IsCellCleanable(Direction.West),
                Direction.South => IsCellCleanable(Direction.North),
                Direction.West => IsCellCleanable(Direction.East),
                _ => false
            };
        }


        private void Validate()
        {
            if (!IsCellCleanable(robotState.X, robotState.Y))
            {
                throw new ArgumentException(ERROR_INVALID_START_CELL, nameof(Source.Start));
            }
            if (robotState.Battery < 0)
            {
                throw new ArgumentException(ERROR_NEGATIVE_BATTERY_LEVEL, nameof(Source.Battery));
            }
        }


        private void Visit()
        {
            if (!robotState.Visited.Any(c => c.X == robotState.X && c.Y == robotState.Y))
            {
                robotState.Visited.Add(new Location { X = robotState.X, Y = robotState.Y });
            }
        }


        private bool IsCellCleanable(Direction direction)
        {
            return direction switch
            {
                Direction.North => IsCellCleanable(robotState.X, robotState.Y - 1),
                Direction.East => IsCellCleanable(robotState.X + 1, robotState.Y),
                Direction.South => IsCellCleanable(robotState.X, robotState.Y + 1),
                Direction.West => IsCellCleanable(robotState.X - 1, robotState.Y),
                _ => false
            };
        }


        private bool IsCellCleanable(int x, int y)
        {
            return (CellExists(x, y) ? robotState.Map[y][x] : null) == SpaceType.Cleanable; 
        }


        private bool CellExists(int x, int y)
        {
            return (x >= 0) && (y >= 0) && (robotState.Map.Length > y) && (robotState.Map[y].Length > x);
        }
    }
}