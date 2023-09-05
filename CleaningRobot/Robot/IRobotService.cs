using CleaningRobot.Serializer;
using CleaningRobot.Enums;

namespace CleaningRobot.Robot
{
    /// <summary>
    /// Service responsible for running robot commands.
    /// </summary>
    internal interface IRobotService
    {
        /// <summary>
        /// Initializes the robot to its starting status.
        /// <param name="source">The initial robot status.</param>
        /// <exception cref="ArgumentException">When the robot is initialized at uncleanable location or with negative battery.</exception>
        /// </summary>
        void Initialize(Source source);


        /// <summary>
        /// Tries draining the robot's battery.
        /// <param name="batteryCost">A battery cost of an operation.</param>
        /// <returns>Result of the battery draining:
        /// <see cref="CommandState.Success"/> when battery draining is executed successfully.
        /// <see cref="CommandState.OutOfBattery"/> when robot does not have enough battery.</returns>
        /// </summary>
        CommandState TryDrainBattery(int batteryCost);


        /// <summary>
        /// Instructs the robot to turn 90 degrees to the left.
        /// </summary>
        void TurnLeft();


        /// <summary>
        /// Instructs the robot to turn 90 degrees to the right.
        /// </summary>
        void TurnRight();


        /// <summary>
        /// Instructs the robot to try advance forward.
        /// <returns>Result of the command:
        /// <see cref="CommandState.Success"/> when command is executed successfully.
        /// <see cref="CommandState.CannotExecute"/> when command cannot be executed.</returns>
        /// </summary>
        CommandState TryAdvance();


        /// <summary>
        /// Instructs the robot to try go back.
        /// <returns>Result of the command:
        /// <see cref="CommandState.Success"/> when command is executed successfully.
        /// <see cref="CommandState.CannotExecute"/> when command cannot be executed.</returns>
        /// </summary>
        CommandState TryGoBack();


        /// <summary>
        /// Instructs the robot to clean current space.
        /// </summary>
        void Clean();


        /// <summary>
        /// Gets a current position of the robot.
        /// </summary>
        Destination GetCurrentPosition();
    }
}