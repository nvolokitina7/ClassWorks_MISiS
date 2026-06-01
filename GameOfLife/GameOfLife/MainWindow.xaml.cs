using System.Text;
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
using Core.GameOfLife;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;
        private Border[,] cells;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            game = new Game();
            cells = new Border[game.Rows, game.Columns];
        }
        private void CreateGameGrid()
        {
            gameGrid.Children.Clear();
        }

    }
}