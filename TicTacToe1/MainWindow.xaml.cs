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

namespace TicTacToe1
{
    #region Constructor
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        //Holds the current results of the active game
        private MarkType[] mResults;

        //true if it is Player 1's turn (X) false for Player 2's (O)
        private bool mPlayerTurn;

        private bool mGameEnd;
        #endregion

         void NewGame()
        {
            mResults = new MarkType[9];

            for(var  i = 0; i < mResults.Length;  i++)
            {
                mResults[i] =  MarkType.Free;
            }

            mPlayerTurn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            mGameEnd = false;
        }

         void Button_Click(object sender, RoutedEventArgs e)
        {
            if(mGameEnd)
            {
                NewGame();
                return;
            }
            var button = (Button) sender;

            var column = Grid.GetColumn(button);

            var row = Grid.GetRow(button);

            var Index = column + (row * 3);

            if (mResults[Index] != MarkType.Free)
            
                return;

                mResults[Index] = mPlayerTurn ? MarkType.Cross : MarkType.Nought;

                button.Content = mPlayerTurn ? "x" : "O";

                if(!mPlayerTurn)
                {
                    button.Foreground = Brushes.Green;
                }

                mPlayerTurn ^= true;

                CheckforWinner();
            } 

             void CheckforWinner()
            {
                //row 0
                if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0]){
                    mGameEnd = true;

                    Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green; 
                }

                //row1
                if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
                {
                    mGameEnd = true;

                    Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
                }


                //row2
                if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
                {
                    mGameEnd = true;

                    Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
                }

                //Vertical win
                //
                //Column 0
                if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
                {
                    mGameEnd = true;

                    Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
                }
                //Column 1
                if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
                {
                    mGameEnd = true;

                    Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
                }
                //Column 2
                if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
                {
                    mGameEnd = true;

                    Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
                }
                //Diagonal win
                if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
                {
                    mGameEnd = true;

                    Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
                }
                //
                if (mResults[6] != MarkType.Free && (mResults[6] & mResults[4] & mResults[2]) == mResults[6])
                {
                    mGameEnd = true;

                    Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green;
                }
                //No winner
                if (!mResults.Any(result => result == MarkType.Free)){
                    mGameEnd = true;


                    Container.Children.Cast<Button>().ToList().ForEach(button =>
                    {
                       
                        button.Background = Brushes.Orange;
                        
                    });


                }
            }
            
        }
    }
