using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Snake_3._0
{
	class Program
	{
		public Random rand = new Random();
		public ConsoleKeyInfo keypress = new ConsoleKeyInfo();
		int score, headX, headY, fruitX, fruitY, nTail, speed;
		int[] TailX = new int[100];
		int[] TailY = new int[100];

		const int height = 30;
		const int width = 60;

		bool gameOver, reset, isprinted, horizontal, vertical, level;
		string dir, predir;

		
		void ShowBanner()
		{
			Console.SetWindowSize(width, height + 3 );
			Console.ForegroundColor = ConsoleColor.Green;
			Console.CursorVisible = false;
			Console.Title = "Snake 3.0";
			Console.BackgroundColor = ConsoleColor.Black;
			Console.CursorTop = height - (height - 5);
			Console.CursorLeft = width / 2;

			Console.WriteLine(@"

   __	          __             ___   
  / _\____   ____|  | _____     / _ \_____ ________   ___
  \ \|  _ \ / _  |  |/ / _ \   / /_\/  _  |  _   _ \ / _ \
  _\ \ | | | (_| |    <  __/  / /_\\  (_| | | | | | |  __/ 
  \__/_| |_|\____|__|\_\___|  \____/\_____|_| |_| | |\___/ 
                           

                              ");


			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("                Select the difficulty level");
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("                        1 = easy");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("                        2 = Average");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("                        3 = hard");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("                Press to key for select level");
			Console.WriteLine();



			level = true;
			keypress = Console.ReadKey(true);
			while (level == true)
			{
				if (keypress.Key == ConsoleKey.D1)
				{
					speed = 1;
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.WriteLine("                     SELECTED EASY LEVEL");
					level = false;
				}
				else if (keypress.Key == ConsoleKey.D2)
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					speed = 2;
					Console.WriteLine("                     SELECTED AVERAGE LEVEL");
					level = false;
				}
				else if (keypress.Key == ConsoleKey.D3)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					speed = 3;
					Console.WriteLine("                     SELECTED HARD LEVEL");
					level = false;
				}
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine();
			Console.WriteLine("                     Press Any Key to Play");
			keypress = Console.ReadKey(true);
			if (keypress.Key == ConsoleKey.Escape)
				Environment.Exit(0);

		}

		
		void Setup()
		{
			dir = "RIGHT";
			predir = "";
			score = 0;
			nTail = 0;



			gameOver = false;
			reset = false;
			isprinted = false;
			if (speed == 2)
			{
				headX = width / 2 + 1;
				headY = height / 2 ;
			}
			else
			{
				headX = width / 2;
				headY = height / 2;
			}


			Speed();

		}






		void CheckInput()
		{
			while (Console.KeyAvailable)
			{
				keypress = Console.ReadKey(true);
				if (keypress.Key == ConsoleKey.Escape)
				{
					Environment.Exit(0);
				}
				if (keypress.Key == ConsoleKey.S)
				{
					predir = dir;
					dir = "STOP";
				}
				else if (keypress.Key == ConsoleKey.LeftArrow && dir != "RIGHT")
				{
					predir = dir;
					dir = "LEFT";
				}
				else if (keypress.Key == ConsoleKey.RightArrow && dir != "LEFT")
				{
					predir = dir;
					dir = "RIGHT";
				}
				else if (keypress.Key == ConsoleKey.UpArrow && dir != "DOWN")
				{
					predir = dir;

					dir = "UP";
				}
				else if (keypress.Key == ConsoleKey.DownArrow && dir != "UP")
				{
					predir = dir;
					dir = "DOWN";
				}

			}
		}

		void Logic()
		{
			int PreX = TailX[0];
			int PreY = TailY[0];
			int tempX, tempY;

			if (dir != "STOP")
			{
				TailX[0] = headX;
				TailY[0] = headY;

				for (int i = 1; i < nTail; ++i)
				{
					tempX = TailX[i];
					tempY = TailY[i];
					TailX[i] = PreX;
					TailY[i] = PreY;
					PreX = tempX;
					PreY = tempY;
				}
			}

			
			switch (dir)
			{
				case "RIGHT":
						headX += speed;

					break;

				case "LEFT":
						headX -= speed;

					break;

				case "UP":
						headY -= speed; 
					
					break;

				case "DOWN":

						headY += speed; 
			
					break;
				case "STOP":
					while (true)
					{
						Console.Clear();
						Console.CursorTop = height - (height - 5);
						Console.CursorLeft = width / 2;
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.WriteLine(@" 

    ___                        __ __                __          __
   / _ \_____ ________   ___   || _ \ ____  _    _ / _\ ___     ||
  / /_\/  _  |  _   _ \ / _ \  || __|/ _  || |  / |\ \ / _ \ ___|| 
 / /_\\  (_| | | | | | |  __/  ||   / (_| || |_/ /|_\ \| __// _ ||
 \____/\_____|_| |_| | |\___/  ||   \_____||_|_ /||\__/\___/\___||


                                        ");
						Console.CursorLeft = 21;
						Console.ForegroundColor = ConsoleColor.DarkGreen;
						Console.WriteLine("Press S to resume game");
						Console.CursorLeft = 21;
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.WriteLine("Press R to reset game");
						Console.CursorLeft = 21;
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Press ESC to quit game");
						Console.ForegroundColor = ConsoleColor.White;
						keypress = Console.ReadKey(true);
						if (keypress.Key == ConsoleKey.Escape)
						{
							Environment.Exit(0);
						}
						if (keypress.Key == ConsoleKey.R)
						{
							reset = true;
							break;
						}
						if (keypress.Key == ConsoleKey.S)
						{
							break;
						}
					}
					dir = predir;
					break;
			}
			if (headX <= 0 || headX >= width - 1 || headY <= 0 || headY >= height - 1)
			{
				gameOver = true;
			}
			else
			{
				gameOver = false;
			}

			if (headX == fruitX && headY == fruitY)
			{
				score += 1;
				nTail++;
				Speed();
			}

			if (((dir == "LEFT" && predir != "UP") && (dir == "LEFT" && predir != "DOWN")) || ((dir == "RIGHT" && predir != "UP") && (dir == "RIGHT" && predir != "DOWN")))
			{
				horizontal = true;
			}
			else
			{
				horizontal = false;
			}

			if (((dir == "UP" && predir != "LEFT") && (dir == "UP" && predir != "RIGHT")) || ((dir == "DOWN" && predir != "LEFT") && (dir == "DOWN" && predir != "RIGHT")))
			{
				vertical = true;
			}
			else
			{
				vertical = false;
			}

			for (int i = 1; i < nTail; ++i)
			{
				if (TailX[i] == headX && TailY[i] == headY)
				{
					if (horizontal || vertical)
					{
						gameOver = false;
					}
					else
					{
						gameOver = true;
					}
				}
				if (TailX[i] == fruitX && TailY[i] == fruitY)
				{
					Speed();
				}



			}
		}

		void Render()
		{
			Console.SetCursorPosition(0, 0);
			Console.ForegroundColor = ConsoleColor.White;
			for (int i = 0; i < height; ++i)
			{
				for (int j = 0; j < width; ++j)
				{
					if (i == 0 || i == height - 1)
					{
						Console.ForegroundColor = ConsoleColor.White;
						Console.Write("-");
					}
					else if (j == 0 || j == width - 1)
					{
						Console.ForegroundColor = ConsoleColor.White;
						Console.Write("|");
					}
					else if (j == fruitX && i == fruitY)
					{
						Console.ForegroundColor = ConsoleColor.DarkGreen;
						Console.Write("F");
					}
					else if (j == headX && i == headY)
					{
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.Write("0");
					}
					else
					{
						isprinted = false;
						for (int k = 0; k < nTail; ++k)
						{
							if (TailX[k] == j && TailY[k] == i)
							{
								Console.ForegroundColor = ConsoleColor.DarkMagenta;
								Console.Write("o");
								isprinted = true;
							}
						}
						if (!isprinted)
						{
							Console.Write(" ");
						}
					}



				}
				Console.WriteLine();

			}
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Your score: " + score);


		}

		void Lose()
		{
			Console.Clear();
			Console.CursorTop = height - (height - 10) ;
			Console.CursorLeft = width / 2;
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(@"  
     ___                           ___
    / _ \_____ ________   ___     / _ \___  ___ ___  ____  
   / /_\/  _  |  _   _ \ / _ \   / / \ \  ||  /  _ \|  __|
  / /_\\  (_| | | | | | |  __/   \ \_/ /\    /|  __/| |
  \____/\_____|_| |_| | |\___/    \___/  \__/  \___/|_|
                           
				");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("                     Press  R  to reset game");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("                     Press ESC to quit game");
			Console.ForegroundColor = ConsoleColor.White;
			while (true)
			{
				keypress = Console.ReadKey(true);
				if (keypress.Key == ConsoleKey.Escape)
				{
					Environment.Exit(0);
				}
				if (keypress.Key == ConsoleKey.R)
				{
					reset = true;
					break;
				}
			}
		}
		void Speed()
		{
			if (speed == 1)
			{
				fruitX = rand.Next(1, width - 1);
				fruitY = rand.Next(1, height - 1);
			}
			else if (speed == 2)
			{
				fruitX = rand.Next(2, width - 1);
				fruitY = rand.Next(2, height - 1);

				while (!((fruitX % 2 != 0 && fruitX > 1) && (fruitY % 2 != 0 && fruitY > 1)) )
				{
					fruitX = rand.Next(2, width - 1);
					fruitY = rand.Next(2, height - 1);
				}
			}
			else if (speed == 3)
			{
				fruitX = rand.Next(3, width - 1);
				fruitY = rand.Next(3, height - 1);

				while (!((fruitX % 3 == 0 && fruitX > 2) && (fruitY % 3 == 0 && fruitY > 2)))
				{
					fruitX = rand.Next(3, width - 1);
					fruitY = rand.Next(3, height - 1);
				}
			}
		}

		void Update()
		{
			while (!gameOver)
			{
				CheckInput();
				Logic();
				Render();
				if (reset)
					break;
			}
			if (gameOver)
				Lose();


		}

		static void Main(string[] args)
		{
			Program Snake = new Program();
			Snake.ShowBanner();
			while (true)
			{
				Snake.Setup();
				Snake.Update();
				Console.Clear();
			}



		}
	}
}