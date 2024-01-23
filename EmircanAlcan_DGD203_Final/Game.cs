using System;

namespace DGD203
{
    public class Game
    {
        #region VARIABLES

        #region Game

        private bool _gameRunning = true;
        private char[,] _mapCurrent;
        private int _playerRow;
        private int _playerCol;
        private int _mapindex;
        private string _playerInput;

        #endregion

        #region Map

        private char[][,] _mapAll =
        {
            new char[,]
            {
                {'X','X','X','X','_','_','_','_','_','_'},
                {'X','_','#','X','_','_','_','_','_','_'},
                {'X','_','_','X','X','X','_','_','_','_'},
                {'X','Ö','U','_','_','X','_','_','_','_'},
                {'X','_','_','O','_','X','_','_','_','_'},
                {'X','_','_','X','X','X','_','_','_','_'},
                {'X','X','X','X','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'}
            },
            new char[,]
            {
                {'X','X','X','X','X','X','_','_','_','_'},
                {'X','_','_','_','_','X','_','_','_','_'},
                {'X','_','X','U','_','X','_','_','_','_'},
                {'X','_','O','Ö','_','X','_','_','_','_'},
                {'X','_','#','Ö','_','X','_','_','_','_'},
                {'X','_','_','_','_','X','_','_','_','_'},
                {'X','X','X','X','X','X','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'}
            },
            new char[,]
            {
                {'_','_','X','X','X','X','_','_','_','_'},
                {'X','X','X','_','_','X','X','X','X','_'},
                {'X','_','_','_','_','_','O','_','X','_'},
                {'X','_','X','_','_','X','O','_','X','_'},
                {'X','_','#','_','#','X','U','_','X','_'},
                {'X','X','X','X','X','X','X','X','X','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'}
            },
            new char[,]
            {
                {'X','X','X','X','X','X','X','X','_','_'},
                {'X','_','_','_','_','_','_','X','_','_'},
                {'X','_','#','Ö','Ö','O','U','X','_','_'},
                {'X','_','_','_','_','_','_','X','_','_'},
                {'X','X','X','X','X','_','_','X','_','_'},
                {'_','_','_','_','X','X','X','X','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'}
            },
            new char[,]
            {
                {'_','X','X','X','X','X','X','X','_','_'},
                {'_','X','_','_','_','_','_','X','_','_'},
                {'_','X','_','#','O','#','_','X','_','_'},
                {'X','X','_','O','U','O','_','X','_','_'},
                {'X','_','_','#','O','#','_','X','_','_'},
                {'X','_','_','_','_','_','_','X','_','_'},
                {'X','X','X','X','X','X','X','X','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'},
                {'_','_','_','_','_','_','_','_','_','_'}
            }
        };

        #endregion

        #endregion

        #region METHODS

        #region Initialization

        public void StartGame(Game gameInstanceReference)
        {
            Console.WriteLine("Hello.\n\nI am Emircan Alcan and my school number is 225040064.\nThis is a project I made for Istinye University Digital Game Design lesson DGD 203 in between 2023 - 2024 period.\nYour progress will be loaded and saved automatically. Write 'help' to view commands.\n");
            LoadGame();
            InitializeMap();
            StartGameLoop();
        }

        private void InitializeMap()
        {
            _mapCurrent = (char[,])_mapAll[_mapindex].Clone();
            for (int row = 0; row < _mapCurrent.GetLength(0); row++)
            {
                for (int col = 0; col < _mapCurrent.GetLength(1); col++)
                {
                    if (_mapCurrent[row, col] == 'U')
                    {
                        _playerRow = row;
                        _playerCol = col;
                    }
                }
            }
        }

        #endregion

        #region Game Loop

        public void StartGameLoop()
        {
            while (_gameRunning)
            {
                GetInput();
                ProcessInput();
            }
        }

        private void GetInput()
        {
            _playerInput = Console.ReadLine();
            Console.WriteLine();
        }

        private void ProcessInput()
        {
            switch (_playerInput)
            {
                case "w":
                    Movement(-1, 0);
                    break;
                case "a":
                    Movement(0, -1);
                    break;
                case "s":
                    Movement(1, 0);
                    break;
                case "d":
                    Movement(0, 1);
                    break;
                case "clear":
                    Console.Clear();
                    Console.WriteLine("Cleared past text.\n");
                    break;
                case "delete":
                    _mapindex = 0;
                    SaveGame();
                    InitializeMap();
                    Console.WriteLine("Deleted all of your progress.\n");
                    break;
                case "exit":
                    _gameRunning = false;
                    Console.WriteLine("Exited the game. I hope you liked it. Have a nice day.");
                    break;
                case "game":
                    Console.WriteLine("This is a sokoban game. It contains the first 5 levels of the video game Sokoban.\nReference for levels: https://www.sokobanonline.com/play/web-archive/david-w-skinner/microban\nAs a player on a 2D grid, your goal is pushing boxes to certain box locations.\nYou cannot go through or push boxes in walls. You can only push 1 box simultaneously.\nList of symbols:\n_: Empty tile.\nU: Player.\nÜ: Player on box location.\nO: Box.\nÖ: Box on box location.\n#: Box location.\nX: Wall.\n");
                    break;
                case "help":
                    Console.WriteLine("List of commands:\nw: Takes the player north and shows the map.\na: Takes the player west and shows the map.\ns: Takes the player south and shows the map.\nd: Takes the player east and shows the map.\nclear: Clears past text.\ndelete: Deletes all of your progress.\nexit: Exits the game.\ngame: Gives details about the game. (Recommended at your first time playing)\nhelp: Lists all commands.\nreset: Resets current level and shows the map.\nshow: Shows the level map and number.\n");
                    break;
                case "reset":
                    Console.WriteLine("Reset current level.\n");
                    InitializeMap();
                    DrawMap();
                    break;
                case "show":
                    DrawMap();
                    Console.WriteLine("You are at level " + (_mapindex + 1) + ".\n");
                    break;
                default:
                    Console.WriteLine("Command not recognized. Write 'help' to view commands.\n");
                    break;
            }
        }

