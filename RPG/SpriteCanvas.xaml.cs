using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RPG
{
    /// <summary>
    /// Interaction logic for SpriteCanvas.xaml
    /// </summary>
    public partial class SpriteCanvas : UserControl
    {
        private DispatcherTimer _timer = new DispatcherTimer();

        private Direction _direction;

        private int _movementSpeed = 10;

        private static Key currentKey;

        public SpriteCanvas()
        {
            InitializeComponent();
            _timer.Tick += dispatcherTimer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }

        public void Move(Key k)
        {
            currentKey = k;
            _direction = DirectionControl.GetDirection(k);
            DirectionControl.SetKeyDown(_direction);
            _timer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var top = Canvas.GetTop(this);
            var left = Canvas.GetLeft(this);

            switch (_direction)
            {
                case Direction.Down:
                    Canvas.SetTop(SpriteSheet, 0);
                    Canvas.SetTop(this, top + _movementSpeed);
                    break;
                case Direction.Left:
                    Canvas.SetTop(SpriteSheet, -48);
                    Canvas.SetLeft(this, left - _movementSpeed);
                    break;
                case Direction.Right:
                    Canvas.SetTop(SpriteSheet, -96);
                    Canvas.SetLeft(this, left + _movementSpeed);
                    break;
                case Direction.Up:
                    Canvas.SetTop(SpriteSheet, -144);
                    Canvas.SetTop(this, top - _movementSpeed);
                    break;
            }
            Canvas.SetLeft(SpriteSheet, DirectionControl.NextFrame());
        }

        internal void Stop(Key k)
        {
            var key = DirectionControl.GetDirection(k);
            DirectionControl.StopKeyPress(key);

            if (DirectionControl.AllKeysLifted())
                _timer.Stop();
        }
    }
}
