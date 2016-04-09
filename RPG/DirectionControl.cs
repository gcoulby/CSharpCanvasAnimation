using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RPG
{
    class DirectionControl
    {
        public static readonly Key[] MovementKeys = new Key[]
        {
            Key.Up,
            Key.W,
            Key.Down,
            Key.S,
            Key.Left,
            Key.A,
            Key.Right,
            Key.D
        };


        private static Dictionary<Direction, bool> presses = new Dictionary<Direction, bool>()
        {
            { Direction.Up, false },
            { Direction.Down, false },
            { Direction.Left, false },
            { Direction.Right, false },
        };

        private static int ImagePosition = 0;
        public static readonly int ImageStart = 0;
        private static readonly int ImageEnd = -128;

        public static int NextFrame()
        {
            if (ImagePosition - 32 == ImageEnd)
                ImagePosition = ImageStart;
            else
                ImagePosition -= 32;

            return ImagePosition;
        }

        internal static Direction GetDirection(Key k)
        {
            switch (k)
            {
                case Key.Down:
                case Key.S:
                    return Direction.Down;
                case Key.Left:
                case Key.A:
                    return Direction.Left;
                case Key.Right:
                case Key.D:
                    return Direction.Right;
                case Key.Up:
                case Key.W:
                    return Direction.Up;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static void StopKeyPress(Direction direction)
        {
            presses[direction] = false;
        }

        public static bool AllKeysLifted()
        {
            return (!presses[Direction.Up] && !presses[Direction.Down] && !presses[Direction.Left] && !presses[Direction.Right]) ? true : false;
        }

        public static void SetKeyDown(Direction d)
        {
            presses[Direction.Up] = false;
            presses[Direction.Down] = false;
            presses[Direction.Left] = false;
            presses[Direction.Right] = false;
            presses[d] = true;
        }
    }
}