        private void Movement(int playerRowChange, int playerColChange)
        {
            bool flag = true;
            switch (_mapCurrent[_playerRow, _playerCol])
            {
                case 'U':
                    switch (_mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange])
                    {
                        case '_':
                            _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'U';
                            _mapCurrent[_playerRow, _playerCol] = '_';
                            _playerRow += playerRowChange;
                            _playerCol += playerColChange;
                            break;
                        case '#':
                            _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'Ü';
                            _mapCurrent[_playerRow, _playerCol] = '_';
                            _playerRow += playerRowChange;
                            _playerCol += playerColChange;
                            break;
                        case 'O':
                            switch (_mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2])
                            {
                                case '_':
                                    _mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2] = 'O';
                                    _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'U';
                                    _mapCurrent[_playerRow, _playerCol] = '_';
                                    _playerRow += playerRowChange;
                                    _playerCol += playerColChange;
                                    break;
                                case '#':
                                    _mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2] = 'Ö';
                                    _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'U';
                                    _mapCurrent[_playerRow, _playerCol] = '_';
                                    _playerRow += playerRowChange;
                                    _playerCol += playerColChange;
                                    break;
                            }
                            break;
                        case 'Ö':
                            switch (_mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2])
                            {
                                case '_':
                                    _mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2] = 'O';
                                    _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'Ü';
                                    _mapCurrent[_playerRow, _playerCol] = '_';
                                    _playerRow += playerRowChange;
                                    _playerCol += playerColChange;
                                    break;
                                case '#':
                                    _mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2] = 'Ö';
                                    _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'Ü';
                                    _mapCurrent[_playerRow, _playerCol] = '_';
                                    _playerRow += playerRowChange;
                                    _playerCol += playerColChange;
                                    break;
                            }
                            break;
                    }
                    break;
                case 'Ü':
                    switch (_mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange])
                    {
                        case '_':
                            _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'U';
                            _mapCurrent[_playerRow, _playerCol] = '#';
                            _playerRow += playerRowChange;
                            _playerCol += playerColChange;
                            break;
                        case '#':
                            _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'Ü';
                            _mapCurrent[_playerRow, _playerCol] = '#';
                            _playerRow += playerRowChange;
                            _playerCol += playerColChange;
                            break;
                        case 'O':
                            switch (_mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2])
                            {
                                case '_':
                                    _mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2] = 'O';
                                    _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'U';
                                    _mapCurrent[_playerRow, _playerCol] = '#';
                                    _playerRow += playerRowChange;
                                    _playerCol += playerColChange;
                                    break;
                                case '#':
                                    _mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2] = 'Ö';
                                    _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'U';
                                    _mapCurrent[_playerRow, _playerCol] = '#';
                                    _playerRow += playerRowChange;
                                    _playerCol += playerColChange;
                                    break;
                            }
                            break;
                        case 'Ö':
                            switch (_mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2])
                            {
                                case '_':
                                    _mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2] = 'O';
                                    _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'Ü';
                                    _mapCurrent[_playerRow, _playerCol] = '#';
                                    _playerRow += playerRowChange;
                                    _playerCol += playerColChange;
                                    break;
                                case '#':
                                    _mapCurrent[_playerRow + playerRowChange * 2, _playerCol + playerColChange * 2] = 'Ö';
                                    _mapCurrent[_playerRow + playerRowChange, _playerCol + playerColChange] = 'Ü';
                                    _mapCurrent[_playerRow, _playerCol] = '#';
                                    _playerRow += playerRowChange;
                                    _playerCol += playerColChange;
                                    break;
                            }
                            break;
                    }
                    break;
            }
            DrawMap();
            for (int row = 0; row < _mapCurrent.GetLength(0); row++)
            {
                for (int col = 0; col < _mapCurrent.GetLength(1); col++)
                {
                    if (_mapCurrent[row, col] == '#' || _mapCurrent[row, col] == 'Ü')
                    {
                        flag = false;
                    }
                }
            }
            if (flag)
            {
                if (_mapindex < 4)
                {
                    _mapindex++;
                    SaveGame();
                    Console.WriteLine("You completed level " + _mapindex + " and now you are at level " + (_mapindex + 1) + ".\n");
                    InitializeMap();
                    DrawMap();
                }
                else
                {
                    Console.WriteLine("You completed level " + _mapindex + " so you completed the game. Congratulations!\nWrite 'delete' to delete all of your progress or 'exit' to exit the game.\n");
                }
            }
        }

        private void DrawMap()
        {
            for (int row = 0; row < _mapCurrent.GetLength(0); row++)
            {
                for (int col = 0; col < _mapCurrent.GetLength(1); col++)
                {
                    Console.Write(_mapCurrent[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        #endregion

        #region Save Management

        private string SaveFilePath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string path = projectDirectory + @"\Save.txt";
            return path;
        }

        private void SaveGame()
        {
            File.WriteAllLines(SaveFilePath(), [_mapindex.ToString()]);
        }

        private void LoadGame()
        {
            string path = SaveFilePath();
            if (!File.Exists(path) || !int.TryParse(File.ReadAllText(path), out _mapindex))
            {
                return;
            }
        }

        #endregion

        #endregion
    }
}